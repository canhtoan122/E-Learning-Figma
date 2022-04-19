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
    public class SubjectController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await _context.Subject.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Subject>>> SubjectSearch(string name)
        {
            try
            {
                IQueryable<Subject> query = _context.Subject;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SubjectCode.Contains(name));
                    query = query.Where(e => e.SubjectName.Contains(name));
                    query = query.Where(e => e.SubjectType.Contains(name));
                    query = query.Where(e => e.FirstSemesterLession.Contains(name));
                    query = query.Where(e => e.SecondSemesterLession.Contains(name));
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
        public async Task<ActionResult<List<Subject>>> Add(Subject subject)
        {
            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subject>>> Update(Subject request)
        {
            var result = await _context.Subject.FindAsync(request.SubjectID);
            if (result == null)
                return BadRequest("Subject not found.");

            result.SubjectCode = request.SubjectCode;
            result.SubjectName = request.SubjectName;
            result.SubjectType = request.SubjectType;
            result.FirstSemesterLession = request.FirstSemesterLession;
            result.SecondSemesterLession = request.SecondSemesterLession;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject>>> Delete(int id)
        {
            var result = await _context.Subject.FindAsync(id);
            if (result == null)
                return BadRequest("Subject not found.");

            _context.Subject.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }
    }
}
