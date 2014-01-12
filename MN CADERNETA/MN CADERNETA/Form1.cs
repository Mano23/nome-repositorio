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
    public partial class FrmPrincipal : Form
    {
        Classes.Vendedores ve  = new Classes.Vendedores();
        CadastroVendedor   ven = new CadastroVendedor();
        Login              l   = new Login();


        //variaveis do form principal
        private string vusuario;        
        private string vsenha;
        private int vid;
        //essas propriedades são para receber a senha e o nome do usuario logado que foram armazenados nas propriedades do 
        //formulario login        
        public string Usuario
        {
            get { return vusuario; }
            set { vusuario = value; }
        }
        public string Senha
        {
            get { return vsenha; }
            set { vsenha = value; }
        }
        public int Id
        {
            get { return vid; }
            set { vid = value; }
        }

        public FrmPrincipal()
        {           
         
            InitializeComponent();
            
            
        }

        //Cadastro
        private void btn1_Click(object sender, EventArgs e)
        {
            btn5.Visible = btn6.Visible = true;

            btn5.Text = "Clientes";
            btn6.Text = "Vendedores";
            
        }

        //Cadastro Cliente
        private void btn5_Click(object sender, EventArgs e)
        {
            CadastroCliente pr = new CadastroCliente();
            if (Application.OpenForms.OfType<CadastroCliente>().Count() > 0)
            {
                MessageBox.Show("A Janela Cadastro de Produtos já está aberta!");
                pr.WindowState = FormWindowState.Normal;

            }
            else
            {
                pr.Usuario = Usuario;
                pr.Senha   = Senha;
                pr.Id      = Id;
                
                pr.Show();
                pr.WindowState = FormWindowState.Normal;

            }
        }

        //Cadastro Vendedor
        private void btn6_Click(object sender, EventArgs e)
        {
            CadastroVendedor ve = new CadastroVendedor();
            if (Application.OpenForms.OfType<CadastroVendedor>().Count() > 0)
            {
                MessageBox.Show("A Janela Vendedores já está aberta!");
                ve.WindowState = FormWindowState.Normal;

            }
            else
            {
                ve.Usuario = Usuario;
                ve.Senha   = Senha;
                ve.Id      = Id;
                ve.Show();

            }
        }

        //Caderneta
        private void btn2_Click(object sender, EventArgs e)
        {
            btn5.Visible = btn6.Visible = false;
            Caderneta ca = new Caderneta();
            if (Application.OpenForms.OfType<Caderneta>().Count() > 0)
            {
                MessageBox.Show("A Janela Caderneta já está aberta!");
                ca.WindowState = FormWindowState.Normal;

            }
            else
            {
                ca.Usuario = Usuario;
                ca.Senha   = Senha;
                ca.Id      = Id;
                ca.Show();
            }
        }

        //Relatório
        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            btn5.Visible = btn6.Visible = false;
            Relatorios re = new Relatorios();
            if (Application.OpenForms.OfType<Relatorios>().Count() > 0)
            {
                MessageBox.Show("A Janela Relatórios já está aberta!");
                re.WindowState = FormWindowState.Normal;

            }
            else
            {
                re.Usuario = Usuario;
                re.Senha = Senha;
                re.Show();
            }
        }

        //mudar cor do botão quando passa o mouse
        private void btn1_MouseMove(object sender, MouseEventArgs e)
        {
            btn1.BackColor = Color.FromArgb(192, 0, 192);

            
            btn2.BackColor = Color.Purple;
            btnRelatorios.BackColor = Color.Purple;
            btn5.BackColor = Color.Purple;
            btn6.BackColor = Color.Purple;
            
        }

        //mudar cor do botão quando passa o mouse
        private void btn2_MouseMove(object sender, MouseEventArgs e)
        {
            btn2.BackColor = Color.FromArgb(192, 0, 192);

            btn1.BackColor = Color.Purple;            
            btnRelatorios.BackColor = Color.Purple;
            btn5.BackColor = Color.Purple;
            btn6.BackColor = Color.Purple;
        }

        //mudar cor do botão quando passa o mouse
        private void btnRelatorios_MouseMove(object sender, MouseEventArgs e)
        {
            btnRelatorios.BackColor = Color.FromArgb(192, 0, 192);

            btn1.BackColor = Color.Purple;
            btn2.BackColor = Color.Purple;            
            btn5.BackColor = Color.Purple;
            btn6.BackColor = Color.Purple;
        }

        //mudar cor do botão quando passa o mouse
        private void btn5_MouseMove(object sender, MouseEventArgs e)
        {
            btn5.BackColor = Color.FromArgb(192, 0, 192);

            btn1.BackColor = Color.Purple;
            btn2.BackColor = Color.Purple;
            btnRelatorios.BackColor = Color.Purple;            
            btn6.BackColor = Color.Purple;
        }

        //mudar cor do botão quando passa o mouse
        private void btn6_MouseMove(object sender, MouseEventArgs e)
        {
            btn6.BackColor = Color.FromArgb(192, 0, 192);

            btn1.BackColor = Color.Purple;
            btn2.BackColor = Color.Purple;
            btnRelatorios.BackColor = Color.Purple;
            btn5.BackColor = Color.Purple;
            
        }

        //mudar cor do botão quando passa o mouse
        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            btn1.BackColor = Color.Purple;
            btn2.BackColor = Color.Purple;
            btnRelatorios.BackColor = Color.Purple;
            btn5.BackColor = Color.Purple;
            btn6.BackColor = Color.Purple;
        }

        //comando teclado
        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //--------------Login--------------------\\
            if (l.ShowDialog() == DialogResult.Cancel)
                Close();//vai fechar o programa
            else
            {

                Usuario = l.usuario;//as propriedade Usuario e Senha do formulario principal estão recebendo
                Senha = l.senha;//o usuario e senha que estavam armazenados no formulario login
                Id = l.id;
                //tipo = Convert.ToString(ve.CONSULTA_VENDEDOR_NOME_SENHA(Usuario, Senha).Rows[0][3]);
                lblV.Text = Usuario;
            }
            //-----------Fim Login------------------\\

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente pr = new CadastroCliente();
            if (Application.OpenForms.OfType<CadastroCliente>().Count() > 0)
            {
                MessageBox.Show("A Janela Cadastro de Produtos já está aberta!");
                pr.WindowState = FormWindowState.Normal;

            }
            else
            {
                pr.Usuario = Usuario;
                pr.Senha = Senha;
                pr.Id = Id;

                pr.Show();
                pr.WindowState = FormWindowState.Normal;

            }
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroVendedor ve = new CadastroVendedor();
            if (Application.OpenForms.OfType<CadastroVendedor>().Count() > 0)
            {
                MessageBox.Show("A Janela Vendedores já está aberta!");
                ve.WindowState = FormWindowState.Normal;

            }
            else
            {
                ve.Usuario = Usuario;
                ve.Senha = Senha;
                ve.Id = Id;
                ve.Show();

            }
        }

        private void CadernetatoolStripButton2_Click(object sender, EventArgs e)
        {           
            Caderneta ca = new Caderneta();
            if (Application.OpenForms.OfType<Caderneta>().Count() > 0)
            {
                MessageBox.Show("A Janela Caderneta já está aberta!");
                ca.WindowState = FormWindowState.Normal;

            }
            else
            {
                ca.Usuario = Usuario;
                ca.Senha = Senha;
                ca.Id = Id;
                ca.Show();
            }
        }

        private void RelatoriostoolStripButton1_Click(object sender, EventArgs e)
        {            
            Relatorios re = new Relatorios();
            if (Application.OpenForms.OfType<Relatorios>().Count() > 0)
            {
                MessageBox.Show("A Janela Relatórios já está aberta!");
                re.WindowState = FormWindowState.Normal;

            }
            else
            {
                re.Usuario = Usuario;
                re.Senha = Senha;
                re.Show();
            }
        }
    }
}
