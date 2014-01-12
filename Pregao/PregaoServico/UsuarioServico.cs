using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;

namespace PregaoServico
{
    class UsuarioServico
    {
        private readonly UsuarioRepositorio repositorio;

        public UsuarioServico()
        {
            repositorio = new UsuarioRepositorio();
        }

        public void Salvar(Usuario usuario)
        {
            repositorio.Salvar(usuario);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Usuario> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Usuario ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
