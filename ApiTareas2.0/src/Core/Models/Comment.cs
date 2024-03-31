using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }


        public AppUser AppUser { get; set; }
        public int  AppUserId { get; set; }

        public JobTask JobTask { get; set; }

        public int JobTaskNewId { get; set; }
    }
}
