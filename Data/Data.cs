using Bai_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_3.Data
{
    public class AppDbContext : DbContext
    {
        // Hàm khởi tạo nhận cấu hình (chuỗi kết nối) từ Program.cs
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng trong cơ sở dữ liệu
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pooduct> Products { get; set; }
    }
}
