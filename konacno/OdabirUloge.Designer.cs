namespace Forme
{
    partial class OdabirUloge
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
            this.btnRazrednik = new System.Windows.Forms.Button();
            this.btnProfesor = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRazrednik
            // 
            this.btnRazrednik.Location = new System.Drawing.Point(99, 63);
            this.btnRazrednik.Name = "btnRazrednik";
            this.btnRazrednik.Size = new System.Drawing.Size(112, 48);
            this.btnRazrednik.TabIndex = 0;
            this.btnRazrednik.Text = "Razrednik";
            this.btnRazrednik.UseVisualStyleBackColor = true;
            this.btnRazrednik.Click += new System.EventHandler(this.btnRazrednik_Click);
            // 
            // btnProfesor
            // 
            this.btnProfesor.Location = new System.Drawing.Point(217, 63);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Size = new System.Drawing.Size(110, 48);
            this.btnProfesor.TabIndex = 1;
            this.btnProfesor.Text = "Profesor";
            this.btnProfesor.UseVisualStyleBackColor = true;
            this.btnProfesor.Click += new System.EventHandler(this.btnProfesor_Click);
            // 
            // btnOdjava
            // 
            this.btnOdjava.Location = new System.Drawing.Point(298, 12);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(75, 23);
            this.btnOdjava.TabIndex = 2;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // OdabirUloge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 181);
            this.Controls.Add(this.btnOdjava);
            this.Controls.Add(this.btnProfesor);
            this.Controls.Add(this.btnRazrednik);
            this.Name = "OdabirUloge";
            this.Text = "Uloga";
            this.Load += new System.EventHandler(this.OdabirUloge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRazrednik;
        private System.Windows.Forms.Button btnProfesor;
        private System.Windows.Forms.Button btnOdjava;
    }
}