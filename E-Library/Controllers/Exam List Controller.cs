using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Exam_List_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Exam_List_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exam_List>>> Get()
        {
            return Ok(await _context.Exam_List.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Exam_List>>> Exam_List_Search(string name)
        {
            try
            {
                IQueryable<Exam_List> query = _context.Exam_List;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Topic.Contains(name));           
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

        [HttpGet("subject filter")]
        public async Task<ActionResult<IEnumerable<Exam_List>>> Subject_filter(string name)
        {
            try
            {
                IQueryable<Exam_List> query = _context.Exam_List;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Subject.Contains(name));
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

        [HttpGet("department filter")]
        public async Task<ActionResult<IEnumerable<Exam_List>>> Department_filter(string name)
        {
            try
            {
                IQueryable<Exam_List> query = _context.Exam_List;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Department.Contains(name));
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
        [HttpGet("Exam date filter")]
        public async Task<ActionResult<IEnumerable<Exam_List>>> Exam_Date_filter(string name)
        {
            try
            {
                IQueryable<Exam_List> query = _context.Exam_List;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.Starting_date.Contains(name)
                                    || e.Ending_date.Contains(name));
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
        public async Task<ActionResult<List<Exam_List>>> Add(Exam_List exam)
        {
            _context.Exam_List.Add(exam);
            await _context.SaveChangesAsync();

            return Ok(await _context.Exam_List.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Exam_List>>> Update(Exam_List request)
        {
            var result = await _context.Exam_List.FindAsync(request.Exam_List_ID);
            if (result == null)
                return BadRequest("Exam not found.");

            result.Topic = request.Topic;
            result.Description = request.Description;
            result.Teaching_Assistant = request.Teaching_Assistant;
            result.Exam_amount_of_time = request.Exam_amount_of_time;
            result.Starting_date = request.Starting_date;
            result.Ending_date = request.Ending_date;
            result.Security_password = request.Security_password;
            result.Other_setting = request.Other_setting;
            result.Shared_link = request.Shared_link;

            await _context.SaveChangesAsync();

            return Ok(await _context.Exam_List.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Exam_List>>> Delete(int id)
        {
            var result = await _context.Exam_List.FindAsync(id);
            if (result == null)
                return BadRequest("Exam not found.");

            _context.Exam_List.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Exam_List.ToListAsync());
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

        [HttpGet("Get All file")]
        public List<FileRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.FileData.Select(n => new FileRecord
            {
                Id = n.Id,
                ContentType = n.MimeType,
                FileFormat = n.FileExtension,
                FileName = n.FileName,
                FilePath = n.FilePath
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            if (!Directory.Exists(AppDirectory))
                Directory.CreateDirectory(AppDirectory);

            //getting file from inmemory obj
            //var file = fileDB?.Where(n => n.Id == id).FirstOrDefault();
            //getting file from DB
            var file = _context.FileData.Where(n => n.Id == id).FirstOrDefault();

            var path = Path.Combine(AppDirectory, file?.FilePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
        [HttpDelete("Delete file")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            var file = _context.FileData.Where(n => n.Id == id).FirstOrDefault();

            var path = Path.Combine(AppDirectory, file?.FilePath);


            if (path != null)
            {
                System.IO.File.Delete(path);
                _context.SaveChanges();
            }
            return Ok(await _context.FileData.ToListAsync());
        }
    }
}
