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
    public class ManageExamController : ControllerBase
    {
        private readonly DataContext _context;

        public ManageExamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ManageExamSchedule>>> Get()
        {
            return Ok(await _context.ManageExamSchedule.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ManageExamSchedule>>> ManageExamScheduleSearch(string name)
        {
            try
            {
                IQueryable<ManageExamSchedule> query = _context.ManageExamSchedule;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Semester.Contains(name));
                    query = query.Where(e => e.ExamDate.Contains(name));
                    query = query.Where(e => e.Department.Contains(name));
                    query = query.Where(e => e.ExamSubject.Contains(name));
                    query = query.Where(e => e.ExamName.Contains(name));
                    query = query.Where(e => e.Status.Contains(name));
                    query = query.Where(e => e.ExamMarkingAssignment.Contains(name));
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

        [HttpPost]
        public async Task<ActionResult<List<ManageExamSchedule>>> Add(ManageExamSchedule chu_de)
        {
            _context.ManageExamSchedule.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.ManageExamSchedule.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ManageExamSchedule>>> Update(ManageExamSchedule request)
        {
            var result = await _context.ManageExamSchedule.FindAsync(request.ManageExamScheduleID);
            if (result == null)
                return BadRequest("Exam Schedule not found.");

            result.Semester = request.Semester;
            result.ExamDate = request.ExamDate;
            result.Department = request.Department;
            result.ExamSubject = request.ExamSubject;
            result.ExamName = request.ExamName;
            result.Status = request.Status;
            result.ExamMarkingAssignment = request.ExamMarkingAssignment;

            await _context.SaveChangesAsync();

            return Ok(await _context.ManageExamSchedule.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ManageExamSchedule>>> Delete(int id)
        {
            var result = await _context.ManageExamSchedule.FindAsync(id);
            if (result == null)
                return BadRequest("Exam Schedule not found.");

            _context.ManageExamSchedule.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.ManageExamSchedule.ToListAsync());
        }
    }
}
