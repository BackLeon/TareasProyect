using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<Tentity> where Tentity : class
    {
        public static IQueryable<Tentity> GetQuery(IQueryable<Tentity> inputQuery,
                ISpecification<Tentity> spec)
        {
            var query = inputQuery; //la entidad inputQuery es _context.Set<T>().AsQuery();

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // por ejemplo esta expresion lambda p => p.ProductTypeId == id;
            }

            //Esto es igual a .Include( x => x.AppUsuarios).Include(x => x.JobAreas)
            query = spec.Includes.Aggregate(query, (current, include) =>
                 current.Include(include));

            return query;
        }
    }
}