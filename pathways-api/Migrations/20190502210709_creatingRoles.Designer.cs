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
    [Migration("20190502210709_creatingRoles")]
    partial class creatingRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("pathways_api.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleLevelId");

                    b.Property<int>("RoleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RoleLevelId");

                    b.HasIndex("RoleTypeId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.RoleLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("rolelevels");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("roletypes");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Login_id");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("pathways_api.Data.Entities.Role", b =>
                {
                    b.HasOne("pathways_api.Data.Entities.RoleLevel", "RoleLevel")
                        .WithMany()
                        .HasForeignKey("RoleLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("pathways_api.Data.Entities.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}