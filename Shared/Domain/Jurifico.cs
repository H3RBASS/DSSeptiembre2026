using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Juridico")]
public class Juridico : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    
    [Column("nombreempresa")]
    public string NombreEmpresa { get; set; } = string.Empty;
   
    [Column("representantelegal")]
    public string RepresentanteLegal { get; set; } = string.Empty;
}