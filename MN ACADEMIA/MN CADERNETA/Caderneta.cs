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

        Classes.Clientes   cli = new Classes.Clientes();
        Classes.Auditoria audi = new Classes.Auditoria();
        Classes.Cadernetas cad = new Classes.Cadernetas();
        Classes.Vendedores ven = new Classes.Vendedores();
        Classes.Acertos    ace = new Classes.Acertos();
        Classes.Caixas     cai = new Classes.Caixas();


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

        private List<int> IDACERTO = new List<int>();

        //variavel usada para guardar o id do cliente para salvar, diferente da utilidade dos outros forms
        private int idcliente;        

        //variavel usada para guardar o id do acerto para quitar para salvar
        private int idacerto;

        //variavel  usada para guardar a data do ultimo pagamento
        private DateTime datapagamento;

        //nome cliente
        private string nomecliente = "";

        public Caderneta()
        {
            InitializeComponent();

            //combo box pesquisa começa com valor nome
            cbbTPesquisa.Text = "Todos";

            //desativa todos os componentes que estão nesses panels
            panel4.Enabled = false;

            

            CarregaTudo();
            
        }

        //mudar cor do botão quando passa o mouse
        private void btnGravar_MouseMove(object sender, MouseEventArgs e)
        {
            
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
        
        //carrega o list view da pesquisa com a mensalidade de todos
        private void CarregaTudo()
        {
            //apaga todos os ids da lista para começar do 0
            IDACERTO.Clear();

            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;

            lstCaderneta.Items.Clear();
            
            txtPesquisa.Text = "";
            txtPesquisa.Enabled = false;

            double total = 0.00;
            //consulta todos os ids dos clientes
            var produtos = ace.CONSULTA_ACERTO_DISTINCT_IDCLIENTE().Rows;
            foreach (DataRow dr in produtos)
            {
                //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz
                var produtos2 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_MES(Convert.ToInt32(dr[0].ToString())).Rows;
                foreach (DataRow dr2 in produtos2)
                {
                    if (dr2[0].ToString() != "")
                    {
                        //salva os id das mensalidades
                        IDACERTO.Add(Convert.ToInt32(dr2[0].ToString()));
                        //procura o id do acerto e o resto de suas informaçoes
                        var produtos3 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr2[0].ToString())).Rows;
                        foreach (DataRow dr3 in produtos3)
                        {
                            //id acerto
                            idacerto = Convert.ToInt32(dr3[0].ToString());

                            //procura pelo nome do cliente atraves do seu id
                            string nomecliente = "";
                            var produtos4 = cli.CONSULTA_CLIENTE_ID(Convert.ToInt32(dr3[1].ToString())).Rows;
                            foreach (DataRow dr4 in produtos4)
                            {
                                nomecliente = dr4[1].ToString();
                            }

                            ListViewItem lvi = new ListViewItem(nomecliente);
                            DateTime dt = Convert.ToDateTime(dr3[2].ToString());
                            //valor da mensalidade
                            lvi.SubItems.Add(dr3[3].ToString());
                            //data do vencimento
                            lvi.SubItems.Add(dt.ToString("d"));

                            //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz e pago
                            var produtos5 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_ULTIMO_MES_PAGO(Convert.ToInt32(dr[0].ToString())).Rows;                            
                            foreach (DataRow dr5 in produtos5)
                            {
                                if (dr5[0].ToString() != "")
                                {

                                    //procura pelo valor da mensalidade paga e a data do pagamento atraves do seu id
                                    var produtos6 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr5[0].ToString())).Rows;
                                    foreach (DataRow dr6 in produtos6)
                                    {
                                        DateTime dt2 = Convert.ToDateTime(dr6[5].ToString());
                                        //data ultimo pagamento
                                        lvi.SubItems.Add(dt2.ToString("d"));
                                        //valor ultimo pagamento
                                        lvi.SubItems.Add(dr6[6].ToString());
                                        //vendedor
                                        string vendedor = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt32(dr6[7].ToString())).Rows[0][1].ToString();
                                        lvi.SubItems.Add(vendedor);
                                    }
                                }
                            }
                            lstCaderneta.Items.Add(lvi);
                            total += Convert.ToDouble(dr3[3].ToString());
                            contador++;
                        }   
                    }
                }
            }

            //mechendo nas cores, verde ja pago, verelho deve e preto em aberto
            for (int i = 0; i < contador; i++)
            {
                if (ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows.Count > 0)
                {
                    //pago
                    if (ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][4].ToString() == "True")
                        lstCaderneta.Items[i].ForeColor = Color.Green;
                    //vence hoje
                    else if (Convert.ToDateTime(ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][2].ToString()).ToString("d") == DateTime.Now.ToString("d"))
                        lstCaderneta.Items[i].ForeColor = Color.Blue;
                    //atrasado
                    else if(Convert.ToDateTime(ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][2].ToString()) < DateTime.Now)
                        lstCaderneta.Items[i].ForeColor = Color.Red;
                    
                       
                }
            }
            lblTotal2.Text = total.ToString();
        }

        //textbox pesquisa
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            lblTotalPagar2.Text = "0,00";
            lblTroco3.Text = "0,00";
            txtPagar2.Text = "0,00";
            lblTotal2.Text = "0.00";
            panel4.Enabled = false;
            double total   = 0.00;
            lblTotal2.Text = "0.00";
            lstCaderneta.Items.Clear();
            //contador de linhas, vai servir para saber a linha que escolhi
            int contador = 0;

            
            //consulta todos os ids dos clientes
            if (ckbConsultaDetalhada.Checked == true)
            {
                IDACERTO.Clear();
                var produtos = ace.CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE(txtPesquisa.Text).Rows;

                foreach (DataRow dr in produtos)
                {
                    //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz
                    var produtos2 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_MES(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr2 in produtos2)
                    {
                        if (dr2[0].ToString() != "")
                        {
                            //salva os id das mensalidades
                            IDACERTO.Add(Convert.ToInt32(dr2[0].ToString()));
                            //procura o id do acerto e o resto de suas informaçoes
                            var produtos3 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr2[0].ToString())).Rows;
                            foreach (DataRow dr3 in produtos3)
                            {
                                //id acerto
                                idacerto = Convert.ToInt32(dr3[0].ToString());

                                //procura pelo nome do cliente atraves do seu id
                                string nomecliente = "";
                                var produtos4 = cli.CONSULTA_CLIENTE_ID(Convert.ToInt32(dr3[1].ToString())).Rows;
                                foreach (DataRow dr4 in produtos4)
                                {
                                    nomecliente = dr4[1].ToString();
                                }

                                ListViewItem lvi = new ListViewItem(nomecliente);
                                DateTime dt = Convert.ToDateTime(dr3[2].ToString());
                                //valor da mensalidade
                                lvi.SubItems.Add(dr3[3].ToString());
                                //data do vencimento
                                lvi.SubItems.Add(dt.ToString("d"));

                                //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz e pago
                                var produtos5 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_ULTIMO_MES_PAGO(Convert.ToInt32(dr[0].ToString())).Rows;
                                foreach (DataRow dr5 in produtos5)
                                {
                                    if (dr5[0].ToString() != "")
                                    {

                                        //procura pelo valor da mensalidade paga e a data do pagamento atraves do seu id
                                        var produtos6 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr5[0].ToString())).Rows;
                                        foreach (DataRow dr6 in produtos6)
                                        {
                                            DateTime dt2 = Convert.ToDateTime(dr6[5].ToString());
                                            //data ultimo pagamento
                                            lvi.SubItems.Add(dt2.ToString("d"));
                                            //valor ultimo pagamento
                                            lvi.SubItems.Add(dr6[6].ToString());
                                            //vendedor
                                            string vendedor = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt32(dr6[7].ToString())).Rows[0][1].ToString();
                                            lvi.SubItems.Add(vendedor);
                                        }
                                    }
                                }
                                lstCaderneta.Items.Add(lvi);
                                total += Convert.ToDouble(dr3[3].ToString());
                                contador++;
                            }
                        }
                    }
                }
            }
            //consulta todos os ids dos clientes
            else if (ckbConsultaDetalhada.Checked == false)
            {
                IDACERTO.Clear();

                var produtos7 = ace.CONSULTA_ACERTO_DISTINCT_IDCLIENTE_NOMECLIENTE2(txtPesquisa.Text).Rows;

                foreach (DataRow dr7 in produtos7)
                {
                    //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz
                    string n = dr7[0].ToString();
                    var produtos8 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_MES(Convert.ToInt32(dr7[0].ToString())).Rows;
                    foreach (DataRow dr8 in produtos8)
                    {
                        if (dr8[0].ToString() != "")
                        {
                            //salva os id das mensalidades
                            IDACERTO.Add(Convert.ToInt32(dr8[0].ToString()));
                            //procura o id do acerto e o resto de suas informaçoes
                            var produtos9 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr8[0].ToString())).Rows;
                            foreach (DataRow dr9 in produtos9)
                            {
                                //id acerto
                                idacerto = Convert.ToInt32(dr9[0].ToString());

                                //procura pelo nome do cliente atraves do seu id
                                string nomecliente = "";
                                var produtos10 = cli.CONSULTA_CLIENTE_ID(Convert.ToInt32(dr9[1].ToString())).Rows;
                                foreach (DataRow dr10 in produtos10)
                                {
                                    nomecliente = dr10[1].ToString();
                                }

                                ListViewItem lvi = new ListViewItem(nomecliente);
                                DateTime dt = Convert.ToDateTime(dr9[2].ToString());
                                //valor da mensalidade
                                lvi.SubItems.Add(dr9[3].ToString());
                                //data do vencimento
                                lvi.SubItems.Add(dt.ToString("d"));

                                //consulta os ids das mensalidades dos clientes ativos e que tenha mensalidade do mes atual para traz e pago
                                var produtos11 = ace.CONSULTA_ACERTO_MENSALIDADE_DO_ULTIMO_MES_PAGO(Convert.ToInt32(dr7[0].ToString())).Rows;
                                foreach (DataRow dr11 in produtos11)
                                {
                                    if (dr11[0].ToString() != "")
                                    {

                                        //procura pelo valor da mensalidade paga e a data do pagamento atraves do seu id
                                        var produtos12 = ace.CONSULTA_ACERTO_IDACERTO(Convert.ToInt32(dr11[0].ToString())).Rows;
                                        foreach (DataRow dr12 in produtos12)
                                        {
                                            DateTime dt2 = Convert.ToDateTime(dr12[2].ToString());
                                            //data ultimo pagamento
                                            lvi.SubItems.Add(dt2.ToString("d"));
                                            //valor ultimo pagamento
                                            lvi.SubItems.Add(dr12[3].ToString());
                                            //vendedor
                                            string vendedor = ven.CONSULTA_VENDEDOR_ID(Convert.ToInt32(dr12[7].ToString())).Rows[0][1].ToString();
                                            lvi.SubItems.Add(vendedor);
                                        }
                                    }
                                }
                                lstCaderneta.Items.Add(lvi);
                                total += Convert.ToDouble(dr9[3].ToString());
                                contador++;
                            }
                        }
                    }
                }
            }
            //mechendo nas cores, verde ja pago, verelho deve e preto em aberto
            for (int i = 0; i < contador; i++)
            {
                if (ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows.Count > 0)
                {
                    //pago
                    if (ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][4].ToString() == "True")
                        lstCaderneta.Items[i].ForeColor = Color.Green;
                    //atrasado
                    else if (Convert.ToDateTime(ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][2].ToString()) < DateTime.Now)
                        lstCaderneta.Items[i].ForeColor = Color.Red;
                    //vence hoje
                    else if (Convert.ToDateTime(ace.CONSULTA_ACERTO_IDACERTO(IDACERTO[i]).Rows[0][2].ToString()).ToString("d") == DateTime.Now.ToString("d"))
                        lstCaderneta.Items[i].ForeColor = Color.Blue;

                   
                }
            }
            lblTotal2.Text = total.ToString();
        }       

        //troco automatico
        private void txtPagar2_TextChanged(object sender, EventArgs e)
        {
            double a, b;
            try
            {
                a = Convert.ToDouble(txtPagar2.Text);
                b = Convert.ToDouble(lblTotalPagar2.Text);

                
                    lblTroco2.Text = "R$ "; 
                    lblTroco3.Text =(a - b).ToString();
                
            }
            catch
            {
                
                txtPagar2.Text = "0,00";
                txtPagar2.Focus();
            }

        }

        //efetuar pagamento
        private void btnPagar_Click(object sender, EventArgs e)
        {
            //quitar a parcela?
            var result = MessageBox.Show("Quitar a mensalidade?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //quitou uma mensalidade
                ace.UPDATE_ACERTO(idcliente, datapagamento, Convert.ToDouble(lblTotalPagar2.Text), true, dtpDataPag.Value, Convert.ToDouble(lblTotalPagar2.Text), Id);

                //encontra a ultima mensalidade quitada no caixa para gerar o numero da nova
                int maior = 0;
                string caixa = cai.CONSULTA_CAIXA__ORIGEM_MAIORID("MENSALIDADE").Rows[0][0].ToString();
                if (caixa == "")
                    maior = 1;
                else
                    maior = Convert.ToInt32(cai.CONSULTA_CAIXA__ORIGEM_MAIORID("MENSALIDADE").Rows[0][0].ToString()) + 1;

                cai.INSERT_CAIXA(maior, "Mensalidade " + nomecliente, Convert.ToDouble(lblTotalPagar2.Text), true, false, dtpDataPag.Text, Id, "MENSALIDADE");

                //gerar mensalidade do proximo mês?
                var result2 = MessageBox.Show("Gerar do proximo mês?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.OK)
                {
                    DateTime data = datapagamento;
                    //gera um boleto
                    ace.INSERT_ACERTO(idcliente, data = datapagamento.AddMonths(1), Convert.ToDouble(lblTotalPagar2.Text), false, data, 0, Id);
                    //auditoria
                    audi.INSERT_AUDITORIA(Id, " Quitou a mensalidade de " + nomecliente + " e já lançou a segunda mensalidade no sistema", DateTime.Now);
                }

                //senão não vai gerar a segunda parcela
                else
                    audi.INSERT_AUDITORIA(Id, " Quitou a mensalidade de " + nomecliente + " e NÃO lançou a segunda mensalidade no sistema", DateTime.Now);

                if (cbbTPesquisa.Text == "Todos")
                {
                    lblTotalPagar2.Text = "0,00";
                    lblTroco3.Text = "0,00";
                    txtPagar2.Text = "0,00";
                    lblTotal2.Text = "0.00";
                    panel4.Enabled = false;
                    CarregaTudo();
                }
                else if (cbbTPesquisa.Text == "Nome")
                {
                    lblTotalPagar2.Text = "0,00";
                    lblTroco3.Text = "0,00";
                    txtPagar2.Text = "0,00";
                    lblTotal2.Text = "0.00";
                    lblTotal2.Text = "0.00";
                    panel4.Enabled = false;
                    txtPesquisa.Enabled = true;
                    lstCaderneta.Items.Clear();
                }
            }            
            
        }

        //Atualiza a lista
        private void AtualizarListaCaderneta()
        {
            
        }

        //seleciona o item da lista
        private void lstCaderneta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstCaderneta.SelectedItems.Count != 0)
            {
                txtPagar2.Text = "0,00";
                lblTroco3.Text = "0,00";
                lblTotalPagar2.Text = "0,00";
               
                if (lstCaderneta.SelectedItems[0].Selected)
                {
                    string nome = "";
                    nome = lstCaderneta.FocusedItem.SubItems[0].Text;
                    nomecliente = nome;
                    string pago = "";

                    //atraves do nome acha o idacerto do mes atual
                    int ida = 0;
                    var prod = ace.CONSULTA_ACERTO_MENSALIDADE_DO_MES_NOME(nome).Rows;
                    foreach (DataRow d in prod)
                    {
                        ida = Convert.ToInt32(d[0].ToString());
                    }


                    var produtos = ace.CONSULTA_ACERTO_IDACERTO(ida).Rows;
                    foreach (DataRow dr in produtos)
                    {
                        //idacerto
                        idacerto  = Convert.ToInt32(dr[0].ToString());
                        //idcliente
                        idcliente = Convert.ToInt32(dr[1].ToString());
                        //data acerto
                        string t = dr[2].ToString();
                        datapagamento = Convert.ToDateTime(dr[2].ToString());
                        //valor
                        lblTotalPagar2.Text = dr[3].ToString();

                        //pago
                        pago = dr[4].ToString();
                    }
                    if (pago == "True")
                        panel4.Enabled = false;
                    else
                        panel4.Enabled = true;
                }
            }
        }

        //tipo de pesquisa
        private void cbbTPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTPesquisa.Text == "Todos")
            {
                lblTotalPagar2.Text = "0,00";
                lblTroco3.Text = "0,00";
                txtPagar2.Text = "0,00";
                lblTotal2.Text = "0.00";
                panel4.Enabled = false;
                CarregaTudo();
            }
            else if (cbbTPesquisa.Text == "Nome")
            {
                lblTotalPagar2.Text = "0,00";
                lblTroco3.Text = "0,00";
                txtPagar2.Text = "0,00";
                lblTotal2.Text = "0.00";
                lblTotal2.Text = "0.00";
                panel4.Enabled = false;
                txtPesquisa.Enabled = true;
                lstCaderneta.Items.Clear();
            }
                
        }

        private void Caderneta_Load(object sender, EventArgs e)
        {

        }
    }
}
