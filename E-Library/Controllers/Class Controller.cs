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
    public class Class_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Class_Controller(DataContext context)
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
                    query = query.Where(e => e.Class_code.Contains(name));
                    query = query.Where(e => e.Class_name.Contains(name));
                    query = query.Where(e => e.Homeroom_teacher.Contains(name));
                    query = query.Where(e => e.Student_number.Contains(name));
                    query = query.Where(e => e.Class_classify.Contains(name));
                    query = query.Where(e => e.Description.Contains(name));
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

        [HttpPost]
        public async Task<ActionResult<List<Class>>> Add(Class lop)
        {
            _context.Class.Add(lop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Class>>> Update(Class request)
        {
            var result = await _context.Class.FindAsync(request.Class_ID);
            if (result == null)
                return BadRequest("Class not found.");

            result.Class_code = request.Class_code;
            result.Class_name = request.Class_name;
            result.Homeroom_teacher = request.Homeroom_teacher;
            result.Student_number = request.Student_number;
            result.Class_classify = request.Class_classify;
            result.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }

        [HttpDelete("{Mã Lớp}")]
        public async Task<ActionResult<List<Class>>> Delete(string lop)
        {
            var result = await _context.Class.FindAsync(lop);
            if (result == null)
                return BadRequest("Class not found.");

            _context.Class.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }
    }
}
