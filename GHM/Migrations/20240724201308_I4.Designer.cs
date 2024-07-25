﻿// <auto-generated />
using System;
using GHM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GHM.Migrations
{
    [DbContext(typeof(GhmDbContext))]
    [Migration("20240724201308_I4")]
    partial class I4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("GHM.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FeedbackQuestion1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestion2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestion3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestion4Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestionId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Teacher1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Teacher2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Teacher3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId3")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackQuestion1Id");

                    b.HasIndex("FeedbackQuestion2Id");

                    b.HasIndex("FeedbackQuestion3Id");

                    b.HasIndex("FeedbackQuestion4Id");

                    b.HasIndex("Teacher1Id");

                    b.HasIndex("Teacher2Id");

                    b.HasIndex("Teacher3Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("GHM.FeedbackQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Q1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FeedbackQuestions");
                });

            modelBuilder.Entity("GHM.Models.FeedbackQuestionViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FeedbackViewModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Q1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Q4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackViewModelId");

                    b.ToTable("FeedbackQuestionViewModel");
                });

            modelBuilder.Entity("GHM.Models.FeedbackViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeedbackQuestion1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeedbackQuestion2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeedbackQuestion3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeedbackQuestion4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FeedbackQuestionId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestionId2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestionId3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeedbackQuestionId4")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Module1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Module2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Module3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ModuleId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId3")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Teacher1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Teacher2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Teacher3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId3")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FeedbackViewModel");
                });

            modelBuilder.Entity("GHM.Models.ModuleViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FeedbackViewModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackViewModelId");

                    b.ToTable("ModuleViewModel");
                });

            modelBuilder.Entity("GHM.Models.TeacherViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FeedbackViewModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackViewModelId");

                    b.ToTable("TeacherViewModel");
                });

            modelBuilder.Entity("GHM.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("GHM.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("GHM.Feedback", b =>
                {
                    b.HasOne("GHM.FeedbackQuestion", "FeedbackQuestion1")
                        .WithMany()
                        .HasForeignKey("FeedbackQuestion1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.FeedbackQuestion", "FeedbackQuestion2")
                        .WithMany()
                        .HasForeignKey("FeedbackQuestion2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.FeedbackQuestion", "FeedbackQuestion3")
                        .WithMany()
                        .HasForeignKey("FeedbackQuestion3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.FeedbackQuestion", "FeedbackQuestion4")
                        .WithMany()
                        .HasForeignKey("FeedbackQuestion4Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.Teacher", "Teacher1")
                        .WithMany()
                        .HasForeignKey("Teacher1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.Teacher", "Teacher2")
                        .WithMany()
                        .HasForeignKey("Teacher2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHM.Teacher", "Teacher3")
                        .WithMany()
                        .HasForeignKey("Teacher3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedbackQuestion1");

                    b.Navigation("FeedbackQuestion2");

                    b.Navigation("FeedbackQuestion3");

                    b.Navigation("FeedbackQuestion4");

                    b.Navigation("Teacher1");

                    b.Navigation("Teacher2");

                    b.Navigation("Teacher3");
                });

            modelBuilder.Entity("GHM.Models.FeedbackQuestionViewModel", b =>
                {
                    b.HasOne("GHM.Models.FeedbackViewModel", null)
                        .WithMany("FeedbackQuestions")
                        .HasForeignKey("FeedbackViewModelId");
                });

            modelBuilder.Entity("GHM.Models.ModuleViewModel", b =>
                {
                    b.HasOne("GHM.Models.FeedbackViewModel", null)
                        .WithMany("Modules")
                        .HasForeignKey("FeedbackViewModelId");
                });

            modelBuilder.Entity("GHM.Models.TeacherViewModel", b =>
                {
                    b.HasOne("GHM.Models.FeedbackViewModel", null)
                        .WithMany("Teachers")
                        .HasForeignKey("FeedbackViewModelId");
                });

            modelBuilder.Entity("GHM.Teacher", b =>
                {
                    b.HasOne("GHM.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("GHM.Models.FeedbackViewModel", b =>
                {
                    b.Navigation("FeedbackQuestions");

                    b.Navigation("Modules");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
