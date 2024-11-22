using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models.Pond
{
    public class PondStatusResponse
    {
        public int Id { get; set; }                 // ID trạng thái hồ
        public float Temperature { get; set; }     // Nhiệt độ nước
        public float PHLevel { get; set; }         // Độ pH của nước
        public float WaterLevel { get; set; }      // Mức nước
        public DateTime RecordedAt { get; set; }   // Thời điểm ghi nhận
    }
}
