using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Zona")]
public class Zona : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("nombrezona")]
    public string NombreZona { get; set; } = string.Empty;
}
