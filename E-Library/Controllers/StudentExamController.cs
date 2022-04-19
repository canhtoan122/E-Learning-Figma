using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentExamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exam>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Exam>>> ExamSearch(string name)
        {
            try
            {
                IQueryable<Exam> query = _context.Exam;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.ExamTopic.Contains(name));
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
        public async Task<ActionResult<IEnumerable<SubjectGroup>>> SubjectGroupFilter(string name)
        {
            try
            {
                IQueryable<SubjectGroup> query = _context.SubjectGroup;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SubjectGroupName.Contains(name));
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
        public async Task<ActionResult<IEnumerable<Subject>>> SubjectFilter(string name)
        {
            try
            {
                IQueryable<Subject> query = _context.Subject;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SubjectName.Contains(name));
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
        public async Task<ActionResult<IEnumerable<Exam>>> ExamDateFilter(string name)
        {
            try
            {
                IQueryable<Exam> query = _context.Exam;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.ExamTime.Contains(name));
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
