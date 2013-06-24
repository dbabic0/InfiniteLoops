namespace Forme
{
    partial class EvidencijaSata
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRedni_broj_sata = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDatum = new System.Windows.Forms.Label();
            this.cmbPrisutni = new System.Windows.Forms.ComboBox();
            this.cmbIzostali = new System.Windows.Forms.ComboBox();
            this.lblSvi = new System.Windows.Forms.Label();
            this.lblIzostali = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNijeIzostao = new System.Windows.Forms.Button();
            this.btnIzostao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIzostali = new System.Windows.Forms.TextBox();
            this.txtPrisutni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Redni broj sata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tema:";
            // 
            // txtRedni_broj_sata
            // 
            this.txtRedni_broj_sata.Location = new System.Drawing.Point(98, 42);
            this.txtRedni_broj_sata.Name = "txtRedni_broj_sata";
            this.txtRedni_broj_sata.Size = new System.Drawing.Size(176, 20);
            this.txtRedni_broj_sata.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datum:";
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(98, 77);
            this.txtTema.Multiline = true;
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(176, 185);
            this.txtTema.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(124, 17);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(35, 13);
            this.lblDatum.TabIndex = 10;
            this.lblDatum.Text = "label5";
            this.lblDatum.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbPrisutni
            // 
            this.cmbPrisutni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrisutni.FormattingEnabled = true;
            this.cmbPrisutni.Location = new System.Drawing.Point(9, 48);
            this.cmbPrisutni.Name = "cmbPrisutni";
            this.cmbPrisutni.Size = new System.Drawing.Size(392, 21);
            this.cmbPrisutni.TabIndex = 11;
            // 
            // cmbIzostali
            // 
            this.cmbIzostali.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIzostali.FormattingEnabled = true;
            this.cmbIzostali.Location = new System.Drawing.Point(9, 117);
            this.cmbIzostali.Name = "cmbIzostali";
            this.cmbIzostali.Size = new System.Drawing.Size(392, 21);
            this.cmbIzostali.TabIndex = 12;
            // 
            // lblSvi
            // 
            this.lblSvi.AutoSize = true;
            this.lblSvi.Location = new System.Drawing.Point(140, 32);
            this.lblSvi.Name = "lblSvi";
            this.lblSvi.Size = new System.Drawing.Size(159, 13);
            this.lblSvi.TabIndex = 13;
            this.lblSvi.Text = "Popis ucenika koji su na nastavi";
            this.lblSvi.Click += new System.EventHandler(this.lblSvi_Click);
            // 
            // lblIzostali
            // 
            this.lblIzostali.AutoSize = true;
            this.lblIzostali.Location = new System.Drawing.Point(140, 101);
            this.lblIzostali.Name = "lblIzostali";
            this.lblIzostali.Size = new System.Drawing.Size(114, 13);
            this.lblIzostali.TabIndex = 14;
            this.lblIzostali.Text = "Popis izostalih učenika";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNijeIzostao);
            this.groupBox1.Controls.Add(this.btnIzostao);
            this.groupBox1.Controls.Add(this.cmbIzostali);
            this.groupBox1.Controls.Add(this.lblIzostali);
            this.groupBox1.Controls.Add(this.lblSvi);
            this.groupBox1.Controls.Add(this.cmbPrisutni);
            this.groupBox1.Location = new System.Drawing.Point(33, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 158);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izostanci učenika";
            // 
            // btnNijeIzostao
            // 
            this.btnNijeIzostao.Location = new System.Drawing.Point(417, 115);
            this.btnNijeIzostao.Name = "btnNijeIzostao";
            this.btnNijeIzostao.Size = new System.Drawing.Size(75, 23);
            this.btnNijeIzostao.TabIndex = 16;
            this.btnNijeIzostao.Text = "Nije izostao";
            this.btnNijeIzostao.UseVisualStyleBackColor = true;
            this.btnNijeIzostao.Click += new System.EventHandler(this.btnNijeIzostao_Click);
            // 
            // btnIzostao
            // 
            this.btnIzostao.Location = new System.Drawing.Point(417, 46);
            this.btnIzostao.Name = "btnIzostao";
            this.btnIzostao.Size = new System.Drawing.Size(75, 23);
            this.btnIzostao.TabIndex = 15;
            this.btnIzostao.Text = "Izostao";
            this.btnIzostao.UseVisualStyleBackColor = true;
            this.btnIzostao.Click += new System.EventHandler(this.btnIzostao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRedni_broj_sata);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblDatum);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTema);
            this.groupBox2.Location = new System.Drawing.Point(33, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 276);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evidencija sata";
            // 
            // txtIzostali
            // 
            this.txtIzostali.Location = new System.Drawing.Point(751, 67);
            this.txtIzostali.Multiline = true;
            this.txtIzostali.Name = "txtIzostali";
            this.txtIzostali.ReadOnly = true;
            this.txtIzostali.Size = new System.Drawing.Size(177, 378);
            this.txtIzostali.TabIndex = 17;
            // 
            // txtPrisutni
            // 
            this.txtPrisutni.Location = new System.Drawing.Point(574, 67);
            this.txtPrisutni.Multiline = true;
            this.txtPrisutni.Name = "txtPrisutni";
            this.txtPrisutni.ReadOnly = true;
            this.txtPrisutni.Size = new System.Drawing.Size(148, 378);
            this.txtPrisutni.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(764, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Izostali";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Prisutni";
            // 
            // EvidencijaSata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 523);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrisutni);
            this.Controls.Add(this.txtIzostali);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "EvidencijaSata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija sata";
            this.Load += new System.EventHandler(this.EvidencijaSata_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRedni_broj_sata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.ComboBox cmbPrisutni;
        private System.Windows.Forms.ComboBox cmbIzostali;
        private System.Windows.Forms.Label lblSvi;
        private System.Windows.Forms.Label lblIzostali;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNijeIzostao;
        private System.Windows.Forms.Button btnIzostao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIzostali;
        private System.Windows.Forms.TextBox txtPrisutni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

    }
}