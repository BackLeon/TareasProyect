using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.JobTaskDtos
{
    public class JobTaskToListForAppUserCtrDto
    {
        public Guid TaskGuid { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }
    }
}