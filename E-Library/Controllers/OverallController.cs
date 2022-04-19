using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverallController : ControllerBase
    {
        private readonly DataContext _context;
        public OverallController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Student")]
        [Authorize (Roles = "Leadership")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var sum = _context.Student.Count<Student>();
            return Ok(sum);
        }
        [HttpGet("Teacher")]
        [Authorize(Roles = "Leadership")]
        public async Task<ActionResult<List<Teacher>>> GetTeacher()
        {
            var sum = _context.Teacher.Count<Teacher>();
            return Ok(sum);
        }
        [HttpGet("Class")]
        [Authorize(Roles = "Leadership")]
        public async Task<ActionResult<List<Class>>> GetClassroom()
        {
            var sum = _context.Class.Count<Class>();
            return Ok(sum);
        }
        [HttpGet("Course")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Course>>> GetCourse()
        {
            var sum = _context.Course.Count<Course>();
            return Ok(sum);
        }

        [HttpGet("Online class")]
        [Authorize(Roles = "Teacher, Student")]
        public async Task<ActionResult<List<OnlineClass>>> GetOnlineClass()
        {
            var sum = _context.OnlineClass.Count<OnlineClass>();
            return Ok(sum);
        }
        [HttpGet("Exam List")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<ExamList>>> GetExamList()
        {
            var sum = _context.ExamList.Count<ExamList>();
            return Ok(sum);
        }
        [HttpGet("Q&A Questionaire")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<QAQuestionaire>>> GetQAQquestionaire()
        {
            var sum = _context.QAQuestionaire.Count<QAQuestionaire>();
            return Ok(sum);
        }
        [HttpGet("Get Average Grade")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<List<ExamGrade>>> GetAverageGrade()
        {
            var sum = _context.ExamGrade.Count<ExamGrade>();
            return Ok(sum);
        }
    }
}
