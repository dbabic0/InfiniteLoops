namespace Forme
{
    partial class IzbornikProfesora
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
            this.btnPopisPredmetnih = new System.Windows.Forms.Button();
            this.btnEvidencijaSata = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImePrezime = new System.Windows.Forms.TextBox();
            this.cmbPopis = new System.Windows.Forms.ComboBox();
            this.btnOdabirUloge = new System.Windows.Forms.Button();
            this.cmbRazred = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPopisPredmetnih
            // 
            this.btnPopisPredmetnih.Location = new System.Drawing.Point(33, 144);
            this.btnPopisPredmetnih.Name = "btnPopisPredmetnih";
            this.btnPopisPredmetnih.Size = new System.Drawing.Size(136, 69);
            this.btnPopisPredmetnih.TabIndex = 0;
            this.btnPopisPredmetnih.Text = "Popis predmetnih učenika";
            this.btnPopisPredmetnih.UseVisualStyleBackColor = true;
            this.btnPopisPredmetnih.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEvidencijaSata
            // 
            this.btnEvidencijaSata.Location = new System.Drawing.Point(273, 144);
            this.btnEvidencijaSata.Name = "btnEvidencijaSata";
            this.btnEvidencijaSata.Size = new System.Drawing.Size(136, 69);
            this.btnEvidencijaSata.TabIndex = 1;
            this.btnEvidencijaSata.Text = "Evidencija sata";
            this.btnEvidencijaSata.UseVisualStyleBackColor = true;
            this.btnEvidencijaSata.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(210, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(273, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ime i prezime profesora";
            // 
            // txtImePrezime
            // 
            this.txtImePrezime.Location = new System.Drawing.Point(4, 40);
            this.txtImePrezime.Name = "txtImePrezime";
            this.txtImePrezime.ReadOnly = true;
            this.txtImePrezime.Size = new System.Drawing.Size(135, 20);
            this.txtImePrezime.TabIndex = 5;

            // 
            // cmbPopis
            // 
            this.cmbPopis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPopis.FormattingEnabled = true;
            this.cmbPopis.Location = new System.Drawing.Point(352, 51);
            this.cmbPopis.Name = "cmbPopis";
            this.cmbPopis.Size = new System.Drawing.Size(121, 21);
            this.cmbPopis.TabIndex = 6;
            this.cmbPopis.SelectedIndexChanged += new System.EventHandler(this.cmbPopis_SelectedIndexChanged);
            // 
            // btnOdabirUloge
            // 
            this.btnOdabirUloge.Location = new System.Drawing.Point(377, 230);
            this.btnOdabirUloge.Name = "btnOdabirUloge";
            this.btnOdabirUloge.Size = new System.Drawing.Size(94, 23);
            this.btnOdabirUloge.TabIndex = 7;
            this.btnOdabirUloge.Text = "Odabir uloge";
            this.btnOdabirUloge.UseVisualStyleBackColor = true;
            this.btnOdabirUloge.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbRazred
            // 
            this.cmbRazred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRazred.FormattingEnabled = true;
            this.cmbRazred.Location = new System.Drawing.Point(352, 84);
            this.cmbRazred.Name = "cmbRazred";
            this.cmbRazred.Size = new System.Drawing.Size(121, 21);
            this.cmbRazred.TabIndex = 8;

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Naziv predmeta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Razred";
            // 
            // IzbornikProfesora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 284);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRazred);
            this.Controls.Add(this.btnOdabirUloge);
            this.Controls.Add(this.cmbPopis);
            this.Controls.Add(this.txtImePrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEvidencijaSata);
            this.Controls.Add(this.btnPopisPredmetnih);
            this.Name = "IzbornikProfesora";
            this.Text = "Izbornik profesora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPopisPredmetnih;
        private System.Windows.Forms.Button btnEvidencijaSata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImePrezime;
        private System.Windows.Forms.ComboBox cmbPopis;
        private System.Windows.Forms.Button btnOdabirUloge;
        private System.Windows.Forms.ComboBox cmbRazred;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}