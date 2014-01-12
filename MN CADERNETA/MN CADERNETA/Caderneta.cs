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
    public partial class Caderneta : Form
    {

        Classes.Clientes cli = new Classes.Clientes();
        Classes.Auditoria audi = new Classes.Auditoria();
        Classes.Cadernetas cad = new Classes.Cadernetas();
        Classes.Vendedores ven = new Classes.Vendedores();


        private string vusuario;

        private string vsenha;
        private int vid;

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

        private List<int> IDCADERNETA = new List<int>();

        //variavel usada para guardar o id do cliente para salvar, diferente da utilidade dos outros forms
        private int idcliente;

        //variavel usada para guardar o numero da caderneta para salvar
        private int numerocaderneta;

        //variavel usada para guardar o id da caderneta para salvar
        private int idcaderneta;

        public Caderneta()
        {
            InitializeComponent();

            //combo box pesquisa começa com valor nome
            cbbTPesquisa.Text = "Nome";

            //desativa todos os componentes que estão nesses panels
            panel3.Enabled = panel4.Enabled = false;

            //deixa a lista invisivel
            lstPesquisa.Visible = false;
        }

        //mudar cor do botão quando passa o mouse
        private void btnGravar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGravar.BackColor = Color.FromArgb(0, 192, 0);
        }

        //mudar cor do botão quando passa o mouse
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            btnGravar.BackColor = Color.Green;
        }

        //mudar cor do botão quando passa o mouse
        private void btnPagar_MouseMove(object sender, MouseEventArgs e)
        {
            btnPagar.BackColor = Color.FromArgb(192, 0, 192);
        }

        //mudar cor do botão quando passa o mouse
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            btnPagar.BackColor = Color.Purple;
        }

        //comando teclado
        private void Caderneta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }

        //carrega o list view da pesquisa com todos os nomes dos clientes cadastrados
        private void CarregaNome()
        {
            idcliente = 0;
            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                if (cli.CONSULTA_CLIENTE_NOME(txtPesquisa.Text).Rows.Count > 0)
                {
                    var produtos = cli.CONSULTA_CLIENTE_NOME(txtPesquisa.Text).Rows;
                    string nucader = "";
                    foreach (DataRow dr in produtos)
                    {
                        //pesquisando o numero da caderneta do cliente
                        var produtoss = cad.CONSULTA_CADERNETA_IDCLIENTE(Convert.ToInt16(dr[0].ToString())).Rows;
                        foreach (DataRow dr2 in produtoss)
                        {
                            nucader = dr2[8].ToString();
                        }


                        ListViewItem lvi = new ListViewItem(nucader);
                        lvi.SubItems.Add(dr[1].ToString());


                        lstPesquisa.Items.Add(lvi);
                    }
                    lstPesquisa.Visible = true;
                }
                else
                    lstPesquisa.Visible = false;
            }
            txtPesquisa.Focus();
        }


        //carrega o list view da pesquisa com todos os nomes
        private void CarregaNumerCaderneta()
        {
            //começa de 0 para não interferir na outra
            idcliente = 0;
            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {                
                int pesquisa = 0;
                if (txtPesquisa.Text != "")
                {  
                   try
                   {
                       pesquisa = Convert.ToInt16(txtPesquisa.Text);
                   }
                   catch
                   {
                       MessageBox.Show("Preencha o campo Pesquisa corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                }

                if (cad.CONSULTA_CADERNETA_NUMERO_CADERNETA(pesquisa).Rows.Count > 0)
                {
                    var produtos = cad.CONSULTA_CADERNETA_NUMERO_CADERNETA(pesquisa).Rows;
                    ListViewItem lvi = new ListViewItem();
                    foreach (DataRow dr in produtos)
                    {
                        lvi = new ListViewItem(dr[8].ToString());

                        //faz uma pesquisa com o id do cliente na tabela do cliente para se ter o nome do cliente
                        var produtos2 = cli.CONSULTA_CLIENTE_ID(Convert.ToInt16(dr[1].ToString())).Rows;
                        foreach (DataRow dr2 in produtos2)
                        {
                            lvi.SubItems.Add(dr2[1].ToString());
                        }

                        //salva o id do cliente e o id da caderneta para salvar na caderneta
                        idcliente = Convert.ToInt16(dr[1].ToString());

                        //pegando o numero da cadernenta
                        numerocaderneta = Convert.ToInt16(dr[8].ToString());

                        //foi comentado devido que todas as compras estão aparecendo
                        //lstPesquisa.Items.Add(lvi);
                    }
                    lstPesquisa.Items.Add(lvi);
                    lstPesquisa.Visible = true;
                }
                else
                    lstPesquisa.Visible = false;
            }
            txtPesquisa.Focus();
        }

        //textbox pesquisa
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //se apagar tudo que tiver no listview pesquisa, então o panel pesquisa some
            if (txtPesquisa.Text == "")
            {
                lstPesquisa.Visible = false;
                txtCaderneta.Enabled = false;
            }

            //caso contrario ele aparece
            else
            {
                
                if (cbbTPesquisa.Text == "Nome")
                    CarregaNome();
                else if (cbbTPesquisa.Text == "Número Caderneta")
                    CarregaNumerCaderneta();
            }
            lblErroNCaderneta.Visible = false;
            
        }

        //evento de dois clique na lista pesquisa
        private void lstPesquisa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega os dados de venda do cliente e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    lstCaderneta.Items.Clear();

                    //desativando o lista de pesquisa
                    lstPesquisa.Visible = false;

                    //limpando o campo de pesquisa
                    txtPesquisa.Text = "";

                    //se for diferente de 0 é pq a pesquisa pode ser feita pelo id do cliente pego na pesquisa por numero da caderneta
                    if (idcliente != 0)
                    {
                        //pesquisa o nome do cliente através do seu id
                        var cliente = cli.CONSULTA_CLIENTE_ID(idcliente).Rows;

                        foreach (DataRow dr in cliente)
                        {
                            txtNomeCliente.Text = dr[1].ToString();
                        }

                        txtCaderneta.Enabled = true;
                        //numero da caderneta
                        txtCaderneta.Text = numerocaderneta.ToString();
                    }

                    //senão, pego o nome do cliente, e pesquiso pelo seu id e numero da caderneta
                    else
                    {
                        string nomecliente;

                        nomecliente = lstPesquisa.FocusedItem.SubItems[1].Text;

                        //faz uma pesquisa com o nome do cliente na tabela do cliente para saber seu id
                        var produtos2 = cli.CONSULTA_CLIENTE_NOME(nomecliente).Rows;
                        foreach (DataRow dr2 in produtos2)
                        {
                            idcliente = Convert.ToInt16(dr2[0].ToString());
                            txtNomeCliente.Text = nomecliente;
                        }



                        //faz uma pesquisa com o id do cliente para saber o numero da sua caderneta  
                        if (cad.CONSULTA_CADERNETA_IDCLIENTE(idcliente).Rows.Count > 0)
                        {
                            var produtos22 = cad.CONSULTA_CADERNETA_IDCLIENTE(idcliente).Rows;
                            foreach (DataRow dr22 in produtos22)
                            {
                                numerocaderneta = Convert.ToInt16(dr22[8].ToString());
                            }
                        }
                        else
                            numerocaderneta = 0;
                        txtCaderneta.Enabled = true;
                        txtCaderneta.Clear();
                        txtCaderneta.Text = numerocaderneta.ToString();

                    }

                }  
            }
           txtCaderneta.Focus();
        }

        //verifica se o numero da caderneta foi digitado
        private bool VerificaIdCaderneta()
        {
            int j = 0;
            bool h = false;

            while (j < txtCaderneta.Text.Length)
            {
                if (!char.IsDigit(txtCaderneta.Text[j]))
                {
                    j = txtCaderneta.Text.Length;
                    h = true;
                }
                j++;
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo Numero Caderneta somente com numeros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCaderneta.Focus();
                return false;
            }
            return true;
        }

        //verfica o numero da caderneta e preenche a lista da caderneta
        private void txtCaderneta_TextChanged(object sender, EventArgs e)
        {

            if (txtCaderneta.Text != "")
            {
                lblErroNCaderneta.Visible = true;
                //se foi digitado um numero
                if (VerificaIdCaderneta() == true)
                {
                    int numcaderneta = Convert.ToInt16(txtCaderneta.Text);

                    //verifico se o o numero da caderneta é 0
                    if (numcaderneta == 0)
                    {
                        lblErroNCaderneta.Text = "Numero não pode ser 0!";
                        lblErroNCaderneta.ForeColor = Color.OrangeRed;
                        panel3.Enabled = panel4.Enabled = false;
                        lblTotalPagar2.Text = "R$ 0,00";
                        txtPagar2.Text = "";
                        lblTroco2.Text = "R$ ";
                        lblTroco3.Text = "0,00";
                        dtpDataPag.Text = DateTime.Now.Date.ToString();
                    }

                    //verifico se o numero da caderneta já tem dono
                    else if (cad.CONSULTA_CADERNETA_IDCADERNETA(numcaderneta).Rows.Count > 0)
                    {
                        //a caderneta é minha
                        if (cad.CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(numcaderneta, idcliente).Rows.Count > 0)
                        {
                            //limpa a lista com os ids
                            IDCADERNETA.Clear();

                            lblErroNCaderneta.Text = "Numero liberado!";
                            lblErroNCaderneta.ForeColor = Color.DarkGreen;
                            txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                            lstCaderneta.Items.Clear();
                            panel3.Enabled = true;
                            panel4.Enabled = false;
                            lblTotalPagar2.Text = "R$ 0,00";
                            txtPagar2.Text = "";
                            lblTroco2.Text = "R$ ";
                            lblTroco3.Text = "0,00";
                            dtpDataPag.Text = DateTime.Now.Date.ToString();
                            txtProduto.Focus();

                            lstCaderneta.Items.Clear();

                            //soma todos os totais 
                            double totalpagar = 0;
                            //preenche a lista caderneta com as informações da caderneta do cliente 
                            var produtos = cad.CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(numcaderneta, idcliente, Convert.ToDateTime("01/01/1753 12:00:00")).Rows;
                            foreach (DataRow dr in produtos)
                            {
                                //armazena todos os ids
                                IDCADERNETA.Add(Convert.ToInt16(dr[0].ToString()));

                                ListViewItem lvi = new ListViewItem(dr[2].ToString());
                                lvi.SubItems.Add(dr[3].ToString());
                                lvi.SubItems.Add(dr[4].ToString());


                                double a, b;
                                a = Convert.ToDouble(dr[3].ToString());
                                b = Convert.ToDouble(dr[4].ToString());
                                lvi.SubItems.Add((a * b).ToString());
                                totalpagar += a * b;

                                lvi.SubItems.Add(dr[5].ToString());


                                //pesquisa pelo nome do vendedor através do id
                                var produtos2 = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[7].ToString())).Rows;
                                foreach (DataRow dr2 in produtos2)
                                {
                                    lvi.SubItems.Add(dr2[1].ToString());
                                }

                                lstCaderneta.Items.Add(lvi);
                                
                            }
                            panel4.Enabled = true;
                            lblTotalPagar2.Text = totalpagar.ToString();
                        }

                        //se não for a caderneta desse cliente mando um aviso
                        else
                        {
                            lblErroNCaderneta.Text = "Numero de outro cliente!";
                            lblErroNCaderneta.ForeColor = Color.IndianRed;
                            txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                            lstCaderneta.Items.Clear();
                            panel3.Enabled = panel4.Enabled = false;
                            lblTotalPagar2.Text = "R$ 0,00";
                            txtPagar2.Text = "";
                            lblTroco2.Text = "R$ ";
                            lblTroco3.Text = "0,00";
                            dtpDataPag.Text = DateTime.Now.Date.ToString();
                        }
                    }

                    //senao é pq não tem dono
                    else
                    {
                        lblErroNCaderneta.Text = "Numero novo liberado!";
                        lblErroNCaderneta.ForeColor = Color.Green;
                        txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                        lstCaderneta.Items.Clear();
                        panel3.Enabled = true;
                        panel4.Enabled = false;
                        lblTotalPagar2.Text = "R$ 0,00";
                        txtPagar2.Text = "";
                        lblTroco2.Text = "R$ ";
                        lblTroco3.Text = "0,00";
                        dtpDataPag.Text = DateTime.Now.Date.ToString();
                    }
                }
                else
                {
                    txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                    lstCaderneta.Items.Clear();
                    panel3.Enabled = false;
                    panel4.Enabled = false;
                    lblTotalPagar2.Text = "R$ 0,00";
                    txtPagar2.Text = "";
                    lblTroco2.Text = "R$ ";
                    lblTroco3.Text = "0,00";
                    dtpDataPag.Text = DateTime.Now.Date.ToString();
                    txtCaderneta.Text = "0";
                }
            }
            //senão limpa tudo
            else
            {
                txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                lstCaderneta.Items.Clear();
                panel3.Enabled = false;
                panel4.Enabled = false;
                lblTotalPagar2.Text = "R$ 0,00";
                txtPagar2.Text = "";
                lblTroco2.Text = "R$ ";
                lblTroco3.Text = "0,00";
                dtpDataPag.Text = DateTime.Now.Date.ToString();
                txtCaderneta.Text = "0";

            }
        }

        private bool VerificaSalvar()
        {
            int j;
            bool h;


            //----------------Inicio Nome----------------------\\

            //verifica se o nome foi digitado
            if (txtProduto.Text == "")
            {
                MessageBox.Show("Preencha o campo Produto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProduto.Focus();
                return false;
            }

            //--------------inicio quantidade-------------------\\

            //quantidade de digitos
            j = 0;

            //h abilita o erro
            h = false;

            //quantidade de virgula
            int quantidadevirgula = 0;

            //quantidade de digitos, para saber se for só 1, e se esse 1 é uma virgula ou sinal negativo
            int quantidadedigitos = 0;

            //se tiver só 1 digito e for uma virgula ou sinal negativo, então vai abilitar o h para o erro
            bool virgulasinal = false;
            while (j < txtQuantidade.Text.Length)
            {
                char quantidade = txtQuantidade.Text[j];

                if (!char.IsDigit(quantidade) && quantidade != (char)32 && quantidade != (char)44 )
                {
                    j = txtQuantidade.Text.Length;
                    h = true;
                }
                
                //verifica se tem mais de uma virgula
                else if (quantidade == (char)44)
                {
                    quantidadevirgula++;

                    virgulasinal = true;
                    if (quantidadevirgula != 1)
                    {
                        j = txtQuantidade.Text.Length;
                        h = true;
                    }
                }
                j++;
                quantidadedigitos++;
            }
            if (quantidadedigitos == 1)
            {
                //o unico digito é uma virgula ou sinal negativo
                if (virgulasinal == true)
                {
                    j = txtQuantidade.Text.Length;
                    h = true;
                }
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo Quantidade corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
                return false;
            }
            if (txtQuantidade.Text == "")
            {
                txtQuantidade.Text = "0";
            }
            //-----------------------fim quantidade----------------------------\\


            //--------------inicio preço-------------------\\

            //quantidade de digitos
            j = 0;

            //h abilita o erro
            h = false;

            //quantidade de virgula
            quantidadevirgula = 0;

            //quantidade de digitos, para saber se for só 1, e se esse 1 é uma virgula ou sinal negativo
            quantidadedigitos = 0;

            //se tiver só 1 digito e for uma virgula ou sinal negativo, então vai abilitar o h para o erro
            virgulasinal = false;
            while (j < txtValor.Text.Length)
            {
                char valor = txtValor.Text[j];

                if (!char.IsDigit(valor) && valor != (char)32 && valor != (char)44)
                {
                    j = txtValor.Text.Length;
                    h = true;
                }

                //verifica se tem mais de uma virgula
                else if (valor == (char)44)
                {
                    quantidadevirgula++;

                    virgulasinal = true;
                    if (quantidadevirgula != 1)
                    {
                        j = txtValor.Text.Length;
                        h = true;
                    }
                }
                j++;
                quantidadedigitos++;
            }
            if (quantidadedigitos == 1)
            {
                //o unico digito é uma virgula ou sinal negativo
                if (virgulasinal == true)
                {
                    j = txtValor.Text.Length;
                    h = true;
                }
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo Preço corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return false;
            }
            if (txtValor.Text == "")
            {
                MessageBox.Show("Preencha o campo Preço corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return false;
            }
            //-----------------------fim preço----------------------------\\



            return true;
        }

        //botão gravar
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificaSalvar() == true)
            {
                DateTime dtp = Convert.ToDateTime("01/01/1753 12:00:00");
                cad.INSERT_CADERNETA(idcliente, txtProduto.Text, Convert.ToDouble(txtQuantidade.Text),
                                     Convert.ToDouble(txtValor.Text), DateTime.Now, false, Id,Convert.ToInt16(txtCaderneta.Text), dtp);
                audi.INSERT_AUDITORIA(Id, "Vendeu " + txtProduto.Text + " para " + txtNomeCliente.Text, DateTime.Now);

                AtualizarListaCaderneta();
            }
          
        }

        //apaga a pesquisa de clientes
        private void cbbTPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = txtCaderneta.Text = txtNomeCliente.Text = "";
            lstPesquisa.Items.Clear();

        }

        //verifica valor pago
        private bool VerificarPago()
        {
            //--------------inicio valor-------------------\\
            int j;
            bool h;
            //quantidade de digitos
            j = 0;

            //h abilita o erro
            h = false;

            //quantidade de virgula
            int quantidadevirgula = 0;

            //quantidade de digitos, para saber se for só 1, e se esse 1 é uma virgula ou sinal negativo
            int quantidadedigitos = 0;

            //se tiver só 1 digito e for uma virgula ou sinal negativo, então vai abilitar o h para o erro
            bool virgulasinal = false;
            while (j < txtPagar2.Text.Length)
            {
                char valor = txtPagar2.Text[j];

                if (!char.IsDigit(valor) && valor != (char)32 && valor != (char)44)
                {
                    j = txtPagar2.Text.Length;
                    h = true;
                }

                //verifica se tem mais de uma virgula
                else if (valor == (char)44)
                {
                    quantidadevirgula++;

                    virgulasinal = true;
                    if (quantidadevirgula != 1)
                    {
                        j = txtPagar2.Text.Length;
                        h = true;
                    }
                }
                j++;
                quantidadedigitos++;
            }
            if (quantidadedigitos == 1)
            {
                //o unico digito é uma virgula ou sinal negativo
                if (virgulasinal == true)
                {
                    j = txtPagar2.Text.Length;
                    h = true;
                }
            }
            if (h)
            {
                MessageBox.Show("Preencha o campo a Pagar corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPagar2.Text = "0,00";
                txtPagar2.Focus();
                return false;
            }
            if (txtPagar2.Text == "")
            {
                MessageBox.Show("Preencha o campo a Pagar corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPagar2.Text = "0,00";
                txtPagar2.Focus();
                return false;
            }
            //-----------------------fim quantidade----------------------------\\
            return true;
        }

        //troco automatico
        private void txtPagar2_TextChanged(object sender, EventArgs e)
        {
            double a, b;
            try
            {
                a = Convert.ToDouble(txtPagar2.Text);
                b = Convert.ToDouble(lblTotalPagar2.Text);

                if (VerificarPago() == true)
                {
                    lblTroco2.Text = "R$ "; 
                    lblTroco3.Text =(a - b).ToString();
                }
            }
            catch
            {
                
                txtPagar2.Text = "0,00";
                txtPagar2.Focus();
            }

        }

        //arruma a quantidade quando alguem digita errado
        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtQuantidade.Text);
            }
            catch
            {
                txtQuantidade.Text = "0,00";
            }
        }

        //arruma a quantidade quando alguem digita errado
        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtValor.Text);
            }
            catch
            {
                txtValor.Text = "0,00";
            }
        }

        //efetuar pagamento
        private void btnPagar_Click(object sender, EventArgs e)
        {
            //se o troco for negativo, é pq vai gerar uma nova parcela com o restante
            double troco = Convert.ToDouble(lblTroco3.Text);
            if (troco < 0)
            {
                //apaga os dados
                cad.DELETE_CADERNETA(idcliente, Convert.ToInt16(txtCaderneta.Text));

                DateTime dtp = Convert.ToDateTime("01/01/1753 12:00:00");
                cad.INSERT_CADERNETA(idcliente, " Restante ", 1, Math.Abs(troco), DateTime.Now, false, Id, Convert.ToInt16(txtCaderneta.Text), dtp);
                audi.INSERT_AUDITORIA(Id, "Quitou a conta de " + txtNomeCliente.Text + " e ficou um restante de " + Math.Abs(troco), DateTime.Now);
            }

            //senão, é pq pagou tudo
            else
            {
                //apaga os dados
                cad.DELETE_CADERNETA(idcliente, Convert.ToInt16(txtCaderneta.Text));
                DateTime dtp = Convert.ToDateTime("01/01/1753 12:00:00");
                cad.INSERT_CADERNETA(idcliente, " NADA ", 0, 0, DateTime.Now, false, Id, Convert.ToInt16(txtCaderneta.Text), dtp);
                audi.INSERT_AUDITORIA(Id, "Quitou a conta de " + txtNomeCliente.Text, DateTime.Now);
            }
            AtualizarListaCaderneta();
            
        }

        //Atualiza a lista
        private void AtualizarListaCaderneta()
        {
            lstCaderneta.Items.Clear();
            //atualiza a lista
            //a caderneta é minha
            int numcaderneta = Convert.ToInt16(txtCaderneta.Text);
            if (cad.CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(numcaderneta, idcliente).Rows.Count > 0)
            {
                //limpa a lista com os ids
                IDCADERNETA.Clear();

                lblErroNCaderneta.Text = "Numero liberado!";
                lblErroNCaderneta.ForeColor = Color.DarkGreen;
                txtProduto.Text = txtQuantidade.Text = txtValor.Text = "";
                lstCaderneta.Items.Clear();
                panel3.Enabled = true;
                panel4.Enabled = false;
                lblTotalPagar2.Text = "R$ 0,00";
                txtPagar2.Text = "";
                lblTroco2.Text = "R$ ";
                lblTroco3.Text = "0,00";
                dtpDataPag.Text = DateTime.Now.Date.ToString();
                txtProduto.Focus();

                

                //soma todos os totais 
                double totalpagar = 0;
                //preenche a lista caderneta com as informações da caderneta do cliente 
                var produtos = cad.CONSULTA_CADERNETA_IDCLIENTE_IDCADERNETA(numcaderneta, idcliente, Convert.ToDateTime("01/01/1753 12:00:00")).Rows;
                foreach (DataRow dr in produtos)
                {
                    //armazena todos os ids
                    IDCADERNETA.Add(Convert.ToInt16(dr[0].ToString()));

                    ListViewItem lvi = new ListViewItem(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());


                    double a, b;
                    a = Convert.ToDouble(dr[3].ToString());
                    b = Convert.ToDouble(dr[4].ToString());
                    lvi.SubItems.Add((a * b).ToString());
                    totalpagar += a * b;

                    lvi.SubItems.Add(dr[5].ToString());


                    //pesquisa pelo nome do vendedor através do id
                    var produtos2 = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt16(dr[7].ToString())).Rows;
                    foreach (DataRow dr2 in produtos2)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }

                    lstCaderneta.Items.Add(lvi);

                }
                panel4.Enabled = true;
                lblTotalPagar2.Text = totalpagar.ToString();
            }
        }

        //seleciona o item da lista
        private void lstCaderneta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega o index da lista para poder excluir dpois
            idcaderneta = lstCaderneta.SelectedItems[0].Index;
            

            //pega os dados de venda do cliente e tras para tela
            if (lstCaderneta.SelectedItems.Count != 0)
            {
                if (lstCaderneta.SelectedItems[0].Selected)
                {
                    txtProduto.Text    = lstCaderneta.FocusedItem.SubItems[0].Text;
                    txtQuantidade.Text = lstCaderneta.FocusedItem.SubItems[1].Text;
                    txtValor.Text      = lstCaderneta.FocusedItem.SubItems[2].Text;

                    btnGravar.Enabled   = false;
                    btnExcluir.Enabled  = true;
                    btnCancelar.Enabled = true;

                    
                    btnExcluir.BackColor  = Color.FromArgb(0, 64, 64);
                    btnCancelar.BackColor = Color.Teal;
                }
            }

           // AtualizarListaCaderneta();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            btnGravar.Enabled   = true;
            btnExcluir.Enabled  = false;
            btnCancelar.Enabled = false;

            btnExcluir.BackColor  = Color.Silver;
            btnCancelar.BackColor = Color.Silver;

            cad.DELETE_CADERNETA2(IDCADERNETA[idcaderneta]);
            audi.INSERT_AUDITORIA(Id, "Excluir uma venda do cliente " + txtNomeCliente.Text, DateTime.Now);
            AtualizarListaCaderneta();

            txtProduto.Text = "";
            txtQuantidade.Text = txtValor.Text = "0,00";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGravar.Enabled   = true;
            btnExcluir.Enabled  = false;
            btnCancelar.Enabled = false ;

            btnExcluir.BackColor  = Color.Silver;
            btnCancelar.BackColor = Color.Silver;

            txtProduto.Text = "";
            txtQuantidade.Text = txtValor.Text = "0,00";
        }

      
    }
}
