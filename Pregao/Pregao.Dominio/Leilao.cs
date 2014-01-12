using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Pregao.Dominio
{
    public class Leilao
    {
        [DisplayName("Numero")]
        public int LeilaoID { get; set; }

        [Required(ErrorMessage = "Escolha um produto")]
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Preencha o valor inicial do leilão")]
        public decimal Valor { get; set; }        
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage = "Escolha a Data da finalização do leilão")]
        public DateTime DataFinalizacao { get; set; }
        public string Observacao { get; set; }        
        public byte Status { get; set; }

        public enumStatusLeilao enmStatus
        {
            get { return (enumStatusLeilao)Status; }
            set { Status = (byte)value; }
        }

        public enum enumStatusLeilao
        {
            Aberto  = 0,
            Cancelado  = 1,
            Encerrado  = 2
            
        }

        public Leilao()
        {
            this.DataCadastro = DateTime.Now;
            this.enmStatus = enumStatusLeilao.Aberto;
        }
    }
}
