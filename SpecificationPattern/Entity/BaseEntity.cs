using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SpecificationPattern.Entity;

public class BaseEntity<TKey>
{
   
    public TKey Id { get; set; }
    public string CreateDate { get; set; }
}