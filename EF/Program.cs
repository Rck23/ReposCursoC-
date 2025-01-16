using EF.Entities;
using EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<taskContex>(p => p.UseInMemoryDatabase("TaskDB"));

builder.Services.AddSqlServer<taskContex>("StringConnection");


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] taskContex dbContext) => {
    dbContext.Database.EnsureCreated();

    return Results.Ok("BD in memory!!");
}); 

app.MapGet("/api/tareas", async ([FromServices] taskContex dbContext) => {

    return Results.Ok(dbContext.tasks.Include(p => p.Categories));
}); 

app.MapPost("/api/tareas", async ([FromServices] taskContex dbContext, [FromBody] task tarea) => {
    tarea.TaskId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok("BD in memory!!");
}); 

app.MapPut("/api/tareas/{id}", async ([FromServices] taskContex dbContext, [FromBody] task tarea, [FromRoute] Guid id) => {

    var tareaActual = dbContext.tasks.Find(id); 

    if (tareaActual != null)
    { 
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PriorityTask = tarea.PriorityTask;
        tareaActual.Descripcion = tarea.Descripcion;
        return Results.Ok();
    }
    return Results.NotFound();
}); 


app.MapDelete("/api/tareas/{id}", async ([FromServices] taskContex dbContext, [FromBody] task tarea, [FromRoute] Guid id) => {

    var tareaActual = dbContext.tasks.Find(id); 

    if (tareaActual != null)
    { 
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
}); 

app.Run();
