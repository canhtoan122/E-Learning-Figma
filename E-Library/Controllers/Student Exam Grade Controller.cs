using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_Exam_Grade_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Student_Exam_Grade_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("School Year Filter")]
        public async Task<ActionResult<IEnumerable<School_year>>> School_Year_Filter(string name)
        {
            try
            {
                IQueryable<School_year> query = _context.School_year;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.School_year_time.Contains(name));
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
        public async Task<ActionResult<IEnumerable<Department>>> Department_Filter(string name)
        {
            try
            {
                IQueryable<Department> query = _context.Department;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Department_name.Contains(name));
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
        public async Task<ActionResult<IEnumerable<Exam_Grade>>> Exam_Semester_Filter(string name)
        {
            try
            {
                IQueryable<Exam_Grade> query = _context.Exam_Grade;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Mid_term_test.Contains(name) || e.Final_test_test.Contains(name));
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
