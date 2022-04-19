using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassHistoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassHistory>>> Get()
        {
            return Ok(await _context.ClassHistory.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ClassHistory>>> Add(ClassHistory lop)
        {
            _context.ClassHistory.Add(lop);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassHistory.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ClassHistory>>> Update(ClassHistory request)
        {
            var result = await _context.ClassHistory.FindAsync(request.ClassHistoryID);
            if (result == null)
                return BadRequest("Class not found.");

            result.Teacher = request.Teacher;
            result.Subject = request.Subject;
            result.Description = request.Description;
            result.Class = request.Class;
            result.ClassSchedule = request.ClassSchedule;
            result.StartingDate = request.StartingDate;
            result.EndingDate = request.EndingDate;
            result.Content = request.Content;
            result.ExamDate = request.ExamDate;
            result.CLassCode = request.CLassCode;
            result.SecurityPassword = request.SecurityPassword;
            result.OtherSetting = request.OtherSetting;
            result.SharedLink = request.SharedLink;

            await _context.SaveChangesAsync();

            return Ok(await _context.ClassHistory.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<ClassHistory>>> Delete(int id)
        {
            var result = await _context.ClassHistory.FindAsync(id);
            if (result == null)
                return BadRequest("Class not found.");

            _context.ClassHistory.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassHistory.ToListAsync());
        }
    }
}
