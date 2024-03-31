using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.AppUserDtos
{
    public class AppUserToLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string License { get; set; }

        [Required]
        public string Password { get; set;}
    
    }
}