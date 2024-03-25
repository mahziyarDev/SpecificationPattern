using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Data;
using SpecificationPattern.Entity;
using SpecificationPattern.Specification;

namespace SpecificationPattern.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
   
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// get all users
    /// </summary>
    /// <returns></returns>
    public async Task<List<User>> GetAllUser() =>
        await _context.Users.ToListAsync();


    /// <summary>
    /// get User By Filter  Use SpecificationPattern
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    public async Task<List<User>> GetUserByFilter(Specification<User> specification) =>
        await SpecificationQueryBuilder
            .GetQuery(_context.Users , specification)
            .ToListAsync();


	/// <summary>
	/// get UserRole By Filter  Use SpecificationPattern
	/// </summary>
	/// <param name="specification"></param>
	/// <returns></returns>
	public async Task<List<UserRole>> GetUserRoleByFilter(Specification<UserRole> specification)=>
		await SpecificationQueryBuilder
		   .GetQuery(_context.UserRoles, specification)
		   .ToListAsync();
	

	//public Task<List<UserRole>> GetRoleByFilter(Specification<UserRole> specification) =>
	//		await SpecificationQueryBuilder
	//		.GetQuery(_context.UserRoles, specification)
	//		.ToListAsync();




}