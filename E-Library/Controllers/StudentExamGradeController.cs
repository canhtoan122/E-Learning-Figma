using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamGradeController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentExamGradeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("School Year Filter")]
        public async Task<ActionResult<IEnumerable<SchoolYear>>> SchoolYearFilter(string name)
        {
            try
            {
                IQueryable<SchoolYear> query = _context.SchoolYear;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SchoolYearTime.Contains(name));
                }
                if (query.Any())
                {
                    return Ok(query);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
        [HttpGet("Department Filter")]
        public async Task<ActionResult<IEnumerable<Department>>> DepartmentFilter(string name)
        {
            try
            {
                IQueryable<Department> query = _context.Department;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.DepartmentName.Contains(name));
                }
                if (query.Any())
                {
                    return Ok(query);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
        [HttpGet("Exam Semester Filter")]
        public async Task<ActionResult<IEnumerable<ExamGrade>>> ExamSemesterFilter(string name)
        {
            try
            {
                IQueryable<ExamGrade> query = _context.ExamGrade;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.MidTermTest.Contains(name) || e.FinalTestTest.Contains(name));
                }
                if (query.Any())
                {
                    return Ok(query);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
    }
}
