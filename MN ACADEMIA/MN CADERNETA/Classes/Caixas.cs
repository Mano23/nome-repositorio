using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MN_CADERNETA.Classes
{
    class Caixas:Conexão
    {
        public DataTable CONSULTA_CAIXA()
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA_DATA(string data)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_DATA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DATA = da.SelectCommand.Parameters.Add("@DataCaixa", SqlDbType.DateTime);

            DATA.Value = data;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA_DATA2(string data, string data2)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_DATA2", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DATA = da.SelectCommand.Parameters.Add("@DataCaixa", SqlDbType.DateTime);
            SqlParameter DATA2 = da.SelectCommand.Parameters.Add("@DataCaixa2", SqlDbType.DateTime);

            DATA.Value = data;
            DATA2.Value = data2;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA_DOCUMENTO(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_DOCUMENTO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdCaixa", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_SALDO_SAIDA()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_SALDO_SAIDA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_SALDO_ENTRADA()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_SALDO_ENTRADA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable SOMA_SALDO_ENTRADA_DATA(string data, string data2)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SOMA_SALDO_Entrada_DATA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DATA  = da.SelectCommand.Parameters.Add("@DataCaixa", SqlDbType.DateTime);
            SqlParameter DATA2 = da.SelectCommand.Parameters.Add("@DataCaixa2", SqlDbType.DateTime);

            DATA.Value  = data;
            DATA2.Value = data2;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable SOMA_SALDO_SAIDA_DATA(string data, string data2)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SOMA_SALDO_SAIDA_DATA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DATA  = da.SelectCommand.Parameters.Add("@DataCaixa", SqlDbType.DateTime);
            SqlParameter DATA2 = da.SelectCommand.Parameters.Add("@DataCaixa2", SqlDbType.DateTime);

            DATA.Value  = data;
            DATA2.Value = data2;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA_ID_ORIGEM(int id, string od)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_ID_ORIGEM", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdCaixa"    , SqlDbType.Int);
            SqlParameter OD = da.SelectCommand.Parameters.Add("@OrigemCaixa", SqlDbType.VarChar, 30);


            ID.Value = id;
            OD.Value = od;


            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA__ORIGEM_MAIORID(string od)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_ORIGEM_MAIORID", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter OD = da.SelectCommand.Parameters.Add("@OrigemCaixa", SqlDbType.VarChar, 30);

            OD.Value = od;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CAIXA_HISTORICO(string historico)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CAIXA_NOME", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter HISTORICO       = da.SelectCommand.Parameters.Add("@HistoricoCaixa", SqlDbType.VarChar, 100);

            HISTORICO.Value = historico;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable DELETE_CAIXA(int id, string origem)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_CAIXA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID     = da.SelectCommand.Parameters.Add("@IdCaixa"    , SqlDbType.Int);
            SqlParameter ORIGEM = da.SelectCommand.Parameters.Add("@OrigemCaixa", SqlDbType.VarChar, 30);

            ID.Value     = id;
            ORIGEM.Value = origem;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_CAIXA(int documento, string historico, Double valor, Boolean entrada, Boolean saida, string data, int idv, string origem)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_CAIXA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DOCUMENTO = da.SelectCommand.Parameters.Add("@IdCaixa"        , SqlDbType.Int);
            SqlParameter HISTORICO = da.SelectCommand.Parameters.Add("@HistoricoCaixa" , SqlDbType.VarChar, 100);
            SqlParameter VALOR     = da.SelectCommand.Parameters.Add("@ValorCaixa"     , SqlDbType.Real);
            SqlParameter ENTRADA   = da.SelectCommand.Parameters.Add("@EntradaCaixa"   , SqlDbType.Bit);
            SqlParameter SAIDA     = da.SelectCommand.Parameters.Add("@SaidaCaixa"     , SqlDbType.Bit);
            SqlParameter DATA      = da.SelectCommand.Parameters.Add("@DataCaixa"      , SqlDbType.Date);
            SqlParameter IDV       = da.SelectCommand.Parameters.Add("@IdVendedorCaixa", SqlDbType.Int);
            SqlParameter ORIGEM    = da.SelectCommand.Parameters.Add("@OrigemCaixa"    , SqlDbType.VarChar, 30);

            DOCUMENTO.Value = documento;
            HISTORICO.Value = historico;
            VALOR.Value     = valor;
            ENTRADA.Value   = entrada;
            SAIDA.Value     = saida;
            DATA.Value      = data;
            IDV.Value       = idv;
            ORIGEM.Value    = origem;                            

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable SOMA_SALDO()
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SOMA_SALDO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable SOMA_SALDO_ENTRADA()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SOMA_SALDO_ENTRADA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable SOMA_SALDO_SAIDA()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SOMA_SALDO_SAIDA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable UPDATE_CAIXA(int documento, string historico, Double valor, Boolean entrada, Boolean saida, string data, int idv, string origem)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE_CAIXA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter DOCUMENTO = da.SelectCommand.Parameters.Add("@IdCaixa"        , SqlDbType.Int);
            SqlParameter HISTORICO = da.SelectCommand.Parameters.Add("@HistoricoCaixa" , SqlDbType.VarChar, 100);
            SqlParameter VALOR     = da.SelectCommand.Parameters.Add("@ValorCaixa"     , SqlDbType.Real);
            SqlParameter ENTRADA   = da.SelectCommand.Parameters.Add("@EntradaCaixa"   , SqlDbType.Bit);
            SqlParameter SAIDA     = da.SelectCommand.Parameters.Add("@SaidaCaixa"     , SqlDbType.Bit);
            SqlParameter DATA      = da.SelectCommand.Parameters.Add("@DataCaixa"      , SqlDbType.DateTime);
            SqlParameter IDV       = da.SelectCommand.Parameters.Add("@IdVendedorCaixa", SqlDbType.Int);
            SqlParameter ORIGEM    = da.SelectCommand.Parameters.Add("@OrigemCaixa"    , SqlDbType.VarChar, 30);

            DOCUMENTO.Value = documento;
            HISTORICO.Value = historico;
            VALOR.Value     = valor;
            ENTRADA.Value   = entrada;
            SAIDA.Value     = saida;
            DATA.Value      = data;
            IDV.Value       = idv;
            ORIGEM.Value    = origem;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }


    }
}
