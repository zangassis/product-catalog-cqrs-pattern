using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Resources.Commands.Create;
using ProductCatalog.Resources.Commands.Delete;
using ProductCatalog.Resources.Commands.Update;
using ProductCatalog.Resources.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDBContext>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("product/get-all", async (IMediator _mediator) =>
{
    try
    {
        var command = new GetAllProductsQuery();
        var response = await _mediator.Send(command);
        return response is not null ? Results.Ok(response) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("product/get-by-id", async (IMediator _mediator, int id) =>
{
    try
    {
        var command = new GetProductByIdQuery() { Id = id };
        var response = await _mediator.Send(command);
        return response is not null ? Results.Ok(response) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("product/create", async (IMediator _mediator, Product product) =>
{
    try
    {
        var command = new CreateProductCommand()
        {
            Name = product.Name,
            Description = product.Description,
            Category = product.Category,
            Price = product.Price,
            Active = product.Active,
        };
        var response = await _mediator.Send(command);
        return response is not null ? Results.Ok(response) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});


app.MapPut("product/update", async (IMediator _mediator, Product product) =>
{
    try
    {
        var command = new UpdateProductCommand()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Category = product.Category,
            Price = product.Price,
            Active = product.Active,
        };
        var response = await _mediator.Send(command);
        return response is not null ? Results.Ok(response) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("product/delete", async (IMediator _mediator, int id) =>
{
    try
    {
        var command = new DeleteProductCommand() { Id = id };
        var response = await _mediator.Send(command);
        return response is not null ? Results.Ok(response) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();