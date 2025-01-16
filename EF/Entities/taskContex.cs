using EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.Entities; 


public class taskContex: DbContext
{
    public taskContex(DbContextOptions<taskContex> options ): base(options){

    }

    public DbSet<categories> categories { get; set; }
    public DbSet<task> tasks { get;set; }

    protected override void OnModelCreating(ModelBuilder builder){ 

        builder.Entity<categories>(c => {
            c.ToTable("Categoria");
            c.HasKey(c => c.CategoriaId);

            c.Property(c => c.Nombre).IsRequired().HasMaxLength(80);

            c.Property(c => c.Descripcion).IsRequired().HasMaxLength(200 );


        });

        builder.Entity<task>(c => {
            c.ToTable("Tarea");
            c.HasKey(p => p.TaskId); 
            c.Ignore(p => p.Resumen);
            // c.HasOne(p => p.Categories).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoriaId);
        });
    }
}