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
    public class SubjectGroupController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectGroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectGroup>>> Get()
        {
            return Ok(await _context.SubjectGroup.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SubjectGroup>>> SubjectGroupSearch(string name)
        {
            try
            {
                IQueryable<SubjectGroup> query = _context.SubjectGroup;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.SubjectGroupName.Contains(name));
                    query = query.Where(e => e.HeadOfDepartment.Contains(name));
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

        [HttpGet("Subject List")]
        public async Task<ActionResult<List<Subject>>> Subject_List()
        {
            return Ok(await _context.Subject.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SubjectGroup>>> Add(SubjectGroup subject)
        {
            _context.SubjectGroup.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectGroup.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SubjectGroup>>> Update(SubjectGroup request)
        {
            var result = await _context.SubjectGroup.FindAsync(request.SubjectGroupID);
            if (result == null)
                return BadRequest("Ko tìm thấy tổ-bộ môn.");

            result.SubjectGroupName = request.SubjectGroupName;
            result.HeadOfDepartment = request.HeadOfDepartment;

            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectGroup.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SubjectGroup>>> Delete(int id)
        {
            var result = await _context.SubjectGroup.FindAsync(id);
            if (result == null)
                return BadRequest("Subject group not found.");

            _context.SubjectGroup.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectGroup.ToListAsync());
        }
    }
}
