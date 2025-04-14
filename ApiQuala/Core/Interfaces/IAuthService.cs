using ApiQuala.Core.Domain.Entities;

namespace ApiQuala.Core.Interfaces
{

        public interface IAuthService
        {
            Task<Users> ValidarUsuarioAsync(string usuarioNombre, string contraseña);
        }
}
