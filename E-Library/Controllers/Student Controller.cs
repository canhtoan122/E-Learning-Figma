using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Leadership")]
    public class Student_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Student_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> Student_Search(string name)
        {
            try
            {
                IQueryable<Student> query = _context.Student;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Student_code.Contains(name));
                    query = query.Where(e => e.Full_name.Contains(name));
                    query = query.Where(e => e.Sex.Contains(name));
                    query = query.Where(e => e.Ethnic.Contains(name));
                    query = query.Where(e => e.Ethnic.Contains(name));
                    query = query.Where(e => e.Class.Contains(name));
                    query = query.Where(e => e.Study_Status.Contains(name));

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
        public async Task<ActionResult<List<Student>>> Add(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> Update(Student request)
        {
            var hoc_vien = await _context.Student.FindAsync(request.Student_ID);
            if (hoc_vien == null)
                return BadRequest("Student not found.");

            hoc_vien.Full_name = request.Full_name;
            hoc_vien.Sex = request.Sex;
            hoc_vien.Date_of_birth = request.Date_of_birth;
            hoc_vien.Place_of_birth = request.Place_of_birth;
            hoc_vien.Ethnic = request.Ethnic;
            hoc_vien.Religion = request.Religion;
            //hoc_vien.School_year = request.School_year;
            //hoc_vien.Department = request.Department;
            hoc_vien.Class = request.Class;
            hoc_vien.Student_code = request.Student_code;
            hoc_vien.Date_of_admission = request.Date_of_admission;
            hoc_vien.Graduate_form = request.Graduate_form;
            hoc_vien.Study_Status = request.Study_Status;
            hoc_vien.Province_city = request.Province_city;
            hoc_vien.District = request.District;
            hoc_vien.Wards = request.Wards;
            hoc_vien.Address = request.Address;
            hoc_vien.Email = request.Email;
            hoc_vien.Phone_number = request.Phone_number;
            hoc_vien.Father_full_name = request.Father_full_name;
            hoc_vien.Mother_full_name = request.Mother_full_name;
            hoc_vien.Guardian_full_name = request.Guardian_full_name;
            hoc_vien.Father_date_of_birth = request.Father_date_of_birth;
            hoc_vien.Mother_date_of_birth = request.Mother_date_of_birth;
            hoc_vien.Guardian_date_of_birth = request.Guardian_date_of_birth;
            hoc_vien.Father_occupation = request.Father_occupation;
            hoc_vien.Mother_occupation = request.Mother_occupation;
            hoc_vien.Guardian_occupation = request.Guardian_occupation;
            hoc_vien.Father_phone_number = request.Father_phone_number;
            hoc_vien.Mother_phone_number = request.Mother_phone_number;
            hoc_vien.Guardian_phone_number = request.Guardian_phone_number;

            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var result = await _context.Student.FindAsync(id);
            if (result == null)
                return BadRequest("Student not found.");

            _context.Student.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpPost("Post File")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] FileManagement model)
        {
            try
            {
                FileRecord file = await SaveFileAsync(model.MyFile);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.AltText = model.AltText;
                    file.Description = model.Description;
                    //Save to Inmemory object
                    //fileDB.Add(file);
                    //Save to SQL Server DB
                    SaveToDB(file);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }

        private async Task<FileRecord> SaveFileAsync(IFormFile myFile)
        {
            FileRecord file = new FileRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName);
                var path = Path.Combine(AppDirectory, fileName);

                file.Id = fileDB.Count() + 1;
                file.FilePath = path;
                file.FileName = fileName;
                file.FileFormat = Path.GetExtension(myFile.FileName);
                file.ContentType = myFile.ContentType;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

                return file;
            }
            return file;
        }

        private void SaveToDB(FileRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            FileData fileData = new FileData();
            fileData.FilePath = record.FilePath;
            fileData.FileName = record.FileName;
            fileData.FileExtension = record.FileFormat;
            fileData.MimeType = record.ContentType;

            _context.FileData.Add(fileData);
            _context.SaveChanges();
        }
    }
}
