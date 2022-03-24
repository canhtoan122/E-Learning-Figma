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
    public class Danh_sách_khen_thưởng_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Danh_sách_khen_thưởng_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Danh_Sách_Khen_Thưởng>>> Get()
        {
            return Ok(await _context.Danh_Sách_Khen_Thưởng.ToListAsync());
        }
        [HttpGet("{Mã Học Viên}")]
        public async Task<ActionResult<List<Danh_Sách_Khen_Thưởng>>> Get_Mã_Học_Viên(Học_viên hoc_vien)
        {
            var result = await _context.Học_viên.FindAsync(hoc_vien);
            if (result == null)
                return BadRequest(" Ko tìm thấy học viên");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Danh_Sách_Khen_Thưởng>>> Add(Danh_Sách_Khen_Thưởng khen_thuong)
        {
            _context.Danh_Sách_Khen_Thưởng.Add(khen_thuong);
            await _context.SaveChangesAsync();

            return Ok(await _context.Danh_Sách_Khen_Thưởng.ToListAsync());
        }

        [HttpPost]
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
