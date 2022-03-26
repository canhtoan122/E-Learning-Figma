using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_list_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public User_list_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User_list>>> Get()
        {
            return Ok(await _context.User_list.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<User_list>>> Add(User_list nguoi_dung)
        {
            _context.User_list.Add(nguoi_dung);
            await _context.SaveChangesAsync();

            return Ok(await _context.User_list.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User_list>>> Update(User_list request)
        {
            var result = await _context.User_list.FindAsync(request.User_list_ID);
            if (result == null)
                return BadRequest("User not found.");

            result.Username = request.Username;
            result.Email = request.Email;
            result.User_group = request.User_group;

            await _context.SaveChangesAsync();

            return Ok(await _context.User_list.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User_list>>> Delete(int id)
        {
            var result = await _context.User_list.FindAsync(id);
            if (result == null)
                return BadRequest("User not found.");

            _context.User_list.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(await _context.User_list.ToListAsync());
        }
    }
}
