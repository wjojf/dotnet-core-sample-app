﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SampleRestAPI.infrastructure.EF.Workout;

#nullable disable

namespace SampleRestAPI.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20240913144509_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SampleRestAPI.infrastructure.EF.Exercise.ExerciseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Repetitions")
                        .HasColumnType("integer");

                    b.Property<int>("Sets")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<Guid?>("WorkoutEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutEntityId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("SampleRestAPI.infrastructure.EF.Workout.WorkoutEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("workouts");
                });

            modelBuilder.Entity("SampleRestAPI.infrastructure.EF.Exercise.ExerciseEntity", b =>
                {
                    b.HasOne("SampleRestAPI.infrastructure.EF.Workout.WorkoutEntity", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutEntityId");
                });

            modelBuilder.Entity("SampleRestAPI.infrastructure.EF.Workout.WorkoutEntity", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
