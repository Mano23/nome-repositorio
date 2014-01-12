using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MN_CADERNETA.Classes
{
    class Clientes:Conexão
    {
        public DataTable DELETE_CLIENTE(int id)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("DELETE_CLIENTE", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdCliente", SqlDbType.Int);


            ID.Value = id;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable INSERT_CLIENTES(string nome, string rua, int numero, string bairro, string cidade, string cpf, string rg, bool ativo, string telefone, string celular, int idVendedor)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("INSERT_CLIENTES", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            
            SqlParameter NOME = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);
            SqlParameter RUA = da.SelectCommand.Parameters.Add("@RuaCliente", SqlDbType.VarChar, 30);
            SqlParameter NUMERO = da.SelectCommand.Parameters.Add("@NumeroCliente", SqlDbType.Int);
            SqlParameter BAIRRO = da.SelectCommand.Parameters.Add("@BairroCliente", SqlDbType.VarChar, 30);
            SqlParameter CIDADE = da.SelectCommand.Parameters.Add("@CidadeCliente", SqlDbType.VarChar, 30);
            SqlParameter CPF = da.SelectCommand.Parameters.Add("@CpfCliente", SqlDbType.VarChar, 12);
            SqlParameter RG = da.SelectCommand.Parameters.Add("@RgCliente", SqlDbType.VarChar, 12);
            SqlParameter ATIVO = da.SelectCommand.Parameters.Add("@AtivoCliente", SqlDbType.Bit);
            SqlParameter TELEFONE = da.SelectCommand.Parameters.Add("@TelefoneCliente", SqlDbType.VarChar, 15);
            SqlParameter CELULAR = da.SelectCommand.Parameters.Add("@CelularCliente", SqlDbType.VarChar, 15);
            SqlParameter IDVENDEDOR = da.SelectCommand.Parameters.Add("@IdVendedorCliente", SqlDbType.Int);

            NOME.Value       = nome;
            RUA.Value        = rua;
            NUMERO.Value     = numero;
            BAIRRO.Value     = bairro;
            CIDADE.Value     = cidade;
            CPF.Value        = cpf;
            RG.Value         = rg;
            ATIVO.Value      = ativo;
            TELEFONE.Value   = telefone;
            CELULAR.Value    = celular;
            IDVENDEDOR.Value = idVendedor;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CLIENTE(string cliente)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CLIENTE", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);


            CLI.Value = cliente;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CLIENTE_NOME(string cliente)
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CLIENTE_NOME", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@NomeCliente", SqlDbType.VarChar, 30);


            CLI.Value = cliente;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CLIENTE_CPF(string cliente)
        {

            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CLIENTE_CPF", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter CLI = da.SelectCommand.Parameters.Add("@CpfCliente", SqlDbType.VarChar, 30);


            CLI.Value = cliente;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CLIENTE2()
        {

            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CLIENTE23", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable CONSULTA_CLIENTE_ID(int id)
        {
            Conn.Open();

            DataTable      dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("CONSULTA_CLIENTE_ID", Conn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = da.SelectCommand.Parameters.Add("@IdCliente", SqlDbType.VarChar, 30);

            ID.Value = id;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }

        public DataTable UPDATE_CLIENTES(string nome, string rua, int numero, string bairro, string cidade, string cpf, string rg, bool ativo, string telefone, string celular, int idVendedor, int IdCliente)
        {

            Conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE_CLIENTES", Conn);


            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter IDCLIENTE   = da.SelectCommand.Parameters.Add("@IdCliente",     SqlDbType.Int);
            SqlParameter NOME        = da.SelectCommand.Parameters.Add("@NomeCliente",       SqlDbType.VarChar, 30);
            SqlParameter RUA         = da.SelectCommand.Parameters.Add("@RuaCliente",        SqlDbType.VarChar, 30);
            SqlParameter NUMERO      = da.SelectCommand.Parameters.Add("@NumeroCliente",     SqlDbType.Int);
            SqlParameter BAIRRO      = da.SelectCommand.Parameters.Add("@BairroCliente",     SqlDbType.VarChar, 30);
            SqlParameter CIDADE      = da.SelectCommand.Parameters.Add("@CidadeCliente",     SqlDbType.VarChar, 30);
            SqlParameter CPF         = da.SelectCommand.Parameters.Add("@CpfCliente",        SqlDbType.VarChar, 12);
            SqlParameter RG          = da.SelectCommand.Parameters.Add("@RgCliente",         SqlDbType.VarChar, 12);
            SqlParameter ATIVO       = da.SelectCommand.Parameters.Add("@AtivoCliente",      SqlDbType.Bit);
            SqlParameter TELEFONE    = da.SelectCommand.Parameters.Add("@TelefoneCliente",   SqlDbType.VarChar, 15);
            SqlParameter CELULAR     = da.SelectCommand.Parameters.Add("@CelularCliente",    SqlDbType.VarChar, 15);
            SqlParameter IDVENDEDOR  = da.SelectCommand.Parameters.Add("@IdVendedorCliente", SqlDbType.Int);

            IDCLIENTE.Value  = IdCliente;
            NOME.Value       = nome;
            RUA.Value        = rua;
            NUMERO.Value     = numero;
            BAIRRO.Value     = bairro;
            CIDADE.Value     = cidade;
            CPF.Value        = cpf;
            RG.Value         = rg;
            ATIVO.Value      = ativo;
            TELEFONE.Value   = telefone;
            CELULAR.Value    = celular;
            IDVENDEDOR.Value = idVendedor;

            da.Fill(dt);

            Conn.Close();

            return dt;
        }
    }
}
