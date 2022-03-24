using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Thông_tin_trường_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Thông_tin_trường_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Thông_tin_trường>>> Get()
        {
            return Ok(await _context.Thông_tin_trường.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Thông_tin_trường>>> Add(Thông_tin_trường truong)
        {
            _context.Thông_tin_trường.Add(truong);
            await _context.SaveChangesAsync();

            return Ok(await _context.Thông_tin_trường.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Thông_tin_trường>>> Update(Thông_tin_trường request)
        {
            var result = await _context.Thông_tin_trường.FindAsync(request.Thông_tin_trường_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy thông tin trường.");

            result.Tên_trường = request.Tên_trường;
            result.Mã_chuẩn = request.Mã_chuẩn;
            result.Tỉnh_Thành_phố = request.Tỉnh_Thành_phố;
            result.Xã_Phường = request.Xã_Phường;
            result.Quận_Huyện = request.Quận_Huyện;
            result.Trụ_sở_chính = request.Trụ_sở_chính;
            result.Loại_trường = request.Loại_trường;
            result.Số_điện_thoại = request.Số_điện_thoại;
            result.Fax = request.Fax;
            result.Email = request.Email;
            result.Ngày_thành_lập = request.Ngày_thành_lập;
            result.Mô_hình_thành_lập = request.Mô_hình_thành_lập;
            result.Website = request.Website;
            result.Hiệu_trưởng = request.Hiệu_trưởng;
            result.SĐT_Hiệu_Trưởng = request.SĐT_Hiệu_Trưởng;
            result.Tên_cơ_sở = request.Tên_cơ_sở;
            result.Địa_chỉ = request.Địa_chỉ;
            result.SĐT_Trường = request.SĐT_Trường;
            result.Người_Phụ_Trách = request.Người_Phụ_Trách;
            result.Di_Động = request.Di_Động;

            await _context.SaveChangesAsync();

            return Ok(await _context.Thông_tin_trường.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Thông_tin_trường>>> Delete(int id)
        {
            var result = await _context.Thông_tin_trường.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy thông tin trường.");

            _context.Thông_tin_trường.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Thông_tin_trường.ToListAsync());
        }
    }
}
