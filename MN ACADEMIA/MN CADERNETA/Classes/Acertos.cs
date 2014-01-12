using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MN_CADERNETA.Classes
{
    class Acertos:Conexão
    {
        public DataTable CONSULTA_ACERTO_DISTINCT_IDCLIENTE()
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_DISTINCT_IDCLIENTE", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;            

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE(string nome)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);

            CLI.Value = nome;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE2(string nome)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE2", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);

            CLI.Value = nome;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_IDACERTO(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_IDACERTO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_IDCLIENTE(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_IDCLIENTE", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_IDCLIENTE_MAIOR(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_IDCLIENTE_MAIOR", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_MENSALIDADE_DO_MES(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_MENSALIDADE_DO_MES", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_MENSALIDADE_DO_MES_NOME(string nome)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_MENSALIDADE_DO_MES_NOME", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter NOME = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);

            NOME.Value = nome;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_MENSALIDADE_DO_ULTIMO_MES_PAGO(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_MENSALIDADE_DO_ULTIMO_MES_PAGO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_ACERTO_NOME(string nome)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_ACERTO_NOME", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);

            CLI.Value = nome;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }


        public DataTable DELETE_ACERTO(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_ACERTO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_ACERTO(int idcliente, DateTime diaacerto, double valor, bool pago, DateTime diapagamento, double valorpago, int idvendedor)
        {
         

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_ACERTO", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDCLIENTE    = da.SelectCommand.Parameters.Add("@IdClienteAcerto"    , SqlDbType.Int);
            SqlParameter DIAACERTO    = da.SelectCommand.Parameters.Add("@DiaAcerto"          , SqlDbType.DateTime);
            SqlParameter VALOR        = da.SelectCommand.Parameters.Add("@ValorAcerto"        , SqlDbType.Real);
            SqlParameter PAGO         = da.SelectCommand.Parameters.Add("@PagoAcerto"         , SqlDbType.Bit);
            SqlParameter DIAPAGAMENTO = da.SelectCommand.Parameters.Add("@DiaPagamentoAcerto" , SqlDbType.DateTime);
            SqlParameter VALORPAGO    = da.SelectCommand.Parameters.Add("@ValorPagoAcerto"    , SqlDbType.Real);
            SqlParameter IDVENDEDOR   = da.SelectCommand.Parameters.Add("@IdVendedorAcerto"   , SqlDbType.Int);

            IDCLIENTE.Value    = idcliente;
            DIAACERTO.Value    = diaacerto;
            VALOR.Value        = valor;
            PAGO.Value         = pago;
            DIAPAGAMENTO.Value = diapagamento;
            VALORPAGO.Value    = valorpago;
            IDVENDEDOR.Value   = idvendedor;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable UPDATE_ACERTO(int idcliente, DateTime diaacerto, double valor, bool pago, DateTime diapagamento, double valorpago, int idvendedor)
        {


            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE_ACERTO", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDCLIENTE = da.SelectCommand.Parameters.Add("@IdClienteAcerto", SqlDbType.Int);
            SqlParameter DIAACERTO = da.SelectCommand.Parameters.Add("@DiaAcerto", SqlDbType.DateTime);
            SqlParameter VALOR = da.SelectCommand.Parameters.Add("@ValorAcerto", SqlDbType.Real);
            SqlParameter PAGO = da.SelectCommand.Parameters.Add("@PagoAcerto", SqlDbType.Bit);
            SqlParameter DIAPAGAMENTO = da.SelectCommand.Parameters.Add("@DiaPagamentoAcerto", SqlDbType.DateTime);
            SqlParameter VALORPAGO = da.SelectCommand.Parameters.Add("@ValorPagoAcerto", SqlDbType.Real);
            SqlParameter IDVENDEDOR = da.SelectCommand.Parameters.Add("@IdVendedorAcerto", SqlDbType.Int);

            IDCLIENTE.Value = idcliente;
            DIAACERTO.Value = diaacerto;
            VALOR.Value = valor;
            PAGO.Value = pago;
            DIAPAGAMENTO.Value = diapagamento;
            VALORPAGO.Value = valorpago;
            IDVENDEDOR.Value = idvendedor;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }
    }
}
