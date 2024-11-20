using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KoiFishManager.Api.Common;
using System;


namespace KoiFishManager.Api.Entities
{
    public class FeedingSchedule : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int Id { get; set; }
        [Required]
        public DateTime FeedingTime { get; set; } = DateTime.Now;// Thời gian cho ăn

        [MaxLength(50)]
        public string FoodType { get; set; } // Loại thức ăn

        [Range(1, 1000)]
        public int Quantity { get; set; } // Số lượng thức ăn

        [ForeignKey("Pond")]
        public int PondId { get; set; } // Mã hồ cá cần cho ăn

        public Pond Pond { get; set; } // Thông tin hồ cá cần cho ăn
    }
}
