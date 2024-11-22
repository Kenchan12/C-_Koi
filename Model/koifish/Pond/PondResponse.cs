using KoiFishManager.Models.KoiFish;
using System;
using System.Collections.Generic;

namespace KoiFishManager.Models.Pond
{
    public class PondResponse
    {
        public int Id { get; set; }                     // ID của hồ cá
        public string Name { get; set; }                // Tên hồ cá
        public double Size { get; set; }                // Diện tích hồ cá
        public double Depth { get; set; }               // Độ sâu của hồ cá
        public string WaterQuality { get; set; }        // Chất lượng nước
        public List<KoiFishResponse> KoiFishes { get; set; } = new List<KoiFishResponse>(); // Danh sách cá Koi
        public List<FeedingScheduleResponse> FeedingSchedules { get; set; } = new List<FeedingScheduleResponse>(); // Lịch cho ăn
        public List<PondStatusResponse> PondStatuses { get; set; } = new List<PondStatusResponse>(); // Trạng thái hồ
        public DateTime CreatedAt { get; set; }         // Thời gian tạo
        public DateTime UpdatedAt { get; set; }         // Thời gian cập nhật
    }
}
