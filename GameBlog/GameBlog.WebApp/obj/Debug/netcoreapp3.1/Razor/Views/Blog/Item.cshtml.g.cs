#pragma checksum "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8b6a6c3cbdb3820aca597c7f986838bf6fb6a19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Item), @"mvc.1.0.view", @"/Views/Blog/Item.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\_ViewImports.cshtml"
using GameBlog.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\_ViewImports.cshtml"
using GameBlog.Models.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8b6a6c3cbdb3820aca597c7f986838bf6fb6a19", @"/Views/Blog/Item.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b188acc566f61f2a2a69b7da9f2f4e77705c1f4e", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Item : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameBlog.Models.ViewModels.BlogViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
  
    ViewData["Title"] = $"{Model.Title}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mb-4\">\r\n    <h2>\r\n        ");
#nullable restore
#line 10 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h2>\r\n    <div class=\"row\">\r\n        <div class=\"col-4 small\"> Author : ");
#nullable restore
#line 13 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
                                      Write(Model.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n        <div class=\"col-3 small\"> Views : ");
#nullable restore
#line 14 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
                                     Write(Model.Views);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n        <div class=\"col-3 small\"> Likes : ");
#nullable restore
#line 15 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
                                     Write(Model.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n    </div>\r\n");
#nullable restore
#line 17 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
     using (Html.BeginForm("AddLike", "CommentAjax", new { PostId = Model.Id }, FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button type=\"submit\" class=\"btn btn-success\">");
#nullable restore
#line 19 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
                                                  Write(!Model.isLiked ? "Like" : "Unlike");

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 20 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br>\r\n    <div class=\"align-content-lg-around\">\r\n        ");
#nullable restore
#line 23 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
    Write(new HtmlString(Model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n");
#nullable restore
#line 26 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
     using (Html.BeginForm("PostComments", "CommentAjax", new { PostId = Model.Id }, FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8b6a6c3cbdb3820aca597c7f986838bf6fb6a197155", async() => {
                WriteLiteral("Comment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 29 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8b6a6c3cbdb3820aca597c7f986838bf6fb6a198659", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 30 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8b6a6c3cbdb3820aca597c7f986838bf6fb6a1910199", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 31 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-success\">Publish</button>\r\n");
#nullable restore
#line 34 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
     foreach (var comment in Model.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 37 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
      Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 38 "C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.WebApp\Views\Blog\Item.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameBlog.Models.ViewModels.BlogViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
