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
    public class Overall_Controller : ControllerBase
    {
        private readonly DataContext _context;
        public Overall_Controller(DataContext context)
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
        public async Task<ActionResult<List<Teacher>>> Get_Teacher()
        {
            var sum = _context.Teacher.Count<Teacher>();
            return Ok(sum);
        }
        [HttpGet("Class")]
        [Authorize(Roles = "Leadership")]
        public async Task<ActionResult<List<Class>>> Get_Classroom()
        {
            var sum = _context.Class.Count<Class>();
            return Ok(sum);
        }
        [HttpGet("Course")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Course>>> Get_Course()
        {
            var sum = _context.Course.Count<Course>();
            return Ok(sum);
        }

        [HttpGet("Online class")]
        [Authorize(Roles = "Teacher, Student")]
        public async Task<ActionResult<List<Online_class>>> Get_Online_class()
        {
            var sum = _context.Online_class.Count<Online_class>();
            return Ok(sum);
        }
        [HttpGet("Exam List")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<ExamList>>> Get_Exam_List()
        {
            var sum = _context.Exam_List.Count<ExamList>();
            return Ok(sum);
        }
        [HttpGet("Q&A Questionaire")]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Q_A_questionaire>>> Get_Q_A_questionaire()
        {
            var sum = _context.Q_A_questionaire.Count<Q_A_questionaire>();
            return Ok(sum);
        }
        [HttpGet("Get Average Grade")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<List<Exam_Grade>>> Get_Average_Grade()
        {
            var sum = _context.Exam_Grade.Count<Exam_Grade>();
            return Ok(sum);
        }
    }
}
