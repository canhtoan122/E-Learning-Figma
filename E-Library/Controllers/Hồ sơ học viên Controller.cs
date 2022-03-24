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
    public class Hồ_sơ_học_viên_Controller : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public Hồ_sơ_học_viên_Controller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Học_viên>>> Get()
        {
            return Ok(await _context.Học_viên.ToListAsync());
        }
        [HttpGet("{Mã Học Viên}")]
        public async Task<ActionResult<List<Học_viên>>> Get_Mã_Học_Viên(string hoc_vien)
        {
            var result = await _context.Học_viên.FindAsync(hoc_vien);
            if (result == null)
                return BadRequest(" Ko tìm thấy học viên");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Học_viên>>> Add(Học_viên hoc_vien)
        {
            _context.Học_viên.Add(hoc_vien);
            await _context.SaveChangesAsync();

            return Ok(await _context.Học_viên.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Học_viên>>> Update(Học_viên request)
        {
            var result = await _context.Học_viên.FindAsync(request.Học_viên_ID);
            if (result == null)
                return BadRequest("Ko tìm thấy học viên.");

            result.Họ_và_tên = request.Họ_và_tên;
            result.Giới_Tính = request.Giới_Tính;
            result.Ngày_sinh = request.Ngày_sinh;
            result.Nơi_Sinh = request.Nơi_Sinh;
            result.Dân_Tộc = request.Dân_Tộc;
            result.Tôn_Giáo = request.Tôn_Giáo;
            result.Niên_Khoá = request.Niên_Khoá;
            result.Khoa_Khối = request.Khoa_Khối;
            result.Lớp_học = request.Lớp_học;
            result.Mã_Học_viên = request.Mã_Học_viên;
            result.Ngày_Nhập_Học = request.Ngày_Nhập_Học;
            result.Hình_Thức = request.Hình_Thức;
            result.Tình_Trạng = request.Tình_Trạng;
            result.Tỉnh_Thành_Phố = request.Tỉnh_Thành_Phố;
            result.Quận_Huyện = request.Quận_Huyện;
            result.Xã_Phường = request.Xã_Phường;
            result.Địa_Chỉ = request.Địa_Chỉ;
            result.Email = request.Email;
            result.Điện_Thoại = request.Điện_Thoại;
            result.Họ_Tên_Bố = request.Họ_Tên_Bố;
            result.Họ_Tên_Mẹ = request.Họ_Tên_Mẹ;
            result.Họ_Tên_Giám_Hộ = request.Họ_Tên_Giám_Hộ;
            result.Năm_Sinh_Bố = request.Năm_Sinh_Bố;
            result.Năm_Sinh_Mẹ = request.Năm_Sinh_Mẹ;
            result.Năm_Sinh_GH = request.Năm_Sinh_GH;
            result.Nghề_Nghiệp_Bố = request.Nghề_Nghiệp_Bố;
            result.Nghề_Nghiệp_Mẹ = request.Nghề_Nghiệp_Mẹ;
            result.Nghề_Nghiệp_GH = request.Nghề_Nghiệp_GH;
            result.Điện_Thoại_Bố = request.Điện_Thoại_Bố;
            result.Điện_Thoại_Mẹ = request.Điện_Thoại_Mẹ;
            result.Điện_Thoại_GH = request.Điện_Thoại_GH;

            await _context.SaveChangesAsync();

            return Ok(await _context.Học_viên.ToListAsync());
        }

        [HttpDelete("{Mã học viên}")]
        public async Task<ActionResult<List<Học_viên>>> Delete(string hoc_vien)
        {
            var result = await _context.Học_viên.FindAsync(hoc_vien);
            if (result == null)
                return BadRequest("Ko tìm thấy khoa/khối.");

            _context.Học_viên.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Học_viên.ToListAsync());
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
