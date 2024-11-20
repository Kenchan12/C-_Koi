using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KoiFishManager.Api.Common;


namespace KoiFishManager.Api.Entities
{
    public class KoiFish : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Color { get; set; } // Màu sắc của cá koi

        [Range(1, 100)]
        public double Size { get; set; } // Kích thước của cá koi

        [MaxLength(50)]
        public string Origin { get; set; } // Xuất xứ của cá koi

        [MaxLength(20)]
        public string HealthStatus { get; set; } // Tình trạng sức khỏe của cá koi

        [ForeignKey("Pond")]
        public int PondId { get; set; } // Mã hồ cá chứa cá koi

        public Pond Pond { get; set; } // Thông tin hồ cá chứa cá koi
    }

}
