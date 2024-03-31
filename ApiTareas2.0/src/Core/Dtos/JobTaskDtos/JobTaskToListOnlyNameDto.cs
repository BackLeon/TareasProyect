using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.JobTaskDtos
{
    public class JobTaskToListOnlyNameDto
    {
        public int Id { get; set;}

        public string Radicado { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }

        public int AppUserId { get; set;}
        public string AppUserEmail { get; set; }
        public string AppUserName { get; set; }
        public string AppUserLastName { get; set; }

        public string AppUserArea { get; set; }
    }
}