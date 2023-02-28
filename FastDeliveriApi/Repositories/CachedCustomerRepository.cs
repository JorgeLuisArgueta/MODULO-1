using FastDeliveriApi.Entity;
using FastDeliveriApi.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FastDeliveriApi.Repositories;

public class CachedCustomerRepository : ICustomerRepository
{
    private readonly ICustomerRepository _decorated;
    private readonly IMemoryCache _memoryCache;
    public CachedCustomerRepository(ICustomerRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public void Add(Customer customer)
    {
        _memoryCache.Remove("GetAllCustomer");
        _decorated.Add(customer);
    }

    public async Task<IReadOnlyCollection<Customer>> GetAll() => 
    await _decorated.GetAll();

    public Task<Customer?> GetCustomerById(int id, CancellationToken cancellationToken)
    {
        string key = $"customer-{id}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry => {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                return _decorated.GetCustomerById(id, cancellationToken);
            });
    }

    public void Update(Customer customer) =>
    _decorated.Update(customer);
}