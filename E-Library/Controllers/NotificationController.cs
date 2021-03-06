using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly DataContext _context;

        public NotificationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> Get()
        {
            return Ok(await _context.ClassroomSetting.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Notification>>> Add(Notification notification)
        {
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();

            return Ok(await _context.Notification.ToListAsync());
        }
    }
}
