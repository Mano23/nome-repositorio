using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Pregao.Dominio;
using Pregao.RepositorioADO;



namespace Pregao.Servico
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

        public Lance ListarPorIdLeilao(int id, int le)
        {
            return repositorio.ListarPorIdLeilao(id, le);
        }

        public Lance ListarPorUsuarioLeilao(int id, int le)
        {
            return repositorio.ListarPorUsuarioLeilao(id, le);
        }

        

        /*public Lance ListarPorValorLance(decimal valor, int le)
        {
            return repositorio.ListarPorValorLance(valor,le);
        }

        public decimal ListarMenorLanceLeilao(int le)
        {
            return repositorio.ListarMenorLanceLeilao(le);
        }*/

        public List<Lance> ListarTodosSoUsuarioID(int id)
        {
            return repositorio.ListarTodosSoUsuarioID(id);
        }

        public List<Lance> ListarTodosNaoUsuarioID(int id)
        {
            return repositorio.ListarTodosNaoUsuarioID(id);
        }
    }
}
