using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;

namespace Pregao.Servico
{
    public class UsuarioServico
    {
        private readonly UsuarioRepositorio repositorio;

        public UsuarioServico()
        {
            repositorio = new UsuarioRepositorio();
        }

        public void Salvar(Usuarios usuario)
        {
            repositorio.Salvar(usuario);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Usuarios> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Usuarios ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
