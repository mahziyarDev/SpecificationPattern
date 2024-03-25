﻿namespace SpecificationPattern.Entity;

public class UserRole : BaseEntity<int>
{
    public User User { get; set; }
    public int UserId { get; set; }

    public Role Role { get; set; }
    public int RoleId { get; set; }
    
}