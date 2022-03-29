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
    public class Subject_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Subject_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await _context.Subject.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Subject>>> Subject_Search(string name)
        {
            try
            {
                IQueryable<Subject> query = _context.Subject;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject_code.Contains(name));
                    query = query.Where(e => e.Subject_name.Contains(name));
                    query = query.Where(e => e.Subject_type.Contains(name));
                    query = query.Where(e => e.First_semester_lession.Contains(name));
                    query = query.Where(e => e.Second_semester_lession.Contains(name));
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
            var result = await _context.Subject.FindAsync(request.Subject_ID);
            if (result == null)
                return BadRequest("Subject not found.");

            result.Subject_code = request.Subject_code;
            result.Subject_name = request.Subject_name;
            result.Subject_type = request.Subject_type;
            result.First_semester_lession = request.First_semester_lession;
            result.Second_semester_lession = request.Second_semester_lession;

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
