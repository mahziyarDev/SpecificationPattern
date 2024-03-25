using Microsoft.AspNetCore.DataProtection.KeyManagement;
using SpecificationPattern.Entity;
using SpecificationPattern.Specification;

namespace SpecificationPattern.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUser();

    Task<List<User>> GetUserByFilter(Specification<User> specification);

	Task<List<UserRole>> GetUserRoleByFilter(Specification<UserRole> specification);
}