using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pregao.Dominio;
using Pregao.Servico;
using Pregao.Util;


namespace Pregao.Areas.Admin.Controllers
{
    public class LeilaoAdminController : Controller
    {
        //
        // GET: /Admin/Leilao/
        ProdutoServico ProdutoServico;
        public LeilaoAdminController()
        {
            ProdutoServico = new ProdutoServico();    
        }
        public ActionResult Cadastrar()
        {
            var tste = ProdutoServico.ListarTodos().ToSelectList(e => e.Nome, x => x.ProdutoID.ToString(), "Selecione a empresa", string.Empty);
            ViewBag.DropProdutos = ProdutoServico.ListarTodos().ToSelectList(e => e.Nome, x=>x.ProdutoID.ToString(), "Selecione a empresa", string.Empty);
            var leilao = new Leilao();
            return View(leilao);
        
        }
        [HttpPost]
        public ActionResult Cadastrar(Leilao leilao)
        {
            
            var tste = ProdutoServico.ListarTodos().ToSelectList(e => e.Nome, x => x.ProdutoID.ToString(), "Selecione a empresa", string.Empty);
            ViewBag.DropProdutos = ProdutoServico.ListarTodos().ToSelectList(e => e.Nome, x => x.ProdutoID.ToString(), "Selecione a empresa", string.Empty);            
            return View();
        }

    }
}
