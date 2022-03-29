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
    public class Management_of_training_levels_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Management_of_training_levels_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Management_of_training_levels>>> Get()
        {
            return Ok(await _context.Management_of_training_levels.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Management_of_training_levels>>> Management_of_training_levels_Search(string name)
        {
            try
            {
                IQueryable<Management_of_training_levels> query = _context.Management_of_training_levels;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Degree_training.Contains(name));
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
        public async Task<ActionResult<List<Management_of_training_levels>>> Add(Management_of_training_levels level)
        {
            _context.Management_of_training_levels.Add(level);
            await _context.SaveChangesAsync();

            return Ok(await _context.Management_of_training_levels.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Management_of_training_levels>>> Update(Management_of_training_levels request)
        {
            var result = await _context.Management_of_training_levels.FindAsync(request.Management_of_training_levels_ID);
            if (result == null)
                return BadRequest("Training level not found.");

            result.Degree_training = request.Degree_training;
            result.Form_of_training = request.Form_of_training;
            result.Training_time = request.Training_time;
            result.Notification = request.Notification;

            await _context.SaveChangesAsync();

            return Ok(await _context.Management_of_training_levels.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Management_of_training_levels>>> Delete(int id)
        {
            var result = await _context.Management_of_training_levels.FindAsync(id);
            if (result == null)
                return BadRequest("Training level not found.");

            _context.Management_of_training_levels.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Management_of_training_levels.ToListAsync());
        }
    }
}
