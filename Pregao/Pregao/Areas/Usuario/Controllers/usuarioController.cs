using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pregao.Servico;
using Pregao.Dominio;
using Pregao.Util;
using System.Web.Security;
using Pregao.Login;
using AutoMapper;



namespace Pregao.Areas.Usuario.Controllers
{
    [Authorize]
    public class usuarioController : Controller
    {
        
        //
        // GET: /Usuario/usuario/

        public ActionResult iniciousuario()
        {

            ViewBag.nome = UsuarioRepo.GetUsuarioLogado().Nome;            
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            
            return View();
        }

        public ActionResult leiloesaberto()
        {
            int usuario = UsuarioRepo.GetUsuarioLogado().UsuarioID;
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();

            var applance = new LanceServico();
            //var lances = applance.ListarTodosNaoUsuarioID(2);

            var leiloes = appleilao.ListarTodos().OrderByDescending(x => x.DataCadastro);

            //var leilao = appleilao.ListarTodosAberto().OrderByDescending(x => x.DataCadastro);
            List<Leilao> leiloes2 = new List<Leilao>();
            foreach (var item in leiloes)
            {
                var lan = applance.ListarPorUsuarioLeilao(usuario, item.LeilaoID);
                if(lan == null)
                   leiloes2.Add(appleilao.ListarPorId(item.LeilaoID));
            }
           
    
            return View(leiloes2.FindAll(x => x.enmStatus == Leilao.enumStatusLeilao.Aberto).OrderByDescending(x => x.DataCadastro));
        }        

        [HttpGet]
        public ActionResult lanceget(int id)
        {
            //ViewBag.LeilaoId = id;
            
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            var leilao = appleilao.ListarTodos().FirstOrDefault(x => x.LeilaoID == id);

            
            var applance = new LanceServico();
            var lance = applance.ListarTodos().OrderBy(x => x.Valor).FirstOrDefault(x => x.LeilaoID == id);
            
            if (leilao == null)
                return HttpNotFound();

            ViewBag.Leilao = leilao;
            ViewBag.Lances = lance;

            var lancenovo = new Lance();
            
            return View(lancenovo);
        }

        [HttpPost, ActionName("lanceget")]
        [ValidateAntiForgeryToken]
        public ActionResult lancepost(Lance lan, int id)
        {
            int usuario = UsuarioRepo.GetUsuarioLogado().UsuarioID;
            decimal valor = 0;

            var applance = new LanceServico();  
            var lance = applance.ListarTodos().OrderBy(x => x.Valor).FirstOrDefault(x => x.LeilaoID == id);

            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            
            var leilao = appleilao.ListarTodos().FirstOrDefault(x => x.LeilaoID == id);
            if (leilao == null)
                return HttpNotFound();

            if (lance == null)
                valor = leilao.Valor;
            else
                valor = lance.Valor;

            if(lan.Valor == 0 || lan.Valor >= valor)
            {
                ModelState.AddModelError("","Preencha o campo valor corretamente");
            }

            if(ModelState.IsValid)
            {
                if (lan.Valor > 0 && lan.Valor < valor)
                {
                    lan.LeilaoID = id;
                    lan.UsuarioID = usuario;
                    lan.DataCadastro = DateTime.Now;
                    
                    applance.Salvar(lan);
                    return @RedirectToAction("iniciousuario");
                }
                else
                {
                    return @RedirectToAction("errol");
                }
            }

            

            ViewBag.Leilao = leilao;
            ViewBag.Lances = lance;

            var lancenovo = new Lance();

            return View(lancenovo);
        }

        public ActionResult errol()
        {
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            return View();
        }

        public ActionResult participando()
        {
            int usuario = UsuarioRepo.GetUsuarioLogado().UsuarioID;
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();

            var applance = new LanceServico();
            //var lances = applance.ListarTodosSoUsuarioID(2);
            var leiloes = appleilao.ListarTodos().OrderByDescending(x => x.DataCadastro);

            List<Leilao> leiloes2 = new List<Leilao>();
            foreach (var item in leiloes)
            {
                var lan = applance.ListarPorUsuarioLeilao(usuario, item.LeilaoID);
                if (lan != null)
                    leiloes2.Add(appleilao.ListarPorId(item.LeilaoID));
                //leiloes.Add(appleilao.ListarPorId(item.LeilaoID));
            }
            
            return View(leiloes2.FindAll(x => x.enmStatus == Leilao.enumStatusLeilao.Aberto));
        }

        [HttpGet]
        public ActionResult lenceget(int id)
        {
            //ViewBag.LeilaoId = id;

            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            var leilao = appleilao.ListarTodos().FirstOrDefault(x => x.LeilaoID == id);


            var applance = new LanceServico();
            var lance = applance.ListarTodos().OrderBy(x => x.Valor).FirstOrDefault(x => x.LeilaoID == id);

            if (leilao == null)
                return HttpNotFound();

            ViewBag.lin = "";
            ViewBag.Leilao = leilao;
            ViewBag.Lances = lance;

            var lancenovo = new Lance();

            return View(lancenovo);
        }

        [HttpPost, ActionName("lenceget")]
        [ValidateAntiForgeryToken]
        public ActionResult lencepost(Lance lan, int id)
        {
            int usuario = UsuarioRepo.GetUsuarioLogado().UsuarioID;
            var applance = new LanceServico();
            var lance = applance.ListarTodos().OrderBy(x => x.Valor).FirstOrDefault(x => x.LeilaoID == id);
            
            if (lan.Valor == 0 || lan.Valor >= lance.Valor)
            {
                ModelState.AddModelError("", "Preencha o campo valor corretamente");
            }

            if (ModelState.IsValid)
            {
                if (lan.Valor > 0 && lan.Valor < lance.Valor)
                {
                    lan.LeilaoID = id;
                    lan.UsuarioID = usuario;
                    lan.DataCadastro = DateTime.Now;

                    applance.Salvar(lan);
                    return @RedirectToAction("iniciousuario");
                }
                else
                {
                    return @RedirectToAction("errol");
                }
            }

            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();
            var leilao = appleilao.ListarTodos().FirstOrDefault(x => x.LeilaoID == id);
            if (leilao == null)
                return HttpNotFound();

            ViewBag.Leilao = leilao;
            ViewBag.Lances = lance;

            var lancenovo = new Lance();

            return View(lancenovo);
        }

        public ActionResult encerrados()
        {
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();

            var leilao = appleilao.ListarTodos().FindAll(x => x.enmStatus == Leilao.enumStatusLeilao.Encerrado);
            return View(leilao);

        }

        public ActionResult cancelados()
        {
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();

            var leilao = appleilao.ListarTodos().FindAll(x => x.enmStatus == Leilao.enumStatusLeilao.Cancelado);
            return View(leilao);

        }

        public ActionResult venci()
        {
            int usuario = UsuarioRepo.GetUsuarioLogado().UsuarioID;
            var appleilao = new LeilaoServico();
            appleilao.EncerrarLeilao();

            var applance = new LanceServico();
            var lances = applance.ListarTodos().FindAll(x => x.enmStatus == Lance.enumStatusEmpresa.Vencedor && x.UsuarioID == usuario).OrderBy(x => x.Valor);          
            
            List<Leilao> leiloes2 = new List<Leilao>();
            foreach (var item in lances)
            {
                var lan = appleilao.ListarPorId(item.LeilaoID);
                leiloes2.Add(lan);                
            }

            return View(leiloes2.OrderByDescending(x => x.DataFinalizacao));

        }

        public ActionResult ver(int id)
        {
            var applance = new LanceServico();
            var lance = applance.ListarTodos().FindAll(x => x.LeilaoID == id).OrderBy(x => x.Valor);

            var appleilao = new LeilaoServico();
            var leilao = appleilao.ListarTodos().FirstOrDefault(x => x.LeilaoID == id);
            ViewBag.leilao = leilao;

            return View(lance);
        }

        public ActionResult sair()
        {
            UsuarioRepo.Deslogar();
            return RedirectToAction("Index", "Home", new { area = "" });
            
        }

        [HttpGet]
        public ActionResult editar()
        {
            var usuario = UsuarioRepo.GetUsuarioLogado();
            Usuario.Models.UsuariosEditarModel model = new Models.UsuariosEditarModel();

            Mapper.CreateMap<Usuarios, Usuario.Models.UsuariosEditarModel>();
            Mapper.DynamicMap<Usuarios, Usuario.Models.UsuariosEditarModel>(usuario, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult editar(Usuario.Models.UsuariosEditarModel model)
        {
            Usuarios usuario = new Usuarios();
            if (ModelState.IsValid)
            {
                
                Mapper.CreateMap<Usuario.Models.UsuariosEditarModel, Usuarios>();
                Mapper.DynamicMap<Usuario.Models.UsuariosEditarModel, Usuarios>(model, usuario);

                var appUsuario = new UsuarioServico();                
                appUsuario.Salvar(usuario);                
                return RedirectToAction("iniciousuario", "usuario", new { area = "Usuario" });
            }
            return View(usuario);
        }

        

        

    }
}
