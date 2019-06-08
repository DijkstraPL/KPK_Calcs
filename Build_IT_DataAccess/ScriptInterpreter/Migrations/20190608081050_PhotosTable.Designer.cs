﻿// <auto-generated />
using System;
using Build_IT_DataAccess.ScriptInterpreter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    [DbContext(typeof(ScriptInterpreterDbContext))]
    [Migration("20190608081050_PhotosTable")]
    partial class PhotosTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo");

                    b.Property<int>("Context");

                    b.Property<string>("DataValidator");

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Notes");

                    b.Property<int>("Number");

                    b.Property<long>("ScriptId");

                    b.Property<string>("Unit");

                    b.Property<string>("Value");

                    b.Property<int>("ValueOptionSetting");

                    b.Property<int>("ValueType");

                    b.Property<string>("VisibilityValidator");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ParameterPhoto", b =>
                {
                    b.Property<long>("ParameterId");

                    b.Property<long>("PhotoId");

                    b.Property<int?>("PhotoId1");

                    b.HasKey("ParameterId", "PhotoId");

                    b.HasIndex("PhotoId1");

                    b.ToTable("ParameterPhotos");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.Script", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Added");

                    b.Property<string>("Author")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("GroupName")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Notes");

                    b.Property<float>("Version");

                    b.HasKey("Id");

                    b.ToTable("Scripts");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ScriptTag", b =>
                {
                    b.Property<long>("ScriptId");

                    b.Property<long>("TagId");

                    b.HasKey("ScriptId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ScriptTags");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ValueOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("ParameterId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("ValueOptions");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.Parameter", b =>
                {
                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Script", "Script")
                        .WithMany("Parameters")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ParameterPhoto", b =>
                {
                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Parameter", "Parameter")
                        .WithMany("ParameterPhotos")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId1");
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ScriptTag", b =>
                {
                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Script", "Script")
                        .WithMany("Tags")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Build_IT_DataAccess.ScriptInterpreter.Models.ValueOption", b =>
                {
                    b.HasOne("Build_IT_DataAccess.ScriptInterpreter.Models.Parameter", "Parameter")
                        .WithMany("ValueOptions")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
