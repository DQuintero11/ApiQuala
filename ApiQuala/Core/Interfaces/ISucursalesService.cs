using ApiQuala.Core.Domain.Entities;

namespace ApiQuala.Core.Interfaces
{
    public interface ISucursalesService
    {
        Task<IEnumerable<SucursalDto>> GetAllSucursalesAsync();
        Task<Sucursal> GetSucursalByIdAsync(int id);
        Task<int> AddSucursalAsync(Sucursal sucursal);
        Task<int> UpdateSucursalAsync(Sucursal sucursal);
        Task<int> DeleteSucursalAsync(int id);


    }
}
