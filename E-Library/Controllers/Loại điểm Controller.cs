using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loại_điểm_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Loại_điểm_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Loại_Điểm>>> Get()
        {
            return Ok(await _context.Loại_Điểm.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Loại_Điểm>>> Get_Loại_Điểm(string diem)
        {
            var result = await _context.Loại_Điểm.FindAsync(diem);
            if (result == null)
                return BadRequest(" Ko tìm thấy điểm");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Loại_Điểm>>> Add(Loại_Điểm diem)
        {
            _context.Loại_Điểm.Add(diem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Loại_Điểm.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Loại_Điểm>>> Update(Loại_Điểm request)
        {
            var result = await _context.Loại_Điểm.FindAsync(request.Loại_Điểm_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Loại_Điểm_name = request.Loại_Điểm_name;
            result.Hệ_Số = request.Hệ_Số;
            result.Số_cột_điểm_tối_thiểu_học_kì_1 = request.Số_cột_điểm_tối_thiểu_học_kì_1;
            result.Số_cột_điểm_tối_thiểu_học_kì_2 = request.Số_cột_điểm_tối_thiểu_học_kì_2;

            await _context.SaveChangesAsync();

            return Ok(await _context.Loại_Điểm.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Loại_Điểm>>> Delete(int id)
        {
            var result = await _context.Loại_Điểm.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy môn học.");

            _context.Loại_Điểm.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Loại_Điểm.ToListAsync());
        }
    }
}
