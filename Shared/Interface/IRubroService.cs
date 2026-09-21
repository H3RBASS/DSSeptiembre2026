using DSSeptiembre.Shared.Domain;

namespace DSSeptiembre.Shared.Interface;

public interface IRubroService
{
    Task<List<Rubro>> GetAllAsync();
    Task<Rubro> CreateAsync(Rubro rubro);
    Task<Rubro> UpdateAsync(Rubro rubro);
    Task DeleteAsync(long id);
}
