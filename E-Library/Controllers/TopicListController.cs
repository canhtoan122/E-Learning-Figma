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
    public class TopicListController : ControllerBase
    {
        private readonly DataContext _context;

        public TopicListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TopicList>>> Get()
        {
            return Ok(await _context.TopicList.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TopicList>>> Add(TopicList chu_de)
        {
            _context.TopicList.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.TopicList.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TopicList>>> Update(TopicList request)
        {
            var result = await _context.TopicList.FindAsync(request.TopicListID);
            if (result == null)
                return BadRequest("Topic not found.");
            
            //result.Giáo_viên = request.Giáo_viên;
            //result.Lớp_học = request.Lớp_học;
            //result.Môn_học = request.Môn_học;
            result.Topic = request.Topic;
            result.Description = request.Description;
            result.EndingDate = request.EndingDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.TopicList.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TopicList>>> Delete(int id)
        {
            var result = await _context.TopicList.FindAsync(id);
            if (result == null)
                return BadRequest("Topic not found.");

            _context.TopicList.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.TopicList.ToListAsync());
        }
    }
}
