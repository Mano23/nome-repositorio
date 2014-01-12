using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregao.Dominio
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string ProdutoNome { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte Status { get; set; }

        private enumStatusProduto enmStatus
        {
            get { return (enumStatusProduto)Status; }
            set { Status = (byte)value; }
        }

        public enum enumStatusProduto
        {
            Ativado    = 0,
            Desativado = 1            
        }

        public Produto()
        {
            this.DataCadastro = DateTime.Now;
            this.enmStatus = enumStatusProduto.Ativado;
        }
    }
}
