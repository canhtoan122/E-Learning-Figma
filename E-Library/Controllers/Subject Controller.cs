using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Subject_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Subject_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await _context.Subject.ToListAsync());
        }
        [HttpGet("{Mã Khoa Khối}")]
        public async Task<ActionResult<List<Subject>>> Get_Môn_Học(string mon)
        {
            var result = await _context.Subject.FindAsync(mon);
            if (result == null)
                return BadRequest("Subject not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subject>>> Add(Subject subject)
        {
            _context.Subject.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subject>>> Update(Subject request)
        {
            var result = await _context.Subject.FindAsync(request.Subject_ID);
            if (result == null)
                return BadRequest("Subject not found.");

            result.Subject_code = request.Subject_code;
            result.Subject_name = request.Subject_name;
            result.Subject_type = request.Subject_type;
            result.First_semester_lession = request.First_semester_lession;
            result.Second_semester_lession = request.Second_semester_lession;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject>>> Delete(int id)
        {
            var result = await _context.Subject.FindAsync(id);
            if (result == null)
                return BadRequest("Subject not found.");

            _context.Subject.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subject.ToListAsync());
        }
    }
}
