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
    public class User_group_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public User_group_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User_group>>> Get()
        {
            return Ok(await _context.User_group.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<User_group>>> User_group_Search(string name)
        {
            try
            {
                IQueryable<User_group> query = _context.User_group;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Group_name.Contains(name));
                    query = query.Where(e => e.User_number.Contains(name));
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
        public async Task<ActionResult<List<User_group>>> Add(User_group user)
        {
            _context.User_group.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.User_group.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User_group>>> Update(User_group request)
        {
            var result = await _context.User_group.FindAsync(request.User_ID);
            if (result == null)
                return BadRequest("User not found.");

            result.Group_name = request.Group_name;
            result.Notification = request.Notification;
            result.Decentralization = request.Decentralization;
            result.Data_declaration = request.Data_declaration;
            result.Student_profile = request.Student_profile;
            result.Teacher_profile = request.Teacher_profile;
            result.Examination = request.Examination;
            result.System_update = request.System_update;

            await _context.SaveChangesAsync();

            return Ok(await _context.User_group.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User_group>>> Delete(int id)
        {
            var result = await _context.User_group.FindAsync(id);
            if (result == null)
                return BadRequest("User not found.");

            _context.User_group.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.User_group.ToListAsync());
        }
    }
}
