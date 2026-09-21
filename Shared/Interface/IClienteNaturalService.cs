using DSSeptiembre.Shared.Domain;

namespace DSSeptiembre.Shared.Interface;

public interface IClienteNaturalService
{
    Task<List<Natural>> GetAllAsync();
    Task<Natural?> GetByIdAsync(long id);
    Task<Natural> CreateAsync(Cliente cliente, Natural natural);
    Task<Natural> UpdateAsync(Cliente cliente, Natural natural);
    Task DeleteAsync(long id);
    Task<int> CountNaturalesAsync();
    Task<int> CountJuridicosAsync();
}
