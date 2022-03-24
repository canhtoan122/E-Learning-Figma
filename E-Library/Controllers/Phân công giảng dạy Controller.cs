using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Phân_công_giảng_dạy_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Phân_công_giảng_dạy_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Phân_Công_Giảng_Dạy>>> Get()
        {
            return Ok(await _context.Phân_Công_Giảng_Dạy.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Phân_Công_Giảng_Dạy>>> Add(Phân_Công_Giảng_Dạy giang_day)
        {
            _context.Phân_Công_Giảng_Dạy.Add(giang_day);
            await _context.SaveChangesAsync();

            return Ok(await _context.Khoa_Khối.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Phân_Công_Giảng_Dạy>>> Update(Phân_Công_Giảng_Dạy request, Giảng_Viên giang_vien, Môn_Học mon_hoc)
        {
            var result = await _context.Phân_Công_Giảng_Dạy.FindAsync(request.Phân_Công_Giảng_Dạy_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            //result.Giảng_Viên = giang_vien.Họ_và_Tên;
            //result.Môn_Học = mon_hoc.Tên_Môn_Học;
            result.Lớp_học = request.Lớp_học;
            result.Ngày_bắt_đầu = request.Ngày_bắt_đầu;
            result.Ngày_kết_thúc = request.Ngày_kết_thúc;
            result.Mô_tả = request.Mô_tả;

            await _context.SaveChangesAsync();

            return Ok(await _context.Phân_Công_Giảng_Dạy.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Phân_Công_Giảng_Dạy>>> Delete(int id)
        {
            var result = await _context.Phân_Công_Giảng_Dạy.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy Giáo viên.");

            _context.Phân_Công_Giảng_Dạy.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Phân_Công_Giảng_Dạy.ToListAsync());
        }
    }
}
