using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewLessonController : ControllerBase
    {
        private readonly DataContext _context;

        public AddNewLessonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> Get()
        {
            return Ok(await _context.Lesson.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Lesson>>> Add(Lesson lesson)
        {
            _context.Lesson.Add(lesson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lesson.ToListAsync());
        }
    }
}
