using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Incoming_Class_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Incoming_Class_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
    }
}
