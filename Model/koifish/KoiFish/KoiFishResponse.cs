using System;

namespace KoiFishManager.Models.KoiFish
{
    public class KoiFishResponse
    {
        public int Id { get; set; }                 // ID cá Koi
        public string Name { get; set; } = string.Empty;           // Tên cá Koi
        public string Color { get; set; } = string.Empty;         // Màu sắc cá Koi
        public double Size { get; set; }          // Kích thước cá Koi
        public string Origin { get; set; } = string.Empty;         // Xuất xứ cá Koi
        public string HealthStatus { get; set; } = string.Empty;     // Tình trạng sức khỏe
        public DateTime CreatedAt { get; set; } 
        public int PondId { get; set; }
    }
}
