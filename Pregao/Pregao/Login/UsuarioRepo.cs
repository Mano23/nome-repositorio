using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pregao.RepositorioADO;
using Pregao.Dominio;
using System.Web.Security;


namespace Pregao.Login
{
    public class UsuarioRepo
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            Contexto contexto;

            using (contexto = new Contexto())
            {

                var strQuery = string.Format("SELECT * FROM Usuario WHERE Email = '{0}' and Senha = '{1}' ", Login, Senha);
                var reader = contexto.ExecutaComandoComRetorno(strQuery);
                var usuario = new Usuarios();
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
                    usuario = temObjeto;
                }

                //Usuário não existe ou a senha está incorreta
                if (usuario.Email == null)
                    return false;

                //Irá setar um cookie encriptado com o Login do usuário autenticado
                FormsAuthentication.SetAuthCookie(Login, false);

                return true;
            }
            
        }

        public static Usuarios GetUsuarioLogado()
        {
            Contexto contexto;
            UsuarioRepositorio usu = new UsuarioRepositorio();

            //Pegamos o login do usuário logado
            string _Login = HttpContext.Current.User.Identity.Name;

            //Não existe usuário logado, retornamos null
            if (_Login == "")
            {
                return null;
            }
            else
            {
                                

                using (contexto = new Contexto())
                {
                    var strQuery = string.Format("SELECT * FROM Usuario WHERE Email = '{0}'", _Login);
                    var reader = contexto.ExecutaComandoComRetorno(strQuery);
                    var usuario = new Usuarios();
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
                        usuario = temObjeto;
                    }
                    return usuario;
                }
            }

        }

        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
        }
    }
}