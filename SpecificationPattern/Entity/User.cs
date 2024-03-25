namespace SpecificationPattern.Entity;

public class User : BaseEntity<int>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public byte Age { get; set; }
    public string FullAddress { get; set; }
    
    public List<UserRole> UserRoles { get; set; }
}