using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Pregao.Login;


namespace Pregao.Areas.Usuario.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        public EmailController()
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.EnableSsl = true;
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = false;
            WebMail.From = "pregao.schiassi@gmail.com";//UsuarioRepo.GetUsuarioLogado().Email.ToLower();
            WebMail.UserName = "pregao.schiassi@gmail.com";
            WebMail.Password = "atividadesintegradoras";
        }

        [HttpGet]
        public ActionResult Envia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Envia(string assunto ,string mensagem)
        {
            
            WebMail.Send(WebMail.From.Trim(), assunto, mensagem + "<br/><br/><br/> Email: " + WebMail.From.Trim());
            ViewBag.nome = UsuarioRepo.GetUsuarioLogado().Nome;            
            return View("mensagemsucesso");
        }

    }
}
