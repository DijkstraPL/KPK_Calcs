﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTest.Persistance;

namespace WebTest.Migrations
{
    [DbContext(typeof(BuildItDbContext))]
    [Migration("20190106183146_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebTest.Models.AlternativeScript", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ParameterId");

                    b.Property<string>("ScriptName");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("AlternativeScript");
                });

            modelBuilder.Entity("WebTest.Models.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo");

                    b.Property<int>("Context");

                    b.Property<string>("DataValidator");

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("Number");

                    b.Property<long>("ScriptId");

                    b.Property<string>("Unit");

                    b.Property<string>("Value");

                    b.Property<int>("ValueType");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("WebTest.Models.Script", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo");

                    b.Property<DateTime>("Added");

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.ToTable("Scripts");
                });

            modelBuilder.Entity("WebTest.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long?>("ScriptId");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("WebTest.Models.ValueOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<long>("ParameterId");

                    b.Property<string>("Value");

                    b.Property<int>("ValueOptionSetting");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("ValueOption");
                });

            modelBuilder.Entity("WebTest.Models.AlternativeScript", b =>
                {
                    b.HasOne("WebTest.Models.Parameter")
                        .WithMany("NestedScripts")
                        .HasForeignKey("ParameterId");
                });

            modelBuilder.Entity("WebTest.Models.Parameter", b =>
                {
                    b.HasOne("WebTest.Models.Script", "Script")
                        .WithMany("Parameters")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebTest.Models.Tag", b =>
                {
                    b.HasOne("WebTest.Models.Script")
                        .WithMany("Tags")
                        .HasForeignKey("ScriptId");
                });

            modelBuilder.Entity("WebTest.Models.ValueOption", b =>
                {
                    b.HasOne("WebTest.Models.Parameter", "Parameter")
                        .WithMany("ValueOptions")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}