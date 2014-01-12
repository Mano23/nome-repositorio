using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;

namespace Pregao.Servico
{
    public class ProdutoServico
    {
        private readonly ProdutoRepositorio repositorio;

        public ProdutoServico()
        {
            repositorio = new ProdutoRepositorio();
        }

        public void Salvar(Produto produto)
        {
            repositorio.Salvar(produto);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Produto> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Produto ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }

        public List<string> ListarTodosLeilao()
        {
            return repositorio.ListarTodosLeilao();
        }
    }
}
