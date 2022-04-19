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
    public class StudentController : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> StudentSearch(string name)
        {
            try
            {
                IQueryable<Student> query = _context.Student;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.StudentCode.Contains(name));
                    query = query.Where(e => e.FullName.Contains(name));
                    query = query.Where(e => e.Sex.Contains(name));
                    query = query.Where(e => e.Ethnic.Contains(name));
                    query = query.Where(e => e.Ethnic.Contains(name));
                    query = query.Where(e => e.Class.Contains(name));
                    query = query.Where(e => e.StudyStatus.Contains(name));

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
            var hoc_vien = await _context.Student.FindAsync(request.StudentID);
            if (hoc_vien == null)
                return BadRequest("Student not found.");

            hoc_vien.FullName = request.FullName;
            hoc_vien.Sex = request.Sex;
            hoc_vien.DateOfBirth = request.DateOfBirth;
            hoc_vien.PlaceOfBirth = request.PlaceOfBirth;
            hoc_vien.Ethnic = request.Ethnic;
            hoc_vien.Religion = request.Religion;
            //hoc_vien.School_year = request.School_year;
            //hoc_vien.Department = request.Department;
            hoc_vien.Class = request.Class;
            hoc_vien.StudentCode = request.StudentCode;
            hoc_vien.DateOfAdmission = request.DateOfAdmission;
            hoc_vien.GraduateForm = request.GraduateForm;
            hoc_vien.StudyStatus = request.StudyStatus;
            hoc_vien.ProvinceCity = request.ProvinceCity;
            hoc_vien.District = request.District;
            hoc_vien.Wards = request.Wards;
            hoc_vien.Address = request.Address;
            hoc_vien.Email = request.Email;
            hoc_vien.PhoneNumber = request.PhoneNumber;
            hoc_vien.FatherFullName = request.FatherFullName;
            hoc_vien.MotherFullName = request.MotherFullName;
            hoc_vien.GuardianFullName = request.GuardianFullName;
            hoc_vien.FatherDateOfBirth = request.FatherDateOfBirth;
            hoc_vien.MotherDateOfBirth = request.MotherDateOfBirth;
            hoc_vien.GuardianDateOfBirth = request.GuardianDateOfBirth;
            hoc_vien.FatherOccupation = request.FatherOccupation;
            hoc_vien.MotherOccupation = request.MotherOccupation;
            hoc_vien.GuardianOccupation = request.GuardianOccupation;
            hoc_vien.FatherPhoneNumber = request.FatherPhoneNumber;
            hoc_vien.MotherPhoneNumber = request.MotherPhoneNumber;
            hoc_vien.GuardianPhoneNumber = request.GuardianPhoneNumber;

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
