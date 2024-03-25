using SpecificationPattern.Entity;

namespace SpecificationPattern.Specification
{
	public class GetRoleTitlesWithIdsSpesification : Specification<UserRole>
	{
        public GetRoleTitlesWithIdsSpesification(List<int> ids) : base(x=>ids.Contains(x.Id))
        {
            AddInclude(x=>x.Role);
        }
    }
}
