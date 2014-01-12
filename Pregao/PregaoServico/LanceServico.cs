using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;


namespace PregaoServico
{
    public class LanceServico
    {
        private readonly LanceRepositorio repositorio;

        public LanceServico()
        {
            repositorio = new LanceRepositorio();
        }

        public void Salvar(Lance lance)
        {
            repositorio.Salvar(lance);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Lance> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Lance ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
