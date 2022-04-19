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
    public class ExamListController : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public ExamListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamList>>> Get()
        {
            return Ok(await _context.ExamList.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ExamList>>> ExamListSearch(string name)
        {
            try
            {
                IQueryable<ExamList> query = _context.ExamList;
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
        public async Task<ActionResult<IEnumerable<ExamList>>> SubjectFilter(string name)
        {
            try
            {
                IQueryable<ExamList> query = _context.ExamList;
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
        public async Task<ActionResult<IEnumerable<ExamList>>> DepartmentFilter(string name)
        {
            try
            {
                IQueryable<ExamList> query = _context.ExamList;
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
        public async Task<ActionResult<IEnumerable<ExamList>>> ExamDateFilter(string name)
        {
            try
            {
                IQueryable<ExamList> query = _context.ExamList;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.StartingDate.Contains(name)
                                    || e.EndingDate.Contains(name));
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
        public async Task<ActionResult<List<ExamList>>> Add(ExamList exam)
        {
            _context.ExamList.Add(exam);
            await _context.SaveChangesAsync();

            return Ok(await _context.ExamList.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ExamList>>> Update(ExamList request)
        {
            var result = await _context.ExamList.FindAsync(request.ExamListID);
            if (result == null)
                return BadRequest("Exam not found.");

            result.Topic = request.Topic;
            result.Description = request.Description;
            result.TeachingAssistant = request.TeachingAssistant;
            result.ExamAmountOfTime = request.ExamAmountOfTime;
            result.StartingDate = request.StartingDate;
            result.EndingDate = request.EndingDate;
            result.SecurityPassword = request.SecurityPassword;
            result.OtherSetting = request.OtherSetting;
            result.SharedLink = request.SharedLink;

            await _context.SaveChangesAsync();

            return Ok(await _context.ExamList.ToListAsync());
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<ExamList>>> Delete(int id)
        {
            var result = await _context.ExamList.FindAsync(id);
            if (result == null)
                return BadRequest("Exam not found.");

            _context.ExamList.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.ExamList.ToListAsync());
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
