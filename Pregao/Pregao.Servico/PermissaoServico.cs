using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;

namespace Pregao.Servico
{
    public class PermissaoServico
    {
        private readonly PermissaoRepositorio repositorio;

        public PermissaoServico()
        {
            repositorio = new PermissaoRepositorio();
        }

        public void Salvar(Permissao permissao)
        {
            repositorio.Salvar(permissao);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Permissao> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Permissao ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
