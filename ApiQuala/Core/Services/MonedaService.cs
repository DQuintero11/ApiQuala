using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using ApiQuala.Infraestructure;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiQuala.Core.Services
{

    public class MonedaService : IMonedaService
    {
        private readonly IDataBaseService _dataBaseService;


        public MonedaService(IConfiguration configuration, IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService ?? throw new ArgumentNullException(nameof(dataBaseService));

        }



        public async Task<IEnumerable<Moneda>> GetAllMonedasAsync()
        {


            return await _dataBaseService.GetAllMonedasAsync();

        }

    





    }
}