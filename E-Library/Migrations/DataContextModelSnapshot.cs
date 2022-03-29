﻿// <auto-generated />
using System;
using E_Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Library.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("E_Library.Model.Class", b =>
                {
                    b.Property<int>("Class_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Class_ID"), 1L, 1);

                    b.Property<string>("Class_classify")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homeroom_teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Class_ID");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("E_Library.Model.Classroom_setting", b =>
                {
                    b.Property<int>("Classroom_setting_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Classroom_setting_ID"), 1L, 1);

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Classroom_setting_ID");

                    b.ToTable("Classroom_setting");
                });

            modelBuilder.Entity("E_Library.Model.Department", b =>
                {
                    b.Property<int>("Department_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Department_ID"), 1L, 1);

                    b.Property<string>("Dean")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Department_ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("E_Library.Model.Disciplinary_list", b =>
                {
                    b.Property<int>("Disciplinary_list_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Disciplinary_list_ID"), 1L, 1);

                    b.Property<string>("Disciplinary_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disciplinary_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Disciplinary_list_ID");

                    b.ToTable("Disciplinary_list");
                });

            modelBuilder.Entity("E_Library.Model.FileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileData");
                });

            modelBuilder.Entity("E_Library.Model.Grade", b =>
                {
                    b.Property<int>("Grade_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Grade_ID"), 1L, 1);

                    b.Property<string>("Grade_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minimum_number_of_columns_for_semester_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minimum_number_of_columns_for_semester_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Score_factor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Grade_ID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("E_Library.Model.List_of_award", b =>
                {
                    b.Property<int>("List_of_award_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("List_of_award_ID"), 1L, 1);

                    b.Property<string>("Award_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Award_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("List_of_award_ID");

                    b.ToTable("List_of_award");
                });

            modelBuilder.Entity("E_Library.Model.Manage_Exam_Schedule", b =>
                {
                    b.Property<int>("Manage_Exam_Schedule_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Manage_Exam_Schedule_ID"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exam_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exam_marking_assignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exam_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exam_subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Manage_Exam_Schedule_ID");

                    b.ToTable("Manage_Exam_Schedule");
                });

            modelBuilder.Entity("E_Library.Model.Management_of_training_levels", b =>
                {
                    b.Property<int>("Management_of_training_levels_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Management_of_training_levels_ID"), 1L, 1);

                    b.Property<string>("Degree_training")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Form_of_training")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Training_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Management_of_training_levels_ID");

                    b.ToTable("Management_of_training_levels");
                });

            modelBuilder.Entity("E_Library.Model.Reservation_Record", b =>
                {
                    b.Property<int>("Reservation_Record_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_Record_ID"), 1L, 1);

                    b.Property<string>("Date_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reserve_class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reserve_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reserve_period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reserve_reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Reservation_Record_ID");

                    b.ToTable("Reservation_Record");
                });

            modelBuilder.Entity("E_Library.Model.School_Information", b =>
                {
                    b.Property<int>("School_Information_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("School_Information_ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cellphone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facility_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Founded_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Headquarter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person_in_charge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Principal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Principal_phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_establishment_model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("School_Information_ID");

                    b.ToTable("School_Information");
                });

            modelBuilder.Entity("E_Library.Model.School_transfer_admission", b =>
                {
                    b.Property<int>("School_transfer_admission_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("School_transfer_admission_ID"), 1L, 1);

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transfer_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transfer_from")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transfer_reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transfer_semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("School_transfer_admission_ID");

                    b.ToTable("School_transfer_admission");
                });

            modelBuilder.Entity("E_Library.Model.School_year", b =>
                {
                    b.Property<int>("School_year_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("School_year_ID"), 1L, 1);

                    b.Property<string>("Ending_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School_year_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester_end_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester_start_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Starting_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("School_year_ID");

                    b.ToTable("School_year");
                });

            modelBuilder.Entity("E_Library.Model.Student", b =>
                {
                    b.Property<int>("Student_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date_of_admission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ethnic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Father_date_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Father_full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Father_occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Father_phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Graduate_form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guardian_date_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guardian_full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guardian_occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guardian_phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother_date_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother_full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother_occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mother_phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place_of_birth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Study_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("E_Library.Model.Subject", b =>
                {
                    b.Property<int>("Subject_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_ID"), 1L, 1);

                    b.Property<string>("First_semester_lession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Second_semester_lession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_ID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("E_Library.Model.Subject_group", b =>
                {
                    b.Property<int>("Subject_group_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_group_ID"), 1L, 1);

                    b.Property<string>("Head_of_department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_group_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_group_ID");

                    b.ToTable("Subject_group");
                });

            modelBuilder.Entity("E_Library.Model.Subject_setting", b =>
                {
                    b.Property<int>("Subject_setting_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_setting_ID"), 1L, 1);

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_setting_ID");

                    b.ToTable("Subject_setting");
                });

            modelBuilder.Entity("E_Library.Model.Teacher", b =>
                {
                    b.Property<int>("Teacher_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Teacher_ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aliases")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_of_joining_the_party")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_of_joining_the_union")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ethnic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Party_members")
                        .HasColumnType("bit");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Starting_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Union_members")
                        .HasColumnType("bit");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Teacher_ID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("E_Library.Model.Teaching_Assignment", b =>
                {
                    b.Property<int>("Teaching_Assignment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Teaching_Assignment_ID"), 1L, 1);

                    b.Property<string>("Classroom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ending_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Starting_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Teaching_Assignment_ID");

                    b.ToTable("Teaching_Assignment");
                });

            modelBuilder.Entity("E_Library.Model.Topic_list", b =>
                {
                    b.Property<int>("Topic_list_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Topic_list_ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ending_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Topic_list_ID");

                    b.ToTable("Topic_list");
                });

            modelBuilder.Entity("E_Library.Model.User_group", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"), 1L, 1);

                    b.Property<bool>("Data_declaration")
                        .HasColumnType("bit");

                    b.Property<bool>("Decentralization")
                        .HasColumnType("bit");

                    b.Property<bool>("Examination")
                        .HasColumnType("bit");

                    b.Property<string>("Group_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Student_profile")
                        .HasColumnType("bit");

                    b.Property<bool>("System_update")
                        .HasColumnType("bit");

                    b.Property<bool>("Teacher_profile")
                        .HasColumnType("bit");

                    b.HasKey("User_ID");

                    b.ToTable("User_group");
                });

            modelBuilder.Entity("E_Library.Model.User_list", b =>
                {
                    b.Property<int>("User_list_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_list_ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_list_ID");

                    b.ToTable("User_list");
                });
#pragma warning restore 612, 618
        }
    }
}
