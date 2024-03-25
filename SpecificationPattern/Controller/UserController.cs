using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SpecificationPattern.Repository;
using SpecificationPattern.Specification;

namespace SpecificationPattern.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> User()
    {
        return Ok(await _userRepository.GetAllUser());
    }

    [HttpGet("name")]
    public async Task<IActionResult> FilterByName(string name)
    {
        var result = await _userRepository.GetUserByFilter(new GetUserWithFilterNameSpecification(name));
        return Ok(result);
    }

    [HttpGet("RoleTitlt")]
    public async Task<IActionResult> GetUserRolesTitles()
    {
        var userId = 1;

        var userRoles = await _userRepository.GetUserByFilter(new GetUserRoleIdsSpecisication(userId));

        var RolesId = userRoles.SelectMany(x => x.UserRoles.Select(i => i.RoleId)).ToList();

        var RoleTitel = (await _userRepository.GetUserRoleByFilter(new GetRoleTitlesWithIdsSpesification(RolesId)))
            .Select(x=>x.Role.RoleName).ToList();

    

        return Ok(RoleTitel);
    }

}