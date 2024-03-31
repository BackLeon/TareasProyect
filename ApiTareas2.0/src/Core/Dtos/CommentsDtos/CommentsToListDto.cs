using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.CommentsDtos
{
    public class CommentsToListDto
    {

        public string AppUserName { get; set; }
        public string AppUserLastName { get; set; }

        public string AppUserEmail { get; set;}

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
