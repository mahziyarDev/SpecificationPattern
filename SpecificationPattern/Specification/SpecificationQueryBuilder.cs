using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Entity;

namespace SpecificationPattern.Specification;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
        Specification<TEntity> specification) where TEntity : BaseEntity<int>
    {
        var query = inputQuery;
        
        //for conditionals in where
        if (specification.Criteria != null)
            query = query.Where(specification.Criteria);

        // for include in entity
        if (specification.Includes != null)
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

        //for orderBy
        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);

        return query;
    }
}