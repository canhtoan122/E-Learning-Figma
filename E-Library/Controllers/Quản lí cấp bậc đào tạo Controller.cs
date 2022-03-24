using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Quản_lí_cấp_bậc_đào_tạo_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Quản_lí_cấp_bậc_đào_tạo_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Quản_lí_các_bậc_đào_tạo>>> Get()
        {
            return Ok(await _context.Nhóm_người_dùng.ToListAsync());
        }

        [HttpGet("{Trình độ}")]
        public async Task<ActionResult<List<Quản_lí_các_bậc_đào_tạo>>> Get_Mã_Học_Viên(string trinh_do)
        {
            var result = await _context.Quản_lí_các_bậc_đào_tạo.FindAsync(trinh_do);
            if (result == null)
                return BadRequest(" Ko tìm thấy trình độ");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Quản_lí_các_bậc_đào_tạo>>> Add(Quản_lí_các_bậc_đào_tạo bac_dao_tao)
        {
            _context.Quản_lí_các_bậc_đào_tạo.Add(bac_dao_tao);
            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_các_bậc_đào_tạo.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Quản_lí_các_bậc_đào_tạo>>> Update(Quản_lí_các_bậc_đào_tạo request)
        {
            var result = await _context.Quản_lí_các_bậc_đào_tạo.FindAsync(request.Quản_lí_các_bậc_đào_tạo_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy bậc đào tạo.");

            result.Trình_độ_đào_tạo = request.Trình_độ_đào_tạo;
            result.Hình_thức_đào_tạo = request.Hình_thức_đào_tạo;
            result.Thời_gian_đào_tạo = request.Thời_gian_đào_tạo;
            result.Ghi_chú = request.Ghi_chú;

            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_các_bậc_đào_tạo.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Quản_lí_các_bậc_đào_tạo>>> Delete(int id)
        {
            var result = await _context.Quản_lí_các_bậc_đào_tạo.FindAsync(id);
            if (result == null)
                return BadRequest("Ko tìm thấy bậc đào tạo.");

            _context.Quản_lí_các_bậc_đào_tạo.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Quản_lí_các_bậc_đào_tạo.ToListAsync());
        }
    }
}
