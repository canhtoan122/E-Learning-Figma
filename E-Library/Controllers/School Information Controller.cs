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
    public class School_Information_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public School_Information_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<School_Information>>> Get()
        {
            return Ok(await _context.School_Information.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<School_Information>>> Add(School_Information truong)
        {
            _context.School_Information.Add(truong);
            await _context.SaveChangesAsync();

            return Ok(await _context.School_Information.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<School_Information>>> Update(School_Information request)
        {
            var result = await _context.School_Information.FindAsync(request.School_Information_ID);
            if (result == null)
                return BadRequest("School Information not found.");

            result.School_name = request.School_name;
            result.School_code = request.School_code;
            result.Province_city = request.Province_city;
            result.Ward = request.Ward;
            result.District = request.District;
            result.Headquarter = request.Headquarter;
            result.School_type = request.School_type;
            result.Phone_number = request.Phone_number;
            result.Fax = request.Fax;
            result.Email = request.Email;
            result.Founded_date = request.Founded_date;
            result.School_establishment_model = request.School_establishment_model;
            result.Website = request.Website;
            result.Principal = request.Principal;
            result.Principal_phone_number = request.Principal_phone_number;
            result.Facility_name = request.Facility_name;
            result.Address = request.Address;
            result.School_phone_number = request.School_phone_number;
            result.Person_in_charge = request.Person_in_charge;
            result.Cellphone_number = request.Cellphone_number;

            await _context.SaveChangesAsync();

            return Ok(await _context.School_Information.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<School_Information>>> Delete(int id)
        {
            var result = await _context.School_Information.FindAsync(id);
            if (result == null)
                return BadRequest("School Information not found.");

            _context.School_Information.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.School_Information.ToListAsync());
        }
    }
}
