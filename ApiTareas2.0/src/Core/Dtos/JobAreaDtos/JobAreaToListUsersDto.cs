using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos.AppUserDtos;

namespace Core.Dtos.JobAreaDtos
{
    public class JobAreaToListUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUserToJobAreaDto> AppUsers { get; set; }
    }
}