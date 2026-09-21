using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Juridico")]
public class Juridico : BaseModel
{
    // El id es la clave primaria y a la vez la FK hacia Cliente.id.
    [PrimaryKey("id", true)]
    public long Id { get; set; }

    [Column("nombreempresa")]
    public string NombreEmpresa { get; set; } = string.Empty;

    [Column("representantelegal")]
    public string RepresentanteLegal { get; set; } = string.Empty;

    // Propiedad de navegación (no se persiste)
    [JsonIgnore] public Cliente? Cliente { get; set; }
}
