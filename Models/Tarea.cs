using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF.Models;

public class Tarea
{
    //[Key]
    public Guid TareaId { get; set; }
    
    //[ForeignKey("CategoriaId")]
    public  Guid CategoriaId { get; set; }
    
    //[Required]
    //[MaxLength(200)]
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Estado Estado { get; set; }
    
    //Permite traer la informacion de la categoria asociada con la tarea
    public virtual Categoria Categoria { get; set; }
    
    //[NotMapped]
    public string resumen { get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}

public enum Estado
{
    PorHacer,
    EnProceso,
    Hecha
}