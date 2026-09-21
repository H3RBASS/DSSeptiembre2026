using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Rubros")]
public class Rubro : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    
    [Column("nombrerubro")]
    public string NombreRubro { get; set; } = string.Empty;
}
