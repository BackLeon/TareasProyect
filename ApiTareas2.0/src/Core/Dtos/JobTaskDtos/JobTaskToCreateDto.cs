using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.JobTaskDtos
{
    public class JobTaskToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Radicado { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AppUserId { get; set; }
    }
}


