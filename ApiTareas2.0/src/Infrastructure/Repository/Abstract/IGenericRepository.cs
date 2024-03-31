using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;

namespace Infrastructure.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetEntityByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllNosSpecAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        
        
    }
}