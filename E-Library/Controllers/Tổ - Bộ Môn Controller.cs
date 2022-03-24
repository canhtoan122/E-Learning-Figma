using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tổ___Bộ_Môn_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Tổ___Bộ_Môn_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tổ_Bộ_Môn>>> Get()
        {
            return Ok(await _context.Tổ_Bộ_Môn.ToListAsync());
        }

        [HttpGet("Danh sách Môn học")]
        public async Task<ActionResult<List<Môn_Học>>> Danh_sách_môn_học()
        {
            return Ok(await _context.Môn_Học.ToListAsync());
        }
        [HttpGet("Tìm Tổ bộ môn")]
        public async Task<ActionResult<List<Môn_Học>>> Search_Tổ_Bộ_Môn(string name)
        {
            var result = await _context.Môn_Học.FindAsync(name);
            if (result == null)
                return BadRequest("Ko tìm thấy bộ môn");
            return Ok(await _context.Môn_Học.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Tổ_Bộ_Môn>>> Add(Tổ_Bộ_Môn mon)
        {
            _context.Tổ_Bộ_Môn.Add(mon);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tổ_Bộ_Môn.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Tổ_Bộ_Môn>>> Update(Tổ_Bộ_Môn request)
        {
            var result = await _context.Tổ_Bộ_Môn.FindAsync(request.Tổ_Bộ_Môn_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy tổ-bộ môn.");

            result.Tên_Tổ_Bộ_Môn = request.Tên_Tổ_Bộ_Môn;
            result.Trưởng_Bộ_môn = request.Trưởng_Bộ_môn;

            await _context.SaveChangesAsync();

            return Ok(await _context.Tổ_Bộ_Môn.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tổ_Bộ_Môn>>> Delete(int id)
        {
            var result = await _context.Tổ_Bộ_Môn.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy tổ-bộ môn.");

            _context.Tổ_Bộ_Môn.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tổ_Bộ_Môn.ToListAsync());
        }

        [HttpDelete("{Xoá Lớp Học}")]
        public async Task<ActionResult<List<Lớp_học>>> Xoá_Lớp_Học(bool lop)
        {
            var result = await _context.Tổ_Bộ_Môn.FindAsync(lop);
            if (result != null)
            {
                _context.Tổ_Bộ_Môn.Remove(result);
            }
            await _context.SaveChangesAsync();

            return Ok(await _context.Lớp_học.ToListAsync());
        }
    }
}
