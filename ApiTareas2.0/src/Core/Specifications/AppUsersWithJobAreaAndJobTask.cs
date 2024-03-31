using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specifications
{
    public class AppUsersWithJobAreaAndJobTask : BaseSpecification<AppUser>
    {
        public AppUsersWithJobAreaAndJobTask()
        {
            AddInclude(x => x.JobArea);
            AddInclude( x => x.JobTasksList);
            AddInclude( x => x.CommentsList);
            
            //Si tuviera otra relacion la pondria aqui de la misma manera que el AddInclude de linea 14
        }

        public AppUsersWithJobAreaAndJobTask(int id) : base( x => x.Id == id)
        {
            AddInclude(x => x.JobArea);
            AddInclude( x => x.JobTasksList);
            AddInclude(x => x.CommentsList);
        }
    }
}