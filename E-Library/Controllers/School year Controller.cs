﻿using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class School_year_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public School_year_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<School_year>>> Get()
        {
            return Ok(await _context.School_year.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<School_year>>> Get_Niên_Khoá(int id)
        {
            var result = await _context.School_year.FindAsync(id);
            if (result == null)
                return BadRequest("School year not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<School_year>>> Add(School_year year)
        {
            _context.School_year.Add(year);
            await _context.SaveChangesAsync();

            return Ok(await _context.School_year.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<School_year>>> Update(School_year request)
        {
            var result = await _context.School_year.FindAsync(request.School_year_ID);
            if (result == null)
                return BadRequest("School year not found.");

            result.School_year_time = request.School_year_time;
            result.Starting_date = request.Starting_date;
            result.Ending_date = request.Ending_date;
            result.Semester_name = request.Semester_name;
            result.Semester_start_date = request.Semester_start_date;
            result.Semester_end_date = request.Semester_end_date;

            await _context.SaveChangesAsync();

            return Ok(await _context.School_year.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<School_year>>> Delete(int id)
        {
            var result = await _context.School_year.FindAsync(id);
            if (result == null)
                return BadRequest("School year not found.");

            _context.School_year.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.School_year.ToListAsync());
        }
    }
}