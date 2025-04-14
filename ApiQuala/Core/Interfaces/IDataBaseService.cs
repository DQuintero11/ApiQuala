using ApiQuala.Core.Domain.Entities;

namespace ApiQuala.Core.Interfaces
{
    public interface IDataBaseService
    {

        public Task<IEnumerable<SucursalDto>> GetAllSucursalesAsync();
        public Task<Sucursal> GetSucursalByIdAsync(int id);
        public Task<int> AddSucursalAsync(Sucursal sucursal);
        public Task<int> UpdateSucursalAsync(Sucursal sucursal);
        public Task<int> DeleteSucursalAsync(int id);



        public Task<IEnumerable<Moneda>> GetAllMonedasAsync();

        public Task<Users> ValidateLogin(string usuarioNombre);
    }
}
