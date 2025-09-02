using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class AuthResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? Token { get; set; }
    }
}
