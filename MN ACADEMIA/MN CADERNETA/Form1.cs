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
            MudaCor(1);
            btn5.Visible = btn6.Visible = true;
            

            btn5.Text = "Clientes";
            btn6.Text = "Vendedores";
            
        }

        //Cadastro de cliente ou 
        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text == "Clientes")
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
            else if (btn5.Text == "Caixa")
            {
                Caixa ca = new Caixa();
                if (Application.OpenForms.OfType<Caixa>().Count() > 0)
                {
                    MessageBox.Show("A Janela Caixa já está aberta!");
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
        }

        //Cadastro Vendedor
        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text == "Vendedores")
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
            else if (btn6.Text == "Mensalidades")
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
                    ca.Senha = Senha;
                    ca.Id = Id;
                    ca.Show();
                }
            }
        }

        //Caderneta
        private void btn2_Click(object sender, EventArgs e)
        {
            btn5.Visible = btn6.Visible =  false;
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

        //Financeiro
        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            MudaCor(2);
            btn5.Visible = btn6.Visible =  true;

            btn5.Text = "Caixa";
            btn6.Text = "Mensalidades";
            
        }

        //Relatório
        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            MudaCor(3);
            btn5.Visible = btn6.Visible =  false;
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

        //muda cor das bordas quando clica
        private void MudaCor(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        btn1.FlatAppearance.BorderColor = Color.Green;
                        btn1.FlatAppearance.BorderSize = 2;

                        btnRelatorios.FlatAppearance.BorderColor = Color.Purple;
                        btnRelatorios.FlatAppearance.BorderSize = 1;

                        btn5.FlatAppearance.BorderColor = Color.Purple;
                        btn5.FlatAppearance.BorderSize = 1;

                        btn6.FlatAppearance.BorderColor = Color.Purple;
                        btn6.FlatAppearance.BorderSize = 1;

                        btnFinanceiro.FlatAppearance.BorderColor = Color.Purple;
                        btnFinanceiro.FlatAppearance.BorderSize = 1;      
                        break;
                    }
                case 2:
                    {
                        btnFinanceiro.FlatAppearance.BorderColor = Color.Green;
                        btnFinanceiro.FlatAppearance.BorderSize = 2;

                        btnRelatorios.FlatAppearance.BorderColor = Color.Purple;
                        btnRelatorios.FlatAppearance.BorderSize = 1;

                        btn5.FlatAppearance.BorderColor = Color.Purple;
                        btn5.FlatAppearance.BorderSize = 1;

                        btn6.FlatAppearance.BorderColor = Color.Purple;
                        btn6.FlatAppearance.BorderSize = 1;

                        btn1.FlatAppearance.BorderColor = Color.Purple;
                        btn1.FlatAppearance.BorderSize = 1;      
                        break;
                    }
                case 3:
                    {
                        btnRelatorios.FlatAppearance.BorderColor = Color.Green;
                        btnRelatorios.FlatAppearance.BorderSize = 2;

                        btn1.FlatAppearance.BorderColor = Color.Purple;
                        btn1.FlatAppearance.BorderSize = 1;

                        btn5.FlatAppearance.BorderColor = Color.Purple;
                        btn5.FlatAppearance.BorderSize = 1;

                        btn6.FlatAppearance.BorderColor = Color.Purple;
                        btn6.FlatAppearance.BorderSize = 1;

                        btnFinanceiro.FlatAppearance.BorderColor = Color.Purple;
                        btnFinanceiro.FlatAppearance.BorderSize = 1;        
                        break;
                    }
                case 4:
                    {
                        btn5.FlatAppearance.BorderColor = Color.Green;
                        btn5.FlatAppearance.BorderSize = 2;

                        btnRelatorios.FlatAppearance.BorderColor = Color.Purple;
                        btnRelatorios.FlatAppearance.BorderSize = 1;

                        btn1.FlatAppearance.BorderColor = Color.Purple;
                        btn1.FlatAppearance.BorderSize = 1;

                        btn6.FlatAppearance.BorderColor = Color.Purple;
                        btn6.FlatAppearance.BorderSize = 1;

                        btnFinanceiro.FlatAppearance.BorderColor = Color.Purple;
                        btnFinanceiro.FlatAppearance.BorderSize = 1;       
                        break;
                    }
                case 5:
                    {
                        btn6.FlatAppearance.BorderColor = Color.Green;
                        btn6.FlatAppearance.BorderSize = 2;

                        btnRelatorios.FlatAppearance.BorderColor = Color.Purple;
                        btnRelatorios.FlatAppearance.BorderSize = 1;

                        btn5.FlatAppearance.BorderColor = Color.Purple;
                        btn5.FlatAppearance.BorderSize = 1;

                        btn1.FlatAppearance.BorderColor = Color.Purple;
                        btn1.FlatAppearance.BorderSize = 1;

                        btnFinanceiro.FlatAppearance.BorderColor = Color.Purple;
                        btnFinanceiro.FlatAppearance.BorderSize = 1;   
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
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

        //corrigi os numeros se forem digitados errado
        public string CorrigirNumerosDouble(string st)
        {
            try
            {
                Convert.ToDouble(st);
                return st;
            }
            catch
            {
                return "0,00";
            }
        }

        private void btnMensalidades_Click(object sender, EventArgs e)
        {
            btn5.Visible = btn6.Visible =  false;
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

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caixa ca = new Caixa();
            if (Application.OpenForms.OfType<Caixa>().Count() > 0)
            {
                MessageBox.Show("A Janela Caixa já está aberta!");
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

        private void mensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
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
                ca.Senha = Senha;
                ca.Id = Id;
                ca.Show();
            }
        }
    }
}
