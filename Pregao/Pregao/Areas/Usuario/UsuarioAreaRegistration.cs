using System.Web.Mvc;

namespace Pregao.Areas.Usuario
{
    public class UsuarioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Usuario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Usuario_default",
                "Usuario/{controller}/{action}/{id}",
                new { controller = "usuario", action = "iniciousuario", id = UrlParameter.Optional },
                namespaces: new[] { "Pregao.Areas.Usuario.Controllers" }
            );
        }
    }
}
