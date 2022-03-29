using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Help_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Help_Controller(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Help>>> Add(Help help)
        {
            _context.Help.Add(help);
            await _context.SaveChangesAsync();

            return Ok(await _context.Notification.ToListAsync());
        }
    }
}
