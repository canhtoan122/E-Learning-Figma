﻿using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manage_Exam_Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Manage_Exam_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manage_Exam_Schedule>>> Get()
        {
            return Ok(await _context.Manage_Exam_Schedule.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Manage_Exam_Schedule>>> Add(Manage_Exam_Schedule chu_de)
        {
            _context.Manage_Exam_Schedule.Add(chu_de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Manage_Exam_Schedule.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Manage_Exam_Schedule>>> Update(Manage_Exam_Schedule request)
        {
            var result = await _context.Manage_Exam_Schedule.FindAsync(request.Manage_Exam_Schedule_ID);
            if (result == null)
                return BadRequest("Exam Schedule not found.");

            result.Semester = request.Semester;
            result.Exam_date = request.Exam_date;
            result.Department = request.Department;
            result.Exam_subject = request.Exam_subject;
            result.Exam_name = request.Exam_name;
            result.Status = request.Status;
            result.Exam_marking_assignment = request.Exam_marking_assignment;

            await _context.SaveChangesAsync();

            return Ok(await _context.Manage_Exam_Schedule.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Manage_Exam_Schedule>>> Delete(int id)
        {
            var result = await _context.Manage_Exam_Schedule.FindAsync(id);
            if (result == null)
                return BadRequest("Exam Schedule not found.");

            _context.Manage_Exam_Schedule.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Manage_Exam_Schedule.ToListAsync());
        }
    }
}