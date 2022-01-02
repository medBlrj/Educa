﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Educa.Migrations
{
    [DbContext(typeof(EducoDbContext))]
    [Migration("20211222093753_AddRootObjct to entites")]
    partial class AddRootObjcttoentites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Educa.Entities.LevelEntities.Level", b =>
                {
                    b.Property<Guid>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("LevelId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Educa.Entities.QuestionsEntities.Questions", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CorrectAnswer")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PossibleAnswers")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("QNumber")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Educa.Entities.SubjectsEntities.Subjects", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubjectId");

                    b.HasIndex("LevelId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Educa.Entities.QuestionsEntities.Questions", b =>
                {
                    b.HasOne("Educa.Entities.SubjectsEntities.Subjects", "Subjects")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Educa.Entities.SubjectsEntities.Subjects", b =>
                {
                    b.HasOne("Educa.Entities.LevelEntities.Level", "Level")
                        .WithMany("Subjects")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Educa.Entities.LevelEntities.Level", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Educa.Entities.SubjectsEntities.Subjects", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
