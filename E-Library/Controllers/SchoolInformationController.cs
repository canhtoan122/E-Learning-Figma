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
    public class SchoolInformationController : ControllerBase
    {
        private readonly DataContext _context;

        public SchoolInformationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SchoolInformation>>> Get()
        {
            return Ok(await _context.SchoolInformation.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SchoolInformation>>> Add(SchoolInformation truong)
        {
            _context.SchoolInformation.Add(truong);
            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolInformation.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SchoolInformation>>> Update(SchoolInformation request)
        {
            var result = await _context.SchoolInformation.FindAsync(request.SchoolInformationID);
            if (result == null)
                return BadRequest("School Information not found.");

            result.SchoolName = request.SchoolName;
            result.SchoolCode = request.SchoolCode;
            result.ProvinceCity = request.ProvinceCity;
            result.Ward = request.Ward;
            result.District = request.District;
            result.Headquarter = request.Headquarter;
            result.SchoolType = request.SchoolType;
            result.PhoneNumber = request.PhoneNumber;
            result.Fax = request.Fax;
            result.Email = request.Email;
            result.FoundedDate = request.FoundedDate;
            result.SchoolEstablishmentModel = request.SchoolEstablishmentModel;
            result.Website = request.Website;
            result.Principal = request.Principal;
            result.PrincipalPhoneNumber = request.PrincipalPhoneNumber;
            result.FacilityName = request.FacilityName;
            result.Address = request.Address;
            result.SchoolPhoneNumber = request.SchoolPhoneNumber;
            result.PersonInCharge = request.PersonInCharge;
            result.CellphoneNumber = request.CellphoneNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolInformation.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SchoolInformation>>> Delete(int id)
        {
            var result = await _context.SchoolInformation.FindAsync(id);
            if (result == null)
                return BadRequest("School Information not found.");

            _context.SchoolInformation.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.SchoolInformation.ToListAsync());
        }
    }
}
