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
    public class UserListController : ControllerBase
    {
        private readonly DataContext _context;

        public UserListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserList>>> Get()
        {
            return Ok(await _context.UserList.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserList>>> UserListSearch(string name)
        {
            try
            {
                IQueryable<UserList> query = _context.UserList;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Username.Contains(name));
                    query = query.Where(e => e.Email.Contains(name));
                    query = query.Where(e => e.UserGroup.Contains(name));
                    query = query.Where(e => e.Status.Contains(name));
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
        public async Task<ActionResult<List<UserList>>> Add(UserList nguoi_dung)
        {
            _context.UserList.Add(nguoi_dung);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserList.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserList>>> Update(UserList request)
        {
            var result = await _context.UserList.FindAsync(request.UserListID);
            if (result == null)
                return BadRequest("User not found.");

            result.Username = request.Username;
            result.Email = request.Email;
            result.UserGroup = request.UserGroup;

            await _context.SaveChangesAsync();

            return Ok(await _context.UserList.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserList>>> Delete(int id)
        {
            var result = await _context.UserList.FindAsync(id);
            if (result == null)
                return BadRequest("User not found.");

            _context.UserList.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(await _context.UserList.ToListAsync());
        }
    }
}
