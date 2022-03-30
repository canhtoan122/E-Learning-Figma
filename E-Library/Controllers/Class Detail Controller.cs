using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Leadership")]
    public class Class_Detail_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Class_Detail_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Student List")]
        public async Task<ActionResult<List<Student>>> Get_Student()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("Subject List")]
        public async Task<ActionResult<List<Subject>>> Get_Subject()
        {
            return Ok(await _context.Subject.ToListAsync());
        }
        //[HttpGet("Overall Information")]
        //public async Task<ActionResult<List<Class>>> Get_Overall_Information()
        //{
        //    var school_year = _context.Class.Where<School_year>(e => e.School_year_time);
        //    var Department = _context.Class.Where<Department>(e => e.Department_name);
        //    var Class_code = _context.Class.Where<Class>(e => e.Class_code);
        //    var Class_name = _context.Class.Where<Class>(e => e.Class_name);
        //    var Homeroom_teacher = _context.Class.Where<Class>(e => e.Homeroom_teacher);
        //    var Student_number = _context.Class.Where<Class>(e => e.Student_number);
        //    var Class_classify = _context.Class.Where<Class>(e => e.Class_classify);
        //    var Subject = _context.Subject.Count<Subject>();
        //    var Description = _context.Class.Where<Class>(e => e.Description);
        //    var result = school_year + Department + Class_code + Class_name + Homeroom_teacher + Student_number + Class_classify + Subject + Description;
        //    return Ok(result);

        //}
    }
}
