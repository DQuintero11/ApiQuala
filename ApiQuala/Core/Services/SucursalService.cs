using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using ApiQuala.Infraestructure;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiQuala.Core.Services
{

    public class SucursalService : ISucursalesService
    {
        private readonly IDataBaseService _dataBaseService;


        public SucursalService(IConfiguration configuration, IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService ?? throw new ArgumentNullException(nameof(dataBaseService));

        }



        public async Task<IEnumerable<SucursalDto>> GetAllSucursalesAsync()
        {


            return await _dataBaseService.GetAllSucursalesAsync();

        }

        public async Task<Sucursal> GetSucursalByIdAsync(int id)
        {

            return await _dataBaseService.GetSucursalByIdAsync(id);



        }

        public async Task<int> AddSucursalAsync(Sucursal sucursal)
        {
            return await _dataBaseService.AddSucursalAsync(sucursal);

        }

        public async Task<int> UpdateSucursalAsync(Sucursal sucursal)
        {
            return await _dataBaseService.UpdateSucursalAsync(sucursal);


        }

        public async Task<int> DeleteSucursalAsync(int id)
        {
            return await _dataBaseService.DeleteSucursalAsync(id);


        }





    }
}