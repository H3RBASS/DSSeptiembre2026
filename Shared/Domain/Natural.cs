using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Natural")]
public class Natural : BaseModel
{
    // El id es la clave primaria y a la vez la FK hacia Cliente.id,
    // por eso debe insertarse explícitamente (shouldInsert: true).
    [PrimaryKey("id", true)]
    public long Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Column("apellidopaterno")]
    public string? ApellidoPaterno { get; set; }

    [Column("apellidomaterno")]
    public string? ApellidoMaterno { get; set; }

    [Column("genero")]
    public string? Genero { get; set; }

    [Column("documentoidentidad")]
    public string? DocumentoIdentidad { get; set; }

    [Column("fechanacimiento")]
    public DateTime? FechaNacimiento { get; set; }

    // Propiedades de navegación (no se persisten)
    [JsonIgnore] public Cliente? Cliente { get; set; }

    [JsonIgnore]
    public string NombreCompleto =>
        string.Join(" ", new[] { Nombre, ApellidoPaterno, ApellidoMaterno }
            .Where(p => !string.IsNullOrWhiteSpace(p)));
}
