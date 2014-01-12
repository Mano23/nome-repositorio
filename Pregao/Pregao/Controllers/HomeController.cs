using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pregao.Dominio;
using Pregao.Login;
using Pregao.Servico;
using System.Web.Security;
using AutoMapper;


namespace Pregao.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult entrar()
        {
            Models.LoginModel usuario = new Models.LoginModel();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Logar(Models.LoginModel usuario)
        {
            Usuarios model = new Usuarios();

            Mapper.CreateMap<Models.LoginModel, Usuarios>();
            Mapper.DynamicMap<Models.LoginModel, Usuarios>(usuario, model);

            if(UsuarioRepo.AutenticarUsuario(model.Email,model.Senha) == false)
            {
                ModelState.AddModelError("","O nome de usuário ou a senha informada estão incorretos");
                //ViewBag.msg_Erro = "O nome de usuário e ou a senha estão incorretos";
                return RedirectToAction("entrar", "Home");
            }

            ViewBag.msg_Erro = null;
            return RedirectToAction("iniciousuario", "usuario", new { area = "Usuario" });
        }

        [HttpGet]
        public ActionResult cadastrar()
        {
            Usuarios usuario = new Usuarios();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult cadastrar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                var appUsuario = new  UsuarioServico();
                usuario.PermissaoID = 2;
                appUsuario.Salvar(usuario);
                //Irá setar um cookie encriptado com o Login do usuário autenticado
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                return RedirectToAction("iniciousuario", "usuario", new { area = "Usuario" });
            }
            return View(usuario);
        }

        

        public ActionResult LoginUnico(string email)
        {
            var appUsuario = new UsuarioServico();

            return Json(appUsuario.ListarTodos().All(x => x.Email.ToLower() != email.ToLower()), JsonRequestBehavior.AllowGet);
        }

    }
}
