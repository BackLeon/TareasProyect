using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos.JobTaskDtos;

namespace Core.Dtos.AppUserDtos
{
    public class AppUserToListWithAreaAndJobTasksDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string License { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Roles { get; set; }

        public string JobAreaName { get; set; }

        public virtual ICollection<JobTaskToListForAppUserCtrDto> JobTasksList { get; set; }
    }
}