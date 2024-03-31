using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class JobTask
    {   
        [Key]
        public int Id { get; set;}

        public string Radicado { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; } = false;

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

        public virtual ICollection<Comment> CommentsLists { get; set; } = new List<Comment>();

    }
}