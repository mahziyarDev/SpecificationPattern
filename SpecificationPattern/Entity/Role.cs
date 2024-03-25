namespace SpecificationPattern.Entity;

public class Role : BaseEntity<int>
{
    public string RoleName { get; set; }
    public string Description { get; set; }

    public List<UserRole> UserRoles { get; set; }
}