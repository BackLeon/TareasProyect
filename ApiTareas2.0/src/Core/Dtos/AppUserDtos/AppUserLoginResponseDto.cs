using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.AppUserDtos
{
    public class AppUserLoginResponseDto
    {
        public string Email { get; set; }

        public string Roles { get; set; }
        public string Token { get; set; }
    }
}