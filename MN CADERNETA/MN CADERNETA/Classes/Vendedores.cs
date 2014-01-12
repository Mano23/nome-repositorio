using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MN_CADERNETA.Classes
{
   class Vendedores:Conexão
    {       
        
       public DataTable CONSULTA_VENDEDOR2()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_VENDEDOR2", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

       public DataTable CONSULTA_VENDEDOR_SENHA(string vendedor, string senha)
       {

           Conn.Open();

           DataTable      dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("CONSULTA_USUARIO_SENHA", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter ven = da.SelectCommand.Parameters.Add("@NomeVendedor",  SqlDbType.VarChar, 30);
           SqlParameter sen = da.SelectCommand.Parameters.Add("@SenhaVendedor", SqlDbType.VarChar, 30);

           ven.Value = vendedor;
           sen.Value = senha;


           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable CONSULTA_VENDEDOR(string vendedor)
       {

           Conn.Open();

           DataTable dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("CONSULTA_VENDEDOR", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter ven = da.SelectCommand.Parameters.Add("@NomeVendedor", SqlDbType.VarChar, 30);


           ven.Value = vendedor;



           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable CONSULTA_VENDEDOR_NOME(string vendedor)
       {

           Conn.Open();

           DataTable      dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("CONSULTA_VENDEDOR_NOME", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter ven = da.SelectCommand.Parameters.Add("@NomeVendedor", SqlDbType.VarChar, 30);


           ven.Value = vendedor;



           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable CONSULTA_VENDEDOR_ID(int id)
       {

           Conn.Open();

           DataTable      dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("CONSULTA_VENDEDOR_ID", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter ID = da.SelectCommand.Parameters.Add("@IdVendedor", SqlDbType.Int);


           ID.Value = id;



           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable DELETE_VENDEDOR(int id)
       {

           Conn.Open();

           DataTable      dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("DELETE_VENDEDOR", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter ID = da.SelectCommand.Parameters.Add("@IdVendedor", SqlDbType.Int);


           ID.Value = id;



           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable UPDATE_VENDEDOR(string nome, string senha, int id)
       {

           Conn.Open();

           DataTable      dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("UPDATE_VENDEDOR", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter NOME  = da.SelectCommand.Parameters.Add("@NomeVendedor",  SqlDbType.VarChar, 30);
           SqlParameter SENHA = da.SelectCommand.Parameters.Add("@SenhaVendedor", SqlDbType.VarChar, 30);
           SqlParameter ID    = da.SelectCommand.Parameters.Add("@IdVendedor",    SqlDbType.Int);

           NOME.Value  = nome;
           SENHA.Value = senha;
           ID.Value    = id;

           da.Fill(dt);

           Conn.Close();

           return dt;
       }

       public DataTable INSERT_VENDEDOR(string nome, string senha)
       {

           Conn.Open();

           DataTable dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("INSERT_VENDEDOR", Conn);


           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter NOME = da.SelectCommand.Parameters.Add("@NomeVendedor", SqlDbType.VarChar, 30);
           SqlParameter SENHA = da.SelectCommand.Parameters.Add("@SenhaVendedor", SqlDbType.VarChar, 30);

           NOME.Value = nome;
           SENHA.Value = senha;
           da.Fill(dt);

           Conn.Close();

           return dt;
       }
    }
}
