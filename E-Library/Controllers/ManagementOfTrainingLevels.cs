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
    public class ManagementOfTrainingLevelsController : ControllerBase
    {
        private readonly DataContext _context;

        public ManagementOfTrainingLevelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ManagementOfTrainingLevels>>> Get()
        {
            return Ok(await _context.ManagementOfTrainingLevels.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ManagementOfTrainingLevels>>> ManagementOfTrainingLevelsSearch(string name)
        {
            try
            {
                IQueryable<ManagementOfTrainingLevels> query = _context.ManagementOfTrainingLevels;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.DegreeTraining.Contains(name));
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
        public async Task<ActionResult<List<ManagementOfTrainingLevels>>> Add(ManagementOfTrainingLevels level)
        {
            _context.ManagementOfTrainingLevels.Add(level);
            await _context.SaveChangesAsync();

            return Ok(await _context.ManagementOfTrainingLevels.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ManagementOfTrainingLevels>>> Update(ManagementOfTrainingLevels request)
        {
            var result = await _context.ManagementOfTrainingLevels.FindAsync(request.ManagementOfTrainingLevelsID);
            if (result == null)
                return BadRequest("Training level not found.");

            result.DegreeTraining = request.DegreeTraining;
            result.FormOfTraining = request.FormOfTraining;
            result.TrainingTime = request.TrainingTime;
            result.Notification = request.Notification;

            await _context.SaveChangesAsync();

            return Ok(await _context.ManagementOfTrainingLevels.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ManagementOfTrainingLevels>>> Delete(int id)
        {
            var result = await _context.ManagementOfTrainingLevels.FindAsync(id);
            if (result == null)
                return BadRequest("Training level not found.");

            _context.ManagementOfTrainingLevels.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.ManagementOfTrainingLevels.ToListAsync());
        }
    }
}
