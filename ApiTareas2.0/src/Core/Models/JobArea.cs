using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class JobArea
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }
    }
}