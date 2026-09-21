using DSSeptiembre.Shared.Domain;

namespace DSSeptiembre.Shared.Interface;

public interface ICatalogoService
{
    Task<List<Rubro>> GetRubrosAsync();
    Task<List<Barrio>> GetBarriosAsync();
    Task<List<Zona>> GetZonasAsync();
}
