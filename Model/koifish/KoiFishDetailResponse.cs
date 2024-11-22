using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models.KoiFish
{
    public class KoiFishDetailResponse
    {
        public int Id { get; set; } // ID cá Koi
        public string Name { get; set; } // Tên cá Koi
        public string Color { get; set; } // Màu sắc
        public double Size { get; set; } // Kích thước
        public string Origin { get; set; } // Xuất xứ
        public string HealthStatus { get; set; } // Tình trạng sức khỏe
        public int PondId { get; set; } // Mã hồ cá
        public PondDto  Pond { get; set; } // Tên hồ cá
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
