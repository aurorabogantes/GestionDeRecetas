using GestionDeRecetas.BW.CU;
using GestionDeRecetas.BW.Interfaces.BW;
using GestionDeRecetas.BW.Interfaces.DA;
using GestionDeRecetas.DA.Acciones;
using GestionDeRecetas.DA.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AppContext = GestionDeRecetas.DA.Config.AppContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IGestionarRecetasBW, GestionarRecetaBW>();
builder.Services.AddTransient<IGestionarRecetasDA, GestionarRecetasDA>();

builder.Services.AddTransient<IGestionarIngredientesBW, GestionarIngredienteBW>();
builder.Services.AddTransient<IGestionarIngredienteDA, GestionarIngredientesDA>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
