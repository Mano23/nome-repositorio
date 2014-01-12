using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregao.RepositorioADO
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            //var teste = System.Configuration.ConfigurationManager.ConnectionStrings["DBPregaoConfig"].ConnectionString;
            //minhaConexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPregaoConfig"].ConnectionString);
            var teste = System.Configuration.ConfigurationManager.ConnectionStrings["PregaoDB.mssql.somee.com"].ConnectionString;
            minhaConexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PregaoDB.mssql.somee.com"].ConnectionString);
            minhaConexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = strQuery,
                    CommandType = CommandType.Text,
                    Connection = minhaConexao
                };
                cmdComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}
