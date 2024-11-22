using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models
{
    public class FeedingScheduleResponse
    {
        public int Id { get; set; }                 // ID lịch cho ăn
        public DateTime FeedingTime { get; set; }   // Thời gian cho ăn
        public string FoodType { get; set; }        // Loại thức ăn
        public int Quantity { get; set; }           // Số lượng thức ăn
    }
}
