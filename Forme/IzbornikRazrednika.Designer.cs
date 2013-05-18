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
            this.SuspendLayout();
            // 
            // btnEvidencijaSata
            // 
            this.btnEvidencijaSata.Location = new System.Drawing.Point(42, 84);
            this.btnEvidencijaSata.Name = "btnEvidencijaSata";
            this.btnEvidencijaSata.Size = new System.Drawing.Size(116, 51);
            this.btnEvidencijaSata.TabIndex = 0;
            this.btnEvidencijaSata.Text = "Evidencija sata";
            this.btnEvidencijaSata.UseVisualStyleBackColor = true;
            // 
            // btnPopisUcenika
            // 
            this.btnPopisUcenika.Location = new System.Drawing.Point(42, 12);
            this.btnPopisUcenika.Name = "btnPopisUcenika";
            this.btnPopisUcenika.Size = new System.Drawing.Size(116, 51);
            this.btnPopisUcenika.TabIndex = 1;
            this.btnPopisUcenika.Text = "Popis učenika";
            this.btnPopisUcenika.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(204, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Odabir uloge";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // IzbornikRazrednika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 152);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPopisUcenika);
            this.Controls.Add(this.btnEvidencijaSata);
            this.Name = "IzbornikRazrednika";
            this.Text = "Izbornik razrednika";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEvidencijaSata;
        private System.Windows.Forms.Button btnPopisUcenika;
        private System.Windows.Forms.Button button3;
    }
}