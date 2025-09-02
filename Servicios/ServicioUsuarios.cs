using Microsoft.AspNetCore.Identity;

namespace AppMultiUsos.Servicios
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<IdentityUser> userManager;

        public ServicioUsuarios(IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<string> ObtenerUsuarioId()
        {



            var email = httpContextAccessor.HttpContext!.User
                .Claims.FirstOrDefault(x => x.Type == "email")!.Value;

            if (email == null)
            {
                throw new ApplicationException("No esta autenticado");
            }

            var usuario = await userManager.FindByEmailAsync(email);

            if (usuario == null)
            {
                throw new ApplicationException("No se encontro ese correo");

            }

            return usuario!.Id;
        }
    }
}
