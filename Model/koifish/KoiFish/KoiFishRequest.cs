using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models.KoiFish
{
    public class KoiFishRequest
    {
        [Required(ErrorMessage = "Fish name is required.")]
        [StringLength(100, ErrorMessage = "Fish name must not exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(50, ErrorMessage = "Color must not exceed 50 characters.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        [Range(0.1, 100.0, ErrorMessage = "Size must be between 0.1 and 100 cm.")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Origin is required.")]
        [StringLength(100, ErrorMessage = "Origin must not exceed 100 characters.")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Health status is required.")]
        [StringLength(100, ErrorMessage = "Health status must not exceed 100 characters.")]
        public string HealthStatus { get; set; }
        [Required(ErrorMessage = "PondId is required.")]
        public int PondId { get; set; }
    }
}
