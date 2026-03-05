using Aula01.Data;
using Aula01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy => 
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddScoped<TarefaService>();

// Customizar os Data Annotations

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(
                k => k.Key,
                v => v.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );
        return new BadRequestObjectResult(new
        {
            message = "Falha de valida��o.",
            errors
        });
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Api - To Do List")
               .WithTheme(ScalarTheme.Moon)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

}

app.UseCors("DevCors");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
