using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lớp_Học_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Lớp_Học_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lớp_học>>> Get()
        {
            return Ok(await _context.Lớp_học.ToListAsync());
        }
        [HttpGet("{Mã Lớp}")]
        public async Task<ActionResult<List<Lớp_học>>> Get_Môn_Học(string lop)
        {
            var result = await _context.Lớp_học.FindAsync(lop);
            if (result == null)
                return BadRequest(" Ko tìm thấy lớp học");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Lớp_học>>> Add(Lớp_học lop)
        {
            _context.Lớp_học.Add(lop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lớp_học.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Lớp_học>>> Update(Lớp_học request)
        {
            var result = await _context.Lớp_học.FindAsync(request.Lớp_Học_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Mã_Lớp = request.Mã_Lớp;
            result.Tên_Lớp = request.Tên_Lớp;
            result.Giáo_Viên_Chủ_Nhiệm = request.Giáo_Viên_Chủ_Nhiệm;
            result.Số_Lượng_Học_Viên = request.Số_Lượng_Học_Viên;
            result.Phân_Loại_Lớp = request.Phân_Loại_Lớp;
            result.Mô_Tả = request.Mô_Tả;

            await _context.SaveChangesAsync();

            return Ok(await _context.Lớp_học.ToListAsync());
        }

        [HttpDelete("{Mã Lớp}")]
        public async Task<ActionResult<List<Lớp_học>>> Delete(string lop)
        {
            var result = await _context.Lớp_học.FindAsync(lop);
            if (result == null)
                return BadRequest("Ko tìm thấy môn học.");

            _context.Lớp_học.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lớp_học.ToListAsync());
        }
    }
}
