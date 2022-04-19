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
    public class ClassroomSettingController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassroomSettingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassroomSetting>>> Get()
        {
            return Ok(await _context.ClassroomSetting.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ClassroomSetting>>> ClassroomSettingSearch(string name)
        {
            try
            {
                IQueryable<ClassroomSetting> query = _context.ClassroomSetting;
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
        public async Task<ActionResult<List<ClassroomSetting>>> Add(ClassroomSetting classroom)
        {
            _context.ClassroomSetting.Add(classroom);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassroomSetting.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ClassroomSetting>>> Update(ClassroomSetting request)
        {
            var result = await _context.ClassroomSetting.FindAsync(request.ClassroomSettingID);
            if (result == null)
                return BadRequest("Classroom not found.");

            result.SubjectType = request.SubjectType;
            result.Notification = request.Notification;

            await _context.SaveChangesAsync();

            return Ok(await _context.ClassroomSetting.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ClassroomSetting>>> Delete(int id)
        {
            var result = await _context.ClassroomSetting.FindAsync(id);
            if (result == null)
                return BadRequest("Classroom not found.");

            _context.ClassroomSetting.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassroomSetting.ToListAsync());
        }
    }
}
