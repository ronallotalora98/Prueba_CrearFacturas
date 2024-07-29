using Microsoft.Extensions.DependencyInjection;
using Prueba_Buscar_Facturas.Application.Interface;
using Prueba_Buscar_Facturas.Application.Services;
using Prueba_Buscar_Facturas.Domain.Interface;
using Prueba_Buscar_Facturas.Domain.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", options => options.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
});


string connectionString = "Server=RONALL_OTALORA\\SQLEXPRESS01;Database=LabDev;Trusted_Connection=True;;TrustServerCertificate=True;";
    //builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").ToString();

builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();


builder.Services.AddSingleton<IFacturaDomainService>(new FacturaDomainService(connectionString));
builder.Services.AddSingleton<IProductoDomainService>(new ProductoDomainService(connectionString));

// builder.Services.AddScoped<IFacturaDomainService, FacturaDomainService>(connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
