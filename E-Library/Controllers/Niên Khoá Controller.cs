using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Niên_Khoá_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Niên_Khoá_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Niên_Khoá>>> Get()
        {
            return Ok(await _context.Niên_Khoá.ToListAsync());
        }
        [HttpGet("{Niên_Khoá_time}")]
        public async Task<ActionResult<List<Niên_Khoá>>> Get_Niên_Khoá(string time)
        {
            var result = await _context.Niên_Khoá.FindAsync(time);
            if (result == null)
                return BadRequest(" Ko tìm thấy Niên Khoá");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Niên_Khoá>>> Add(Niên_Khoá khoa)
        {
            _context.Niên_Khoá.Add(khoa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Niên_Khoá.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Niên_Khoá>>> Update(Niên_Khoá request)
        {
            var result = await _context.Niên_Khoá.FindAsync(request.Niên_Khoá_ID);
            if (result == null)
                return BadRequest(" Ko tìm thấy Niên Khoá.");

            result.Niên_Khoá_time = request.Niên_Khoá_time;
            result.Thời_Gian_Bắt_Đầu = request.Thời_Gian_Bắt_Đầu;
            result.Thời_Gian_Kết_Thúc = request.Thời_Gian_Kết_Thúc;
            result.Tên_Học_Kì = request.Tên_Học_Kì;
            result.Bắt_Đầu_Học_Kì = request.Bắt_Đầu_Học_Kì;
            result.Kết_Thúc_Học_Kì = request.Kết_Thúc_Học_Kì;

            await _context.SaveChangesAsync();

            return Ok(await _context.Niên_Khoá.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Niên_Khoá>>> Delete(int id)
        {
            var result = await _context.Niên_Khoá.FindAsync(id);
            if (result == null)
                return BadRequest(" Ko tìm thấy Niên Khoá.");

            _context.Niên_Khoá.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Niên_Khoá.ToListAsync());
        }
    }
}
