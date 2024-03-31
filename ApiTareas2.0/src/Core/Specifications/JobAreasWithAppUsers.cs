using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specifications
{
    public class JobAreasWithAppUsers : BaseSpecification<JobArea>
    {
        public JobAreasWithAppUsers()
        {
            AddInclude(x => x.AppUsers);
            //Si tuviera otra relacion la pondria aqui de la misma manera que el AddInclude de linea 14
        }

        public JobAreasWithAppUsers(int id) : base( x => x.Id == id)
        {
            AddInclude(x => x.AppUsers);
        }

        
    }
}