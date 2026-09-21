using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Barrio")]
public class Barrio : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("nombrebarrio")]
    public string NombreBarrio { get; set; } = string.Empty;

    [Column("fechafundacion")]
    public DateTime? FechaFundacion { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("zona_id")]
    public long? ZonaId { get; set; }

    // Propiedad de navegación (no se persiste)
    [JsonIgnore] public Zona? Zona { get; set; }
}
