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
    public partial class Login : Form
    {
        Classes.Conexão    CO  = new Classes.Conexão();
        Classes.Vendedores VE  = new Classes.Vendedores();
        CadastroVendedor   ven = new CadastroVendedor();

        private string vusuario;//essas duas variaveis e esses duas propriedade foram criadas para receber o 
        private string vsenha;//usuario e senha logado para poder usar no frmprincipal
        private int vid;
        private string verro;
        public  string erro
        {
            get { return verro; }
            set { verro = value; }
        }
        public  string usuario
        {
            get { return vusuario; }
            set { vusuario = value; }

        }
        public  string senha
        {
            get { return vsenha; }
            set { vsenha = value; }

        }
        public int id
        {
            get { return vid; }
            set { vid = value; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void lblGerenciador_Click(object sender, EventArgs e)
        {

        }

        //valida vendedor e senha
        private void Validar()
        {
            //se o usuario e senha existir, então a janela de login é fechada
            if (Convert.ToInt16(VE.CONSULTA_VENDEDOR_SENHA(txtUsuario.Text, txtSenha.Text).Rows.Count) > 0)
            {
                Close();
                DialogResult = DialogResult.OK;
                usuario      = txtUsuario.Text;
                senha        = txtSenha.Text;
                var ids = VE.CONSULTA_VENDEDOR_SENHA(txtUsuario.Text, txtSenha.Text).Rows;
                
                foreach (DataRow dr in ids)
                  id = Convert.ToInt16(dr[0].ToString());                    
                
                
                
            }

            //senão, vai verificar se o usuario já está cadastrado
            else if (VE.CONSULTA_VENDEDOR_NOME(txtUsuario.Text).Rows.Count > 0)
                lblErro.Text = "Olá " + txtUsuario.Text + ", " + "sua senha está errada";

            //senão, o usuario não existe
            else
                lblErro.Text = "Usuario não cadastrado";
        }

        //comandos do teclado
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Validar();
            }
        }

        //botão ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            Validar();
        }

        //botão cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;            
        }

        //evento ao carregar a pagina, ira verificar se a conexão com o banco está certa
        private void Login_Load(object sender, EventArgs e)
        {            
            txtUsuario.Focus();
            if (CO.Conectar_Teste() == "erro")
            {
                MessageBox.Show("Arquivo DADOS.TXT não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                DialogResult = DialogResult.Cancel;
            }
            else
                try
                {
                    //se não tiver vendedor cadastrado, abrira uma janela para cadastrar, se não cadastrar o programa fecha.
                    if (VE.CONSULTA_VENDEDOR2().Rows.Count == 0)
                    {
                        MessageBox.Show("Não tem vendedor cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ven.ShowDialog();
                        if (VE.CONSULTA_VENDEDOR2().Rows.Count == 0)
                            Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Erro no caminho da conexão, verifique o arquivo DADOS.TXT", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    DialogResult = DialogResult.Cancel;
                }
        }
    }
}
