using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF.Models; 

public class categories
{   [JsonIgnore]
    public virtual ICollection<Task> Tasks{ get; set; }
    public string Descripcion { get; set; }
    public string Nombre { get; set; }

    [Key]
    public Guid CategoriaId { get; set; }
}