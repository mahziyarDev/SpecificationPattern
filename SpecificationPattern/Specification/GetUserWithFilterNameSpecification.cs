using SpecificationPattern.Entity;

namespace SpecificationPattern.Specification;

public class GetUserWithFilterNameSpecification : Specification<User>
{
    public GetUserWithFilterNameSpecification(string name) :
        base(x=> x.Name.ToLower().Contains(name.ToLower()))
    {
        
    }
}