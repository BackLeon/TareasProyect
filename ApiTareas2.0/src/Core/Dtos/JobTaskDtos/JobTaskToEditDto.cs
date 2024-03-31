using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.JobTaskDtos
{
    public class JobTaskToEditDto
    {
        public string Radicado { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public int AppUserId { get; set; }

    }
}
