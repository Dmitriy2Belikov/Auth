﻿// <auto-generated />
using System;
using Auth.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Auth.DataLayer.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20200827053206_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Auth.DataLayer.Models.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.Permission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RuleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "OperationId");

                    b.HasIndex("OperationId");

                    b.HasIndex("RuleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FactAddress")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("OtherPhones")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationAddress")
                        .HasColumnType("text");

                    b.Property<string>("Snils")
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.RoleSystemModuleLink", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SystemModuleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "SystemModuleId");

                    b.HasIndex("SystemModuleId");

                    b.ToTable("RoleSystemModuleLinks");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.Rule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.SystemModule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemModules");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthToken")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastActionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.UserRoleLink", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoleLinks");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.WorkingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkingEntities");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.WorkingEntityOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("SystemModuleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid>("WorkingEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SystemModuleId");

                    b.HasIndex("WorkingEntityId");

                    b.ToTable("WorkingEntityOperations");
                });

            modelBuilder.Entity("Auth.DataLayer.Models.Permission", b =>
                {
                    b.HasOne("Auth.DataLayer.Models.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Models.Rule", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.DataLayer.Models.RoleSystemModuleLink", b =>
                {
                    b.HasOne("Auth.DataLayer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Models.SystemModule", "SystemModule")
                        .WithMany()
                        .HasForeignKey("SystemModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.DataLayer.Models.UserRoleLink", b =>
                {
                    b.HasOne("Auth.DataLayer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Auth.DataLayer.Models.WorkingEntityOperation", b =>
                {
                    b.HasOne("Auth.DataLayer.Models.SystemModule", "SystemModule")
                        .WithMany()
                        .HasForeignKey("SystemModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Models.WorkingEntity", "WorkingEntity")
                        .WithMany()
                        .HasForeignKey("WorkingEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}