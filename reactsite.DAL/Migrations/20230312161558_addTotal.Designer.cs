﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using reactsite.DAL;

#nullable disable

namespace reactsite.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230312161558_addTotal")]
    partial class addTotal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("reactsite.Domain.Entity.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DailyTasksId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoneType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Total")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeActivity")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DailyTasksId");

                    b.ToTable("Activity", (string)null);
                });

            modelBuilder.Entity("reactsite.Domain.Entity.DailyTasks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("NowActivity")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("DailyTasks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Day = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NowActivity = 0,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("reactsite.Domain.Entity.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = (short)0,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("reactsite.Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Login = "Admin",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            Role = 0
                        },
                        new
                        {
                            Id = 2L,
                            Login = "DefaultUser",
                            Password = "481f6cc0511143ccdd7e2d1b1b94faf0a700a8b49cd13922a70b5ae28acaa8c5",
                            Role = 1
                        });
                });

            modelBuilder.Entity("reactsite.Domain.Entity.Activity", b =>
                {
                    b.HasOne("reactsite.Domain.Entity.DailyTasks", "DailyTasks")
                        .WithMany("Activites")
                        .HasForeignKey("DailyTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DailyTasks");
                });

            modelBuilder.Entity("reactsite.Domain.Entity.DailyTasks", b =>
                {
                    b.HasOne("reactsite.Domain.Entity.User", "User")
                        .WithOne("DailyTasks")
                        .HasForeignKey("reactsite.Domain.Entity.DailyTasks", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("reactsite.Domain.Entity.Profile", b =>
                {
                    b.HasOne("reactsite.Domain.Entity.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("reactsite.Domain.Entity.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("reactsite.Domain.Entity.DailyTasks", b =>
                {
                    b.Navigation("Activites");
                });

            modelBuilder.Entity("reactsite.Domain.Entity.User", b =>
                {
                    b.Navigation("DailyTasks");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
