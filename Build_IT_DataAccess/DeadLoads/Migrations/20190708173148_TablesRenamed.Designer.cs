﻿// <auto-generated />
using Build_IT_DataAccess.DeadLoads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Build_IT_DataAccess.DeadLoads.Migrations
{
    [DbContext(typeof(DeadLoadsDbContext))]
    [Migration("20190708173148_TablesRenamed")]
    partial class TablesRenamed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Addition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(124);

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("DeadLoads_Additions");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DeadLoads_Categories");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Material", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<string>("DocumentName");

                    b.Property<double>("MaximumDensity");

                    b.Property<double>("MinimumDensity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("SubcategoryId");

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("DeadLoads_Materials");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.MaterialAddition", b =>
                {
                    b.Property<long>("MaterialId");

                    b.Property<long>("AdditionId");

                    b.HasKey("MaterialId", "AdditionId");

                    b.HasIndex("AdditionId");

                    b.ToTable("DeadLoads_MaterialAdditions");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Subcategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId");

                    b.Property<string>("DocumentName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("DeadLoads_Subcategories");
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Material", b =>
                {
                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Subcategory", "Subcategory")
                        .WithMany("Materials")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.MaterialAddition", b =>
                {
                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Addition", "Addition")
                        .WithMany()
                        .HasForeignKey("AdditionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Material", "Material")
                        .WithMany("MaterialAdditions")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Build_IT_DataAccess.DeadLoads.Models.Subcategory", b =>
                {
                    b.HasOne("Build_IT_DataAccess.DeadLoads.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}