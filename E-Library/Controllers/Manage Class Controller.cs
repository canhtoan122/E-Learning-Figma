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
    [Authorize(Roles = "Teacher")]
    public class Manage_CLass_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Manage_CLass_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Class>>> Class_Search(string name)
        {
            try
            {
                IQueryable<Class> query = _context.Class;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Class_name.Contains(name));
                }
                if (query.Any())
                {
                    return Ok(query);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
    }
}
