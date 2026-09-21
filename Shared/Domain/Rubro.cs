using System.ComponentModel.DataAnnotations;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DSSeptiembre.Shared.Domain;

[Table("Rubro")]
public class Rubro : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Required(ErrorMessage = "El nombre del rubro es obligatorio.")]
    [Column("nombrerubro")]
    public string NombreRubro { get; set; } = string.Empty;
}
