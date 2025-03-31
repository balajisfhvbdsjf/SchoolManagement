using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string PhotoPath { get; set; }
    }

}
