using System.Linq.Expressions;
using SpecificationPattern.Entity;

namespace SpecificationPattern.Specification;

public class Specification<TEntity>
    where TEntity:BaseEntity<int>
{
    public Specification()
    {
        
    }
    
    public Specification(Expression<Func<TEntity,bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<TEntity, bool>>? Criteria { get; }

	#region IncludesExpression
	public List<Expression<Func<TEntity, object>>>? Includes { get; } = new();

	protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
		Includes?.Add(includeExpression);
	#endregion


	#region OrderByExpression
	public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

	protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExperssion) =>
		OrderBy = orderByExperssion;
	#endregion






}