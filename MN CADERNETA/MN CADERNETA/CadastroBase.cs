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
    public partial class CadastroBase : Form
    {
        //contem todos os tipos de status do cadastro
        public enum statusCadastro
        {
            scInserindo,
            scNavegando,
            scEditando,
            scLocalizando
        }

        //
        public statusCadastro sStatus;
        
        //
        public int _ncodGenerico;

        public CadastroBase()
        {
            InitializeComponent();
        }

        //comando teclado
        private void CadastroBase_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }



        //-----------------------inicio botões do menu-----------------------------------\\
        private void btnNovo_Click(object sender, EventArgs e)
        {
            sStatus = statusCadastro.scInserindo;
            LimpaControles();
            HabilitadesabilitaControles(true);
            Novo();//não tinha ná explicação, criei por necessidade
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Salvar())
            {
                sStatus = statusCadastro.scNavegando;
                LimpaControles();
                HabilitadesabilitaControles(false);
                MessageBox.Show("Registro salvo com sucesso", "Aviso do Sistema",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("O registro não foi salvo, por favor verifique os erros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Excluir())
            {


                sStatus = statusCadastro.scNavegando;
                LimpaControles();
                HabilitadesabilitaControles(false);
                MessageBox.Show("Registro excluido com sucesso", "Aviso do Sistema",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (Localizar())
            {
                sStatus = statusCadastro.scLocalizando;
                HabilitadesabilitaControles(true);
                CarregaValores();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            sStatus = statusCadastro.scNavegando;
            LimpaControles();
            HabilitadesabilitaControles(false);
            Cancelar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }        

        private void CadastroBase_Load(object sender, EventArgs e)
        {
            sStatus = statusCadastro.scNavegando;
            LimpaControles();
            HabilitadesabilitaControles(false);
        }        
        //-----------------------fim botões do menu----------------------------------------\\



        //limpa todos os componentes(textbox, combobox, etc)
        public void LimpaControles()//tava public, só que precisei dele lá no form usuario 
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                    (ctr as TextBox).Text = "";
                if (ctr is ComboBox)
                    (ctr as ComboBox).SelectedIndex = -1;
                if (ctr is ListBox)
                    (ctr as ListBox).SelectedIndex = -1;
                if (ctr is RadioButton)
                    (ctr as RadioButton).Checked = false;
                if (ctr is CheckBox)
                    (ctr as CheckBox).Checked = false;
                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items)
                        item.SelectedIndex = -1;
                }
            }
        }

        //desabilita e habilita todos os componentes(textbox, combobox, etc)
        public void HabilitadesabilitaControles(bool bValue)//tava public, só que precisei dele lá no form usuario 
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is ToolStrip)
                    continue;

                ctr.Enabled = bValue;
            }

            btnNovo.Enabled = (sStatus == statusCadastro.scNavegando);
            btnSalvar.Enabled = (sStatus == statusCadastro.scEditando || sStatus == statusCadastro.scInserindo || sStatus == statusCadastro.scLocalizando);
            btnExcluir.Enabled = (sStatus == statusCadastro.scEditando || sStatus == statusCadastro.scLocalizando);
            btnLocalizar.Enabled = (sStatus == statusCadastro.scNavegando);
            btnCancelar.Enabled = (sStatus == statusCadastro.scEditando || sStatus == statusCadastro.scInserindo
                                     || sStatus == statusCadastro.scLocalizando);

            //btnOk.Enabled = btnOk.Visible = (sStatus == statusCadastro.scLocalizando);
            btnFechar.Enabled = true;
        }



        //-----------------inicio métodos virtuais----------------\\
        public virtual void CarregaValores()
        {
        }

        public virtual void Novo()//criei por necessidade
        {
          
        }

        public virtual bool Salvar()
        {
            return false;
        }

        public virtual bool Excluir()
        {
            return false;
        }

        public virtual bool Localizar()
        {
            return false;
        }

        public virtual void Cancelar()
        {

        }
        //-----------------fim métodos virtuais--------------------\\


    }
}
