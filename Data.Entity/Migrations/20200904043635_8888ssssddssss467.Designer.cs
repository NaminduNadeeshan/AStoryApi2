﻿// <auto-generated />
using System;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Entity.Migrations
{
    [DbContext(typeof(AStoryDatabaseContext))]
    [Migration("20200904043635_8888ssssddssss467")]
    partial class _8888ssssddssss467
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entity.Auther", b =>
                {
                    b.Property<int>("AutherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutherId");

                    b.ToTable("Authers");
                });

            modelBuilder.Entity("Data.Entity.AutherBankDetails", b =>
                {
                    b.Property<int>("bankDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("autherId")
                        .HasColumnType("int");

                    b.Property<string>("bankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("branchName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bankDetailsId");

                    b.HasIndex("autherId")
                        .IsUnique();

                    b.ToTable("AutherBankDetails");
                });

            modelBuilder.Entity("Data.Entity.Episode", b =>
                {
                    b.Property<int>("episodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("episodeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("episodeCoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("episodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("episodeShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("storyId")
                        .HasColumnType("int");

                    b.HasKey("episodeId");

                    b.HasIndex("storyId");

                    b.ToTable("Episode");
                });

            modelBuilder.Entity("Data.Entity.Story", b =>
                {
                    b.Property<int>("storyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("autherId")
                        .HasColumnType("int");

                    b.Property<string>("coverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("storyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storyShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("storyId");

                    b.HasIndex("autherId");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("Data.Entity.Subscription", b =>
                {
                    b.Property<int>("subscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("episodeId")
                        .HasColumnType("int");

                    b.Property<int>("storyId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("subscriptionId");

                    b.HasIndex("userId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Data.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entity.AutherBankDetails", b =>
                {
                    b.HasOne("Data.Entity.Auther", "auther")
                        .WithOne("BankDetails")
                        .HasForeignKey("Data.Entity.AutherBankDetails", "autherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entity.Episode", b =>
                {
                    b.HasOne("Data.Entity.Story", "story")
                        .WithMany("episodes")
                        .HasForeignKey("storyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entity.Story", b =>
                {
                    b.HasOne("Data.Entity.Auther", "auther")
                        .WithMany("stories")
                        .HasForeignKey("autherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entity.Subscription", b =>
                {
                    b.HasOne("Data.Entity.User", "user")
                        .WithMany("SubscribedStories")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
