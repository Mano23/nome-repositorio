using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MN_CADERNETA.Classes
{
    class Auditoria:Conexão
    {        
        public DataTable CONSULTA_AUDITORIA_IDVENDEDOR(int id)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_AUDITORIA_IDVENDEDOR", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdVendedorAuditoria", SqlDbType.Int);


            ID.Value = id;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_AUDITORIA_DATA(DateTime d1, DateTime d2)
        {

            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_AUDITORIA_DATA", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter D1 = da.SelectCommand.Parameters.Add("@DateAuditoria", SqlDbType.DateTime);
            SqlParameter D2 = da.SelectCommand.Parameters.Add("@DateAuditoria2", SqlDbType.DateTime);

            D1.Value = d1;
            D2.Value = d2;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_AUDITORIA_DATA_TODAS()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_AUDITORIA_DATA_TODAS", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        
            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_AUDITORIA(int idvendedor, string atividade, DateTime date)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_AUDITORIA", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDVENDEDOR = da.SelectCommand.Parameters.Add("@idVendedorAuditoria", SqlDbType.Int);
            SqlParameter ATIVIDADE  = da.SelectCommand.Parameters.Add("@AtividadeAuditoria", SqlDbType.VarChar, 100);
            SqlParameter DATE       = da.SelectCommand.Parameters.Add("@DateAuditoria", SqlDbType.DateTime);

            IDVENDEDOR.Value = idvendedor;
            ATIVIDADE.Value  = atividade;
            DATE.Value       = date;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }
    }
}
