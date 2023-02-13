using FastDeliveriApi.Entity;

namespace FastDeliveriApi.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<IReadOnlyCollection<Customer>> GetAll();
    Task<Customer?> GetCustomerBiId(int id, CancellationToken cancellationToken );
    void Add(Customer customer);
    void Update(Customer customer);
}