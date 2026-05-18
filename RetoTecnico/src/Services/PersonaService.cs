using RetoTecnico.src.Services.Interfaces;
using RetoTecnico.src.Models.Dtos;
using RetoTecnico.src.Models;

namespace RetoTecnico.src.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PersonaService> _logger;
        private readonly string _endpoint;

        public PersonaService(HttpClient httpClient, IConfiguration configuration, ILogger<PersonaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _endpoint = configuration["RandomUserApi:Endpoint"] ?? string.Empty;
        }

        public async Task<IEnumerable<PersonaResponse>> ObtenerDiezPersonasAsync()
        {
            try
            {
                var apiResponse = await _httpClient.GetFromJsonAsync<RandomUserApiResponse>(_endpoint);
                
                if (apiResponse?.Results == null || !apiResponse.Results.Any())
                {
                    _logger.LogWarning("La API de RandomUser no devolvió resultados.");
                    return Enumerable.Empty<PersonaResponse>();
                }

                return apiResponse.Results.Select(user => new PersonaResponse
                {
                    Nombre = $"{user.Name.Title} {user.Name.First} {user.Name.Last}".Trim(),
                    Genero = user.Gender,
                    Ubicacion = $"{user.Location.City}, {user.Location.Country}",
                    CorreoElectronico = user.Email,
                    FechaNacimiento = user.Dob.Date.ToString("yyyy-MM-dd"),
                    Fotografia = user.Picture.Large
                });
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "Error de comunicación con el proveedor externo de RandomUser.");
                throw; 
            }
        }
    }
}