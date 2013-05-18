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
            this.lblBrojSata = new System.Windows.Forms.Label();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblIzostanci = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBrojSata = new System.Windows.Forms.TextBox();
            this.lblDatum = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.txtIzostanci = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBrojSata
            // 
            this.lblBrojSata.AutoSize = true;
            this.lblBrojSata.Location = new System.Drawing.Point(57, 81);
            this.lblBrojSata.Name = "lblBrojSata";
            this.lblBrojSata.Size = new System.Drawing.Size(81, 13);
            this.lblBrojSata.TabIndex = 0;
            this.lblBrojSata.Text = "Redni broj sata:";
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(97, 116);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(37, 13);
            this.lblTema.TabIndex = 1;
            this.lblTema.Text = "Tema:";
            // 
            // lblIzostanci
            // 
            this.lblIzostanci.AutoSize = true;
            this.lblIzostanci.Location = new System.Drawing.Point(45, 311);
            this.lblIzostanci.Name = "lblIzostanci";
            this.lblIzostanci.Size = new System.Drawing.Size(93, 13);
            this.lblIzostanci.TabIndex = 3;
            this.lblIzostanci.Text = "Izostanci učenika:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(144, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txtBrojSata
            // 
            this.txtBrojSata.Location = new System.Drawing.Point(144, 81);
            this.txtBrojSata.Name = "txtBrojSata";
            this.txtBrojSata.Size = new System.Drawing.Size(176, 20);
            this.txtBrojSata.TabIndex = 5;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(97, 56);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Text = "Datum:";
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(144, 116);
            this.txtTema.Multiline = true;
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(176, 185);
            this.txtTema.TabIndex = 7;
            // 
            // txtIzostanci
            // 
            this.txtIzostanci.Location = new System.Drawing.Point(145, 311);
            this.txtIzostanci.Multiline = true;
            this.txtIzostanci.Name = "txtIzostanci";
            this.txtIzostanci.Size = new System.Drawing.Size(175, 79);
            this.txtIzostanci.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EvidencijaSata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIzostanci);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.txtBrojSata);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblIzostanci);
            this.Controls.Add(this.lblTema);
            this.Controls.Add(this.lblBrojSata);
            this.Name = "EvidencijaSata";
            this.Text = "Evidencija sata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrojSata;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.Label lblIzostanci;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBrojSata;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.TextBox txtIzostanci;
        private System.Windows.Forms.Button button1;

    }
}