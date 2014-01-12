using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MN_CADERNETA
{
    public partial class EditarUsuario : Form
    {
        private string vusuario;
        public  string Usuario
        {
            get { return vusuario; }
            set { vusuario = value; }
        }
        private string vsenha;
        public  string Senha//variavel do form principal
        {
            get { return vsenha; }
            set { vsenha = value; }
        }

        public EditarUsuario()
        {
            InitializeComponent();
        }
    }
}
