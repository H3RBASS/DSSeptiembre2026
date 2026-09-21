using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("Cliente")]
public class Cliente : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("direccion")]
    public string Direccion { get; set; } = string.Empty;

    [Column("telefono")]
    public string Telefono { get; set; } = string.Empty;

    [Column("nit")]
    public string Nit { get; set; } = string.Empty;
    
    // Solo los IDs de las relaciones
    
    [Column("rubro_id")]
    public int? RubroId { get; set; }
    
    [Column("barrio_id")]
    public int? BarrioId { get; set; }
}