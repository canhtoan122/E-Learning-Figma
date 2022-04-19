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
    public class SchoolYearController : ControllerBase
    {
        private readonly DataContext _context;

        public SchoolYearController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SchoolYear>>> Get()
        {
            return Ok(await _context.SchoolYear.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SchoolYear>>> SchoolYearSearch(string name)
        {
            try
            {
                IQueryable<SchoolYear> query = _context.SchoolYear;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Serial.Contains(name));
                    query = query.Where(e => e.SchoolYearTime.Contains(name));
                    query = query.Where(e => e.SemesterStartDate.Contains(name));
                    query = query.Where(e => e.SemesterEndDate.Contains(name));
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
        public async Task<ActionResult<List<SchoolYear>>> Add(SchoolYear year)
        {
            _context.SchoolYear.Add(year);
            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolYear.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SchoolYear>>> Update(SchoolYear request)
        {
            var result = await _context.SchoolYear.FindAsync(request.SchoolYearID);
            if (result == null)
                return BadRequest("School year not found.");

            result.SchoolYearTime = request.SchoolYearTime;
            result.StartingDate = request.StartingDate;
            result.EndingDate = request.EndingDate;
            result.SemesterName = request.SemesterName;
            result.SemesterStartDate = request.SemesterStartDate;
            result.SemesterEndDate = request.SemesterEndDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolYear.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SchoolYear>>> Delete(int id)
        {
            var result = await _context.SchoolYear.FindAsync(id);
            if (result == null)
                return BadRequest("School year not found.");

            _context.SchoolYear.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolYear.ToListAsync());
        }
    }
}
