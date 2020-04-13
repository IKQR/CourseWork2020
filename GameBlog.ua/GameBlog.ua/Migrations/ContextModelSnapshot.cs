﻿// <auto-generated />
using System;
using GameBlog.ua.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GameBlog.ua.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.AvatarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AvatarImages");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.Property<int>("SteamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<int>("PostContentId")
                        .HasColumnType("integer");

                    b.Property<string>("ShortDescriprion")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostContentId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.PostContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostContents");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuthType")
                        .HasColumnType("integer");

                    b.Property<int>("AvatarImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int[]>("LikedPosts")
                        .HasColumnType("integer[]");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int[]>("Posts")
                        .HasColumnType("integer[]");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AvatarImageId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Ad", b =>
                {
                    b.HasOne("GameBlog.ua.Models.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameBlog.ua.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Comment", b =>
                {
                    b.HasOne("GameBlog.ua.Models.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameBlog.ua.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.Post", b =>
                {
                    b.HasOne("GameBlog.ua.Models.Entities.PostContent", "PostContent")
                        .WithMany()
                        .HasForeignKey("PostContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameBlog.ua.Models.Entities.User", b =>
                {
                    b.HasOne("GameBlog.ua.Models.Entities.AvatarImage", "AvatarImage")
                        .WithMany()
                        .HasForeignKey("AvatarImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameBlog.ua.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
