using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using System.Data;
using System.Data.Entity;

namespace Pregao.RepositorioADO
{
    
    public class ProdutoRepositorio    
    {
        private Contexto contexto;
        

        private void Inserir(Produto produto)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Produto (Nome, DataCadastro, Status) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                        produto.Nome, produto.DataCadastro, produto.Status);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Produto produto)
        {
            var strQuery = "";
            strQuery += " UPDATE Produto SET ";            
            strQuery += string.Format(" Nome               = '{0}', ", produto.Nome);
            strQuery += string.Format(" DataCadastro       = '{0}', ", produto.DataCadastro);
            strQuery += string.Format(" Status             = '{0}', ", produto.Status);            
            strQuery += string.Format(" WHERE ProdutoID    =  {0} ", produto.ProdutoID);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoID > 0)
                Alterar(produto);
            else
                Inserir(produto);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM Produto WHERE ProdutoID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Produto> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Produto ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Produto ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM Produto WHERE ProdutoID = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Produto> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var produto = new List<Produto>();
            while (reader.Read())
            {
                var temObjeto = new Produto()
                {
                    ProdutoID = int.Parse(reader["ProdutoID"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()),
                    Status = byte.Parse(reader["Status"].ToString())
                };
                produto.Add(temObjeto);
            }
            reader.Close();
            return produto;
        }

        public List<string> ListarTodosLeilao()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Produto ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                var produto = new List<string>();
                while (retornoDataReader.Read())
                {
                    produto.Add(retornoDataReader["Nome"].ToString());
                }
                return produto;
            }
        }


    }
}
