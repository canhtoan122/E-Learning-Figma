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
    public class Hồ_sơ_giáo_viên_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Hồ_sơ_giáo_viên_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Giảng_Viên>>> Get()
        {
            return Ok(await _context.Giảng_Viên.ToListAsync());
        }
        [HttpGet("{Mã Giảng Viên}")]
        public async Task<ActionResult<List<Giảng_Viên>>> Get_Mã_Giảng_Viên(string giang_vien)
        {
            var result = await _context.Giảng_Viên.FindAsync(giang_vien);
            if (result == null)
                return BadRequest(" Ko tìm thấy giảng viên");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Giảng_Viên>>> Add(Giảng_Viên giang_vien)
        {
            _context.Giảng_Viên.Add(giang_vien);
            await _context.SaveChangesAsync();

            return Ok(await _context.Giảng_Viên.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Giảng_Viên>>> Update(Giảng_Viên request)
        {
            var result = await _context.Giảng_Viên.FindAsync(request.Giảng_Viên_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy học viên.");

            result.Mã_Giảng_Viên = request.Mã_Giảng_Viên;
            result.Họ_và_Tên = request.Họ_và_Tên;
            result.Ngày_sinh = request.Ngày_sinh;
            result.Giới_Tính = request.Giới_Tính;
            result.Dân_Tộc = request.Dân_Tộc;
            result.Ngày_Vào_trường = request.Ngày_Vào_trường;
            result.Quốc_tịch = request.Quốc_tịch;
            result.Tôn_Giáo = request.Tôn_Giáo;
            result.Trạng_thái = request.Trạng_thái;
            result.Bí_danh = request.Bí_danh;
            result.Tỉnh_Thành = request.Tỉnh_Thành;
            result.Xã_Phường = request.Xã_Phường;
            result.Quận_Huyện = request.Quận_Huyện;
            result.Địa_chỉ = request.Địa_chỉ;
            result.Quận_Huyện = request.Quận_Huyện;
            result.Xã_Phường = request.Xã_Phường;
            result.Email = request.Email;
            result.SĐT = request.SĐT;
            result.Đoàn_Viên = request.Đoàn_Viên;
            result.Đảng_Viên = request.Đảng_Viên;
            result.Ngày_Vào_Đoàn = request.Ngày_Vào_Đoàn;
            result.Ngày_Vào_Đảng = request.Ngày_Vào_Đảng;

            await _context.SaveChangesAsync();

            return Ok(await _context.Giảng_Viên.ToListAsync());
        }

        [HttpDelete("{Mã học viên}")]
        public async Task<ActionResult<List<Giảng_Viên>>> Delete(string giang_vien)
        {
            var result = await _context.Giảng_Viên.FindAsync(giang_vien);
            if (result == null)
                return BadRequest("Ko tìm thấy giảng viên.");

            _context.Giảng_Viên.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Giảng_Viên.ToListAsync());
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
