using DSSeptiembre.Shared.Domain;
using DSSeptiembre.Shared.Interface;
using Supabase;

namespace DSSeptiembre.Shared.Service;

public class RubroService : IRubroService
{
    private readonly Client _supabase;

    public RubroService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Rubro>> GetAllAsync()
    {
        var response = await _supabase.From<Rubro>().Get();
        return response.Models.OrderBy(r => r.NombreRubro).ToList();
    }

    public async Task<Rubro> CreateAsync(Rubro rubro)
    {
        var response = await _supabase.From<Rubro>().Insert(rubro);
        return response.Models.First();
    }

    public async Task<Rubro> UpdateAsync(Rubro rubro)
    {
        var response = await _supabase.From<Rubro>().Update(rubro);
        return response.Models.First();
    }

    public async Task DeleteAsync(long id)
    {
        var filtro = new Dictionary<string, string> { ["id"] = id.ToString() };
        await _supabase.From<Rubro>().Match(filtro).Delete();
    }
}
