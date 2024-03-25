using SpecificationPattern.Entity;

namespace SpecificationPattern.Specification
{
	public class GetUserRoleIdsSpecisication : Specification<User>
	{
		public GetUserRoleIdsSpecisication(int id):base(x=> x.Id == id)
		{

			AddInclude(x => x.UserRoles);

		}
	}
}
