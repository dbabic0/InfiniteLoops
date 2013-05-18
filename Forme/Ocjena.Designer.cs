namespace Forme
{
    partial class FrmOcjena
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblOcjena = new System.Windows.Forms.Label();
            this.lblNapomena = new System.Windows.Forms.Label();
            this.txtOcjena = new System.Windows.Forms.TextBox();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(25, 18);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum:";
            // 
            // lblOcjena
            // 
            this.lblOcjena.AutoSize = true;
            this.lblOcjena.Location = new System.Drawing.Point(25, 47);
            this.lblOcjena.Name = "lblOcjena";
            this.lblOcjena.Size = new System.Drawing.Size(44, 13);
            this.lblOcjena.TabIndex = 2;
            this.lblOcjena.Text = "Ocjena:";
            // 
            // lblNapomena
            // 
            this.lblNapomena.AutoSize = true;
            this.lblNapomena.Location = new System.Drawing.Point(7, 74);
            this.lblNapomena.Name = "lblNapomena";
            this.lblNapomena.Size = new System.Drawing.Size(62, 13);
            this.lblNapomena.TabIndex = 3;
            this.lblNapomena.Text = "Napomena:";
            // 
            // txtOcjena
            // 
            this.txtOcjena.Location = new System.Drawing.Point(78, 47);
            this.txtOcjena.Name = "txtOcjena";
            this.txtOcjena.Size = new System.Drawing.Size(30, 20);
            this.txtOcjena.TabIndex = 4;
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(78, 74);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(200, 69);
            this.txtNapomena.TabIndex = 5;
            // 
            // FrmOcjena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 166);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.txtOcjena);
            this.Controls.Add(this.lblNapomena);
            this.Controls.Add(this.lblOcjena);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FrmOcjena";
            this.Text = "Ocjena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblOcjena;
        private System.Windows.Forms.Label lblNapomena;
        private System.Windows.Forms.TextBox txtOcjena;
        private System.Windows.Forms.TextBox txtNapomena;
    }
}