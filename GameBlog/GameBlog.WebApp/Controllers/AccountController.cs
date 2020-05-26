using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AngleSharp.Dom;
using GameBlog.DAL.Entities;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region Register
        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Logout");
            RegisterViewModel model = new RegisterViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Logout");
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Name,
                    AvatarImageId = 1,
                    PostsId = new int[]{},
                    LikedPostsId = new int[]{},
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "default");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }
        #endregion

        #region Login/Logout
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            returnUrl = Url.Action("Index", "Home");
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Logout");
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Logout");
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
            }
            return View(model);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            returnUrl = Url.Action("Index", "Home");
            var redirectUrl = Url.Action("ExternalLoginCallback",
                "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");

            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null)
            {
                ModelState.AddModelError(String.Empty, $"Error for external login: {remoteError}");
                return View("Login", model);
            }

            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(String.Empty, "Error to Login info");
                return View("Login", model);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    User user = await _userManager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = email,
                            Email = email,
                            PostsId = new int[]{},
                            LikedPostsId = new int[]{},
                            AvatarImageId = 1
                        };
                        IdentityResult result = await _userManager.CreateAsync(user);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "default");
                        }
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect(returnUrl);

                }
            }
            //var Email = info.Principal.FindFirst(ClaimTypes.Email);
            //var Login = info.Principal.FindFirst(ClaimTypes.);
            //var Id = info.Principal.FindFirst(ClaimTypes.Email);
            //var Name = info.Principal.FindFirst(ClaimTypes.Email);
            return View("Login", model);
        }
    }
}