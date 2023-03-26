using System.ComponentModel.DataAnnotations;

namespace ProjectEF.Models;

public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }
    
    //[Required]
    //[MaxLength(150)]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    
    //Permite traer las tareas que están relacionadas con esta categoria
    public virtual ICollection<Tarea> Tareas { get; set; }
}