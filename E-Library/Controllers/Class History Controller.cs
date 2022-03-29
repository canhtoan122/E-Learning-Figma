using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class_History_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Class_History_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class_History>>> Get()
        {
            return Ok(await _context.Class_History.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Class_History>>> Add(Class_History lop)
        {
            _context.Class_History.Add(lop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class_History.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Class_History>>> Update(Class_History request)
        {
            var result = await _context.Class_History.FindAsync(request.Class_History_ID);
            if (result == null)
                return BadRequest("Class not found.");

            result.Teacher = request.Teacher;
            result.Subject = request.Subject;
            result.Description = request.Description;
            result.Class = request.Class;
            result.Class_schedule = request.Class_schedule;
            result.Starting_date = request.Starting_date;
            result.Ending_date = request.Ending_date;
            result.Content = request.Content;
            result.Exam_date = request.Exam_date;
            result.CLass_code = request.CLass_code;
            result.Security_password = request.Security_password;
            result.Other_setting = request.Other_setting;
            result.Shared_link = request.Shared_link;

            await _context.SaveChangesAsync();

            return Ok(await _context.Class_History.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Class_History>>> Delete(int id)
        {
            var result = await _context.Class_History.FindAsync(id);
            if (result == null)
                return BadRequest("Class not found.");

            _context.Class_History.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class_History.ToListAsync());
        }
    }
}
