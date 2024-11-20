using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KoiFishManager.Api.Common;


namespace KoiFishManager.Api.Entities
{
    public class PondStatus : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int Id { get; set; }
        [Range(-10, 40)]
        public float Temperature { get; set; } // Nhiệt độ nước

        [Range(0, 14)]
        public float PHLevel { get; set; } // Độ pH của nước

        [Range(0, 5)]
        public float WaterLevel { get; set; } // Mức nước trong hồ

        [Required]
        public DateTime RecordedAt { get; set; } = DateTime.Now; // Thời điểm ghi nhận 

        [ForeignKey("Pond")]
        public int PondId { get; set; } // Mã hồ cá

        public Pond Pond { get; set; } = new Pond(); // Thông tin hồ cá; } // Thông tin hồ cá
    }
}
