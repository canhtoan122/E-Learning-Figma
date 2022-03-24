using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Thiết_lập_lớp_học_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Thiết_lập_lớp_học_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Thiết_lập_lớp_học>>> Get()
        {
            return Ok(await _context.Thiết_lập_lớp_học.ToListAsync());
        }

        [HttpGet("{Loại lớp}")]
        public async Task<ActionResult<List<Thiết_lập_lớp_học>>> Get_Loại_Lớp(string lop)
        {
            var result = await _context.Thiết_lập_lớp_học.FindAsync(lop);
            if (result == null)
                return BadRequest(" Ko tìm thấy lớp học");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Thiết_lập_lớp_học>>> Add(Thiết_lập_lớp_học mon_hoc)
        {
            _context.Thiết_lập_lớp_học.Add(mon_hoc);
            await _context.SaveChangesAsync();

            return Ok(await _context.Thiết_lập_lớp_học.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Thiết_lập_lớp_học>>> Update(Thiết_lập_lớp_học request)
        {
            var result = await _context.Thiết_lập_lớp_học.FindAsync(request.Thiết_lập_lớp_học_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy lớp học.");

            result.Loại_môn_học = request.Loại_môn_học;
            result.Ghi_chú = request.Ghi_chú;

            await _context.SaveChangesAsync();

            return Ok(await _context.Thiết_lập_lớp_học.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Thiết_lập_lớp_học>>> Delete(int id)
        {
            var result = await _context.Thiết_lập_lớp_học.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy lớp học.");

            _context.Thiết_lập_lớp_học.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Thiết_lập_lớp_học.ToListAsync());
        }
    }
}
