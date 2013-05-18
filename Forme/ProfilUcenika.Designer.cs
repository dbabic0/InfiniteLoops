namespace Forme
{
    partial class ProfilUcenika
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
            this.btnIzvjesce = new System.Windows.Forms.Button();
            this.btnPopis = new System.Windows.Forms.Button();
            this.btnIzbornik = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIzvjesce
            // 
            this.btnIzvjesce.Location = new System.Drawing.Point(246, 210);
            this.btnIzvjesce.Name = "btnIzvjesce";
            this.btnIzvjesce.Size = new System.Drawing.Size(112, 23);
            this.btnIzvjesce.TabIndex = 0;
            this.btnIzvjesce.Text = "Ispis izvješća";
            this.btnIzvjesce.UseVisualStyleBackColor = true;
            // 
            // btnPopis
            // 
            this.btnPopis.Location = new System.Drawing.Point(364, 210);
            this.btnPopis.Name = "btnPopis";
            this.btnPopis.Size = new System.Drawing.Size(104, 23);
            this.btnPopis.TabIndex = 1;
            this.btnPopis.Text = "Popis učenika";
            this.btnPopis.UseVisualStyleBackColor = true;
            // 
            // btnIzbornik
            // 
            this.btnIzbornik.Location = new System.Drawing.Point(474, 210);
            this.btnIzbornik.Name = "btnIzbornik";
            this.btnIzbornik.Size = new System.Drawing.Size(75, 23);
            this.btnIzbornik.TabIndex = 2;
            this.btnIzbornik.Text = "Izbornik";
            this.btnIzbornik.UseVisualStyleBackColor = true;
            // 
            // ProfilUcenika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 262);
            this.Controls.Add(this.btnIzbornik);
            this.Controls.Add(this.btnPopis);
            this.Controls.Add(this.btnIzvjesce);
            this.Name = "ProfilUcenika";
            this.Text = "ProfilUcenika";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIzvjesce;
        private System.Windows.Forms.Button btnPopis;
        private System.Windows.Forms.Button btnIzbornik;
    }
}