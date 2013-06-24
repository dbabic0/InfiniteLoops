namespace Forme
{
    partial class IzbornikRazrednika
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
            this.btnEvidencijaSata = new System.Windows.Forms.Button();
            this.btnPopisUcenika = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImePrezime = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPredmeti = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEvidencijaSata
            // 
            this.btnEvidencijaSata.Location = new System.Drawing.Point(151, 88);
            this.btnEvidencijaSata.Name = "btnEvidencijaSata";
            this.btnEvidencijaSata.Size = new System.Drawing.Size(116, 51);
            this.btnEvidencijaSata.TabIndex = 0;
            this.btnEvidencijaSata.Text = "Evidencija sata";
            this.btnEvidencijaSata.UseVisualStyleBackColor = true;
            this.btnEvidencijaSata.Click += new System.EventHandler(this.btnEvidencijaSata_Click);
            // 
            // btnPopisUcenika
            // 
            this.btnPopisUcenika.Location = new System.Drawing.Point(16, 88);
            this.btnPopisUcenika.Name = "btnPopisUcenika";
            this.btnPopisUcenika.Size = new System.Drawing.Size(116, 51);
            this.btnPopisUcenika.TabIndex = 1;
            this.btnPopisUcenika.Text = "Popis učenika";
            this.btnPopisUcenika.UseVisualStyleBackColor = true;
            this.btnPopisUcenika.Click += new System.EventHandler(this.btnPopisUcenika_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(376, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Odabir uloge";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ime i prezime razrednika";
            // 
            // txtImePrezime
            // 
            this.txtImePrezime.Location = new System.Drawing.Point(15, 30);
            this.txtImePrezime.Name = "txtImePrezime";
            this.txtImePrezime.ReadOnly = true;
            this.txtImePrezime.Size = new System.Drawing.Size(159, 20);
            this.txtImePrezime.TabIndex = 4;
            this.txtImePrezime.TextChanged += new System.EventHandler(this.txtImePrezime_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(273, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Datum";
            // 
            // cmbPredmeti
            // 
            this.cmbPredmeti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmeti.FormattingEnabled = true;
            this.cmbPredmeti.Location = new System.Drawing.Point(170, 56);
            this.cmbPredmeti.Name = "cmbPredmeti";
            this.cmbPredmeti.Size = new System.Drawing.Size(121, 21);
            this.cmbPredmeti.TabIndex = 7;
            this.cmbPredmeti.SelectedIndexChanged += new System.EventHandler(this.cmbPredmet_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Razred";
            // 
            // IzbornikRazrednika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 173);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPredmeti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtImePrezime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPopisUcenika);
            this.Controls.Add(this.btnEvidencijaSata);
            this.Name = "IzbornikRazrednika";
            this.Text = "Izbornik razrednika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEvidencijaSata;
        private System.Windows.Forms.Button btnPopisUcenika;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImePrezime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPredmeti;
        private System.Windows.Forms.Label label3;
    }
}