using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Barrio")]
public class Barrio : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    
    [Column("nombrebarrio")]
    public string NombreBarrio { get; set; } = string.Empty;
    
    [Column("fechafundacion")]
    public DateTime FechaFundacion { get; set; }
    
    [Column("descripcion")]
    public string Descripcion { get; set; } = string.Empty;
    
    // Solo guardamos el ID de la Zona, no el objeto entero
    [Column("zona_id")]
    public int ZonaId { get; set; } 
}