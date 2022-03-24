using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Quản_lí_lịch_thi_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Quản_lí_lịch_thi_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Quản_lí_lịch_thi>>> Get()
        {
            return Ok(await _context.Quản_lí_lịch_thi.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Quản_lí_lịch_thi>>> Add(Quản_lí_lịch_thi chu_de)
        {
            _context.Quản_lí_lịch_thi.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_lịch_thi.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Quản_lí_lịch_thi>>> Update(Quản_lí_lịch_thi request)
        {
            var result = await _context.Quản_lí_lịch_thi.FindAsync(request.Quản_lí_lịch_thi_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy lịch thi.");

            result.Học_kì = request.Học_kì;
            result.Ngày_Làm_Bài = request.Ngày_Làm_Bài;
            result.Khoa_Khối = request.Khoa_Khối;
            result.Môn_Thi = request.Môn_Thi;
            result.Tên_Kì_Thi = request.Tên_Kì_Thi;
            result.Tình_Trạng = request.Tình_Trạng;
            result.Phân_công_chấm_thi = request.Phân_công_chấm_thi;

            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_lịch_thi.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Quản_lí_lịch_thi>>> Delete(int id)
        {
            var result = await _context.Quản_lí_lịch_thi.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy lịch thi.");

            _context.Quản_lí_lịch_thi.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_lịch_thi.ToListAsync());
        }
    }
}
