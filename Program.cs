using earrings;
using earrings.Components;
using earrings.Data;
using earrings.Models;
using earrings.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables();

builder.Services.AddDbContext<EarringsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EarringsDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Earrings API V1");
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Define endpoints
app.MapGet("/api/earrings", async (IProductService productService) =>
{
    var earrings = await productService.GetEarrings();
    return Results.Ok(earrings);
});

app.MapGet("/api/earrings/{id}", async (IProductService productService, Guid id) =>
{
    var earrings = await productService.GetEarrings(id);
    if (earrings == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(earrings);
});

app.MapPost("/api/earrings", async (IProductService productService, Earrings earrings) =>
{
    var newEarrings = await productService.AddEarrings(earrings);
    return Results.Created($"/api/earrings/{newEarrings.Id}", newEarrings);
});

app.MapPut("/api/earrings/{id}", async (IProductService productService, Guid id, Earrings earrings) =>
{
    if (id != earrings.Id)
    {
        return Results.BadRequest();
    }

    var updatedEarrings = await productService.UpdateEarrings(earrings);
    return Results.Ok(updatedEarrings);
});

app.MapDelete("/api/earrings/{id}", async (IProductService productService, Guid id) =>
{
    var earrings = await productService.DeleteEarrings(id);
    if (earrings == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(earrings);
});

app.Run();




