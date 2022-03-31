﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Library.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class_History",
                columns: table => new
                {
                    Class_History_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLass_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Security_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other_setting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shared_link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_History", x => x.Class_History_ID);
                });

            migrationBuilder.CreateTable(
                name: "Classroom_setting",
                columns: table => new
                {
                    Classroom_setting_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom_setting", x => x.Classroom_setting_ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completed_course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uncompleted_course = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinary_list",
                columns: table => new
                {
                    Disciplinary_list_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disciplinary_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disciplinary_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disciplinary_content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinary_list", x => x.Disciplinary_list_ID);
                });

            migrationBuilder.CreateTable(
                name: "Exam_Grade",
                columns: table => new
                {
                    Exam_Grade_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance_grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oral_test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A_quarter_hour_test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Half_hour_test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mid_term_test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Final_test_test = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year_average_grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Update_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam_Grade", x => x.Exam_Grade_ID);
                });

            migrationBuilder.CreateTable(
                name: "Exam_List",
                columns: table => new
                {
                    Exam_List_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teaching_Assistant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_amount_of_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Security_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other_setting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shared_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam_List", x => x.Exam_List_ID);
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Grade_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score_factor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minimum_number_of_columns_for_semester_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minimum_number_of_columns_for_semester_2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Grade_ID);
                });

            migrationBuilder.CreateTable(
                name: "Help",
                columns: table => new
                {
                    Help_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Help", x => x.Help_ID);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Lesson_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teaching_assistant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lession_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Security_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other_setting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Share_link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Lesson_ID);
                });

            migrationBuilder.CreateTable(
                name: "List_of_award",
                columns: table => new
                {
                    List_of_award_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Award_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Award_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Award_content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List_of_award", x => x.List_of_award_ID);
                });

            migrationBuilder.CreateTable(
                name: "Manage_Exam_Schedule",
                columns: table => new
                {
                    Manage_Exam_Schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_marking_assignment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manage_Exam_Schedule", x => x.Manage_Exam_Schedule_ID);
                });

            migrationBuilder.CreateTable(
                name: "Management_of_training_levels",
                columns: table => new
                {
                    Management_of_training_levels_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree_training = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Form_of_training = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Training_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_of_training_levels", x => x.Management_of_training_levels_ID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Notification_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Notification_ID);
                });

            migrationBuilder.CreateTable(
                name: "Online_class",
                columns: table => new
                {
                    Online_class_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Online_class", x => x.Online_class_ID);
                });

            migrationBuilder.CreateTable(
                name: "Q_A_questionaire",
                columns: table => new
                {
                    Q_A_questionaire_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Q_A_questionaire", x => x.Q_A_questionaire_ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Record",
                columns: table => new
                {
                    Reservation_Record_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reserve_class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reserve_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reserve_period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reserve_reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Record", x => x.Reservation_Record_ID);
                });

            migrationBuilder.CreateTable(
                name: "School_Information",
                columns: table => new
                {
                    School_Information_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Headquarter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Founded_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_establishment_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facility_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Person_in_charge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Information", x => x.School_Information_ID);
                });

            migrationBuilder.CreateTable(
                name: "School_transfer_admission",
                columns: table => new
                {
                    School_transfer_admission_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transfer_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transfer_semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transfer_from = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transfer_reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_transfer_admission", x => x.School_transfer_admission_ID);
                });

            migrationBuilder.CreateTable(
                name: "School_year",
                columns: table => new
                {
                    School_year_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_year_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester_start_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester_end_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_year", x => x.School_year_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_admission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ethnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graduate_form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Study_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mother_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guardian_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mother_date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guardian_date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mother_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guardian_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mother_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guardian_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_semester_lession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Second_semester_lession = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Subject_ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject_setting",
                columns: table => new
                {
                    Subject_setting_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_setting", x => x.Subject_setting_ID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Teacher_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ethnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aliases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Union_members = table.Column<bool>(type: "bit", nullable: false),
                    Party_members = table.Column<bool>(type: "bit", nullable: false),
                    Date_of_joining_the_union = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_of_joining_the_party = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacher_ID);
                });

            migrationBuilder.CreateTable(
                name: "Teaching_Assignment",
                columns: table => new
                {
                    Teaching_Assignment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching_Assignment", x => x.Teaching_Assignment_ID);
                });

            migrationBuilder.CreateTable(
                name: "Topic_list",
                columns: table => new
                {
                    Topic_list_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic_list", x => x.Topic_list_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_group",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decentralization = table.Column<bool>(type: "bit", nullable: false),
                    Data_declaration = table.Column<bool>(type: "bit", nullable: false),
                    Student_profile = table.Column<bool>(type: "bit", nullable: false),
                    Teacher_profile = table.Column<bool>(type: "bit", nullable: false),
                    Examination = table.Column<bool>(type: "bit", nullable: false),
                    System_update = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_group", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_list",
                columns: table => new
                {
                    User_list_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_list", x => x.User_list_ID);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Class_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Homeroom_teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_classify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_year_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Class_ID);
                    table.ForeignKey(
                        name: "FK_Class_School_year_School_year_ID",
                        column: x => x.School_year_ID,
                        principalTable: "School_year",
                        principalColumn: "School_year_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject_group",
                columns: table => new
                {
                    Subject_group_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_group_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Head_of_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject_group", x => x.Subject_group_ID);
                    table.ForeignKey(
                        name: "FK_Subject_group_Subject_Subject_ID",
                        column: x => x.Subject_ID,
                        principalTable: "Subject",
                        principalColumn: "Subject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_ID);
                    table.ForeignKey(
                        name: "FK_Department_Class_Class_ID",
                        column: x => x.Class_ID,
                        principalTable: "Class",
                        principalColumn: "Class_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Exam_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test_form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exam_classify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ending_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other_setting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_group_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Exam_ID);
                    table.ForeignKey(
                        name: "FK_Exam_Subject_group_Subject_group_ID",
                        column: x => x.Subject_group_ID,
                        principalTable: "Subject_group",
                        principalColumn: "Subject_group_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_School_year_ID",
                table: "Class",
                column: "School_year_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Class_ID",
                table: "Department",
                column: "Class_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Subject_group_ID",
                table: "Exam",
                column: "Subject_group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_group_Subject_ID",
                table: "Subject_group",
                column: "Subject_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class_History");

            migrationBuilder.DropTable(
                name: "Classroom_setting");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Disciplinary_list");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Exam_Grade");

            migrationBuilder.DropTable(
                name: "Exam_List");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Help");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "List_of_award");

            migrationBuilder.DropTable(
                name: "Manage_Exam_Schedule");

            migrationBuilder.DropTable(
                name: "Management_of_training_levels");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Online_class");

            migrationBuilder.DropTable(
                name: "Q_A_questionaire");

            migrationBuilder.DropTable(
                name: "Reservation_Record");

            migrationBuilder.DropTable(
                name: "School_Information");

            migrationBuilder.DropTable(
                name: "School_transfer_admission");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject_setting");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Teaching_Assignment");

            migrationBuilder.DropTable(
                name: "Topic_list");

            migrationBuilder.DropTable(
                name: "User_group");

            migrationBuilder.DropTable(
                name: "User_list");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Subject_group");

            migrationBuilder.DropTable(
                name: "School_year");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}