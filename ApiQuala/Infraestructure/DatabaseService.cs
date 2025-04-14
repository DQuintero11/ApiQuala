using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using ApiQuala.Core.Domain.Entities;
using ApiQuala.Core.Interfaces;
using System.Data;
using System.Data.Common;

namespace ApiQuala.Infraestructure
{
    public class DatabaseService : IDataBaseService
    {

        private readonly IDbConnection _dbConnection;

        public DatabaseService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Users> ValidateLogin(string usuarioNombre)
        {
            const string storedProcedure = "DQ_SP_ObtenerUsuarioPorNombre";

            var parameters = new { Usuario = usuarioNombre };

            return await _dbConnection.QuerySingleOrDefaultAsync<Users>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        /*****/
        public async Task<IEnumerable<Moneda>> GetAllMonedasAsync()
        {
            return await _dbConnection.QueryAsync<Moneda>("DQ_sp_ObtenerMonedas", commandType: CommandType.StoredProcedure);
        }


        /*****/

        public async Task<IEnumerable<SucursalDto>> GetAllSucursalesAsync()
        {
            return  await _dbConnection.QueryAsync<SucursalDto>("DQ_sp_ObtenerSucursales", commandType: CommandType.StoredProcedure);
        }
    

        public async Task<Sucursal> GetSucursalByIdAsync(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Sucursal>(
            "DQ_sp_ObtenerSucursalPorId",
            new { Id = id },
            commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddSucursalAsync(Sucursal sucursal)
        {
          return  await _dbConnection.ExecuteAsync("DQ_sp_CrearSucursal", new
            {
                sucursal.Codigo,
                sucursal.Descripcion,
                sucursal.Direccion,
                sucursal.Identificacion,
                sucursal.FechaCreacion,
                sucursal.IdMoneda
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateSucursalAsync(Sucursal sucursal)
        {
           return await _dbConnection.ExecuteAsync("DQ_sp_ActualizarSucursal", new
            {
                sucursal.Id,
                sucursal.Codigo,
                sucursal.Descripcion,
                sucursal.Direccion,
                sucursal.Identificacion,
                sucursal.FechaCreacion,
                sucursal.IdMoneda
           }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteSucursalAsync(int id)
        {

             return  await _dbConnection.ExecuteAsync("DQ_sp_EliminarSucursal", new { id = id }, commandType: CommandType.StoredProcedure);

        }




    }
}
