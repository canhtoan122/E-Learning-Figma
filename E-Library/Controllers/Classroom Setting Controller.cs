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
    public class Classroom_Setting_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Classroom_Setting_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Classroom_setting>>> Get()
        {
            return Ok(await _context.Classroom_setting.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Classroom_setting>>> Classroom_setting_Search(string name)
        {
            try
            {
                IQueryable<Classroom_setting> query = _context.Classroom_setting;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject_type.Contains(name));
                    query = query.Where(e => e.Status.Contains(name));
                    query = query.Where(e => e.Notification.Contains(name));
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
        public async Task<ActionResult<List<Classroom_setting>>> Add(Classroom_setting classroom)
        {
            _context.Classroom_setting.Add(classroom);
            await _context.SaveChangesAsync();

            return Ok(await _context.Classroom_setting.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Classroom_setting>>> Update(Classroom_setting request)
        {
            var result = await _context.Classroom_setting.FindAsync(request.Classroom_setting_ID);
            if (result == null)
                return BadRequest("Classroom not found.");

            result.Subject_type = request.Subject_type;
            result.Notification = request.Notification;

            await _context.SaveChangesAsync();

            return Ok(await _context.Classroom_setting.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Classroom_setting>>> Delete(int id)
        {
            var result = await _context.Classroom_setting.FindAsync(id);
            if (result == null)
                return BadRequest("Classroom not found.");

            _context.Classroom_setting.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Classroom_setting.ToListAsync());
        }
    }
}
