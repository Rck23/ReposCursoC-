using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models; 

public class task
{
    [Key]
    public Guid TaskId { get; set; }
    public DateTime FechaCreacion { get; set; }
    
    public Priority PriorityTask { get; set; }
    
    public string Descripcion { get; set; }

    [NotMapped]
    public string Resumen { get; set; }

    [Required]
    public string Titulo { get; set; }
    
    [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }

    public virtual categories Categories{ get; set; }
}

public enum Priority{
    Baja,
    Media,
    Alta
}