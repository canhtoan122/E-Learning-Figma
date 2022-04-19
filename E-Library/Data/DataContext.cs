using E_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SchoolYear> SchoolYear { get; set; }
        public DbSet<SubjectGroup> SubjectGroup { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<ListOfAward> ListOfAward { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<DisciplinaryList> DisciplinaryList { get; set; }
        public DbSet<SchoolTransferAdmission> SchoolTransferAdmission { get; set; }
        public DbSet<ReservationRecord> ReservationRecord { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignment { get; set; }
        public DbSet<TopicList> TopicList { get; set; }
        public DbSet<ManageExamSchedule> ManageExamSchedule { get; set; }
        public DbSet<SchoolInformation> SchoolInformation { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<UserList> UserList { get; set; }
        public DbSet<ClassroomSetting> ClassroomSetting { get; set; }
        public DbSet<SubjectSetting> SubjectSetting { get; set; }
        public DbSet<ManagementOfTrainingLevels> ManagementOfTrainingLevels { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<ClassHistory> ClassHistory { get; set; }
        public DbSet<ExamList> ExamList { get; set; }
        public DbSet<ExamGrade> ExamGrade { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<OnlineClass> OnlineClass { get; set; }
        public DbSet<QAQuestionaire> QAQuestionaire { get; set; }
        public DbSet<Exam> Exam { get; set; }
    }
}
