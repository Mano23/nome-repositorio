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
    public partial class Relatorios : Form
    {
        Classes.Auditoria  aud = new Classes.Auditoria();
        Classes.Cadernetas cad = new Classes.Cadernetas();
        Classes.Clientes   cli = new Classes.Clientes();
        Classes.Avaliacaos ava = new Classes.Avaliacaos();
        Classes.Vendedores ven = new Classes.Vendedores();
        Classes.Caixas     cai = new Classes.Caixas();
        Classes.Acertos    ace = new Classes.Acertos();

        private string vusuario;
        public string Usuario
        {
            get { return vusuario; }
            set { vusuario = value; }
        }
        private string vsenha;
        public string Senha//variavel do form principal
        {
            get { return vsenha; }
            set { vsenha = value; }
        }

        public Relatorios()
        {
            InitializeComponent();
            gpbNome.Enabled = gpbData.Enabled = lblAte.Enabled = lblDe.Enabled = dtpAte.Enabled = dtpDe.Enabled = false;
            lstCaderneta.Visible = lstAvaliacao.Visible = lstPesquisa.Visible = lstPesqCaix.Visible = lstCliente.Visible = lstAuditoria.Visible = false;
        }        

        private void CarregaAuditoria()
        {

            DateTime dt1, dt2;
            dt1 = dtpDe.Value;
            dt2 = dtpAte.Value;
            dt1 = Convert.ToDateTime(dt1.ToString("dd/MM/yyyy"));
            dt2 = Convert.ToDateTime(dt2.ToString("dd/MM/yyyy"));
            lstAuditoria.Items.Clear();
            var produtos = aud.CONSULTA_AUDITORIA_DATA(dt1, dt2).Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());

                lstAuditoria.Items.Add(lvi);

            }
        }

        private void CarregaAuditoriaTodas()
        {
            lstAuditoria.Items.Clear();
            var produtos = aud.CONSULTA_AUDITORIA_DATA_TODAS().Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());

                lstAuditoria.Items.Add(lvi);

            }
        }

        //CAIXA FAZ A PESQUISA DA DATA
        private void PesquisaDataCaixa()
        {
            
            lstPesqCaix.Items.Clear();

            var produtos = cai.CONSULTA_CAIXA_DATA2(dtpDe.Text, dtpAte.Text).Rows;
            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());
                lvi.SubItems.Add(dr[5].ToString().Substring(0, 10));
                lvi.SubItems.Add(dr[6].ToString());
                lvi.SubItems.Add(dr[7].ToString());


                lstPesqCaix.Items.Add(lvi);
            }
            int result;
            result = DateTime.Compare(dtpDe.Value, dtpAte.Value);//verifica se a data inicial é menor que a final

            string so;
            Double soma = 0;
            //verifica data inicial
            string DataI;
            if (cai.SOMA_SALDO_ENTRADA_DATA(dtpDe.Text, dtpAte.Text).Rows.Count > 0)
            {
                for (int i = 0; i < cai.SOMA_SALDO_ENTRADA_DATA(dtpDe.Text, dtpAte.Text).Rows.Count; i++)
                {
                    so = Convert.ToString(cai.SOMA_SALDO_ENTRADA_DATA(dtpDe.Text, dtpAte.Text).Rows[i][0]);
                    so = Decimal.Parse(so).ToString("N2");
                    soma += Convert.ToDouble(so);
                }
                DataI = soma.ToString();//Convert.ToString(caixas.SOMA_SALDO_ENTRADA_DATA(dtpInicialCaixa.Text, dtpFinalCaixa.Text).Rows[0][0]);
            }
            else
                DataI = "0";

            //verifica data final
            string DataF;
            soma = 0;
            if (cai.SOMA_SALDO_SAIDA_DATA(dtpDe.Text, dtpAte.Text).Rows.Count > 0)
            {
                for (int i = 0; i < cai.SOMA_SALDO_SAIDA_DATA(dtpDe.Text, dtpAte.Text).Rows.Count; i++)
                {
                    so = Convert.ToString(cai.SOMA_SALDO_SAIDA_DATA(dtpDe.Text, dtpAte.Text).Rows[i][0]);
                    so = Decimal.Parse(so).ToString("N2");
                    soma += Convert.ToDouble(so);
                }
                DataF = soma.ToString();
            }
            else
                DataF = "0";

            //se result == -1 é pq é inicial é menor, se for 0 é pq são iguais e se tiver algo na data escolhida e se for diferente de 0
            if (result == -1 || result == 0)
            {

                Double total = Convert.ToDouble(DataI) - Convert.ToDouble(DataF);
                lblTotalCaixaValor.Text = "R$ " + Convert.ToString(total);
                lblTotalEntradaCaixaValor.Text = "R$ " + Convert.ToString(DataI);
                lblTotalSaidaCaixaValor.Text = "R$ " + Convert.ToString(DataF);
            }
            else
            {
                lblTotalCaixaValor.Text = "R$ ";
                lblTotalEntradaCaixaValor.Text = "R$ ";
                lblTotalSaidaCaixaValor.Text = "R$ ";
                lstPesqCaix.Items.Clear();

            }
        }

        //pesquisa por data
        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {            
           //tipo de consulta auditoria
           if (ckbAuditoria.Checked == true)
           {
               //data todas
               if (cbbData.Text == "Todas")
               {
               }

               //data especifica
               if (cbbData.Text == "Especifica")
               {
                   
               }
           }
           //tipo de consulta caixa
           if (ckbCaixa.Checked == true)
           {
               //data todas
               if (cbbData.Text == "Todas")
               {
               }

               //data especifica
               if (cbbData.Text == "Especifica")
               {
                   lstPesqCaix.Items.Clear();
                   PesquisaDataCaixa();
               }
           }
        }

        //pesquisa por data
        private void dtpAte_ValueChanged(object sender, EventArgs e)
        {           
            //tipo de consulta auditoria
            if (ckbAuditoria.Checked == true)
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    
                }

                //data Especifico
                if (cbbData.Text == "Especifica")
                {
                    

                }
            }
            //tipo de consulta caixa
            if (ckbCaixa.Checked == true)
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                }

                //data especifica
                if (cbbData.Text == "Especifica")
                {
                    lstPesqCaix.Items.Clear();
                    PesquisaDataCaixa();
                }
            }
        }

        //CAIXA SOMA SALDO TODOS
        private void SomaSaldo()
        {
            Double entrada, saida;
            string en, sa;
            if (cai.CONSULTA_SALDO_ENTRADA().Rows.Count > 0)
            {
                en = Convert.ToString(cai.SOMA_SALDO_ENTRADA().Rows[0][0]);
                en = Decimal.Parse(en).ToString("N3");
                entrada = Convert.ToDouble(en);
            }
            else
                entrada = 0;
            if (cai.CONSULTA_SALDO_SAIDA().Rows.Count > 0)
            {
                sa = Convert.ToString(cai.SOMA_SALDO_SAIDA().Rows[0][0]);
                sa = Decimal.Parse(sa).ToString("N3");
                saida = Convert.ToDouble(sa);

            }
            else
                saida = 0;
            lblTotalCaixaValor.Text        = "R$ " + (entrada - saida).ToString();
            lblTotalEntradaCaixaValor.Text = "R$ " + entrada.ToString();
            lblTotalSaidaCaixaValor.Text   = "R$ " + saida.ToString();
        }

        //combo box Data, serve para escolher as datas que vc quer fazer a consulta
        private void cbbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //se combobox data for igual a todas, as datas vão ser desativadas e o combobox conta vai ser ativada
            if (cbbData.Text == "Todas")
            {
                dtpAte.Enabled = dtpDe.Enabled = false;
               

            }
            //se combobox data for igual a vendas, as datas vão ser ativadas e o combobox conta vai ser ativada
            else if (cbbData.Text == "Especifica")
            {
                dtpAte.Enabled = dtpDe.Enabled = true;
                
            }

            //tipo de consulta auditoria
            if (ckbAuditoria.Checked == true)
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaAuditoriaTodas();
                }

                //data vendas
                if (cbbData.Text == "Especifica")
                {
                    CarregaAuditoria();
                }
            }   
         
            //tipo de consulta caixa
            else if (ckbCaixa.Checked == true)
            {

                //data todas
                if (cbbData.Text == "Todas")
                {
                    lstPesqCaix.Items.Clear();
                    if (lstPesqCaix.Text == "" && cai.CONSULTA_CAIXA().Rows.Count > 0)
                    {
                        var produtos = cai.CONSULTA_CAIXA().Rows;
                        foreach (DataRow dr in produtos)
                        {
                            ListViewItem lvi = new ListViewItem(dr[0].ToString());
                            lvi.SubItems.Add(dr[1].ToString());
                            lvi.SubItems.Add(dr[2].ToString());
                            lvi.SubItems.Add(dr[3].ToString());
                            lvi.SubItems.Add(dr[4].ToString());
                            lvi.SubItems.Add(dr[5].ToString().Substring(0, 10));
                            lvi.SubItems.Add(dr[6].ToString());
                            lvi.SubItems.Add(dr[7].ToString());


                            lstPesqCaix.Items.Add(lvi);
                        }
                        SomaSaldo();
                    }
                }

                //data caixa
                if (cbbData.Text == "Especifica")
                {
                    lstPesqCaix.Items.Clear();
                    PesquisaDataCaixa();
                }
            }

        }

        //comando teclado
        private void Relatorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        //trabalha com as cores dos botões
        private void CorBotao(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        ckbAuditoria.FlatAppearance.BorderColor = Color.Green;
                        ckbAuditoria.FlatAppearance.BorderSize  = 2;

                        ckbAvaliacao.FlatAppearance.BorderColor   = ckbCaixa.FlatAppearance.BorderColor    = ckbCliente.FlatAppearance.BorderColor = Color.Purple;

                        ckbAvaliacao.FlatAppearance.BorderSize   = ckbCaixa.FlatAppearance.BorderSize = ckbCliente.FlatAppearance.BorderSize = 1;

                        break;
                    }
                case 2:
                    {
                        ckbAvaliacao.FlatAppearance.BorderColor = Color.Green;
                        ckbAvaliacao.FlatAppearance.BorderSize  = 2;

                        ckbAuditoria.FlatAppearance.BorderColor   = ckbCaixa.FlatAppearance.BorderColor    = ckbCliente.FlatAppearance.BorderColor = Color.Purple;
                         
                        ckbAuditoria.FlatAppearance.BorderSize   = ckbCaixa.FlatAppearance.BorderSize    = ckbCliente.FlatAppearance.BorderSize = 1;

                        break;
                    }
                case 3:
                    {
                        ckbCaixa.FlatAppearance.BorderColor = Color.Green;
                        ckbCaixa.FlatAppearance.BorderSize  = 2;

                        ckbAvaliacao.FlatAppearance.BorderColor   = ckbAuditoria.FlatAppearance.BorderColor = ckbCliente.FlatAppearance.BorderColor = Color.Purple;

                        ckbAvaliacao.FlatAppearance.BorderSize   = ckbAuditoria.FlatAppearance.BorderSize = ckbCliente.FlatAppearance.BorderSize = 1;

                        break;
                    }
                case 4:
                    {
                        ckbCliente.FlatAppearance.BorderColor = Color.Green;
                        ckbCliente.FlatAppearance.BorderSize  = 2;

                        ckbAuditoria.FlatAppearance.BorderColor   = ckbCaixa.FlatAppearance.BorderColor    = ckbAvaliacao.FlatAppearance.BorderColor = Color.Purple;

                        ckbAuditoria.FlatAppearance.BorderSize   = ckbCaixa.FlatAppearance.BorderSize    = ckbAvaliacao.FlatAppearance.BorderSize = 1;

                        break;
                    }
                case 5:
                    {
                        

                        ckbAvaliacao.FlatAppearance.BorderColor = ckbCaixa.FlatAppearance.BorderColor    = ckbCliente.FlatAppearance.BorderColor =
                        ckbAuditoria.FlatAppearance.BorderColor = Color.Purple;

                        ckbAvaliacao.FlatAppearance.BorderSize = ckbCaixa.FlatAppearance.BorderSize    = ckbCliente.FlatAppearance.BorderSize =
                        ckbAuditoria.FlatAppearance.BorderSize = 1;

                        break;
                    }
                case 6:
                    {
                        

                        ckbAuditoria.FlatAppearance.BorderColor   = ckbCaixa.FlatAppearance.BorderColor     = ckbCliente.FlatAppearance.BorderColor =
                        ckbAvaliacao.FlatAppearance.BorderColor = Color.Purple;

                        ckbAuditoria.FlatAppearance.BorderSize   = ckbCaixa.FlatAppearance.BorderSize     = ckbCliente.FlatAppearance.BorderSize =
                        ckbAvaliacao.FlatAppearance.BorderSize = 1;

                        break;
                    }


            }
        }

        private void ckbAuditoria_CheckedChanged(object sender, EventArgs e)
        {
            //muda cor da borda
            CorBotao(1);

            lstAuditoria.Visible = true;
            lstAuditoria.Items.Clear();

            lstCaderneta.Visible = lstAvaliacao.Visible = lstPesquisa.Visible = lstPesqCaix.Visible = lstCliente.Visible = false;
            gpbData.Enabled = lblAte.Enabled = lblDe.Enabled = dtpAte.Enabled = dtpDe.Enabled = true;
            gpbNome.Enabled      = false;

            lblTotalCaixa.Visible = lblTotalCaixaValor.Visible = lblTotalEntradaCaixa.Visible = lblTotalEntradaCaixaValor.Visible = lblTotalSaidaCaixa.Visible = lblTotalSaidaCaixaValor.Visible = false;
            

            CarregaAuditoria();
        }

        private void ckbAvaliacao_CheckedChanged(object sender, EventArgs e)
        {
            CorBotao(2);

            lstAvaliacao.Visible = true;
            lstAvaliacao.Items.Clear();

            lstCaderneta.Visible = lstAuditoria.Visible = lstPesqCaix.Visible = lstPesquisa.Visible = lstCliente.Visible = false;
            gpbData.Enabled = lblAte.Enabled = lblDe.Enabled = dtpAte.Enabled = dtpDe.Enabled = false;
            gpbNome.Enabled = true;

            textBox1.Focus();

            lblTotalCaixa.Visible = lblTotalCaixaValor.Visible = lblTotalEntradaCaixa.Visible = lblTotalEntradaCaixaValor.Visible = lblTotalSaidaCaixa.Visible = lblTotalSaidaCaixaValor.Visible = false;
            
        }

        private void ckbCaixa_CheckedChanged(object sender, EventArgs e)
        {
            CorBotao(3);

            lstPesqCaix.Visible = true;
            lstPesqCaix.Items.Clear();

            lstCaderneta.Visible = lstAuditoria.Visible = lstAvaliacao.Visible = lstPesquisa.Visible = lstCliente.Visible = false;
            gpbData.Enabled = lblAte.Enabled = lblDe.Enabled = dtpAte.Enabled = dtpDe.Enabled = true;
            gpbNome.Enabled = false;

            textBox1.Focus();

            lblTotalCaixa.Visible = lblTotalCaixaValor.Visible = lblTotalEntradaCaixa.Visible = lblTotalEntradaCaixaValor.Visible = lblTotalSaidaCaixa.Visible = lblTotalSaidaCaixaValor.Visible = true;

            lstPesqCaix.Items.Clear();
            if (lstPesqCaix.Text == "" && cai.CONSULTA_CAIXA().Rows.Count > 0)
            {
                var produtos = cai.CONSULTA_CAIXA().Rows;
                foreach (DataRow dr in produtos)
                {
                    ListViewItem lvi = new ListViewItem(dr[0].ToString());
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());
                    lvi.SubItems.Add(dr[5].ToString().Substring(0, 10));
                    lvi.SubItems.Add(dr[6].ToString());
                    lvi.SubItems.Add(dr[7].ToString());


                    lstPesqCaix.Items.Add(lvi);
                }
                SomaSaldo();
            }
            

        }

        //clientes
        private void Clientes()
        {
            //carrega o list view da pesquisa com o nome digitado
        
            
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
                    foreach (DataRow dr2 in vend)
                    {
                        lvi.SubItems.Add(dr2[1].ToString());
                    }


                    

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


                    lstCliente.Items.Add(lvi);
                    contador++;
                }

            }
        

        
        }

        private void ckbCliente_CheckedChanged(object sender, EventArgs e)
        {
            CorBotao(4);

            lstCliente.Visible = true;
            lstCliente.Items.Clear();

            lstCaderneta.Visible = lstAuditoria.Visible = lstPesquisa.Visible = lstAvaliacao.Visible = lstPesqCaix.Visible = false;
            gpbData.Enabled = lblAte.Enabled = lblDe.Enabled = dtpAte.Enabled = dtpDe.Enabled = false;
            gpbNome.Enabled = false;


            lblTotalCaixa.Visible = lblTotalCaixaValor.Visible = lblTotalEntradaCaixa.Visible = lblTotalEntradaCaixaValor.Visible = lblTotalSaidaCaixa.Visible = lblTotalSaidaCaixaValor.Visible = false;

            Clientes();
        }

        private void ckbMensalidade_CheckedChanged(object sender, EventArgs e)
        {
            CorBotao(5);
        }

        private void ckbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            CorBotao(6);
        }

        //carrega o list view avaliacao com o nome digitado
        private void CarregaNomeAvaliacao(string nome)
        {
            
            lstAvaliacao.Items.Clear();
            if (lstAvaliacao.Text == "")
            {
                var produtos = cli.CONSULTA_CLIENTE(nome).Rows;

                foreach (DataRow dr in produtos)
                {
                    
                    //consulta a avaliação atraves do id do cliente
                    var produtos3 = ava.CONSULTA_AVALIACAO_IDCLIENTE(Convert.ToInt32(dr[0].ToString())).Rows;
                    foreach (DataRow dr3 in produtos3)
                    {
                        ListViewItem lvi = new ListViewItem(dr3[17].ToString());
                        
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

                        //vendedor
                        lvi.SubItems.Add(ven.CONSULTA_VENDEDOR_ID(Convert.ToInt32(dr3[16].ToString())).Rows[0][1].ToString());

                        lstAvaliacao.Items.Add(lvi);
                    }
                }

            }
            textBox1.Focus();

        }

        //carrega o list view da pesquisa com todos os nomes dos clientes cadastrados
        private void CarregaNomeAval()
        {
            //idcliente = 0;
            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
            {
                if (textBox1.Text != "")
                {
                    if (cli.CONSULTA_CLIENTE_NOME(textBox1.Text).Rows.Count > 0)
                    {
                        var produtos = cli.CONSULTA_CLIENTE_NOME(textBox1.Text).Rows;
                        foreach (DataRow dr in produtos)
                        {
                            ListViewItem lvi = new ListViewItem(dr[1].ToString());

                            lstPesquisa.Items.Add(lvi);
                        }
                    }
                }
                else
                    lstPesquisa.Items.Clear();
            }
            textBox1.Focus();
        }

        //pesquisa quando digitar
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lstPesquisa.Visible = true;

            if (ckbAvaliacao.Checked == true)
            {
                CarregaNomeAval();
            }
        }

        //dois clique na lista de pesquisa
        private void lstPesquisa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega os dados de venda do cliente e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {
                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    if (ckbAvaliacao.Checked == true)
                    {
                        CarregaNomeAvaliacao(lstPesquisa.FocusedItem.SubItems[0].Text);
                        lstPesquisa.Visible = false;
                    }
                }
            }
        }

        private void lstPesqCaix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}

        

       

       

      

        


