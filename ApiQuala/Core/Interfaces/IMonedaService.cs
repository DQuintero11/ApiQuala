using ApiQuala.Core.Domain.Entities;

namespace ApiQuala.Core.Interfaces
{
    public interface IMonedaService
    {
        Task<IEnumerable<Moneda>> GetAllMonedasAsync();
    }
}
