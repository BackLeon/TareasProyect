using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.AppUserDtos
{
    public class AppUserForRazorUsuarios
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string License { get; set; }

        public int JobAreaId { get; set; }
        public string JobAreaName { get; set; }

    }
}
