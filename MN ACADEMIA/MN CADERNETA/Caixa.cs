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
    public partial class Caixa : CadastroBase
    {
        FrmPrincipal frm = new FrmPrincipal();
        
        Classes.Vendedores ven = new Classes.Vendedores();
        Classes.Caixas     cai = new Classes.Caixas();
        Classes.Auditoria audi = new Classes.Auditoria();

        private bool localizar = false;//server para saber se vai salvar ou atualizar
        private string origem;//tipo de dinheiro(caixa, contas a pagar...)
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
        private int vid;
        public int Id
        {
            get { return vid; }
            set { vid = value; }
        }
        //usada para excluir
        private string ORIGEM = "";

        public Caixa()
        {
            InitializeComponent();

            pnInicial.Visible   = true;
            pnLocalizar.Visible = false;

            SomaSaldo();
        }

        //Apaga os conteúdos de todos os campos
        private void ApagarCampos()
        {
            txtDocumento.Text = txtHistorico.Text = txtPesquisa.Text = txtValor.Text = "";

            rdbDocumento.Checked = rdbData.Checked = rdbSaida.Checked = false;
            rdbEntrada.Checked = true;

            txtValor.Text = "0";

            lstPesquisa.Items.Clear();

        }

        //saldo
        private void SomaSaldo()
        {
            double entrada, saida;
            string en, sa;

            en = cai.SOMA_SALDO_ENTRADA().Rows[0][0].ToString();
            sa = cai.SOMA_SALDO_SAIDA().Rows[0][0].ToString();

            if (en != "")
                entrada = Convert.ToDouble(cai.SOMA_SALDO_ENTRADA().Rows[0][0]);
            else
                entrada = 0;

            if (sa != "")
                saida = Convert.ToDouble(cai.SOMA_SALDO_SAIDA().Rows[0][0]);
            else
                saida = 0;

            lblValorSaldo.Text = "R$ " + (entrada - saida).ToString("N3");
        }

        //verifica salvar
        private bool VerificaSalvar()
        {
            //documento
            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Preencha o campo Documento", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDocumento.Focus();
                return false;
            }

            //Historico            
            if (txtHistorico.Text == "")
            {
                MessageBox.Show("Preencha o campo Historico", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHistorico.Focus();
                return false;
            }
            return true;
        }

        //carrega todas as contas
        private void CarregaTudo()
        {
            lstPesquisa.Items.Clear();
            if (lstPesquisa.Text == "")
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


                    lstPesquisa.Items.Add(lvi);
                }

                txtPesquisa.Visible = true;
                dtpData2.Visible = false;
            }
        }

        //verifica se o que digitou
        private bool VerificaRealString(string s)
        {

            int j = 0;
            bool h = false;
            if (s == "real")
            {
                while (j < txtPesquisa.Text.Length)
                {

                    if (char.IsDigit(txtPesquisa.Text[j]))
                    {

                        h = true;
                    }
                    else
                    {
                        j = txtPesquisa.Text.Length;
                        h = false;
                    }
                    j++;
                }
            }
            else//se for string
                while (j < txtPesquisa.Text.Length)
                {
                    //se tiver alguma letra ele vai aceitar
                    if (char.IsLetter(txtPesquisa.Text[j]))
                    {
                        j = txtPesquisa.Text.Length;
                        h = true;
                    }
                    j++;
                }
            return h;
        }       

        //carrega por pesquisa de historico
        private void CarregaHistorico()
        {
            if (VerificaRealString("string"))
            {
                var produt = cai.CONSULTA_CAIXA_HISTORICO(txtPesquisa.Text).Rows;
                foreach (DataRow dr in produt)
                {
                    ListViewItem lvi = new ListViewItem(dr["Documento"].ToString());
                    lvi.SubItems.Add(dr["Historico"].ToString());
                    lvi.SubItems.Add(dr["Valor"].ToString());
                    lvi.SubItems.Add(dr["Entrada"].ToString());
                    lvi.SubItems.Add(dr["Saida"].ToString());
                    lvi.SubItems.Add(dr["Data"].ToString().Substring(0, 10));
                    lvi.SubItems.Add(dr["Administrador"].ToString());
                    lvi.SubItems.Add(dr["Origem"].ToString());
                    origem = dr["Origem"].ToString();

                    lstPesquisa.Items.Add(lvi);
                }
            }
            else
                txtPesquisa.Focus();
        }

        //carrega por pesquisa de documento
        private void CarregaDocumento()
        {
            if (VerificaRealString("real"))
            {
                var produt = cai.CONSULTA_CAIXA_DOCUMENTO(Convert.ToInt32(txtPesquisa.Text)).Rows;
                foreach (DataRow dr in produt)
                {
                    ListViewItem lvi = new ListViewItem(dr["Documento"].ToString());
                    lvi.SubItems.Add(dr["Historico"].ToString());
                    lvi.SubItems.Add(dr["Valor"].ToString());
                    lvi.SubItems.Add(dr["Entrada"].ToString());
                    lvi.SubItems.Add(dr["Saida"].ToString());
                    lvi.SubItems.Add(dr["Data"].ToString().Substring(0, 10));
                    lvi.SubItems.Add(dr["Administrador"].ToString());
                    lvi.SubItems.Add(dr["Origem"].ToString());
                    origem = dr["Origem"].ToString();

                    lstPesquisa.Items.Add(lvi);
                }
            }
            else
                txtPesquisa.Focus();
        }

        public override void Novo()
        {
            ApagarCampos();
            rdbSaida.Enabled = true;
            rdbEntrada.Enabled = true;

            localizar = false;
            txtDocumento.ReadOnly = false;
            txtDocumento.Focus();

            SomaSaldo();

        }

        public override bool Salvar()
        {

            string DATA = dtpData.Text;
            if (pnLocalizar.Visible == false)
            {
                if (VerificaSalvar())
                {
                    //se for igual a false é pq vai salvar
                    if (localizar == false)
                    {
                        //documento
                        int documento;
                        documento = Convert.ToInt32(txtDocumento.Text);

                        try
                        {
                            //se for igual a zero é pq não foi cadastrado
                            if (Convert.ToString(cai.CONSULTA_CAIXA_ID_ORIGEM(documento, "CAIXA").Rows[0][0]) == "0")
                            {

                                cai.INSERT_CAIXA(Convert.ToInt32(txtDocumento.Text), txtHistorico.Text, Convert.ToDouble(txtValor.Text), rdbEntrada.Checked, rdbSaida.Checked, DATA, Id, "CAIXA");

                                if (rdbEntrada.Checked == true)
                                    audi.INSERT_AUDITORIA(Id, " Realizou uma operação de entrada no caixa, no documento " + txtDocumento.Text + "no valor de R$ " + txtValor.Text, DateTime.Now);
                                else if (rdbSaida.Checked == true)
                                    audi.INSERT_AUDITORIA(Id, " Realizou uma operação de saida no caixa, no documento "   + txtDocumento.Text + "no valor de R$ " + txtValor.Text, DateTime.Now);

                                

                            }
                            else
                            {
                                MessageBox.Show("Esse Documento já foi Cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Cadastrar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        SomaSaldo();
                    }
                    else //é pq vai atualizar
                    {

                        try
                        {
                            cai.UPDATE_CAIXA(Convert.ToInt32(txtDocumento.Text), txtHistorico.Text, Convert.ToDouble(txtValor.Text), rdbEntrada.Checked, rdbSaida.Checked, DATA, Id, origem);
                            audi.INSERT_AUDITORIA(Id, " Realizou uma alteração no caixa no documento " + txtDocumento.Text + " de origem " + origem, DateTime.Now);

                            SomaSaldo();
                        }
                        catch
                        {
                            MessageBox.Show("Erro ao Atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    return true;
                }
                else//vai retornar false se encontra algum erro de digitação do usuario
                    return false;
            }
            else//vai retornar false se tentar salvar ainda no painel de pesquisa
                return false;
        }

        public override bool Excluir()
        {
            if (pnLocalizar.Visible == false)
            {
                if (cai.CONSULTA_CAIXA_DOCUMENTO(Convert.ToInt32(txtDocumento.Text)).Rows.Count > 0)
                {
                    if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cai.DELETE_CAIXA(Convert.ToInt32(txtDocumento.Text), ORIGEM);
                        if (rdbEntrada.Checked == true)
                            audi.INSERT_AUDITORIA(Id, " Excluiu no CAIXA o registro " + txtHistorico.Text + " no valor de R$ " + txtValor.Text + " (ENTRADA)", DateTime.Now);
                        else if (rdbSaida.Checked == true)
                            audi.INSERT_AUDITORIA(Id, " Excluiu no CAIXA o registro " + txtHistorico.Text + " no valor de R$ " + txtValor.Text + " (SAIDA)", DateTime.Now);
                        SomaSaldo();
                        return true;
                    }
                }
            }
            //vai excluir direto da lista
            else
            {
                //se foi selecionado um item
                if (lstPesquisa.SelectedItems.Count != 0)
                {
                    if (lstPesquisa.SelectedItems[0].Selected)
                    {
                       
                        if (cai.CONSULTA_CAIXA_DOCUMENTO(Convert.ToInt32(lstPesquisa.FocusedItem.SubItems[0].Text)).Rows.Count > 0)
                        {
                            if (MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ORIGEM = lstPesquisa.FocusedItem.SubItems[7].Text;
                                cai.DELETE_CAIXA(Convert.ToInt32(lstPesquisa.FocusedItem.SubItems[0].Text), ORIGEM);
                                if (lstPesquisa.FocusedItem.SubItems[3].Text == "True")
                                    audi.INSERT_AUDITORIA(Id, " Excluiu no CAIXA o registro " + lstPesquisa.FocusedItem.SubItems[0].Text + " no valor de R$ " + lstPesquisa.FocusedItem.SubItems[2].Text + " (ENTRADA)", DateTime.Now);
                                else if (lstPesquisa.FocusedItem.SubItems[4].Text == "True")
                                    audi.INSERT_AUDITORIA(Id, " Excluiu no CAIXA o registro " + lstPesquisa.FocusedItem.SubItems[0].Text + " no valor de R$ " + lstPesquisa.FocusedItem.SubItems[2].Text + " (SAIDA)", DateTime.Now);
                                
                                pnLocalizar.Visible = false;
                                pnInicial.Visible   = true;

                                LimpaControles();
                                SomaSaldo();

                                return true;
                            }
                        }
                    }
                }
            }
            pnLocalizar.Visible = false;
            pnInicial.Visible   = true;
            LimpaControles();
            return false;
        }

        public override bool Localizar()
        {
            ApagarCampos();
            pnLocalizar.Visible = true;
            pnInicial.Visible = false;

            dtpData2.Visible = false;
            txtPesquisa.Visible = true;
            SomaSaldo();
            rdbDocumento.Checked = true;

            txtPesquisa.Focus();
            CarregaTudo();

            return true;

        }

        public override void Cancelar()
        {
            ApagarCampos();

            pnLocalizar.Visible = false;
            pnInicial.Visible = true;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {
                txtDocumento.Text = ""; txtDocumento.ReadOnly = true;
                txtHistorico.Text = "";
                txtValor.Text     = "0";

                pnLocalizar.Visible = false;
                pnInicial.Visible   = true;

                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    txtDocumento.Text = lstPesquisa.FocusedItem.SubItems[0].Text;
                    txtHistorico.Text = lstPesquisa.FocusedItem.SubItems[1].Text;
                    dtpData.Text      = lstPesquisa.FocusedItem.SubItems[5].Text;
                    txtValor.Text     = lstPesquisa.FocusedItem.SubItems[2].Text;

                    if (lstPesquisa.FocusedItem.SubItems[7].Text == "COMPRAS" || lstPesquisa.FocusedItem.SubItems[7].Text == "PAGAR")
                    {
                        rdbEntrada.Enabled = false;
                        rdbSaida.Enabled   = true;
                    }

                    else if (lstPesquisa.FocusedItem.SubItems[7].Text == "VENDA")
                    {
                        rdbEntrada.Enabled = true;
                        rdbSaida.Enabled   = false;
                    }
                    else
                    {
                        rdbSaida.Enabled   = true;
                        rdbEntrada.Enabled = true;
                        rdbEntrada.Checked = Convert.ToBoolean(lstPesquisa.FocusedItem.SubItems[3].Text);
                    }

                    ORIGEM = lstPesquisa.FocusedItem.SubItems[7].Text;
                    rdbSaida.Checked = Convert.ToBoolean(lstPesquisa.FocusedItem.SubItems[4].Text);


                }
                localizar = true;//caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado

                rdbHistorico.Checked = rdbData.Checked = dtpData2.Visible = false;
                rdbDocumento.Checked = true;

                origem = lstPesquisa.FocusedItem.SubItems[7].Text;
            }
        }

        private void lstPesquisa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //pega os dados selecionados e tras para tela
            if (lstPesquisa.SelectedItems.Count != 0)
            {
                txtDocumento.Text = ""; txtDocumento.ReadOnly = true;
                txtHistorico.Text = "";
                txtValor.Text     = "0";

                pnLocalizar.Visible = false;
                pnInicial.Visible   = true;

                if (lstPesquisa.SelectedItems[0].Selected)
                {
                    txtDocumento.Text = lstPesquisa.FocusedItem.SubItems[0].Text;
                    txtHistorico.Text = lstPesquisa.FocusedItem.SubItems[1].Text;
                    dtpData.Text      = lstPesquisa.FocusedItem.SubItems[5].Text;
                    txtValor.Text     = lstPesquisa.FocusedItem.SubItems[2].Text;

                    if (lstPesquisa.FocusedItem.SubItems[7].Text == "COMPRAS" || lstPesquisa.FocusedItem.SubItems[7].Text == "PAGAR")
                    {
                        rdbEntrada.Enabled = false;
                        rdbSaida.Enabled   = true;
                    }

                    else if (lstPesquisa.FocusedItem.SubItems[7].Text == "VENDA")
                    {
                        rdbEntrada.Enabled = true;
                        rdbSaida.Enabled   = false;
                    }
                    else
                    {
                        rdbSaida.Enabled   = true;
                        rdbEntrada.Enabled = true;
                        rdbEntrada.Checked = Convert.ToBoolean(lstPesquisa.FocusedItem.SubItems[3].Text);
                    }
                    ORIGEM = lstPesquisa.FocusedItem.SubItems[7].Text;
                    rdbSaida.Checked = Convert.ToBoolean(lstPesquisa.FocusedItem.SubItems[4].Text);


                }
                localizar = true;//caso tiver mostrado algo no liste view, então quando clicar em ok é pq algo foi selecionado

                rdbHistorico.Checked = rdbData.Checked = dtpData2.Visible = false;
                rdbDocumento.Checked = true;

                origem = lstPesquisa.FocusedItem.SubItems[7].Text;
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            lstPesquisa.Items.Clear();
            //inicio historico
            if (txtPesquisa.Text == "")
                CarregaTudo();
            else
            {
                if (rdbHistorico.Checked == true)
                {
                    CarregaHistorico();
                }
                //fim historico

                //inicio documento
                else if (rdbDocumento.Checked == true)
                {
                    CarregaDocumento();
                }
                //fim documento     
            } 
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Visible = false;
            dtpData2.Visible    = true;

            lstPesquisa.Items.Clear();
            var produt = cai.CONSULTA_CAIXA_DATA(dtpData2.Text).Rows;
            foreach (DataRow dr in produt)
            {
                ListViewItem lvi = new ListViewItem(dr["Documento"].ToString());
                lvi.SubItems.Add(dr["Historico"].ToString());
                lvi.SubItems.Add(dr["Valor"].ToString());
                lvi.SubItems.Add(dr["Entrada"].ToString());
                lvi.SubItems.Add(dr["Saida"].ToString());
                lvi.SubItems.Add(dr["Data"].ToString().Substring(0, 10));
                lvi.SubItems.Add(dr["Administrador"].ToString());
                lvi.SubItems.Add(dr["Origem"].ToString());


                lstPesquisa.Items.Add(lvi);
            }
        }

        private void dtpData2_ValueChanged(object sender, EventArgs e)
        {
            lstPesquisa.Items.Clear();
            var produt = cai.CONSULTA_CAIXA_DATA(dtpData2.Text).Rows;
            foreach (DataRow dr in produt)
            {
                ListViewItem lvi = new ListViewItem(dr["Documento"].ToString());
                lvi.SubItems.Add(dr["Historico"].ToString());
                lvi.SubItems.Add(dr["Valor"].ToString());
                lvi.SubItems.Add(dr["Entrada"].ToString());
                lvi.SubItems.Add(dr["Saida"].ToString());
                lvi.SubItems.Add(dr["Data"].ToString().Substring(0, 10));
                lvi.SubItems.Add(dr["Administrador"].ToString());
                lvi.SubItems.Add(dr["Origem"].ToString());
                origem = dr["Origem"].ToString();


                lstPesquisa.Items.Add(lvi);
            }
        }

        private void rdbHistorico_CheckedChanged(object sender, EventArgs e)
        {
            dtpData2.Visible   = false;
            txtPesquisa.Visible = true;

            lstPesquisa.Items.Clear();
            if (txtPesquisa.Text == "")
                CarregaTudo();
            else
                CarregaHistorico();
        }

        private void rdbDocumento_CheckedChanged(object sender, EventArgs e)
        {
            dtpData2.Visible    = false;
            txtPesquisa.Visible = true;

            lstPesquisa.Items.Clear();
            if (txtPesquisa.Text == "")
                CarregaTudo();
            else
                CarregaDocumento();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            txtValor.Text = frm.CorrigirNumerosDouble(txtValor.Text);
        }

        



    }
}
