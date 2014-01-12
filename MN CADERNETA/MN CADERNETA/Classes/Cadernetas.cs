using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MN_CADERNETA.Classes
{
    class Cadernetas:Conexão
    {
        public DataTable CONSULTA_CADERNETATCNT()
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETATCNT", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETATCNUT()
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETATCNUT", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETATCNTD(DateTime d1, DateTime d2)
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETATCNTD", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter D1 = da.SelectCommand.Parameters.Add("@DataCaderneta", SqlDbType.DateTime);
            SqlParameter D2 = da.SelectCommand.Parameters.Add("@DataCaderneta2", SqlDbType.DateTime);

            D1.Value = d1;
            D2.Value = d2;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETATCNUTD(DateTime d1, DateTime d2)
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETATCNUTD", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter D1 = da.SelectCommand.Parameters.Add("@DataCaderneta", SqlDbType.DateTime);
            SqlParameter D2 = da.SelectCommand.Parameters.Add("@DataCaderneta2", SqlDbType.DateTime);

            D1.Value = d1;
            D2.Value = d2;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_IDCLIENTE(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_IDCLIENTE", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteCaderneta", SqlDbType.Int);


            ID.Value = id;



            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_IDCLIENTE2(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_IDCLIENTE2", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdCaderneta", SqlDbType.Int);


            ID.Value = id;



            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_NUMERO_CADERNETA(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_NUMERO_CADERNETA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@NumeroCaderneta", SqlDbType.Int);


            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(int id, int idc)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID  = da.SelectCommand.Parameters.Add("@NumeroCaderneta",        SqlDbType.Int);
            SqlParameter IDC = da.SelectCommand.Parameters.Add("@IdClienteCaderneta",     SqlDbType.Int);

            ID.Value  = id;
            IDC.Value = idc;



            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(int id, int idc, DateTime datepag)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA_NAOPAGA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID      = da.SelectCommand.Parameters.Add("@NumeroCaderneta", SqlDbType.Int);
            SqlParameter IDC     = da.SelectCommand.Parameters.Add("@IdClienteCaderneta", SqlDbType.Int);
            SqlParameter DATAPAG = da.SelectCommand.Parameters.Add("@DataPagamentoCaderneta", SqlDbType.DateTime);

            ID.Value = id;
            IDC.Value = idc;
            DATAPAG.Value = datepag;



            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_CADERNETA_IDCADERNETA(int id)
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CADERNETA_IDCADERNETA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@NumeroCaderneta", SqlDbType.Int);
           

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable DELETE_CADERNETA(int idc, int num)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_CADERNETA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDC = da.SelectCommand.Parameters.Add("@IdClienteCaderneta", SqlDbType.Int);
            SqlParameter NUM = da.SelectCommand.Parameters.Add("@NumeroCaderneta",    SqlDbType.Int);

            IDC.Value = idc;
            NUM.Value = num;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable DELETE_CADERNETA2(int idc)
        {
            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_CADERNETA2", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDC = da.SelectCommand.Parameters.Add("@IdCaderneta", SqlDbType.Int);            

            IDC.Value = idc;            

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_CADERNETA(int idc, string produto, Double quantidade, Double  valor, DateTime data, bool pago, int idv, int caderneta, DateTime datapag)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_CADERNETA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter IDC         = da.SelectCommand.Parameters.Add("@IdClienteCaderneta"          , SqlDbType.Int);
            SqlParameter PRODUTO     = da.SelectCommand.Parameters.Add("@ProdutoCaderneta"            , SqlDbType.VarChar, 60);
            SqlParameter QUANTIDADE  = da.SelectCommand.Parameters.Add("@QuantidadeCaderneta"         , SqlDbType.Real);
            SqlParameter VALOR       = da.SelectCommand.Parameters.Add("@ValorCaderneta"              , SqlDbType.Real);
            SqlParameter DATA        = da.SelectCommand.Parameters.Add("@DataCaderneta"               , SqlDbType.DateTime);
            SqlParameter PAGO        = da.SelectCommand.Parameters.Add("@PagoCaderneta"               , SqlDbType.Bit);
            SqlParameter IDV         = da.SelectCommand.Parameters.Add("@IdVendedorCaderneta"         , SqlDbType.Int);
            SqlParameter CADERNETAA  = da.SelectCommand.Parameters.Add("@NumeroCaderneta"             , SqlDbType.Int);
            SqlParameter DATAPAG     = da.SelectCommand.Parameters.Add("@DataPagamentoCaderneta"      , SqlDbType.DateTime);

            IDC.Value        = idc;
            PRODUTO.Value    = produto;
            QUANTIDADE.Value = quantidade;
            VALOR.Value      = valor;
            DATA.Value       = data;
            PAGO.Value       = pago;
            IDV.Value        = idv;
            CADERNETAA.Value = caderneta;
            DATAPAG.Value    = datapag;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable UPDATE_CADERNETA(int id, int idc, string produto, Double quantidade, Double valor, DateTime data, bool pago, int idv, int caderneta, DateTime datapag)
        {

            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE_CADERNETA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID         = da.SelectCommand.Parameters.Add("@IdCCaderneta"           , SqlDbType.Int);
            SqlParameter IDC        = da.SelectCommand.Parameters.Add("@IdClienteCaderneta"     , SqlDbType.Int);
            SqlParameter PRODUTO    = da.SelectCommand.Parameters.Add("@ProdutoCaderneta"       , SqlDbType.VarChar, 60);
            SqlParameter QUANTIDADE = da.SelectCommand.Parameters.Add("@QuantidadeCaderneta"    , SqlDbType.Real);
            SqlParameter VALOR      = da.SelectCommand.Parameters.Add("@ValorCaderneta"         , SqlDbType.Real);
            SqlParameter DATA       = da.SelectCommand.Parameters.Add("@DataCaderneta"          , SqlDbType.DateTime);
            SqlParameter PAGO       = da.SelectCommand.Parameters.Add("@PagoCaderneta"          , SqlDbType.Bit);
            SqlParameter IDV        = da.SelectCommand.Parameters.Add("@IdVendedorCaderneta"    , SqlDbType.Int);
            SqlParameter CADERNETAA = da.SelectCommand.Parameters.Add("@NumeroCaderneta"        , SqlDbType.Int);
            SqlParameter DATAPAG    = da.SelectCommand.Parameters.Add("@DataPagamentoCaderneta" , SqlDbType.DateTime);

            ID.Value            = id;
            IDC.Value           = idc;
            PRODUTO.Value       = produto;
            QUANTIDADE.Value    = quantidade;
            VALOR.Value         = valor;
            DATA.Value          = data;
            PAGO.Value          = pago;
            IDV.Value           = idv;
            CADERNETAA.Value    = caderneta;
            DATAPAG.Value       = datapag;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }
    }
}
