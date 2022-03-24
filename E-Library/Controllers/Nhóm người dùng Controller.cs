using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nhóm_người_dùng_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Nhóm_người_dùng_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Nhóm_người_dùng>>> Get()
        {
            return Ok(await _context.Nhóm_người_dùng.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Nhóm_người_dùng>>> Add(Nhóm_người_dùng nguoi_dung)
        {
            _context.Nhóm_người_dùng.Add(nguoi_dung);
            await _context.SaveChangesAsync();

            return Ok(await _context.Nhóm_người_dùng.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Nhóm_người_dùng>>> Update(Nhóm_người_dùng request)
        {
            var result = await _context.Nhóm_người_dùng.FindAsync(request.Người_dùng_hệ_thống_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy nhóm người dùng.");

            result.Tên_Nhóm = request.Tên_Nhóm;
            result.Ghi_chú = request.Ghi_chú;
            result.Phân_quyền = request.Phân_quyền;
            result.Khai_báo_dữ_liệu = request.Khai_báo_dữ_liệu;
            result.Hồ_sơ_học_viên = request.Hồ_sơ_học_viên;
            result.Hồ_sơ_giảng_viên = request.Hồ_sơ_giảng_viên;
            result.Thi_cử = request.Thi_cử;
            result.Cập_nhật_hệ_thống = request.Cập_nhật_hệ_thống;

            await _context.SaveChangesAsync();

            return Ok(await _context.Nhóm_người_dùng.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Nhóm_người_dùng>>> Delete(int id)
        {
            var result = await _context.Nhóm_người_dùng.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy người dùng.");

            _context.Nhóm_người_dùng.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Nhóm_người_dùng.ToListAsync());
        }
    }
}
