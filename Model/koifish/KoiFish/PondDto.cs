using KoiFishManager.Models.Pond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models.KoiFish
{
    public class PondDto
    {

        public int Id { get; set; }                     // ID của hồ cá
        public string Name { get; set; }                // Tên hồ cá
        public double Size { get; set; }                // Diện tích hồ cá
        public double Depth { get; set; }               // Độ sâu của hồ cá
        public string WaterQuality { get; set; }        // Chất lượng nước        
        public DateTime CreatedAt { get; set; }         // Thời gian tạo
        public DateTime UpdatedAt { get; set; }         // Thời gian cập nhật
    }
}
