using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.AppUserDtos
{
    public class AppRoleToCreateDto
    {
        [Required]
        public string? RoleName { get; set; }
    }
}