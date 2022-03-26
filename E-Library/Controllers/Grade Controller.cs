using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Grade_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Grade_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grade>>> Get()
        {
            return Ok(await _context.Grade.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Grade>>> Get_Loại_Điểm(string diem)
        {
            var result = await _context.Grade.FindAsync(diem);
            if (result == null)
                return BadRequest("Grade not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Grade>>> Add(Grade diem)
        {
            _context.Grade.Add(diem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Grade>>> Update(Grade request)
        {
            var result = await _context.Grade.FindAsync(request.Grade_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Grade_name = request.Grade_name;
            result.Score_factor = request.Score_factor;
            result.Minimum_number_of_columns_for_semester_1 = request.Minimum_number_of_columns_for_semester_1;
            result.Minimum_number_of_columns_for_semester_2 = request.Minimum_number_of_columns_for_semester_2;

            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Grade>>> Delete(int id)
        {
            var result = await _context.Grade.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy môn học.");

            _context.Grade.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grade.ToListAsync());
        }
    }
}
