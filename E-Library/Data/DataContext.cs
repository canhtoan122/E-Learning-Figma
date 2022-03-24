using E_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Niên_Khoá> Niên_Khoá { get; set; }
        public DbSet<Tổ_Bộ_Môn> Tổ_Bộ_Môn { get; set; }
        public DbSet<Môn_Học> Môn_Học { get; set; }
        public DbSet<Khoa_Khối> Khoa_Khối { get; set; }
        public DbSet<Lớp_học> Lớp_học { get; set; }
        public DbSet<Học_viên> Học_viên { get; set; }
        public DbSet<Loại_Điểm> Loại_Điểm { get; set; }
        public DbSet<Danh_Sách_Khen_Thưởng> Danh_Sách_Khen_Thưởng { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<Danh_sách_kỉ_luật> Danh_sách_kỉ_luật { get; set; }
        public DbSet<Tiếp_nhận_chuyển_trường> Tiếp_nhận_chuyển_trường { get; set; }
        public DbSet<Hồ_sơ_bảo_lưu> Hồ_sơ_bảo_lưu { get; set; }
        public DbSet<Giảng_Viên> Giảng_Viên { get; set; }
        public DbSet<Phân_Công_Giảng_Dạy> Phân_Công_Giảng_Dạy { get; set; }
        public DbSet<Danh_Sách_Chủ_Đề> Danh_Sách_Chủ_Đề { get; set; }
        public DbSet<Quản_lí_lịch_thi> Quản_lí_lịch_thi { get; set; }
        public DbSet<Thông_tin_trường> Thông_tin_trường { get; set; }
        public DbSet<Nhóm_người_dùng> Nhóm_người_dùng { get; set; }
        public DbSet<Danh_sách_người_dùng> Danh_sách_người_dùng { get; set; }
        public DbSet<Thiết_lập_lớp_học> Thiết_lập_lớp_học { get; set; }
        public DbSet<Thiết_lập_môn_học> Thiết_lập_môn_học { get; set; }
        public DbSet<Quản_lí_các_bậc_đào_tạo> Quản_lí_các_bậc_đào_tạo { get; set; }
    }
}
