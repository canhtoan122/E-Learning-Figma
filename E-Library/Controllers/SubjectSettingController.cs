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
    public class SubjectSettingController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectSettingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectSetting>>> Get()
        {
            return Ok(await _context.SubjectSetting.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SubjectSetting>>> SubjectSettingSearch(string name)
        {
            try
            {
                IQueryable<SubjectSetting> query = _context.SubjectSetting;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SubjectType.Contains(name));
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
        public async Task<ActionResult<List<SubjectSetting>>> Add(SubjectSetting subject)
        {
            _context.SubjectSetting.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectSetting.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SubjectSetting>>> Update(SubjectSetting request)
        {
            var result = await _context.SubjectSetting.FindAsync(request.SubjectSettingID);
            if (result == null)
                return BadRequest("Subject not found.");

            result.SubjectType = request.SubjectType;
            result.Notification = request.Notification;

            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectSetting.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SubjectSetting>>> Delete(int id)
        {
            var result = await _context.SubjectSetting.FindAsync(id);
            if (result == null)
                return BadRequest("Subject not found.");

            _context.SubjectSetting.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectSetting.ToListAsync());
        }
    }
}
