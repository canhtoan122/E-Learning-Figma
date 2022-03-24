using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Danh_sách_người_dùng_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Danh_sách_người_dùng_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Danh_sách_người_dùng>>> Get()
        {
            return Ok(await _context.Danh_sách_người_dùng.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Danh_sách_người_dùng>>> Add(Danh_sách_người_dùng nguoi_dung)
        {
            _context.Danh_sách_người_dùng.Add(nguoi_dung);
            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_sách_người_dùng.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Danh_sách_người_dùng>>> Update(Danh_sách_người_dùng request)
        {
            var result = await _context.Danh_sách_người_dùng.FindAsync(request.Danh_sách_người_dùng_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy người dùng.");

            result.Tên_người_dùng = request.Tên_người_dùng;
            result.Email = request.Email;
            result.Nhóm_người_dùng = request.Nhóm_người_dùng;

            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_sách_người_dùng.ToListAsync());
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
