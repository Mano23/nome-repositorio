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
        Classes.Acertos    ace  = new Classes.Acertos();
        Classes.Caixas     cai  = new Classes.Caixas();
        Classes.Avaliacaos ava  = new Classes.Avaliacaos();


        MN_CADERNETA.FrmPrincipal frm = new MN_CADERNETA.FrmPrincipal();
        
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
            txtNome.Text         = txtCpf.Text             = txtRg.Text       = txtRua.Text              = txtNumero.Text = txtBairro.Text =
            txtTelefoneFixo.Text = txtTelefoneCelular.Text = txtPesquisa.Text = txtValorMensalidade.Text = txtPeso.Text   = txtCidade.Text =
            txtAltura.Text       = txtBD.Text              = txtBE.Text       = txtCD.Text               = txtCE.Text     = txtPD.Text     = txtPE.Text      = 
            txtQuadril.Text      = txtCintura.Text         = txtTorax.Text    = txtPescoco.Text           = txtAbdome.Text = txtGordura.Text = txtCintura.Text =  "";

            lstPesquisa.Items.Clear();
        }

        //verifica antes de salvar
        private bool VerificaSalvar()
        {
            //----------------Inicio Nome----------------------\\
                      
            //verifica se o nome foi digitado
            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }            
            //----------------Fim Nome-------------------\\           

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

                                //insere um cliente
                                cli.INSERT_CLIENTES(txtNome.Text,txtRua.Text,numero,txtBairro.Text, txtCidade.Text,txtCpf.Text, txtRg.Text,
                                                     ckbAtivo.Checked,txtTelefoneFixo.Text, txtTelefoneCelular.Text, Id);

                                //pesquisa o id do cliente através do id que acabou de ser cadastrado.
                                if (cli.CONSULTA_CLIENTE_NOME(txtPesquisa.Text).Rows.Count > 0)
                                {
                                    var produtos = cli.CONSULTA_CLIENTE_NOME(txtPesquisa.Text).Rows;
                                    
                                    foreach (DataRow dr in produtos)
                                    {
                                        idcliente = Convert.ToInt32(dr[0].ToString());
                                    }
                                }

                                //insere avaliação
                                ava.INSERT_AVALIACAO(idcliente                        , Convert.ToDouble(txtPeso.Text)   , Convert.ToDouble(txtAltura.Text),
                                                     Convert.ToDouble(txtBD.Text)     , Convert.ToDouble(txtBE.Text)     , Convert.ToDouble(txtCD.Text),
                                                     Convert.ToDouble(txtCE.Text)     , Convert.ToDouble(txtPD.Text)     , Convert.ToDouble(txtPE.Text), 
                                                     Convert.ToDouble(txtQuadril.Text), Convert.ToDouble(txtTorax.Text)  , Convert.ToDouble(txtAbdome.Text),
                                                     Convert.ToDouble(txtCintura.Text), Convert.ToDouble(txtPescoco.Text), Convert.ToDouble(txtGordura.Text), Id, dtpDataAvaliacao.Value);

                                //gera um boleto
                                ace.INSERT_ACERTO(idcliente,dtpDiaAcerto.Value,Convert.ToDouble(txtValorMensalidade.Text),false,dtpDiaAcerto.Value,0,Id);

                                //quitar a primeira parcela?
                                var result = MessageBox.Show("Quitar a 1° parcela?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (result == DialogResult.OK)
                                {
                                    ace.UPDATE_ACERTO(idcliente, dtpDiaAcerto.Value, Convert.ToDouble(txtValorMensalidade.Text), true, dtpDiaAcerto.Value, Convert.ToDouble(txtValorMensalidade.Text), Id);

                                    //encontra a ultima mensalidade quitada no caixa para gerar o numero da nova
                                    int maior =  0;
                                    string caixa = cai.CONSULTA_CAIXA__ORIGEM_MAIORID("MENSALIDADE").Rows[0][0].ToString();
                                    if (caixa == "")
                                        maior = 1;
                                    else
                                        maior = Convert.ToInt32(cai.CONSULTA_CAIXA__ORIGEM_MAIORID("MENSALIDADE").Rows[0][0].ToString()) + 1;

                                    cai.INSERT_CAIXA(maior, "Mensalidade " + txtNome.Text, Convert.ToDouble(txtValorMensalidade.Text), true, false, dtpDiaAcerto.Text, Id, "MENSALIDADE");

                                    //gerar mensalidade do proximo mês?
                                    var result2 = MessageBox.Show("Gerar a 2° parcela?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                    if (result2 == DialogResult.OK)
                                    {
                                        DateTime data = dtpDiaAcerto.Value;
                                        //gera um boleto
                                        ace.INSERT_ACERTO(idcliente, data = dtpDiaAcerto.Value.AddMonths(1), Convert.ToDouble(txtValorMensalidade.Text), false, dtpDiaAcerto.Value, 0, Id);
                                        //auditoria
                                        audi.INSERT_AUDITORIA(Id, " Cadastrou " + txtNome.Text + " como cliente e já quitou a primeira parcela e gerou a 2°", DateTime.Now);
                                    }

                                    //senão não vai gerar a segunda parcela
                                    else
                                        audi.INSERT_AUDITORIA(Id, " Cadastrou " + txtNome.Text + " como cliente e já quitou a primeira parcela", DateTime.Now);
                                }

                                //senão não vai gerar boleto
                                else
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

                            
                            //atualiza dados basicos do cliente
                            cli.UPDATE_CLIENTES(txtNome.Text, txtRua.Text, numero, txtBairro.Text, txtCidade.Text, txtCpf.Text, txtRg.Text,
                                                     ckbAtivo.Checked, txtTelefoneFixo.Text, txtTelefoneCelular.Text, idvend,idcliente);

                            //atualiza o acerto
                            string acerto = ace.CONSULTA_ACERTO_IDCLIENTE(idcliente).Rows.Count.ToString();
                            if (acerto == "0")
                                ace.INSERT_ACERTO(idcliente, dtpDiaAcerto.Value, Convert.ToDouble(txtValorMensalidade.Text), false, dtpDiaAcerto.Value, 0, Id);
                            else
                                ace.UPDATE_ACERTO(idcliente, dtpDiaAcerto.Value, Convert.ToDouble(txtValorMensalidade.Text), false, dtpDiaAcerto.Value, 0, Id);


                            //se vai cadastrar nova atualização
                            var result = MessageBox.Show("Deseja manter avaliação já cadastrada?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No)
                            {
                                //insere avaliação
                                ava.INSERT_AVALIACAO(idcliente, Convert.ToDouble(txtPeso.Text), Convert.ToDouble(txtAltura.Text),
                                                     Convert.ToDouble(txtBD.Text), Convert.ToDouble(txtBE.Text), Convert.ToDouble(txtCD.Text),
                                                     Convert.ToDouble(txtCE.Text), Convert.ToDouble(txtPD.Text), Convert.ToDouble(txtPE.Text),
                                                     Convert.ToDouble(txtQuadril.Text), Convert.ToDouble(txtTorax.Text), Convert.ToDouble(txtAbdome.Text),
                                                     Convert.ToDouble(txtCintura.Text), Convert.ToDouble(txtPescoco.Text), Convert.ToDouble(txtGordura.Text), Id, dtpDataAvaliacao.Value);
                            }

                            //insere auditoria
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
                if (ace.CONSULTA_ACERTO_IDCLIENTE(idcliente).Rows.Count == 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cli.DELETE_CLIENTE(idcliente);
                        ace.DELETE_ACERTO(idcliente);
                        ava.DELETE_AVALIACAO(idcliente);

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

                    //pesquisa pelo id do vendedor para achar o seu nome
                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    
                    //salva o id da pessoa que cadastrou para usar na atualização
                    idvend = Convert.ToInt16(dr[11].ToString());

                    //ao inves de colocar o id do vendedor, coloca o nome do mesmo
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }
                    
                    //salva em uma lista todos os id dos clientes
                    idaux.Add(Convert.ToInt16(dr[0].ToString()));

                    //consulta a mensalidade atraves do id do cliente
                    var produtos2 = ace.CONSULTA_ACERTO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr2 in produtos2)
                    {        
                        //vencimento
                        lvi.SubItems.Add(dr2[2].ToString());
                        //valor
                        lvi.SubItems.Add(dr2[3].ToString());
                    }

                    //consulta a avaliação atraves do id do cliente
                    var produtos3 = ava.CONSULTA_AVALIACAO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr3 in produtos3)
                    {
                        //peso
                        lvi.SubItems.Add(dr3[2].ToString());
                        //altura
                        lvi.SubItems.Add(dr3[3].ToString());
                        //BD
                        lvi.SubItems.Add(dr3[4].ToString());
                        //BE
                        lvi.SubItems.Add(dr3[5].ToString());
                        //CD
                        lvi.SubItems.Add(dr3[6].ToString());
                        //CE
                        lvi.SubItems.Add(dr3[7].ToString());
                        //PD
                        lvi.SubItems.Add(dr3[8].ToString());
                        //PE
                        lvi.SubItems.Add(dr3[9].ToString());
                        //QUADRIL
                        lvi.SubItems.Add(dr3[10].ToString());
                        //TORAX
                        lvi.SubItems.Add(dr3[11].ToString());
                        //ABDOME
                        lvi.SubItems.Add(dr3[12].ToString());
                        //CINTURA
                        lvi.SubItems.Add(dr3[13].ToString());
                        //PESCOÇO
                        lvi.SubItems.Add(dr3[14].ToString());
                        //GORDURA
                        lvi.SubItems.Add(dr3[15].ToString());
                        //DATA AVALIAÇÃO
                        lvi.SubItems.Add(dr3[17].ToString());
                    }

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

                    //pesquisa pelo id do vendedor para achar o seu nome
                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }


                    idaux.Add(Convert.ToInt16(dr[0].ToString()));

                    //consulta a mensalidade atraves do id do cliente
                    var produtos2 = ace.CONSULTA_ACERTO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr2 in produtos2)
                    {
                        //vencimento
                        lvi.SubItems.Add(dr2[2].ToString());
                        //valor
                        lvi.SubItems.Add(dr2[3].ToString());
                    }

                    //consulta a avaliação atraves do id do cliente
                    var produtos3 = ava.CONSULTA_AVALIACAO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr3 in produtos3)
                    {
                        //peso
                        lvi.SubItems.Add(dr3[2].ToString());
                        //altura
                        lvi.SubItems.Add(dr3[3].ToString());
                        //BD
                        lvi.SubItems.Add(dr3[4].ToString());
                        //BE
                        lvi.SubItems.Add(dr3[5].ToString());
                        //CD
                        lvi.SubItems.Add(dr3[6].ToString());
                        //CE
                        lvi.SubItems.Add(dr3[7].ToString());
                        //PD
                        lvi.SubItems.Add(dr3[8].ToString());
                        //PE
                        lvi.SubItems.Add(dr3[9].ToString());
                        //QUADRIL
                        lvi.SubItems.Add(dr3[10].ToString());
                        //TORAX
                        lvi.SubItems.Add(dr3[11].ToString());
                        //ABDOME
                        lvi.SubItems.Add(dr3[12].ToString());
                        //CINTURA
                        lvi.SubItems.Add(dr3[13].ToString());
                        //PESCOÇO
                        lvi.SubItems.Add(dr3[14].ToString());
                        //GORDURA
                        lvi.SubItems.Add(dr3[15].ToString());
                        //DATA AVALIAÇÃO
                        lvi.SubItems.Add(dr3[17].ToString());
                    }


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

                    //pesquisa pelo id do vendedor para achar o seu nome
                    var vend = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[11].ToString())).Rows;
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }


                    idaux.Add(Convert.ToInt16(dr[0].ToString()));

                    //consulta a mensalidade atraves do id do cliente
                    var produtos2 = ace.CONSULTA_ACERTO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr2 in produtos2)
                    {
                        //vencimento
                        lvi.SubItems.Add(dr2[2].ToString());
                        //valor
                        lvi.SubItems.Add(dr2[3].ToString());
                    }

                    //consulta a avaliação atraves do id do cliente
                    var produtos3 = ava.CONSULTA_AVALIACAO_IDCLIENTE_MAIOR(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr3 in produtos3)
                    {
                        //peso
                        lvi.SubItems.Add(dr3[2].ToString());
                        //altura
                        lvi.SubItems.Add(dr3[3].ToString());
                        //BD
                        lvi.SubItems.Add(dr3[4].ToString());
                        //BE
                        lvi.SubItems.Add(dr3[5].ToString());
                        //CD
                        lvi.SubItems.Add(dr3[6].ToString());
                        //CE
                        lvi.SubItems.Add(dr3[7].ToString());
                        //PD
                        lvi.SubItems.Add(dr3[8].ToString());
                        //PE
                        lvi.SubItems.Add(dr3[9].ToString());
                        //QUADRIL
                        lvi.SubItems.Add(dr3[10].ToString());
                        //TORAX
                        lvi.SubItems.Add(dr3[11].ToString());
                        //ABDOME
                        lvi.SubItems.Add(dr3[12].ToString());
                        //CINTURA
                        lvi.SubItems.Add(dr3[13].ToString());
                        //PESCOÇO
                        lvi.SubItems.Add(dr3[14].ToString());
                        //GORDURA
                        lvi.SubItems.Add(dr3[15].ToString());
                        //DATA AVALIAÇÃO
                        lvi.SubItems.Add(dr3[17].ToString());
                    }

                    lstPesquisa.Items.Add(lvi);
                    
                    contador++;
                }

            }
            txtPesquisa.Focus();

        }
        
        
        //campo para digitar a pesquisa
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (rdbNome.Checked == true)
                CarregaNome();
            else if (rdbCpf.Checked == true)
                CarregaCPF();           
        }

        //opção cpf
        private void rdbCpf_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Mask = "000,000,000-00";
        }

        //opção nome
        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Mask = "";
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

                    txtTelefoneFixo.Text     = lstPesquisa.FocusedItem.SubItems[9].Text;
                    txtTelefoneCelular.Text  = lstPesquisa.FocusedItem.SubItems[10].Text;
                    dtpDiaAcerto.Text        = lstPesquisa.FocusedItem.SubItems[12].Text;
                    txtValorMensalidade.Text = lstPesquisa.FocusedItem.SubItems[13].Text;
                    txtPeso.Text             = lstPesquisa.FocusedItem.SubItems[14].Text;
                    txtAltura.Text           = lstPesquisa.FocusedItem.SubItems[15].Text;
                    txtBD.Text               = lstPesquisa.FocusedItem.SubItems[16].Text;
                    txtBE.Text               = lstPesquisa.FocusedItem.SubItems[17].Text;
                    txtCD.Text               = lstPesquisa.FocusedItem.SubItems[18].Text;
                    txtCE.Text               = lstPesquisa.FocusedItem.SubItems[19].Text;
                    txtPD.Text               = lstPesquisa.FocusedItem.SubItems[20].Text;
                    txtPE.Text               = lstPesquisa.FocusedItem.SubItems[21].Text;
                    txtQuadril.Text          = lstPesquisa.FocusedItem.SubItems[22].Text;
                    txtTorax.Text            = lstPesquisa.FocusedItem.SubItems[23].Text;
                    txtAbdome.Text           = lstPesquisa.FocusedItem.SubItems[24].Text;
                    txtCintura.Text          = lstPesquisa.FocusedItem.SubItems[25].Text;
                    txtPescoco.Text          = lstPesquisa.FocusedItem.SubItems[26].Text;
                    txtGordura.Text          = lstPesquisa.FocusedItem.SubItems[27].Text;
                    dtpDataAvaliacao.Text    = lstPesquisa.FocusedItem.SubItems[28].Text;
                    

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

                    txtTelefoneFixo.Text     = lstPesquisa.FocusedItem.SubItems[9].Text;
                    txtTelefoneCelular.Text  = lstPesquisa.FocusedItem.SubItems[10].Text;
                    dtpDiaAcerto.Text        = lstPesquisa.FocusedItem.SubItems[12].Text;
                    txtValorMensalidade.Text = lstPesquisa.FocusedItem.SubItems[13].Text;
                    txtPeso.Text             = lstPesquisa.FocusedItem.SubItems[14].Text;
                    txtAltura.Text           = lstPesquisa.FocusedItem.SubItems[15].Text;
                    txtBD.Text               = lstPesquisa.FocusedItem.SubItems[16].Text;
                    txtBE.Text               = lstPesquisa.FocusedItem.SubItems[17].Text;
                    txtCD.Text               = lstPesquisa.FocusedItem.SubItems[18].Text;
                    txtCE.Text               = lstPesquisa.FocusedItem.SubItems[19].Text;
                    txtPD.Text               = lstPesquisa.FocusedItem.SubItems[20].Text;
                    txtPE.Text               = lstPesquisa.FocusedItem.SubItems[21].Text;
                    txtQuadril.Text          = lstPesquisa.FocusedItem.SubItems[22].Text;
                    txtTorax.Text            = lstPesquisa.FocusedItem.SubItems[23].Text;
                    txtAbdome.Text           = lstPesquisa.FocusedItem.SubItems[24].Text;
                    txtCintura.Text          = lstPesquisa.FocusedItem.SubItems[25].Text;
                    txtPescoco.Text          = lstPesquisa.FocusedItem.SubItems[26].Text;
                    txtGordura.Text          = lstPesquisa.FocusedItem.SubItems[27].Text;
                    dtpDataAvaliacao.Text    = lstPesquisa.FocusedItem.SubItems[28].Text;



                }

                //caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado
                localizar = true;
            }
        }

        //arruma o valor quando alguem digita errado
        private void txtValorMensalidade_TextChanged(object sender, EventArgs e)
        {   
            try
            {
                Convert.ToDouble(txtValorMensalidade.Text);
            }
            catch 
            {
                txtValorMensalidade.Text = "0,00";
                
            }

        }

        //arruma o peso quando alguem digita errado
        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtPeso.Text);
            }
            catch 
            {
                txtPeso.Text = "0,00";
                
            }
        }

        //arruma o altura quando alguem digita errado
        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtAltura.Text);
            }
            catch 
            {
                txtAltura.Text = "0,00";
            }
        }

        //arruma o BD quando alguem digita errado
        private void txtBD_TextChanged(object sender, EventArgs e)
        {
            txtBD.Text = frm.CorrigirNumerosDouble(txtBD.Text);
        }

        //arruma o BE quando alguem digita errado
        private void txtBE_TextChanged(object sender, EventArgs e)
        {
            txtBE.Text = frm.CorrigirNumerosDouble(txtBE.Text);
        }

        //arruma o CD quando alguem digita errado
        private void txtCD_TextChanged(object sender, EventArgs e)
        {
            txtCD.Text = frm.CorrigirNumerosDouble(txtCD.Text);
        }

        //arruma o CE quando alguem digita errado
        private void txtCE_TextChanged(object sender, EventArgs e)
        {
            txtCE.Text = frm.CorrigirNumerosDouble(txtCE.Text);

        }

        //arruma o PD quando alguem digita errado
        private void txtPD_TextChanged(object sender, EventArgs e)
        {
            txtPD.Text = frm.CorrigirNumerosDouble(txtPD.Text);

        }

        //arruma o PE quando alguem digita errado
        private void txtPE_TextChanged(object sender, EventArgs e)
        {
            txtPE.Text = frm.CorrigirNumerosDouble(txtPE.Text);

        }

        //arruma o quadril quando alguem digita errado
        private void txtQuadril_TextChanged(object sender, EventArgs e)
        {
            txtQuadril.Text = frm.CorrigirNumerosDouble(txtQuadril.Text);

        }        

        //arruma o torax quando alguem digita errado
        private void txtTorax_TextChanged(object sender, EventArgs e)
        {
            txtTorax.Text = frm.CorrigirNumerosDouble(txtTorax.Text);
        }

        //arruma o pescoço quando alguem digita errado
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            txtPescoco.Text = frm.CorrigirNumerosDouble(txtPescoco.Text);
        }

        //arruma o abdome quando alguem digita errado
        private void txtAbdome_TextChanged(object sender, EventArgs e)
        {
            txtAbdome.Text = frm.CorrigirNumerosDouble(txtAbdome.Text);

        }

        //arruma a gordura quando alguem digita errado
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            txtGordura.Text = frm.CorrigirNumerosDouble(txtGordura.Text);
        }

        //arruma a cintura quando alguem digita errado
        private void txtCintura_TextChanged(object sender, EventArgs e)
        {
           txtCintura.Text = frm.CorrigirNumerosDouble(txtCintura.Text);

        }

        //arruma o rg quando alguem digita errado
        private void txtRg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt64(txtRg.Text);
            }
            catch
            {
                txtRg.Text = "";
            }
        }

        private void lstPesquisa_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtPesquisa_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        

        

       

      

        
       

    }
}
