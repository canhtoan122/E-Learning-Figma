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
    [Authorize(Roles = "Leadership")]
    public class GradeController : ControllerBase
    {
        private readonly DataContext _context;

        public GradeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grade>>> Get()
        {
            return Ok(await _context.Grade.ToListAsync());
        }
        [HttpGet("Department code")]
        public async Task<ActionResult<List<Grade>>> GetGrade(string diem)
        {
            var result = await _context.Grade.FindAsync(diem);
            if (result == null)
                return BadRequest("Grade not found.");
            return Ok(result);
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Grade>>> GradeSearch(string name)
        {
            try
            {
                IQueryable<Grade> query = _context.Grade;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.GradeName.Contains(name));
                    query = query.Where(e => e.ScoreFactor.Contains(name));
                    query = query.Where(e => e.MinimumNumberOfColumnsForSemester1.Contains(name));
                    query = query.Where(e => e.MinimumNumberOfColumnsForSemester2.Contains(name));
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

        [HttpPost]
        public async Task<ActionResult<List<Grade>>> Add(Grade grade)
        {
            _context.Grade.Add(grade);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Grade>>> Update(Grade request)
        {
            var result = await _context.Grade.FindAsync(request.GradeID);
            if (result == null)
                return BadRequest("Grade not found.");

            result.GradeName = request.GradeName;
            result.ScoreFactor = request.ScoreFactor;
            result.MinimumNumberOfColumnsForSemester1 = request.MinimumNumberOfColumnsForSemester1;
            result.MinimumNumberOfColumnsForSemester2 = request.MinimumNumberOfColumnsForSemester2;

            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Grade>>> Delete(int id)
        {
            var result = await _context.Grade.FindAsync(id);
            if (result == null)
                return BadRequest("Grade not found.");

            _context.Grade.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }
    }
}
