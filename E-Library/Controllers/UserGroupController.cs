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
    public class UserGroup_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public UserGroup_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserGroup>>> Get()
        {
            return Ok(await _context.UserGroup.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserGroup>>> User_group_Search(string name)
        {
            try
            {
                IQueryable<UserGroup> query = _context.UserGroup;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.GroupName.Contains(name));
                    query = query.Where(e => e.UserNumber.Contains(name));
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
        public async Task<ActionResult<List<UserGroup>>> Add(UserGroup user)
        {
            _context.UserGroup.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserGroup.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserGroup>>> Update(UserGroup request)
        {
            var result = await _context.UserGroup.FindAsync(request.UserID);
            if (result == null)
                return BadRequest("User not found.");

            result.GroupName = request.GroupName;
            result.Notification = request.Notification;
            result.Decentralization = request.Decentralization;
            result.DataDeclaration = request.DataDeclaration;
            result.StudentProfile = request.StudentProfile;
            result.TeacherProfile = request.TeacherProfile;
            result.Examination = request.Examination;
            result.SystemUpdate = request.SystemUpdate;

            await _context.SaveChangesAsync();

            return Ok(await _context.UserGroup.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserGroup>>> Delete(int id)
        {
            var result = await _context.UserGroup.FindAsync(id);
            if (result == null)
                return BadRequest("User not found.");

            _context.UserGroup.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserGroup.ToListAsync());
        }
    }
}
