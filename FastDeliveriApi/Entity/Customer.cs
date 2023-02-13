using FastDeliveriApi.Repositories;
using FastDeliveriApi.Repositories.Interfaces;

namespace FastDeliveriApi.Entity;
public class Customer : IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }

    public DateTime CreatedOnUtc { get; set; }
     public DateTime? ModifiedOnUtc { get; set; }
}