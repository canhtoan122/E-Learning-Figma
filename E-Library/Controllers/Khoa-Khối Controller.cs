using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Khoa_Khối_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Khoa_Khối_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Khoa_Khối>>> Get()
        {
            return Ok(await _context.Khoa_Khối.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Khoa_Khối>>> Get_Khoa_Khối(string khoa)
        {
            var result = await _context.Khoa_Khối.FindAsync(khoa);
            if (result == null)
                return BadRequest(" Ko tìm thấy Khoa Khối");
            return Ok(result);
        }
        [HttpGet("{Danh sách lớp học}")]
        public async Task<ActionResult<List<Lớp_học>>> Get_Danh_sách_Lớp_Học()
        {
            return Ok(await _context.Lớp_học.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Khoa_Khối>>> Add(Khoa_Khối khoa)
        {
            _context.Khoa_Khối.Add(khoa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Khoa_Khối.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Khoa_Khối>>> Update(Khoa_Khối request)
        {
            var result = await _context.Khoa_Khối.FindAsync(request.Khoa_Khối_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Mã_Khoa_Khối = request.Mã_Khoa_Khối;
            result.Tên_Khoa_Khối = request.Tên_Khoa_Khối;
            result.Trưởng_Khoa_Khối = request.Trưởng_Khoa_Khối;

            await _context.SaveChangesAsync();

            return Ok(await _context.Niên_Khoá.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Khoa_Khối>>> Delete(int id)
        {
            var result = await _context.Khoa_Khối.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            _context.Khoa_Khối.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Khoa_Khối.ToListAsync());
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
