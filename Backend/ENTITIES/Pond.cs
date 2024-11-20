using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KoiFishManager.Api.Common;
using System.Collections.Generic;
using System;


namespace KoiFishManager.Api.Entities
{
    public class Pond :  BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Tên hồ cá

        [Range(1, 1000)]
        public double Size { get; set; } // Diện tích hồ cá

        [Range(0.1, 10)]
        public double Depth { get; set; } // Độ sâu hồ cá

        [MaxLength(50)]
        public string WaterQuality { get; set; } // Chất lượng nước

        [ForeignKey("User")]
        public Guid UserId { get; set; } // Mã người dùng sở hữu hồ cá

        public User User { get; set; } // Thông tin người dùng sở hữu hồ cá
        public List<KoiFish> KoiFishes { get; set; } = new List<KoiFish>(); // Liên kết tới danh sách cá koi
        public List<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>(); // Liên kết tới lịch cho ăn
        public List<PondStatus> PondStatuses { get; set; } = new List<PondStatus> { };
    }
}
