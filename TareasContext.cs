using Microsoft.EntityFrameworkCore;
using ProjectEF.Models;

namespace ProjectEF;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    
    public TareasContext(DbContextOptions<TareasContext> options): base(options){}

    
    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("1f14e96d-3e94-46f0-b152-e93064084e39"),
            Nombre = "Actividades pendientes",
            Peso = 20
        });
        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("1f14e96d-3e94-46f0-b152-e93064023e39"),
            Nombre = "Actividades personales",
            Peso = 50
        });
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("1f14e23d-3e94-46f0-b152-e93064084e39"),
            CategoriaId = Guid.Parse("1f14e96d-3e94-46f0-b152-e93064084e39"),
            Titulo = "Pagos de servicios publicos",
            PrioridadTarea = Prioridad.Media,
            FechaCreacion = DateTime.Now,
            Estado = Estado.PorHacer
        });
        
        tareasInit.Add(new Tarea()
        {
            TareaId = Guid.Parse("1f14e23d-3e94-46f0-b152-e93064084e12"),
            CategoriaId = Guid.Parse("1f14e96d-3e94-46f0-b152-e93064023e39"),
            Titulo = "Terminar de ver peliculas en netflix",
            PrioridadTarea = Prioridad.Baja,
            FechaCreacion = DateTime.Now,
            Estado = Estado.PorHacer
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Property(p => p.Estado);
            tarea.Ignore(p => p.resumen);

            tarea.HasData(tareasInit);

        });
    }
}