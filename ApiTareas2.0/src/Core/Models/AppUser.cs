using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string License { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

        public JobArea JobArea { get; set; }

        public int JobAreaId { get; set; }

        public virtual ICollection<JobTask> JobTasksList { get; set; }

        public virtual ICollection<Comment> CommentsList { get; set; }

    }
}