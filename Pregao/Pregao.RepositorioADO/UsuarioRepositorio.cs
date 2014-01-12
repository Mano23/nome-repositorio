using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;



namespace Pregao.RepositorioADO
{
    public class UsuarioRepositorio
    {
        private Contexto contexto;

        private void Inserir(Usuarios usuario)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Usuario (Nome, Email, Senha, Cpf, Rua, Numero, Bairro, Cep, Cidade, PermissaoID, DataCadastro, Status) ";

            //CONFIGURAÇÃO DO COMPUTADOR LOCAL
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(DATETIME, '{10}', 103),'11') ",
            //            usuario.Nome, usuario.Email, usuario.Senha, usuario.Cpf, usuario.Rua, usuario.Numero, usuario.Bairro, usuario.Cep, usuario.Cidade, usuario.PermissaoID, usuario.DataCadastro, usuario.Status);

            //CONFIGURAÇÃO DO COMPUTADOR DE HOSPEDAGEM
            //strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','11') ",
                        usuario.Nome, usuario.Email, usuario.Senha, usuario.Cpf, usuario.Rua, usuario.Numero, usuario.Bairro, usuario.Cep, usuario.Cidade, usuario.PermissaoID, usuario.DataCadastro, usuario.Status);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Usuarios usuario)
        {
            var strQuery = "";
            strQuery += " UPDATE Usuario SET ";            
            strQuery += string.Format(" Nome                     = '{0}', ", usuario.Nome);
            //strQuery += string.Format(" Email                    = '{0}', ", usuario.Email);
            //strQuery += string.Format(" Senha                    = '{0}', ", usuario.Senha);
            strQuery += string.Format(" Cpf                      = '{0}', ", usuario.Cpf);
            strQuery += string.Format(" Rua                      = '{0}', ", usuario.Rua);
            strQuery += string.Format(" Numero                   = '{0}', ", usuario.Numero);
            strQuery += string.Format(" Bairro                   = '{0}', ", usuario.Bairro);
            strQuery += string.Format(" Cep                      = '{0}', ", usuario.Cep);
            strQuery += string.Format(" Cidade                   = '{0}' ", usuario.Cidade);
            //strQuery += string.Format(" PermissaoID              = '{0}', ", usuario.PermissaoID);
            //strQuery += string.Format(" DataCadastro             = CONVERT(DATETIME,'{0}',103), ", usuario.DataCadastro);
            //strQuery += string.Format(" Status                   = '{0}' ", usuario.Status); 
            strQuery += string.Format(" WHERE UsuarioID    =  '{0}' ", usuario.UsuarioID);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuarios usuario)
        {
            if (usuario.UsuarioID > 0)
                Alterar(usuario);
            else
                Inserir(usuario);
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM Usuario WHERE UsuarioID = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Usuarios> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Usuario ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Usuarios ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM Usuario WHERE UsuarioID = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }
        

        public List<Usuarios> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuario = new List<Usuarios>();
            while (reader.Read())
            {
                var temObjeto = new Usuarios()
                {
                    UsuarioID = int.Parse(reader["UsuarioID"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Email = reader["Email"].ToString(),
                    Senha = reader["Senha"].ToString(),
                    Cpf = reader["Cpf"].ToString(),
                    Rua = reader["Rua"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Cep = reader["Cep"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    PermissaoID = int.Parse(reader["PermissaoID"].ToString()),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()),
                    Status = byte.Parse(reader["Status"].ToString())
                };
                usuario.Add(temObjeto);
            }
            reader.Close();
            return usuario;
        }

       

    }
}
