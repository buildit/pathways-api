﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pathways_api.Data;

namespace pathways_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190525002531_skilltypelevels")]
    partial class skilltypelevels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("pathways_api.Data.Entities.RoleLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("rolelevel","skills");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.RoleLevelRule", b =>
                {
                    b.Property<int>("RoleTypeId");

                    b.Property<int>("RoleLevelId");

                    b.Property<int>("SkillTypeId");

                    b.Property<int>("SkillLevelId");

                    b.Property<int>("Id");

                    b.HasKey("RoleTypeId", "RoleLevelId", "SkillTypeId", "SkillLevelId");

                    b.HasIndex("RoleLevelId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("SkillTypeId");

                    b.ToTable("rolelevelrule","admin");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("roletype","skills");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("skilllevel","skills");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.SkillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("skilltype","skills");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.SkillTypeLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SkillLevelId");

                    b.Property<int>("SkillTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("SkillTypeId");

                    b.ToTable("skilltypelevel","skills");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DirectoryName");

                    b.Property<string>("DomoIdentifier");

                    b.Property<string>("Name");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("users","admin");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.UserSkill", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("SkillTypeId");

                    b.Property<int>("SkillLevelId");

                    b.HasKey("UserId", "SkillTypeId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("SkillTypeId");

                    b.ToTable("userskills","assessment");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.RoleLevelRule", b =>
                {
                    b.HasOne("pathways_api.Data.Entities.RoleLevel", "RoleLevel")
                        .WithMany()
                        .HasForeignKey("RoleLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.RoleLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.SkillType", "SkillType")
                        .WithMany()
                        .HasForeignKey("SkillTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("pathways_api.Data.Entities.SkillTypeLevel", b =>
                {
                    b.HasOne("pathways_api.Data.Entities.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.SkillType", "SkillType")
                        .WithMany()
                        .HasForeignKey("SkillTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("pathways_api.Data.Entities.UserSkill", b =>
                {
                    b.HasOne("pathways_api.Data.Entities.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.SkillType", "SkillType")
                        .WithMany()
                        .HasForeignKey("SkillTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
