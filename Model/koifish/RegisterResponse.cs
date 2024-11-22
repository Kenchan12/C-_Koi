using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models
{
    public class RegisterResponse
    {
        public bool Successful { get; set; }
        public string Error { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

}
