using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using ApiQuala.Core.Interfaces;
using ApiQuala.Core.Domain.Entities;
using System.Data.SqlClient;
using ApiQuala.Infraestructure.Security;

namespace ApiQuala.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _connectionString;
        private readonly IDataBaseService _dataBaseService;

        public AuthService(IConfiguration configuration , IDataBaseService dataBaseService)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _dataBaseService = dataBaseService ?? throw new ArgumentNullException(nameof(dataBaseService));
        }

        public async Task<Users> ValidarUsuarioAsync(string usuarioNombre, string contraseña)
        {

            var usuario  =    await _dataBaseService.ValidateLogin(usuarioNombre);
            if (usuario == null)
                return null;

            if (ValidarContraseña(contraseña, usuario.password))
            {
                return usuario;
            }
            return null;


        }
        private bool ValidarContraseña(string contraseñaIngresada, string contraseñaHash)
        {
            return contraseñaIngresada == contraseñaHash;
        }
    }
}
