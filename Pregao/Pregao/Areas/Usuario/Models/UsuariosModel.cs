using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pregao.Areas.Usuario.Models
{
    public class UsuariosModel
    {        

        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }
        
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

    }

    public class UsuariosEditarModel:UsuariosModel
    {
        [Required]
        public int UsuarioID { get; set; }
    }
}