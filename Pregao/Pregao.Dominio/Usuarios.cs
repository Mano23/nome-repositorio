using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Pregao.Dominio
{
    public class Usuarios
    {
       
        public int UsuarioID { get; set; }        
                      
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail deve ser preenchido")]
        [EmailAddress(ErrorMessage="E-mail com formato incorreto")]
        [Remote("LoginUnico","Home","",ErrorMessage="E-mail já cadastrado no sistema.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha deve ser preenchido")]
        [StringLength(15,MinimumLength = 5, ErrorMessage="A senha deve ter entre 5 e 15 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Cpf deve ser preenchido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Rua deve ser preenchido")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Numero deve ser preenchido")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Bairro deve ser preenchido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cep deve ser preenchido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade deve ser preenchido")]
        public string Cidade { get; set; }

        
        public int PermissaoID { get; set; }

        
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }        
        
        public byte Status { get; set; }

        private enumStatusUsuario enmStatus
        {
            get { return (enumStatusUsuario)Status; }
            set { Status = (byte)value; }
        }

        public enum enumStatusUsuario
        {
            Ativado    = 0,
            Desativado = 1            
        }

        public Usuarios()
        {
            this.DataCadastro = DateTime.Now;
            this.enmStatus = enumStatusUsuario.Ativado;
        }
    }
}
