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
        Classes.Auditoria aud = new Classes.Auditoria();
        Classes.Cadernetas cad = new Classes.Cadernetas();

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
            CarregarDropDL();
        }

        //carregar os drop down list quando carregar o formulario
        private void CarregarDropDL()
        {
            cbbTipoConsulta.Text = "Caderneta";
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

        private void CarregaCadernetaTCNT()
        {
            double total = 0;
            lstCaderneta.Items.Clear();
            var produtos = cad.CONSULTA_CADERNETATCNT().Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());

                lstCaderneta.Items.Add(lvi);
                total += Convert.ToDouble(dr[2].ToString());
            }
            label2.Text = "R$" + total;
        }

        private void CarregaCadernetaTCNUT()
        {
            double total = 0;
            lstCaderneta.Items.Clear();
            var produtos = cad.CONSULTA_CADERNETATCNUT().Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());

                lstCaderneta.Items.Add(lvi);

                total += Convert.ToDouble(dr[2].ToString());
            }
            label2.Text = "R$" + total;
        }

        private void CarregaCadernetaTCNTD()
        {
            double total = 0;
            lstCaderneta.Items.Clear();

            DateTime dt1, dt2;
            dt1 = dtpDe.Value;
            dt2 = dtpAte.Value;
            dt1 = Convert.ToDateTime(dt1.ToString("dd/MM/yyyy"));
            dt2 = Convert.ToDateTime(dt2.ToString("dd/MM/yyyy"));
            var produtos = cad.CONSULTA_CADERNETATCNTD(dt1, dt2).Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());

                lstCaderneta.Items.Add(lvi);

                total += Convert.ToDouble(dr[2].ToString());
            }
            label2.Text = "R$" + total;
        }

        private void CarregaCadernetaTCNUTD()
        {
            double total = 0;
            lstCaderneta.Items.Clear();

            DateTime dt1, dt2;
            dt1 = dtpDe.Value;
            dt2 = dtpAte.Value;
            dt1 = Convert.ToDateTime(dt1.ToString("dd/MM/yyyy"));
            dt2 = Convert.ToDateTime(dt2.ToString("dd/MM/yyyy"));
            var produtos = cad.CONSULTA_CADERNETATCNUTD(dt1, dt2).Rows;

            foreach (DataRow dr in produtos)
            {
                ListViewItem lvi = new ListViewItem(dr[0].ToString());
                lvi.SubItems.Add(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());

                lstCaderneta.Items.Add(lvi);

                total += Convert.ToDouble(dr[2].ToString());
            }
            label2.Text = "R$" + total;
        }

        //Tipo de Consulta
        private void cbbTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            //deixa o panel pesquisa invisivel


            if (cbbTipoConsulta.Text == "Auditoria")
            {

                //desabilitando groupbox
                gpbTipoPesquisa.Enabled = gpbData.Enabled = false;
                //desabilita as datas
                dtpDe.Enabled = dtpAte.Enabled = true;

                //deixa o listview auditoria visivel e na frente
                lstAuditoria.Visible = true;
                lstCaderneta.Visible = false;

                //carrega o listview da auditoria
                CarregaAuditoria();

            }
            else if (cbbTipoConsulta.Text == "Caderneta")
            {

                cbbTipoPesquisa.Text = "Nome";
                cbbData.Text = "Todas";

                //abilitando groubbox
                gpbTipoPesquisa.Enabled = gpbData.Enabled = true;

                //desabilitando as datas se for para mostrar todas as datas
                if (cbbData.Text == "Todas")
                    dtpDe.Enabled = dtpAte.Enabled = false;


                //deixa o listview caderneta visivel e na frente
                lstAuditoria.Visible = false;
                lstCaderneta.Visible = true;

                CarregaCadernetaTCNT();
            }

        }

        //Tipo de pesquisa
        private void cbbTipoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {


            //tipo de consulta nome
            if (cbbTipoPesquisa.Text == "Nome")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNTD();
                }
            }

            //tipo de consulta numero
            else if (cbbTipoPesquisa.Text == "Número")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNUT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNUTD();
                }
            }
        }

        //pesquisa por data
        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            if (cbbTipoConsulta.Text == "Auditoria")
            {
                CarregaAuditoria();
            }
            else
            {
                //tipo de consulta nome
                if (cbbTipoPesquisa.Text == "Nome")
                {
                    //data todas
                    if (cbbData.Text == "Todas")
                    {
                        CarregaCadernetaTCNT();
                    }

                    //data vendas
                    if (cbbData.Text == "Vendas")
                    {
                        CarregaCadernetaTCNTD();
                    }
                }

                //tipo de consulta numero
                else if (cbbTipoPesquisa.Text == "Número")
                {
                    //data todas
                    if (cbbData.Text == "Todas")
                    {
                        CarregaCadernetaTCNUT();
                    }

                    //data vendas
                    if (cbbData.Text == "Vendas")
                    {
                        CarregaCadernetaTCNUTD();
                    }
                }


            }
        }

        //pesquisa por data
        private void dtpAte_ValueChanged(object sender, EventArgs e)
        {
            if (cbbTipoConsulta.Text == "Auditoria")
            {
                CarregaAuditoria();
            }
            else
            {

                //tipo de consulta nome
                if (cbbTipoPesquisa.Text == "Nome")
                {
                    //data todas
                    if (cbbData.Text == "Todas")
                    {
                        CarregaCadernetaTCNT();
                    }

                    //data vendas
                    if (cbbData.Text == "Vendas")
                    {
                        CarregaCadernetaTCNTD();
                    }
                }

                //tipo de consulta numero
                else if (cbbTipoPesquisa.Text == "Número")
                {
                    //data todas
                    if (cbbData.Text == "Todas")
                    {
                        CarregaCadernetaTCNUT();
                    }

                    //data vendas
                    if (cbbData.Text == "Vendas")
                    {
                        CarregaCadernetaTCNUTD();
                    }
                }
            }
        }


        //combo box Listar, é nele que vc escolhe se quer listar todos os clientes ou se quer listar apena algum(s) especifico(s)
        private void cbbListar_SelectedIndexChanged(object sender, EventArgs e)
        {


            //tipo de consulta nome
            if (cbbTipoPesquisa.Text == "Nome")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNTD();
                }
            }

            //tipo de consulta numero
            else if (cbbTipoPesquisa.Text == "Número")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNUT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNUTD();
                }
            }

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
            else if (cbbData.Text == "Vendas")
            {
                dtpAte.Enabled = dtpDe.Enabled = true;
            }


            //tipo de consulta nome
            if (cbbTipoPesquisa.Text == "Nome")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNTD();
                }
            }

            //tipo de consulta numero
            else if (cbbTipoPesquisa.Text == "Número")
            {
                //data todas
                if (cbbData.Text == "Todas")
                {
                    CarregaCadernetaTCNUT();
                }

                //data vendas
                if (cbbData.Text == "Vendas")
                {
                    CarregaCadernetaTCNUTD();
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
    }
}

        

       

       

      

        


