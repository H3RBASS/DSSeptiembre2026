using DSSeptiembre.Shared.Domain;
using DSSeptiembre.Shared.Interface;
using Supabase;

namespace DSSeptiembre.Shared.Service;

public class ClienteNaturalService : IClienteNaturalService
{
    private readonly Client _supabase;

    public ClienteNaturalService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Natural>> GetAllAsync()
    {
        var naturales = (await _supabase.From<Natural>().Get()).Models;
        var clientes = (await _supabase.From<Cliente>().Get()).Models;
        var rubros = (await _supabase.From<Rubro>().Get()).Models;
        var barrios = (await _supabase.From<Barrio>().Get()).Models;
        var zonas = (await _supabase.From<Zona>().Get()).Models;

        Componer(naturales, clientes, rubros, barrios, zonas);

        return naturales.OrderBy(n => n.NombreCompleto).ToList();
    }

    public async Task<Natural?> GetByIdAsync(long id)
    {
        var filtro = new Dictionary<string, string> { ["id"] = id.ToString() };

        var natural = (await _supabase.From<Natural>().Match(filtro).Get()).Models.FirstOrDefault();
        if (natural is null)
        {
            return null;
        }

        var clientes = (await _supabase.From<Cliente>().Match(filtro).Get()).Models;
        var rubros = (await _supabase.From<Rubro>().Get()).Models;
        var barrios = (await _supabase.From<Barrio>().Get()).Models;
        var zonas = (await _supabase.From<Zona>().Get()).Models;

        Componer(new List<Natural> { natural }, clientes, rubros, barrios, zonas);

        return natural;
    }

    public async Task<Natural> CreateAsync(Cliente cliente, Natural natural)
    {
        Normalizar(cliente);

        var clienteCreado = (await _supabase.From<Cliente>().Insert(cliente)).Models.First();

        natural.Id = clienteCreado.Id;
        var naturalCreado = (await _supabase.From<Natural>().Insert(natural)).Models.First();

        return naturalCreado;
    }

    public async Task<Natural> UpdateAsync(Cliente cliente, Natural natural)
    {
        Normalizar(cliente);

        await _supabase.From<Cliente>().Update(cliente);
        var naturalActualizado = (await _supabase.From<Natural>().Update(natural)).Models.First();

        return naturalActualizado;
    }

    public async Task DeleteAsync(long id)
    {
        // El borrado en cascada (ON DELETE CASCADE) elimina la fila de Natural.
        var filtro = new Dictionary<string, string> { ["id"] = id.ToString() };
        await _supabase.From<Cliente>().Match(filtro).Delete();
    }

    public async Task<int> CountNaturalesAsync()
    {
        return (await _supabase.From<Natural>().Get()).Models.Count;
    }

    public async Task<int> CountJuridicosAsync()
    {
        return (await _supabase.From<Juridico>().Get()).Models.Count;
    }

    private static void Componer(
        List<Natural> naturales,
        List<Cliente> clientes,
        List<Rubro> rubros,
        List<Barrio> barrios,
        List<Zona> zonas)
    {
        var clientesPorId = clientes.ToDictionary(c => c.Id);
        var rubrosPorId = rubros.ToDictionary(r => r.Id);
        var zonasPorId = zonas.ToDictionary(z => z.Id);
        var barriosPorId = barrios.ToDictionary(b => b.Id);

        foreach (var natural in naturales)
        {
            if (!clientesPorId.TryGetValue(natural.Id, out var cliente))
            {
                continue;
            }

            if (cliente.RubroId is long rubroId && rubrosPorId.TryGetValue(rubroId, out var rubro))
            {
                cliente.Rubro = rubro;
            }

            if (cliente.BarrioId is long barrioId && barriosPorId.TryGetValue(barrioId, out var barrio))
            {
                if (barrio.ZonaId is long zonaId && zonasPorId.TryGetValue(zonaId, out var zona))
                {
                    barrio.Zona = zona;
                }

                cliente.Barrio = barrio;
            }

            natural.Cliente = cliente;
        }
    }

    private static void Normalizar(Cliente cliente)
    {
        cliente.Direccion = VacioANulo(cliente.Direccion);
        cliente.Telefono = VacioANulo(cliente.Telefono);
        cliente.Nit = VacioANulo(cliente.Nit);
    }

    private static string? VacioANulo(string? valor)
    {
        return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
    }
}
