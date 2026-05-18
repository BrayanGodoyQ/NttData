using RetoTecnico.src.Models;

namespace RetoTecnico.src.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaResponse>> ObtenerDiezPersonasAsync();
    }
}