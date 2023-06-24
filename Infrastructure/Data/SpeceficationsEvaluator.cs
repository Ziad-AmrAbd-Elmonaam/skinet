using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specefications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpeceficationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable <TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecefications<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria !=null)
            {
                query=query.Where(spec.Criteria);
            }
            query=spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
    }
}