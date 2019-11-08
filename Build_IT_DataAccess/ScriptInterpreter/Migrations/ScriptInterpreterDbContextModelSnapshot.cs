﻿// <auto-generated />
using System;
using Build_IT_DataAccess.ScriptInterpreter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Build_IT_DataAccess.ScriptInterpreter.Migrations
{
    [DbContext(typeof(ScriptInterpreterDbContext))]
    partial class ScriptInterpreterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Assertion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("TestDataId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestDataId");

                    b.ToTable("Scripts_Assertions");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Figure", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Scripts_Figures");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ScriptId")
                        .HasColumnType("bigint");

                    b.Property<string>("VisibilityValidator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Scripts_Groups");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Context")
                        .HasColumnType("int");

                    b.Property<string>("DataValidator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<long>("ScriptId")
                        .HasColumnType("bigint");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValueOptionSetting")
                        .HasColumnType("int");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.Property<string>("VisibilityValidator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ScriptId");

                    b.ToTable("Scripts_Parameters");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ParameterFigure", b =>
                {
                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint");

                    b.Property<long>("FigureId")
                        .HasColumnType("bigint");

                    b.HasKey("ParameterId", "FigureId");

                    b.HasIndex("FigureId");

                    b.ToTable("Scripts_ParameterFigures");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Script", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccordingTo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("DefaultLanguage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Scripts_Scripts");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ScriptTag", b =>
                {
                    b.Property<long>("ScriptId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("ScriptId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("Scripts_ScriptTags");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Scripts_Tags");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.TestData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<long>("ScriptId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Scripts_TestDatas");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.TestParameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestDataId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.HasIndex("TestDataId");

                    b.ToTable("Scripts_TestParameters");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.GroupTranslation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Scripts_GroupTranslations");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ParameterTranslation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("Scripts_ParametersTranslations");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ScriptTranslation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ScriptId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ScriptId");

                    b.ToTable("Scripts_ScriptsTranslations");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ValueOptionTranslation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ValueOptionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ValueOptionId");

                    b.ToTable("Scripts_ValueOptionsTranslations");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ValueOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("Scripts_ValueOptions");
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Assertion", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.TestData", "TestData")
                        .WithMany("Assertions")
                        .HasForeignKey("TestDataId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Group", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Script", "Script")
                        .WithMany()
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Parameter", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Group", "Group")
                        .WithMany("Parameters")
                        .HasForeignKey("GroupId");

                    b.HasOne("Build_IT_Data.Entities.Scripts.Script", "Script")
                        .WithMany("Parameters")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ParameterFigure", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Figure", "Figure")
                        .WithMany()
                        .HasForeignKey("FigureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Build_IT_Data.Entities.Scripts.Parameter", "Parameter")
                        .WithMany("ParameterFigures")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ScriptTag", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Script", "Script")
                        .WithMany("Tags")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Build_IT_Data.Entities.Scripts.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.TestData", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Script", "Script")
                        .WithMany()
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.TestParameter", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Parameter", "Parameter")
                        .WithMany()
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Build_IT_Data.Entities.Scripts.TestData", "TestData")
                        .WithMany("TestParameters")
                        .HasForeignKey("TestDataId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.GroupTranslation", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ParameterTranslation", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Parameter", "Parameter")
                        .WithMany("ParametersTranslations")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ScriptTranslation", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Script", "Script")
                        .WithMany("ScriptTranslations")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.Translations.ValueOptionTranslation", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.ValueOption", "ValueOption")
                        .WithMany("ValueOptionsTranslations")
                        .HasForeignKey("ValueOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Build_IT_Data.Entities.Scripts.ValueOption", b =>
                {
                    b.HasOne("Build_IT_Data.Entities.Scripts.Parameter", "Parameter")
                        .WithMany("ValueOptions")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
