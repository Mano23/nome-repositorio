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
    public partial class CadastroVendedor : MN_CADERNETA.CadastroBase
    {
        Classes.Vendedores ven = new Classes.Vendedores();
        Classes.Auditoria  audi = new Classes.Auditoria();

        private bool   localizar = false;//server para saber se vai salvar ou atualizar
        private string vusuario;
        private string vsenha;
        private int vid;

        //variavel usada para guardar o id do vendedor
        private int idvendedor;

        //variavel auxiliar para armazenar seu nome antes de auterar
        private string nomeaux;

        //variavel auxiliar para armazenar todas as senhas carregadas
        private List<string> senhaaux = new List<string>();

        //variavel auxiliar para armazenar todos os ids carregados
        private List<int> idaux = new List<int>();

        
        //propriedades
        public  string Usuario
        {
            get { return vusuario; }
            set { vusuario = value; }
        }
        public  string Senha
        {
            get { return vsenha; }
            set { vsenha = value; }
        }
        public  int Id
        {
            get { return vid; }
            set { vid = value; }
        }


        public CadastroVendedor()
        {
            InitializeComponent();
            pnInicial.Visible   = true;
            pnLocalizar.Visible = false;
        }

        //mudar cor do botão quando passa o mouse
        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK.BackColor = Color.FromArgb(0, 192, 0);
        }

        //mudar cor do botão quando passa o mouse
        private void pnLocalizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK.BackColor = Color.Green;
        }

        //Apaga os conteúdos de todos os campos
        private void ApagarCampos()
        {
            
            txtNome.Text = txtSenha.Text = txtRepitaSenha.Text = txtPesquisa.Text = "";
            lstPesquisa.Items.Clear();

        }

        //verifica se os dados foram preenchidos corretamente
        private bool VerificaSalvar()
        {
            //bool bSalvar = true;
            //essas linhas é para verificar se os campos de textos contem apenas caracteres

            int j = 0;
            bool h = false;

            //----------------Inicio Nome----------------------\\
                      
            //verifica se o nome foi digitado
            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            
            //----------------Fim Nome-------------------\\


            //----------------Inicio Senha---------------\\
            j = 0;
            h = false;

            //verfica se a senha digita possui apenas numeros e ou letras
            while (j < txtSenha.Text.Length)
            {
                if (!char.IsDigit(txtSenha.Text[j]) && !char.IsLetter(txtSenha.Text[j]))
                {
                    j = txtSenha.Text.Length;
                    h = true;
                }
                j++;
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo Senha com numeros e ou letras", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return false;
            }

            //verifica se a senha foi digitada
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Preencha o campo Senha!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Focus();
                return false;
            }

            //verifica se a senha é igual a senha digitada novamente
            if (txtSenha.Text != txtRepitaSenha.Text)
            {
                MessageBox.Show("Senha não confere!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRepitaSenha.Focus();
                return false;
            }
            //---------------------Fim Senha------------------------\\

            
            return true;
        }

        //metodo override do botão novo
        public override void Novo()
        {
            ApagarCampos();
            localizar = false;
            txtNome.Focus();
        }

        //metodo override do botão salvar
        public override bool Salvar()
        {
            if (pnLocalizar.Visible == false)
            {
                if (VerificaSalvar())
                {                    
                    //se for igual a false é pq vai salvar
                    if (localizar == false)
                    {

                        try
                        {
                            //verifica se já existe um usuario com esse nome
                            if (ven.CONSULTA_VENDEDOR(txtNome.Text).Rows.Count > 0)
                            {
                                MessageBox.Show("Já existe um usuário com este nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNome.Focus();
                                return false;
                            }
                            else
                            {
                                ven.INSERT_VENDEDOR(txtNome.Text, txtSenha.Text);
                                audi.INSERT_AUDITORIA(Id, " Cadastrou " + txtNome.Text + " como vendedor.", DateTime.Now);
                            }   
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao cadastrar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }


                    }

                    //senão é pq vai atualizar
                    else if (localizar == true) 
                    {

                        try
                        {
                         
                           //mudou seu nome
                           if (nomeaux != txtNome.Text)
                           {
                               //verifica se esse já existe um usuario com esse nome
                               if (ven.CONSULTA_VENDEDOR(txtNome.Text).Rows.Count > 0)
                               {
                                   MessageBox.Show("Já existe um usuário com este nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   txtNome.Focus();
                                   return false;
                               }

                           }

                            ven.UPDATE_VENDEDOR(txtNome.Text, txtSenha.Text, idvendedor);
                            audi.INSERT_AUDITORIA(Id, " Atualizou os dados do vendedor " + txtNome.Text, DateTime.Now);
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        finally
                        {
                            
                        }

                    }
                    return true;
                }
                else //vai retornar false se encontra algum erro de digitação do usuario
                    return false;
            }
            else//vai retornar false se tentar salvar ainda no painel de pesquisa
                return false;
        }

        //metodo override do botão excluir
        public override bool Excluir()
        {
            if (pnLocalizar.Visible == false)
            {
                //se o vendedor não realizou nenhuma operação ainda, então pode excluir
                if(audi.CONSULTA_AUDITORIA_IDVENDEDOR(idvendedor).Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ven.DELETE_VENDEDOR(idvendedor);
                        audi.INSERT_AUDITORIA(Id, "Excluiu o registro do vendedor " + txtNome.Text, DateTime.Now);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Vendedor não pode ser excluido, já foi feita alguma operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //se foi selecionado um item
                if (lstPesquisa.SelectedItems.Count != 0)
                {
                    txtNome.Text = "";
                    txtSenha.Text = "";

                    pnLocalizar.Visible = false;
                    pnInicial.Visible = true;
                    if (lstPesquisa.SelectedItems[0].Selected)
                    {
                        LimpaControles();
                        idvendedor = idaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    }
                }

                if (audi.CONSULTA_AUDITORIA_IDVENDEDOR(idvendedor).Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ven.DELETE_VENDEDOR(idvendedor);
                        audi.INSERT_AUDITORIA(Id, "Excluiu o registro do vendedor " + txtNome.Text, DateTime.Now);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Vendedor não pode ser excluido, já foi feita alguma operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return false;
        }

        //metodo override do botão localizar
        public override bool Localizar()
        {
            pnLocalizar.Visible = true;
            pnInicial.Visible   = false;
            CarregaTudo();

            txtPesquisa.Focus();
            return true;

        }

        //metodo override do botão cancelar
        public override void Cancelar()
        {
            ApagarCampos();            

            pnLocalizar.Visible = false;
            pnInicial.Visible   = true;

        }

        //carrega o list view da pesquisa com todos os nomes
        private void CarregaTudo()
        {
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;
            
            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                var produtos = ven.CONSULTA_VENDEDOR2().Rows;
                
                foreach (DataRow dr in produtos)
                {
                    ListViewItem lvi = new ListViewItem(contador.ToString());
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add("* * * * * * * * *");

                    
                    idaux.Add(Convert.ToInt16(dr[0].ToString()));
                    senhaaux.Add(dr[2].ToString());
                    
                    lstPesquisa.Items.Add(lvi);
                    contador++;
                }
                
            }
            txtPesquisa.Focus();
            
        }

        //carrega o list view da pesquisa com todos o nome pesquisado
        private void CarregaNome()
        {
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;
            lstPesquisa.Items.Clear();
            

            var produt = ven.CONSULTA_VENDEDOR_NOME(txtPesquisa.Text).Rows;
            foreach (DataRow dr in produt)
            {
                ListViewItem lvi = new ListViewItem(contador.ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add("* * * * * * * * *");


                idaux.Add(Convert.ToInt16(dr[0].ToString()));
                senhaaux.Add(dr[2].ToString());

                lstPesquisa.Items.Add(lvi);
                contador++;
            }
            
        }

        //campo para digitar a pesquisa
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregaNome();
        }


        //botão ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {                
                txtNome.Text  = "";
                txtSenha.Text = "";

                
                pnLocalizar.Visible = false;
                pnInicial.Visible   = true;
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    LimpaControles();
                    idvendedor    = idaux[ Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    txtNome.Text  = nomeaux = lstPesquisa.FocusedItem.SubItems[1].Text;
                    txtSenha.Text = txtRepitaSenha.Text = senhaaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)]; 
                    
                }

                //caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado
                localizar = true;
            }
        }

        //evento de dois clique na lista
        private void lstPesquisa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {
                txtNome.Text  = "";
                txtSenha.Text = "";

                pnLocalizar.Visible = false;
                pnInicial.Visible   = true;
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    LimpaControles();
                    idvendedor    = idaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    txtNome.Text  = nomeaux = lstPesquisa.FocusedItem.SubItems[1].Text;
                    txtSenha.Text = txtRepitaSenha.Text = senhaaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];

                }

                //caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado
                localizar = true;
            }
        }

      
        

       
    }
}
