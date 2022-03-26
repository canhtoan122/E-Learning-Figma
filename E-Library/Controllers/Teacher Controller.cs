using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Teacher_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Get()
        {
            return Ok(await _context.Teacher.ToListAsync());
        }
        [HttpGet("{Mã Giảng Viên}")]
        public async Task<ActionResult<List<Teacher>>> Get_Mã_Giảng_Viên(string giang_vien)
        {
            var result = await _context.Teacher.FindAsync(giang_vien);
            if (result == null)
                return BadRequest("Teacher not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> Add(Teacher giang_vien)
        {
            _context.Teacher.Add(giang_vien);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Teacher>>> Update(Teacher request)
        {
            var result = await _context.Teacher.FindAsync(request.Teacher_ID);
            if (result == null)
                return BadRequest("Teacher not found.");

            result.Teacher_code = request.Teacher_code;
            result.Full_name = request.Full_name;
            result.Date_of_birth = request.Date_of_birth;
            result.Sex = request.Sex;
            result.Ethnic = request.Ethnic;
            result.Starting_date = request.Starting_date;
            result.Nationality = request.Nationality;
            result.Religion = request.Religion;
            result.Status = request.Status;
            result.Aliases = request.Aliases;
            result.Province_city = request.Province_city;
            result.Ward = request.Ward;
            result.District = request.District;
            result.Address = request.Address;
            result.Email = request.Email;
            result.Phone_number = request.Phone_number;
            result.Union_members = request.Union_members;
            result.Party_members = request.Party_members;
            result.Date_of_joining_the_union = request.Date_of_joining_the_union;
            result.Date_of_joining_the_party = request.Date_of_joining_the_party;

            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teacher>>> Delete(int id)
        {
            var result = await _context.Teacher.FindAsync(id);
            if (result == null)
                return BadRequest("Teacher not found.");

            _context.Teacher.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpPost("{Post File}")]
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
