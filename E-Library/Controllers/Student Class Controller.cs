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
    public class Student_Class_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Student_Class_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Class>>> Class_Search(string name)
        {
            try
            {
                IQueryable<Class> query = _context.Class;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Class_name.Contains(name));
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
        [HttpGet("Class date filter")]
        public async Task<ActionResult<IEnumerable<Class>>> Class_date_Filter(string name)
        {
            try
            {
                IQueryable<Class> query = _context.Class;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Class_date.Contains(name));
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
    }
}
