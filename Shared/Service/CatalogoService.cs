using DSSeptiembre.Shared.Domain;
using DSSeptiembre.Shared.Interface;
using Supabase;

namespace DSSeptiembre.Shared.Service;

public class CatalogoService : ICatalogoService
{
    private readonly Client _supabase;

    public CatalogoService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Rubro>> GetRubrosAsync()
    {
        var response = await _supabase.From<Rubro>().Get();
        return response.Models.OrderBy(r => r.NombreRubro).ToList();
    }

    public async Task<List<Barrio>> GetBarriosAsync()
    {
        var response = await _supabase.From<Barrio>().Get();
        return response.Models.OrderBy(b => b.NombreBarrio).ToList();
    }

    public async Task<List<Zona>> GetZonasAsync()
    {
        var response = await _supabase.From<Zona>().Get();
        return response.Models.OrderBy(z => z.NombreZona).ToList();
    }
}
