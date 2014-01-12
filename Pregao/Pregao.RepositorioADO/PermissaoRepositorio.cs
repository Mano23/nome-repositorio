using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;

namespace Pregao.RepositorioADO
{
    public class PermissaoRepositorio    
    {
        private Contexto contexto;

        private void Inserir(Permissao permissao)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Permissao (PermissaoID, Nome) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                        permissao.PermissaoID, permissao.Nome);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Permissao permissao)
        {
            var strQuery = "";
            strQuery += " UPDATE Permissao SET ";
            strQuery += string.Format(" PermissaoID        = '{0}', ", permissao.PermissaoID);
            strQuery += string.Format(" Nome               = '{0}', ", permissao.Nome);            
            strQuery += string.Format(" WHERE PermissaoID  =  {0} ", permissao.PermissaoID);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Permissao permissao)
        {
            if (permissao.PermissaoID > 0)
                Alterar(permissao);
            else
                Inserir(permissao);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM Permissao WHERE PermissaoID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Permissao> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Permissao ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Permissao ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM Permissao WHERE PermissaoID = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Permissao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var permissao = new List<Permissao>();
            while (reader.Read())
            {
                var temObjeto = new Permissao()
                {
                    PermissaoID = int.Parse(reader["PermissaoID"].ToString()),
                    Nome = reader["Nome"].ToString()                    
                };
                permissao.Add(temObjeto);
            }
            reader.Close();
            return permissao;
        }

    }
    
}
