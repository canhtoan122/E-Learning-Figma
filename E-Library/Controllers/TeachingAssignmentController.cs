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
    public class TeachingAssignmentController : ControllerBase
    {
        private readonly DataContext _context;

        public TeachingAssignmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeachingAssignment>>> Get()
        {
            return Ok(await _context.TeachingAssignment.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TeachingAssignment>>> Add(TeachingAssignment teaching)
        {
            _context.TeachingAssignment.Add(teaching);
            await _context.SaveChangesAsync();

            return Ok(await _context.TeachingAssignment.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TeachingAssignment>>> Update(TeachingAssignment request)
        {
            var result = await _context.TeachingAssignment.FindAsync(request.TeachingAssignmentID);
            if (result == null)
                return BadRequest("Assignment not found.");

            //result.Giảng_Viên = giang_vien.Họ_và_Tên;
            //result.Môn_Học = mon_hoc.Tên_Môn_Học;
            result.Classroom = request.Classroom;
            result.StartingDate = request.StartingDate;
            result.EndingDate = request.EndingDate;
            result.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.TeachingAssignment.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TeachingAssignment>>> Delete(int id)
        {
            var result = await _context.TeachingAssignment.FindAsync(id);
            if (result == null)
                return BadRequest("Assignment not found.");

            _context.TeachingAssignment.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.TeachingAssignment.ToListAsync());
        }
    }
}
