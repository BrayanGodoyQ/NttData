using RetoTecnico.src.Services;
using RetoTecnico.src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configurar CORS para que tu Frontend pueda consumir la API sin bloqueos
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Registro del Typed Client con manejo de Resiliencia Básica
builder.Services.AddHttpClient<IPersonaService, PersonaService>(client =>
{
    var baseUrl = builder.Configuration["RandomUserApi:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl ?? throw new InvalidOperationException("La BaseUrl no está configurada en appsettings.json."));
    client.Timeout = TimeSpan.FromSeconds(10); // Evita hilos bloqueados si el proveedor externo se cae
});

var app = builder.Build();

//Configurar el pipeline de la aplicación (Middlewares)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Habilitar la política de CORS que configuramos arriba
app.UseCors("PermitirFrontend");

app.UseAuthorization();

// Mapear los controladores de nuestra arquitectura (PersonaController)
app.MapControllers();

app.Run();