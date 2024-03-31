using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specifications
{
    public class JobTasksWithAppUsers : BaseSpecification<JobTask>
    {
        
        public JobTasksWithAppUsers()
        {
            AddInclude(y => y.AppUser.JobArea);
            AddInclude(x => x.AppUser);
            AddInclude(z => z.CommentsLists);
            //Si tuviera otra relacion la pondria aqui de la misma manera que el AddInclude de linea 14
        }

        public JobTasksWithAppUsers(int id) : base( x => x.Id == id)
        {
            AddInclude(y => y.AppUser.JobArea);
            AddInclude(x => x.AppUser);
            AddInclude(z => z.CommentsLists);
        }

    }
}