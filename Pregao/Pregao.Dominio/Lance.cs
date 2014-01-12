using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pregao.Dominio
{
    public class Lance
    {
        public int LanceID { get; set; }
        public int LeilaoID { get; set; }

        public int UsuarioID { get; set; }
        public string NomeUsuario { get; set; }

        
        //[Remote("validarlance","usuario","Usuario",ErrorMessage="Atenção!")]
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public byte Status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }


        public enumStatusEmpresa enmStatus
        {
            get { return (enumStatusEmpresa)Status; }
            set { Status = (byte)value; }
        }

        public enum enumStatusEmpresa
        {
            Normal = 0,
            Vencedor = 1            
        }

        public Lance()
        {            
            this.enmStatus = enumStatusEmpresa.Normal;
        }
    }
}
