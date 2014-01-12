using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;

namespace Pregao.RepositorioADO
{
    public class LeilaoRepositorio
    {
        private Contexto contexto;

        private void Inserir(Leilao leilao)
        {
            decimal v = decimal.Parse(leilao.Valor.ToString("N2").Replace(",", "."));
            leilao.Valor = v;

            var strQuery = "";
            strQuery += " INSERT INTO Leilao (ProdutoID, Valor, DataCadastro, DataFinalizacao, Observacao, Status) ";
            strQuery += string.Format(" VALUES ('{0}',CAST('{1}' as decimal(10,2)) / 100, CONVERT(DATETIME, '{2}', 103),CONVERT(DATETIME, '{3}', 103),'{4}','{5}') ",
                        leilao.ProdutoID, leilao.Valor, leilao.DataCadastro, leilao.DataFinalizacao, leilao.Observacao, leilao.Status);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Leilao leilao)
        {
            decimal v = decimal.Parse(leilao.Valor.ToString("N2").Replace(",", "."));
            leilao.Valor = v;

            var strQuery = "";
            strQuery += " UPDATE Leilao SET ";
            strQuery += string.Format(" ProdutoID        = '{0}', ", leilao.ProdutoID);
            strQuery += string.Format(" Valor            = CAST('{0}' as decimal(10,2)) / 100, ", leilao.Valor);
            strQuery += string.Format(" DataCadastro     = CONVERT(DATETIME, '{0}', 103), ", leilao.DataCadastro);
            strQuery += string.Format(" DataFinalizacao  = CONVERT(DATETIME, '{0}', 103), ", leilao.DataFinalizacao);
            strQuery += string.Format(" Observacao       = '{0}', ", leilao.Observacao);
            strQuery += string.Format(" Status           = '{0}' ", leilao.Status);
            strQuery += string.Format(" WHERE LeilaoID  =  {0} ", leilao.LeilaoID);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Leilao leilao)
        {
            if (leilao.LeilaoID > 0)
                Alterar(leilao);
            else
                Inserir(leilao);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM Leilao WHERE LeilaoID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Leilao> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT Leilao.LeilaoID, Leilao.ProdutoID, Leilao.Valor, Leilao.DataCadastro, Leilao.DataFinalizacao, Leilao.Observacao, Leilao.Status, Produto.Nome FROM Leilao INNER JOIN Produto ON Leilao.ProdutoID = Produto.ProdutoID";                
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public List<Leilao> ListarTodosAberto()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT Leilao.LeilaoID, Leilao.ProdutoID, Leilao.Valor, Leilao.DataCadastro, Leilao.DataFinalizacao, Leilao.Observacao, Leilao.Status, Produto.Nome FROM Leilao INNER JOIN Produto ON Leilao.ProdutoID = Produto.ProdutoID WHERE  Leilao.Status = 0";                
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Leilao ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT Leilao.LeilaoID, Leilao.ProdutoID, Leilao.Valor, Leilao.DataCadastro, Leilao.DataFinalizacao, Leilao.Observacao, Leilao.Status, Produto.Nome FROM Leilao INNER JOIN Produto ON Leilao.ProdutoID = Produto.ProdutoID WHERE  LeilaoID = {0} ", id);                
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Leilao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var leilao = new List<Leilao>();
            while (reader.Read())
            {
                var temObjeto = new Leilao()
                {
                    LeilaoID = int.Parse(reader["LeilaoID"].ToString()),
                    ProdutoID = int.Parse(reader["ProdutoID"].ToString()),
                    Valor = decimal.Parse(reader["Valor"].ToString()),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()),
                    DataFinalizacao = DateTime.Parse(reader["DataFinalizacao"].ToString()),
                    Observacao = reader["Observacao"].ToString(),
                    Status = byte.Parse(reader["Status"].ToString()),
                    NomeProduto = reader["Nome"].ToString()
                };
                leilao.Add(temObjeto);
            }
            reader.Close();
            return leilao;
        }

        public void EncerrarLeilao()
        {
            var leilao = ListarTodosAberto().FindAll(x => x.DataFinalizacao <= DateTime.Now);
            foreach (var item in leilao)
            {
                item.enmStatus = Leilao.enumStatusLeilao.Encerrado;
                Salvar(item);

                var applance = new LanceRepositorio();  
                var lance = applance.ListarTodos().OrderBy(x => x.Valor).FirstOrDefault(x => x.LeilaoID == item.LeilaoID);
                if (lance != null)
                {
                    lance.enmStatus = Lance.enumStatusEmpresa.Vencedor;
                    applance.Salvar(lance);
                }
            }
        }

    }
}
