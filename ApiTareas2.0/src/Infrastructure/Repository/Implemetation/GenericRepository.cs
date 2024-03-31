using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implemetation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TareaDbContext _context;
        public GenericRepository(TareaDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllNosSpecAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }



        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}