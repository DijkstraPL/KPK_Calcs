﻿// <auto-generated />
using System;
using Build_IT_DataAccess.DeadLoads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Build_IT_DataAccess.DeadLoads.Migrations
{
    [DbContext(typeof(DeadLoadsDbContext))]
    [Migration("20190422110437_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Material", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalComments");

                    b.Property<string>("AdditionalOption1");

                    b.Property<string>("AdditionalOption2");

                    b.Property<string>("DocumentName");

                    b.Property<double>("MaximumDensity");

                    b.Property<double>("MinimumDensity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("SubcategoryId");

                    b.Property<string>("Units")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Subcategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CategoryId");

                    b.Property<string>("DocumentName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Material", b =>
                {
                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Subcategory", "Subcategory")
                        .WithMany("Materials")
                        .HasForeignKey("SubcategoryId");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Subcategory", b =>
                {
                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
