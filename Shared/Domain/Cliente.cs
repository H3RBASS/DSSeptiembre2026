using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Cliente")]
public class Cliente : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("direccion")]
    public string? Direccion { get; set; }

    [Column("telefono")]
    public string? Telefono { get; set; }

    [Column("nit")]
    public string? Nit { get; set; }

    [Column("rubro_id")]
    public long? RubroId { get; set; }

    [Column("barrio_id")]
    public long? BarrioId { get; set; }

    // Propiedades de navegación (no se persisten, se llenan en memoria)
    [JsonIgnore] public Rubro? Rubro { get; set; }
    [JsonIgnore] public Barrio? Barrio { get; set; }
    [JsonIgnore] public Natural? Natural { get; set; }
    [JsonIgnore] public Juridico? Juridico { get; set; }
}
