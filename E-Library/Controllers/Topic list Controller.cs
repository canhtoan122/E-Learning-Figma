using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Leadership")]
    public class Danh_sách_chủ_đề_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Danh_sách_chủ_đề_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Topic_list>>> Get()
        {
            return Ok(await _context.Topic_list.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Topic_list>>> Add(Topic_list chu_de)
        {
            _context.Topic_list.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Topic_list.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Topic_list>>> Update(Topic_list request)
        {
            var result = await _context.Topic_list.FindAsync(request.Topic_list_ID);
            if (result == null)
                return BadRequest("Topic not found.");
            
            //result.Giáo_viên = request.Giáo_viên;
            //result.Lớp_học = request.Lớp_học;
            //result.Môn_học = request.Môn_học;
            result.Topic = request.Topic;
            result.Description = request.Description;
            result.Ending_date = request.Ending_date;

            await _context.SaveChangesAsync();

            return Ok(await _context.Topic_list.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Topic_list>>> Delete(int id)
        {
            var result = await _context.Topic_list.FindAsync(id);
            if (result == null)
                return BadRequest("Topic not found.");

            _context.Topic_list.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Topic_list.ToListAsync());
        }
    }
}
