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
    [Authorize(Roles = "Student")]
    public class StudentClassController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentClassController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Class>>> ClassSearch(string name)
        {
            try
            {
                IQueryable<Class> query = _context.Class;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.ClassName.Contains(name));
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
        [HttpGet("Class date filter")]
        public async Task<ActionResult<IEnumerable<Class>>> ClassDateFilter(string name)
        {
            try
            {
                IQueryable<Class> query = _context.Class;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.ClassDate.Contains(name));
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
    }
}
