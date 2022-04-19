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
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _context.Department.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Department>>> DepartmentSearch(string name)
        {
            try
            {
                IQueryable<Department> query = _context.Department;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.DepartmentCode.Contains(name));
                    query = query.Where(e => e.DepartmentName.Contains(name));
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

        [HttpGet("{Class List}")]
        public async Task<ActionResult<List<Class>>> GetClassList()
        {
            return Ok(await _context.Class.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Department>>> Add(Department khoa)
        {
            _context.Department.Add(khoa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Department.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Department>>> Update(Department request)
        {
            var result = await _context.Department.FindAsync(request.DepartmentID);
            if (result == null)
                return BadRequest("Department not found.");

            result.DepartmentCode = request.DepartmentCode;
            result.DepartmentName = request.DepartmentName;
            result.Dean = request.Dean;

            await _context.SaveChangesAsync();

            return Ok(await _context.Department.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Department>>> Delete(int id)
        {
            var result = await _context.Department.FindAsync(id);
            if (result == null)
                return BadRequest("Department not found.");

            _context.Department.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Department.ToListAsync());
        }
    }
}
