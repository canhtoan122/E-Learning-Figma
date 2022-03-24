using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Môn_Học_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Môn_Học_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Môn_Học>>> Get()
        {
            return Ok(await _context.Môn_Học.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Môn_Học>>> Get_Môn_Học(string mon)
        {
            var result = await _context.Môn_Học.FindAsync(mon);
            if (result == null)
                return BadRequest(" Ko tìm thấy môn học");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Môn_Học>>> Add(Môn_Học mon)
        {
            _context.Môn_Học.Add(mon);
            await _context.SaveChangesAsync();

            return Ok(await _context.Môn_Học.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Môn_Học>>> Update(Môn_Học request)
        {
            var result = await _context.Môn_Học.FindAsync(request.Môn_Học_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Mã_Môn_Học = request.Mã_Môn_Học;
            result.Tên_Môn_Học = request.Tên_Môn_Học;
            result.Loại_Môn = request.Loại_Môn;
            result.Số_Tiết_HK1 = request.Số_Tiết_HK1;
            result.Số_Tiết_HK2 = request.Số_Tiết_HK2;

            await _context.SaveChangesAsync();

            return Ok(await _context.Môn_Học.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Môn_Học>>> Delete(int id)
        {
            var result = await _context.Môn_Học.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy môn học.");

            _context.Môn_Học.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Môn_Học.ToListAsync());
        }
    }
}
