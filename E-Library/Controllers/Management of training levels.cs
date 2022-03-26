using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{Trình độ}")]
        public async Task<ActionResult<List<Management_of_training_levels>>> Get_Mã_Học_Viên(string level)
        {
            var result = await _context.Management_of_training_levels.FindAsync(level);
            if (result == null)
                return BadRequest("Training level not found");
            return Ok(result);
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
