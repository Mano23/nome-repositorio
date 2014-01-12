using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MN_CADERNETA.Classes
{
    class Avaliacaos:Conexão
    {
        public DataTable CONSULTA_AVALIACAO_IDCLIENTE(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_AVALIACAO_IDCLIENTE", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAvaliacao", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable CONSULTA_AVALIACAO_IDCLIENTE_MAIOR(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_AVALIACAO_IDCLIENTE_MAIOR", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAvaliacao", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;

        }

        public DataTable DELETE_AVALIACAO(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_AVALIACAO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdClienteAvaliacao", SqlDbType.Int);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_AVALIACAO(int idc, double peso, double altura, double bd, double be, double cd, double ce, double pd, double pe, double qua, double tor, double abd, double cint, double pes, double gor, int idv, DateTime data)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_AVALIACAO", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDC    = da.SelectCommand.Parameters.Add("@IdClienteAvaliacao" , SqlDbType.Int);
            SqlParameter PESO   = da.SelectCommand.Parameters.Add("@PesoAvaliacao"      , SqlDbType.Real);
            SqlParameter ALTURA = da.SelectCommand.Parameters.Add("@AlturaAvaliacao"    , SqlDbType.Real);
            SqlParameter BD     = da.SelectCommand.Parameters.Add("@BDAvaliacao"        , SqlDbType.Real);
            SqlParameter BE     = da.SelectCommand.Parameters.Add("@BEAvaliacao"        , SqlDbType.Real);
            SqlParameter CD     = da.SelectCommand.Parameters.Add("@CDAvaliacao"        , SqlDbType.Real);
            SqlParameter CE     = da.SelectCommand.Parameters.Add("@CEAvaliacao"        , SqlDbType.Real);
            SqlParameter PD     = da.SelectCommand.Parameters.Add("@PDAvaliacao"        , SqlDbType.Real);
            SqlParameter PE     = da.SelectCommand.Parameters.Add("@PEAvaliacao"        , SqlDbType.Real);
            SqlParameter QUA    = da.SelectCommand.Parameters.Add("@QUAAvaliacao"       , SqlDbType.Real);
            SqlParameter TOR    = da.SelectCommand.Parameters.Add("@TORAvaliacao"       , SqlDbType.Real);
            SqlParameter ABD    = da.SelectCommand.Parameters.Add("@ABDAvaliacao"       , SqlDbType.Real);
            SqlParameter CINT   = da.SelectCommand.Parameters.Add("@CINTAvaliacao"      , SqlDbType.Real);
            SqlParameter PES    = da.SelectCommand.Parameters.Add("@PESAvaliacao"       , SqlDbType.Real);
            SqlParameter GOR    = da.SelectCommand.Parameters.Add("@GORAvaliacao"       , SqlDbType.Real);
            SqlParameter IDV    = da.SelectCommand.Parameters.Add("@IdVendedorAvaliacao", SqlDbType.Int);
            SqlParameter DATA   = da.SelectCommand.Parameters.Add("@DataAvaliacao"      , SqlDbType.DateTime);

            IDC.Value    = idc;
            PESO.Value   = peso;
            ALTURA.Value = altura;
            BD.Value     = bd;
            BE.Value     = be;
            CD.Value     = cd;
            CE.Value     = ce;
            PD.Value     = pd;
            PE.Value     = pe;
            QUA.Value    = qua;
            TOR.Value    = tor;
            ABD.Value    = abd;
            CINT.Value   = cint;
            PES.Value    = pes;
            GOR.Value    = gor;
            IDV.Value    = idv;
            DATA.Value   = data;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }
    }
}
