namespace MN_CADERNETA
{
    partial class Relatorios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDe = new System.Windows.Forms.Label();
            this.gpbData = new System.Windows.Forms.GroupBox();
            this.cbbData = new System.Windows.Forms.ComboBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.gpbTipoConsulta = new System.Windows.Forms.GroupBox();
            this.cbbTipoConsulta = new System.Windows.Forms.ComboBox();
            this.gpbTipoPesquisa = new System.Windows.Forms.GroupBox();
            this.cbbTipoPesquisa = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstCaderneta = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstAuditoria = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gpbData.SuspendLayout();
            this.gpbTipoConsulta.SuspendLayout();
            this.gpbTipoPesquisa.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 191);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblDe);
            this.panel4.Controls.Add(this.gpbData);
            this.panel4.Controls.Add(this.dtpAte);
            this.panel4.Controls.Add(this.lblAte);
            this.panel4.Controls.Add(this.dtpDe);
            this.panel4.Controls.Add(this.gpbTipoConsulta);
            this.panel4.Controls.Add(this.gpbTipoPesquisa);
            this.panel4.Location = new System.Drawing.Point(4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(985, 181);
            this.panel4.TabIndex = 6;
            // 
            // lblDe
            // 
            this.lblDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(741, 48);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(39, 25);
            this.lblDe.TabIndex = 6;
            this.lblDe.Text = "De";
            // 
            // gpbData
            // 
            this.gpbData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbData.Controls.Add(this.cbbData);
            this.gpbData.Location = new System.Drawing.Point(493, 39);
            this.gpbData.Name = "gpbData";
            this.gpbData.Size = new System.Drawing.Size(233, 95);
            this.gpbData.TabIndex = 5;
            this.gpbData.TabStop = false;
            this.gpbData.Text = "Data";
            // 
            // cbbData
            // 
            this.cbbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbData.FormattingEnabled = true;
            this.cbbData.Items.AddRange(new object[] {
            "Todas",
            "Vendas"});
            this.cbbData.Location = new System.Drawing.Point(6, 38);
            this.cbbData.Name = "cbbData";
            this.cbbData.Size = new System.Drawing.Size(221, 33);
            this.cbbData.TabIndex = 4;
            this.cbbData.SelectedIndexChanged += new System.EventHandler(this.cbbData_SelectedIndexChanged);
            // 
            // dtpAte
            // 
            this.dtpAte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(786, 104);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(188, 31);
            this.dtpAte.TabIndex = 24;
            this.dtpAte.ValueChanged += new System.EventHandler(this.dtpAte_ValueChanged);
            // 
            // lblAte
            // 
            this.lblAte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(741, 109);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(44, 25);
            this.lblAte.TabIndex = 7;
            this.lblAte.Text = "Até";
            // 
            // dtpDe
            // 
            this.dtpDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(786, 48);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(188, 31);
            this.dtpDe.TabIndex = 23;
            this.dtpDe.ValueChanged += new System.EventHandler(this.dtpDe_ValueChanged);
            // 
            // gpbTipoConsulta
            // 
            this.gpbTipoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbTipoConsulta.Controls.Add(this.cbbTipoConsulta);
            this.gpbTipoConsulta.Location = new System.Drawing.Point(14, 38);
            this.gpbTipoConsulta.Name = "gpbTipoConsulta";
            this.gpbTipoConsulta.Size = new System.Drawing.Size(197, 97);
            this.gpbTipoConsulta.TabIndex = 5;
            this.gpbTipoConsulta.TabStop = false;
            this.gpbTipoConsulta.Text = "Tipo de Consulta";
            // 
            // cbbTipoConsulta
            // 
            this.cbbTipoConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoConsulta.FormattingEnabled = true;
            this.cbbTipoConsulta.Items.AddRange(new object[] {
            "Auditoria",
            "Caderneta"});
            this.cbbTipoConsulta.Location = new System.Drawing.Point(6, 39);
            this.cbbTipoConsulta.Name = "cbbTipoConsulta";
            this.cbbTipoConsulta.Size = new System.Drawing.Size(172, 33);
            this.cbbTipoConsulta.TabIndex = 1;
            this.cbbTipoConsulta.SelectedIndexChanged += new System.EventHandler(this.cbbTipoConsulta_SelectedIndexChanged);
            // 
            // gpbTipoPesquisa
            // 
            this.gpbTipoPesquisa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbTipoPesquisa.Controls.Add(this.cbbTipoPesquisa);
            this.gpbTipoPesquisa.Location = new System.Drawing.Point(239, 40);
            this.gpbTipoPesquisa.Name = "gpbTipoPesquisa";
            this.gpbTipoPesquisa.Size = new System.Drawing.Size(233, 95);
            this.gpbTipoPesquisa.TabIndex = 3;
            this.gpbTipoPesquisa.TabStop = false;
            this.gpbTipoPesquisa.Text = "Tipo de Pesquisa";
            // 
            // cbbTipoPesquisa
            // 
            this.cbbTipoPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoPesquisa.FormattingEnabled = true;
            this.cbbTipoPesquisa.Items.AddRange(new object[] {
            "Nome",
            "Número"});
            this.cbbTipoPesquisa.Location = new System.Drawing.Point(6, 37);
            this.cbbTipoPesquisa.Name = "cbbTipoPesquisa";
            this.cbbTipoPesquisa.Size = new System.Drawing.Size(221, 33);
            this.cbbTipoPesquisa.TabIndex = 4;
            this.cbbTipoPesquisa.SelectedIndexChanged += new System.EventHandler(this.cbbTipoPesquisa_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lstAuditoria);
            this.panel2.Controls.Add(this.lstCaderneta);
            this.panel2.Location = new System.Drawing.Point(5, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 462);
            this.panel2.TabIndex = 1;
            // 
            // lstCaderneta
            // 
            this.lstCaderneta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCaderneta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.lstCaderneta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCaderneta.FullRowSelect = true;
            this.lstCaderneta.GridLines = true;
            this.lstCaderneta.Location = new System.Drawing.Point(3, 3);
            this.lstCaderneta.Name = "lstCaderneta";
            this.lstCaderneta.Size = new System.Drawing.Size(988, 452);
            this.lstCaderneta.TabIndex = 23;
            this.lstCaderneta.UseCompatibleStateImageBehavior = false;
            this.lstCaderneta.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "N°";
            this.columnHeader3.Width = 83;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cliente";
            this.columnHeader4.Width = 379;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Valor Total";
            this.columnHeader5.Width = 129;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data Venda";
            this.columnHeader6.Width = 179;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Vendedor";
            this.columnHeader8.Width = 256;
            // 
            // lstAuditoria
            // 
            this.lstAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAuditoria.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lstAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAuditoria.FullRowSelect = true;
            this.lstAuditoria.GridLines = true;
            this.lstAuditoria.Location = new System.Drawing.Point(2, 3);
            this.lstAuditoria.Name = "lstAuditoria";
            this.lstAuditoria.Size = new System.Drawing.Size(988, 452);
            this.lstAuditoria.TabIndex = 24;
            this.lstAuditoria.UseCompatibleStateImageBehavior = false;
            this.lstAuditoria.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "VENDEDOR";
            this.columnHeader9.Width = 198;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ATIVIDADES";
            this.columnHeader10.Width = 379;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "DATA";
            this.columnHeader11.Width = 234;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(348, 668);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 25);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "TOTAL";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(434, 669);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "R$";
            // 
            // Relatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 716);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "Relatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Relatorios_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gpbData.ResumeLayout(false);
            this.gpbTipoConsulta.ResumeLayout(false);
            this.gpbTipoPesquisa.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbbTipoConsulta;
        private System.Windows.Forms.GroupBox gpbTipoPesquisa;
        private System.Windows.Forms.ComboBox cbbTipoPesquisa;
        private System.Windows.Forms.GroupBox gpbTipoConsulta;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.GroupBox gpbData;
        private System.Windows.Forms.ComboBox cbbData;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lstCaderneta;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstAuditoria;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}