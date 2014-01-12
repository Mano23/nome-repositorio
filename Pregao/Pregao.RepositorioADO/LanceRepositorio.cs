using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;

namespace Pregao.RepositorioADO
{
    public class LanceRepositorio
    {
        private Contexto contexto;

        private void Inserir(Lance lance)
        {
            decimal v = decimal.Parse(lance.Valor.ToString("N2").Replace(",", "."));
            lance.Valor = v;

            var strQuery = "";
            strQuery += " INSERT INTO lance (LeilaoID, UsuarioID, Valor, Observacao, Status, DataCadastro) ";
           
            //CONFIGURAÇÃO DO COMPUTADOR LOCAL
            strQuery += string.Format(" VALUES ('{0}','{1}', cast('{2}' as decimal(10,2)) / 100,'{3}','{4}', CONVERT(DATETIME, '{5}', 103)) ",

            //CONFIGURAÇÃO DO COMPUTADOR DE HOSPEDAGEM
           // strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}') ",

                        lance.LeilaoID, lance.UsuarioID, lance.Valor, lance.Observacao, lance.Status, lance.DataCadastro);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Lance lance)
        {
            decimal v = decimal.Parse(lance.Valor.ToString("N2").Replace(",", "."));
            lance.Valor = v;

            var strQuery = "";
            strQuery += " UPDATE Lance SET ";
            strQuery += string.Format(" LeilaoID       = '{0}', ", lance.LeilaoID);
            strQuery += string.Format(" UsuarioID      = '{0}', ", lance.UsuarioID);
            strQuery += string.Format(" Valor          = CAST('{0}' as decimal(10,2)) / 100, ", lance.Valor);
            strQuery += string.Format(" Observacao     = '{0}', ", lance.Observacao);
            strQuery += string.Format(" Status         = '{0}', ", lance.Status);
            strQuery += string.Format(" DataCadastro   = CONVERT(DATETIME, '{0}', 103) ", lance.DataCadastro);
            strQuery += string.Format(" WHERE LanceID  =  {0} ", lance.LanceID);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Lance lance)
        {
            if (lance.LanceID > 0)
                Alterar(lance);
            else
                Inserir(lance);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM Lance WHERE LanceID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Lance> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome FROM Lance INNER JOIN Usuario ON Lance.UsuarioID = Usuario.UsuarioID";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }


        public Lance ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome FROM Lance INNER JOIN Usuario ON Lance.UsuarioID = Usuario.UsuarioID WHERE Lance.LanceID = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        //retorna um determinado lance atraves do seu id e do numero do seu leilao
        public Lance ListarPorIdLeilao(int id, int le)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome FROM Lance INNER JOIN Usuario ON Lance.UsuarioID = Usuario.UsuarioID WHERE LanceID = {0} and LeilaoID = {1} ", id, le);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        //lista o lance de um usuario atraves do id do usuario e do id do leilão
        public Lance ListarPorUsuarioLeilao(int id, int le)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome FROM Lance INNER JOIN Usuario ON Lance.UsuarioID = Usuario.UsuarioID WHERE Lance.UsuarioID = {0} and Lance.LeilaoID = {1} ", id, le);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        //lista os lances de um usuario de um determinado leilão
        /* public Lance ListarPorValorLance(decimal valor, int le)
         {
             using (contexto = new Contexto())
             {
                 var strQuery = "";
                 strQuery += "SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome ";
                 strQuery += "FROM Lance  INNER JOIN Usuario ";
                 strQuery += "ON Lance.UsuarioID = Usuario.UsuarioID ";
                 strQuery += string.Format("WHERE LeilaoID = {0} and Valor = convert(decimal(10,2),{1}) ", le, valor);
                 //strQuery += string.Format("WHERE Lance.Valor = {0}",valor);// and LeilaoID = {1}", valor, le);

                 //var strQuery = string.Format(" SELECT Lance.LanceID, Lance.LeilaoID, Lance.UsuarioID, Lance.Valor, Lance.Observacao, Lance.Status, Lance.DataCadastro, Usuario.Nome FROM Lance INNER JOIN Usuario ON Lance.UsuarioID = Usuario.UsuarioID WHERE Lance.Valor = {0}",valor + " and LeilaoID = {1} ", le);
                 var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                 return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
             }
         }*/

        //lista o menor lance de um determinado leilão
        /*public decimal ListarMenorLanceLeilao(int le)
        {
            using (contexto = new Contexto())
            {
                decimal i = 0;
                var strQuery = string.Format("Select MIN(Valor) AS Valor FROM  Lance WHERE LeilaoID = {0} GROUP BY LeilaoID", le);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                while (retornoDataReader.Read())
                    i = decimal.Parse(retornoDataReader["Valor"].ToString());
                return i;
            }
        }*/

        private List<Lance> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var lance = new List<Lance>();

            while (reader.Read())
            {
                var temObjeto = new Lance()
                {
                    LanceID = int.Parse(reader["LanceID"].ToString()),
                    LeilaoID = int.Parse(reader["LeilaoID"].ToString()),
                    UsuarioID = int.Parse(reader["UsuarioID"].ToString()),
                    Valor = decimal.Parse(reader["Valor"].ToString()),
                    Observacao = reader["Observacao"].ToString(),
                    Status = byte.Parse(reader["Status"].ToString()),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()),
                    NomeUsuario = reader["Nome"].ToString()
                };
                lance.Add(temObjeto);
            }
            reader.Close();

            return lance;
        }

        public List<Lance> ListarTodosSoUsuarioID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT DISTINCT LeilaoID FROM Lance WHERE UsuarioID = {0} ",id);
                var reader = contexto.ExecutaComandoComRetorno(strQuery);
                var lance = new List<Lance>();
                while (reader.Read())
                {
                    var temObjeto = new Lance()
                    {                        
                        LeilaoID = int.Parse(reader["LeilaoID"].ToString())                        
                    };
                    lance.Add(temObjeto);
                }
                reader.Close();

                return lance;
            }
        }

        public List<Lance> ListarTodosNaoUsuarioID(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT DISTINCT LeilaoID FROM Lance WHERE UsuarioID != {0} ", id);
                var reader = contexto.ExecutaComandoComRetorno(strQuery);
                var lance = new List<Lance>();
                while (reader.Read())
                {
                    var temObjeto = new Lance()
                    {
                        LeilaoID = int.Parse(reader["LeilaoID"].ToString())
                    };
                    lance.Add(temObjeto);
                }
                reader.Close();

                return lance;
            }
        }

    }
}
