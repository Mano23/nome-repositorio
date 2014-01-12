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
    public partial class CadastroCliente : MN_CADERNETA.CadastroBase
    {
        Classes.Clientes   cli  = new Classes.Clientes();
        Classes.Auditoria  audi = new Classes.Auditoria();
        Classes.Cadernetas cad  = new Classes.Cadernetas();
        Classes.Vendedores ven  = new Classes.Vendedores();
        
        private string vusuario;        
        private string vsenha;
        private int vid;

        public string Usuario
        {
            get { return vusuario; }
            set { vusuario = value; }
        }
        public string Senha//variavel do form principal
        {
            get { return vsenha; }
            set { vsenha = value; }
        }
        public int Id
        {
            get { return vid; }
            set { vid = value; }
        }
        
        //server para saber se vai salvar ou atualizar
        private bool localizar = false;

        //variavel usada para guardar o id do cliente
        private int idcliente;

        //variavel usada para guardar o id do vendedor para salvar, diferente da utilidade dos outros forms
        private int idvend;

        //variavel auxiliar para armazenar seu nome antes de auterar
        private string nomeaux;
        
        //variavel auxiliar para armazenar todos os ids carregados
        private List<int> idaux = new List<int>();


        public CadastroCliente()
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

        //apaga todos os campos
        private void ApagarCampos()
        {
            txtNome.Text = txtCpf.Text = txtRg.Text = txtRua.Text = txtNumero.Text = txtBairro.Text = txtCidade.Text =
            txtTelefoneFixo.Text = txtTelefoneCelular.Text = txtPesquisa.Text = "";
            lstPesquisa.Items.Clear();
        }

        //verifica antes de salvar
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

            //----------------inicio CPF-----------------\\

            j = 0;
            h = false;

            while (j < txtCpf.Text.Length)
            {
                if (!char.IsDigit(txtCpf.Text[j]))
                {
                    j = txtCpf.Text.Length;
                    h = true;
                }
                j++;
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo CPF somente com numeros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Focus();
                return false;
            }
            
            //-----------------fim CPF---------------------\\


            //----------------inicio RG-----------------\\
            j = 0;
            h = false;

            while (j < txtRg.Text.Length)
            {
                if (!char.IsDigit(txtRg.Text[j]))
                {
                    j = txtRg.Text.Length;
                    h = true;
                }
                j++;
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo RG somente com numeros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRg.Focus();
                return false;
            }
            
            //-----------------fim RG---------------------\\

            //----------------inicio RG-----------------\\
            j = 0;
            h = false;

            while (j < txtRg.Text.Length)
            {
                if (!char.IsDigit(txtRg.Text[j]))
                {
                    j = txtRg.Text.Length;
                    h = true;
                }
                j++;
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo RG somente com numeros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRg.Focus();
                return false;
            }

            //-----------------fim RG---------------------\\

            return true;
        }


        //-----------------inicio metedos overrides------------------------\\
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
                            if (cli.CONSULTA_CLIENTE(txtNome.Text).Rows.Count > 0)
                            {
                                MessageBox.Show("Já existe um cliente com este nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNome.Focus();
                                return false;
                            }
                            else
                            {
                                int numero;
                                if (txtNumero.Text == "")
                                    numero = 0;
                                else
                                    numero = Convert.ToInt16(txtNumero.Text);

                                cli.INSERT_CLIENTES(txtNome.Text,txtRua.Text,numero,txtBairro.Text, txtCidade.Text,txtCpf.Text, txtRg.Text,
                                                     ckbAtivo.Checked,txtTelefoneFixo.Text, txtTelefoneCelular.Text, Id);

                                audi.INSERT_AUDITORIA(Id, " Cadastrou " + txtNome.Text + " como cliente.", DateTime.Now);
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
                            //mudou o nome
                            if (nomeaux != txtNome.Text)
                            {
                                //verifica se já existe um usuario com esse nome
                                if (cli.CONSULTA_CLIENTE(txtNome.Text).Rows.Count > 0)
                                {
                                    MessageBox.Show("Já existe um cliente com este nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNome.Focus();
                                    return false;
                                }

                            }

                            int numero;
                            if (txtNumero.Text == "")
                                numero = 0;
                            else
                                numero = Convert.ToInt16(txtNumero.Text);

                            cli.UPDATE_CLIENTES(txtNome.Text, txtRua.Text, numero, txtBairro.Text, txtCidade.Text, txtCpf.Text, txtRg.Text,
                                                     ckbAtivo.Checked, txtTelefoneFixo.Text, txtTelefoneCelular.Text, idvend,idcliente);

                            audi.INSERT_AUDITORIA(Id, " Atualizou os dados do cliente " + txtNome.Text, DateTime.Now);


                        }
                        catch
                        {
                            MessageBox.Show("Erro ao atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }

                    }
                    return true;
                }
                else //vai retornar false se encontra algum erro de digitação do usuario
                    return false;
            }
            else//vai retornar false se tentar salvar ainda no painel de pesquisa*/
                return false;
        }

        //metodo override do botão excluir
        public override bool Excluir()
        {
            if (pnLocalizar.Visible == false)
            {
                //se o cliente não realizou nenhuma operação ainda, então pode excluir
                if (cad.CONSULTA_CADERNETA_IDCLIENTE(idcliente).Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cli.DELETE_CLIENTE(idcliente);
                        audi.INSERT_AUDITORIA(Id, "Excluiu o registro do cliente " + txtNome.Text, DateTime.Now);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não pode ser excluido, já foi feita alguma operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //se foi selecionado um item
                if (lstPesquisa.SelectedItems.Count != 0)
                {                    
                    pnLocalizar.Visible = false;
                    pnInicial.Visible   = true;
                    if (lstPesquisa.SelectedItems[0].Selected)
                    {
                        LimpaControles();
                        idcliente = idaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    }
                }

                //se o cliente não realizou nenhuma operação ainda, então pode excluir
                if (cad.CONSULTA_CADERNETA_IDCLIENTE(idcliente).Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cli.DELETE_CLIENTE(idcliente);
                        audi.INSERT_AUDITORIA(Id, "Excluiu o registro do cliente " + txtNome.Text, DateTime.Now);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não pode ser excluido, já foi feita alguma operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            pnInicial.Visible = true;
        }
        //-----------------fim metodos overrides---------------------------\\


        //carrega o list view da pesquisa com todos os nomes
        private void CarregaTudo()
        {
            //limpa os ids guardados de outras  pesquisas
            idaux.Clear();
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;

            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                var produtos = cli.CONSULTA_CLIENTE2().Rows;

                foreach (DataRow dr in produtos)
                {
                    ListViewItem lvi = new ListViewItem(contador.ToString());
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());
                    lvi.SubItems.Add(dr[5].ToString());
                    lvi.SubItems.Add(dr[6].ToString());
                    lvi.SubItems.Add(dr[7].ToString());
                    lvi.SubItems.Add(dr[8].ToString());
                    lvi.SubItems.Add(dr[9].ToString());
                    lvi.SubItems.Add(dr[10].ToString());

                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    
                    //salva o id da pessoa que cadastrou para usar na atualização
                    idvend = Convert.ToInt16(dr[11].ToString());

                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }
                    

                    idaux.Add(Convert.ToInt16(dr[0].ToString()));
                    

                    lstPesquisa.Items.Add(lvi);
                    contador++;
                }

            }
            txtPesquisa.Focus();

        }

        //carrega o list view da pesquisa com o nome digitado
        private void CarregaNome()
        {
            //limpa os ids guardados de outras  pesquisas
            idaux.Clear();
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;

            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                var produtos = cli.CONSULTA_CLIENTE_NOME(txtPesquisa.Text).Rows;

                foreach (DataRow dr in produtos)
                {
                    ListViewItem lvi = new ListViewItem(contador.ToString());
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());
                    lvi.SubItems.Add(dr[5].ToString());
                    lvi.SubItems.Add(dr[6].ToString());
                    lvi.SubItems.Add(dr[7].ToString());
                    lvi.SubItems.Add(dr[8].ToString());
                    lvi.SubItems.Add(dr[9].ToString());
                    lvi.SubItems.Add(dr[10].ToString());

                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }


                    idaux.Add(Convert.ToInt16(dr[0].ToString()));


                    lstPesquisa.Items.Add(lvi);
                    contador++;
                }

            }
            txtPesquisa.Focus();

        }

        //carrega o list view da pesquisa com o CPF digitado
        private void CarregaCPF()
        {
            //limpa os ids guardados de outras  pesquisas
            idaux.Clear();
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;

            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                var produtos = cli.CONSULTA_CLIENTE_CPF(txtPesquisa.Text).Rows;

                foreach (DataRow dr in produtos)
                {
                    ListViewItem lvi = new ListViewItem(contador.ToString());
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());
                    lvi.SubItems.Add(dr[5].ToString());
                    lvi.SubItems.Add(dr[6].ToString());
                    lvi.SubItems.Add(dr[7].ToString());
                    lvi.SubItems.Add(dr[8].ToString());
                    lvi.SubItems.Add(dr[9].ToString());
                    lvi.SubItems.Add(dr[10].ToString());

                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }


                    idaux.Add(Convert.ToInt16(dr[0].ToString()));


                    lstPesquisa.Items.Add(lvi);
                    contador++;
                }

            }
            txtPesquisa.Focus();

        }

        //campo para digitar a pesquisa
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rdbNome.Checked == true)
                CarregaNome();
            else if (rdbCpf.Checked == true)
                CarregaCPF();
        }

        //botão ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {

                txtNome.Text = txtCpf.Text = txtRg.Text = txtRua.Text = txtNumero.Text = txtBairro.Text = txtCidade.Text =
                txtTelefoneFixo.Text = txtTelefoneCelular.Text = "";

                pnLocalizar.Visible = false;
                pnInicial.Visible   = true;
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    LimpaControles();
                    idcliente      = idaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    txtNome.Text   = nomeaux = lstPesquisa.FocusedItem.SubItems[1].Text;
                    txtRua.Text    = lstPesquisa.FocusedItem.SubItems[2].Text;
                    txtNumero.Text = lstPesquisa.FocusedItem.SubItems[3].Text;
                    txtBairro.Text = lstPesquisa.FocusedItem.SubItems[4].Text;
                    txtCidade.Text = lstPesquisa.FocusedItem.SubItems[5].Text;
                    txtCpf.Text    = lstPesquisa.FocusedItem.SubItems[6].Text;
                    txtRg.Text     = lstPesquisa.FocusedItem.SubItems[7].Text;

                    if (lstPesquisa.FocusedItem.SubItems[8].Text == "True")
                        ckbAtivo.Checked = true;
                    else
                        ckbAtivo.Checked = false;

                    txtTelefoneFixo.Text    = lstPesquisa.FocusedItem.SubItems[9].Text;
                    txtTelefoneCelular.Text = lstPesquisa.FocusedItem.SubItems[10].Text;

                    

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

                txtNome.Text = txtCpf.Text = txtRg.Text = txtRua.Text = txtNumero.Text = txtBairro.Text = txtCidade.Text =
                txtTelefoneFixo.Text = txtTelefoneCelular.Text = "";

                pnLocalizar.Visible = false;
                pnInicial.Visible = true;
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    LimpaControles();
                    idcliente = idaux[Convert.ToInt16(lstPesquisa.FocusedItem.SubItems[0].Text)];
                    txtNome.Text = nomeaux = lstPesquisa.FocusedItem.SubItems[1].Text;
                    txtRua.Text = lstPesquisa.FocusedItem.SubItems[2].Text;
                    txtNumero.Text = lstPesquisa.FocusedItem.SubItems[3].Text;
                    txtBairro.Text = lstPesquisa.FocusedItem.SubItems[4].Text;
                    txtCidade.Text = lstPesquisa.FocusedItem.SubItems[5].Text;
                    txtCpf.Text = lstPesquisa.FocusedItem.SubItems[6].Text;
                    txtRg.Text = lstPesquisa.FocusedItem.SubItems[7].Text;

                    if (lstPesquisa.FocusedItem.SubItems[8].Text == "True")
                        ckbAtivo.Checked = true;
                    else
                        ckbAtivo.Checked = false;

                    txtTelefoneFixo.Text = lstPesquisa.FocusedItem.SubItems[9].Text;
                    txtTelefoneCelular.Text = lstPesquisa.FocusedItem.SubItems[10].Text;



                }

                //caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado
                localizar = true;
            }
        }

        

       

        

    }
}
