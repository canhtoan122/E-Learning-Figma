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
    public class Subject_Group_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Subject_Group_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject_group>>> Get()
        {
            return Ok(await _context.Subject_group.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Subject_group>>> Subject_Group_Search(string name)
        {
            try
            {
                IQueryable<Subject_group> query = _context.Subject_group;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject_group_name.Contains(name));
                    query = query.Where(e => e.Head_of_department.Contains(name));
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

        [HttpGet("Subject List")]
        public async Task<ActionResult<List<Subject>>> Subject_List()
        {
            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Subject_group>>> Add(Subject_group subject)
        {
            _context.Subject_group.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject_group.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subject_group>>> Update(Subject_group request)
        {
            var result = await _context.Subject_group.FindAsync(request.Subject_group_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy tổ-bộ môn.");

            result.Subject_group_name = request.Subject_group_name;
            result.Head_of_department = request.Head_of_department;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subject_group.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject_group>>> Delete(int id)
        {
            var result = await _context.Subject_group.FindAsync(id);
            if (result == null)
                return BadRequest("Subject group not found.");

            _context.Subject_group.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject_group.ToListAsync());
        }
    }
}
