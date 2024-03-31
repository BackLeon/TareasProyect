using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos.AppUserDtos
{
    public class AppUserToListDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string License { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}