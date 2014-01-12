namespace MN_CADERNETA
{
    partial class CadastroVendedor
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
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroVendedor));
            this.pnLocalizar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lstPesquisa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnInicial = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRepitaSenha = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnLocalizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnInicial.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "CONTADOR";
            columnHeader2.Width = 80;
            // 
            // pnLocalizar
            // 
            this.pnLocalizar.BackColor = System.Drawing.SystemColors.Control;
            this.pnLocalizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLocalizar.Controls.Add(this.pictureBox1);
            this.pnLocalizar.Controls.Add(this.btnOK);
            this.pnLocalizar.Controls.Add(this.txtPesquisa);
            this.pnLocalizar.Controls.Add(this.lstPesquisa);
            this.pnLocalizar.Location = new System.Drawing.Point(5, 75);
            this.pnLocalizar.Name = "pnLocalizar";
            this.pnLocalizar.Size = new System.Drawing.Size(998, 504);
            this.pnLocalizar.TabIndex = 19;
            this.pnLocalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnLocalizar_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Purple;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(714, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 42);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(780, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(185, 147);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.Color.White;
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.txtPesquisa.Location = new System.Drawing.Point(14, 29);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(760, 41);
            this.txtPesquisa.TabIndex = 9;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // lstPesquisa
            // 
            this.lstPesquisa.AllowColumnReorder = true;
            this.lstPesquisa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.lstPesquisa.FullRowSelect = true;
            this.lstPesquisa.GridLines = true;
            this.lstPesquisa.Location = new System.Drawing.Point(14, 101);
            this.lstPesquisa.Name = "lstPesquisa";
            this.lstPesquisa.Size = new System.Drawing.Size(760, 334);
            this.lstPesquisa.TabIndex = 10;
            this.lstPesquisa.UseCompatibleStateImageBehavior = false;
            this.lstPesquisa.View = System.Windows.Forms.View.Details;
            this.lstPesquisa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPesquisa_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NOME";
            this.columnHeader1.Width = 434;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SENHA";
            this.columnHeader3.Width = 236;
            // 
            // pnInicial
            // 
            this.pnInicial.BackColor = System.Drawing.SystemColors.Control;
            this.pnInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnInicial.Controls.Add(this.panel2);
            this.pnInicial.Location = new System.Drawing.Point(5, 75);
            this.pnInicial.Name = "pnInicial";
            this.pnInicial.Size = new System.Drawing.Size(998, 504);
            this.pnInicial.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtRepitaSenha);
            this.panel2.Controls.Add(this.txtSenha);
            this.panel2.Controls.Add(this.txtNome);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(137, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 227);
            this.panel2.TabIndex = 0;
            // 
            // txtRepitaSenha
            // 
            this.txtRepitaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepitaSenha.Location = new System.Drawing.Point(265, 141);
            this.txtRepitaSenha.Name = "txtRepitaSenha";
            this.txtRepitaSenha.PasswordChar = '*';
            this.txtRepitaSenha.Size = new System.Drawing.Size(337, 31);
            this.txtRepitaSenha.TabIndex = 5;
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(265, 90);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(337, 31);
            this.txtSenha.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(265, 33);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(337, 31);
            this.txtNome.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Repita a senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // CadastroVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 584);
            this.Controls.Add(this.pnInicial);
            this.Controls.Add(this.pnLocalizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastroVendedor";
            this.Text = "CadastroVendedor";
            this.Controls.SetChildIndex(this.pnLocalizar, 0);
            this.Controls.SetChildIndex(this.pnInicial, 0);
            this.pnLocalizar.ResumeLayout(false);
            this.pnLocalizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnInicial.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLocalizar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ListView lstPesquisa;
        private System.Windows.Forms.Panel pnInicial;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRepitaSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}