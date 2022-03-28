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
    public class Department_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Department_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _context.Department.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Department>>> Get_Khoa_Khối(string khoa)
        {
            var result = await _context.Department.FindAsync(khoa);
            if (result == null)
                return BadRequest("Department not found.");
            return Ok(result);
        }
        [HttpGet("{Danh sách lớp học}")]
        public async Task<ActionResult<List<Class>>> Get_Danh_sách_Lớp_Học()
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
            var result = await _context.Department.FindAsync(request.Department_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            result.Department_code = request.Department_code;
            result.Department_name = request.Department_name;
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
