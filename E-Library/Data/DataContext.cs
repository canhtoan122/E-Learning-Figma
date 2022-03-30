using E_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<School_year> School_year { get; set; }
        public DbSet<Subject_group> Subject_group { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<List_of_award> List_of_award { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<Disciplinary_list> Disciplinary_list { get; set; }
        public DbSet<School_transfer_admission> School_transfer_admission { get; set; }
        public DbSet<Reservation_Record> Reservation_Record { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Teaching_Assignment> Teaching_Assignment { get; set; }
        public DbSet<Topic_list> Topic_list { get; set; }
        public DbSet<Manage_Exam_Schedule> Manage_Exam_Schedule { get; set; }
        public DbSet<School_Information> School_Information { get; set; }
        public DbSet<User_group> User_group { get; set; }
        public DbSet<User_list> User_list { get; set; }
        public DbSet<Classroom_setting> Classroom_setting { get; set; }
        public DbSet<Subject_setting> Subject_setting { get; set; }
        public DbSet<Management_of_training_levels> Management_of_training_levels { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Class_History> Class_History { get; set; }
        public DbSet<Exam_List> Exam_List { get; set; }
        public DbSet<Exam_Grade> Exam_Grade { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Online_class> Online_class { get; set; }
        public DbSet<Q_A_questionaire> Q_A_questionaire { get; set; }
        public DbSet<Exam> Exam { get; set; }
    }
}
