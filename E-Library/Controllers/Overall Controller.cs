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
    public class Overall_Controller : ControllerBase
    {
        private readonly DataContext _context;
        public Overall_Controller(DataContext context)
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
        
        public async Task<ActionResult<List<Teacher>>> Get_Teacher()
        {
            var sum = _context.Teacher.Count<Teacher>();
            return Ok(sum);
        }
        [HttpGet("Lớp học")]
        
        public async Task<ActionResult<List<Class>>> Get_Classroom()
        {
            var sum = _context.Class.Count<Class>();
            return Ok(sum);
        }
        [HttpGet("Khoá học")]
        public async Task<ActionResult<List<Class>>> Get_Course()
        {
            var sum = _context.Class.Count<Class>();
            return Ok(sum);
        }
    }
}
