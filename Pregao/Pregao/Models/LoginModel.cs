using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pregao.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail deve ser preenchido")]
        //[EmailAddress(ErrorMessage = "E-mail com formato incorreto")]
        //[Remote("LoginUnico","Home","",ErrorMessage="E-mail já cadastrado no sistema.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha deve ser preenchido")]
        public string Senha { get; set; }
    }
}