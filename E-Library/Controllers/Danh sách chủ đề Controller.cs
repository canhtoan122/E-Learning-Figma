using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Danh_sách_chủ_đề_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Danh_sách_chủ_đề_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Danh_Sách_Chủ_Đề>>> Get()
        {
            return Ok(await _context.Danh_Sách_Chủ_Đề.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Danh_Sách_Chủ_Đề>>> Add(Danh_Sách_Chủ_Đề chu_de)
        {
            _context.Danh_Sách_Chủ_Đề.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_Sách_Chủ_Đề.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Danh_Sách_Chủ_Đề>>> Update(Danh_Sách_Chủ_Đề request)
        {
            var result = await _context.Danh_Sách_Chủ_Đề.FindAsync(request.Chủ_Đề_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy chủ đề.");
            
            //result.Giáo_viên = request.Giáo_viên;
            //result.Lớp_học = request.Lớp_học;
            //result.Môn_học = request.Môn_học;
            result.Chủ_Đề = request.Chủ_Đề;
            result.Miêu_tả = request.Miêu_tả;
            result.Ngày_Kết_Thúc = request.Ngày_Kết_Thúc;

            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_Sách_Chủ_Đề.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Danh_Sách_Chủ_Đề>>> Delete(int id)
        {
            var result = await _context.Danh_Sách_Chủ_Đề.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy chủ đề.");

            _context.Danh_Sách_Chủ_Đề.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_Sách_Chủ_Đề.ToListAsync());
        }
    }
}
