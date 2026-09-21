using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Natural")]
public class Natural : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Column("apellidopaterno")]
    public string ApellidoPaterno { get; set; } = string.Empty;
    
    [Column("apellidomaterno")]
    public string ApellidoMaterno { get; set; } = string.Empty;
    
    [Column("genero")]
    public string Genero { get; set; } = string.Empty;
    
    [Column("documentoidentidad")]
    public string DocumentoIdentidad { get; set; } = string.Empty;
    
    [Column("fechanacimiento")]
    public DateTime FechaNacimiento { get; set; }
}