using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_Exam_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Student_Exam_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exam>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Exam>>> Exam_Search(string name)
        {
            try
            {
                IQueryable<Exam> query = _context.Exam;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Exam_topic.Contains(name));
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
        [HttpGet("Subject group Filter")]
        public async Task<ActionResult<IEnumerable<Subject_group>>> Subject_group_Filter(string name)
        {
            try
            {
                IQueryable<Subject_group> query = _context.Subject_group;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject_group_name.Contains(name));
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
        [HttpGet("Subject filter")]
        public async Task<ActionResult<IEnumerable<Subject>>> Subject_Filter(string name)
        {
            try
            {
                IQueryable<Subject> query = _context.Subject;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject_name.Contains(name));
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
        [HttpGet("Exam date filter")]
        public async Task<ActionResult<IEnumerable<Exam>>> Exam_date_Filter(string name)
        {
            try
            {
                IQueryable<Exam> query = _context.Exam;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Exam_time.Contains(name));
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
