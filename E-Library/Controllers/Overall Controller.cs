using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tổng_Quan_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Tổng_Quan_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Student")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var sum = _context.Student.Count<Student>();
            return Ok(sum);
        }
        [HttpGet("Giảng viên")]
        public async Task<ActionResult<List<Teacher>>> Get_Giảng_viên()
        {
            var sum = _context.Giảng_Viên.Count<Teacher>();
            return Ok(sum);
        }
        [HttpGet("Lớp học")]
        public async Task<ActionResult<List<Teacher>>> Get_Lớp_Học()
        {
            var sum = _context.Giảng_Viên.Count<Teacher>();
            return Ok(sum);
        }
    }
}
