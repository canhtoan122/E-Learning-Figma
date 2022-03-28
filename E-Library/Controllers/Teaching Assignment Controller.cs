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
    public class Teaching_Assignment_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Teaching_Assignment_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teaching_Assignment>>> Get()
        {
            return Ok(await _context.Teaching_Assignment.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Teaching_Assignment>>> Add(Teaching_Assignment teaching)
        {
            _context.Teaching_Assignment.Add(teaching);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teaching_Assignment.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Teaching_Assignment>>> Update(Teaching_Assignment request)
        {
            var result = await _context.Teaching_Assignment.FindAsync(request.Teaching_Assignment_ID);
            if (result == null)
                return BadRequest("Assignment not found.");

            //result.Giảng_Viên = giang_vien.Họ_và_Tên;
            //result.Môn_Học = mon_hoc.Tên_Môn_Học;
            result.Classroom = request.Classroom;
            result.Starting_date = request.Starting_date;
            result.Ending_date = request.Ending_date;
            result.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Teaching_Assignment.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teaching_Assignment>>> Delete(int id)
        {
            var result = await _context.Teaching_Assignment.FindAsync(id);
            if (result == null)
                return BadRequest("Assignment not found.");

            _context.Teaching_Assignment.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teaching_Assignment.ToListAsync());
        }
    }
}
