using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrijava prijava = new FrmPrijava();
            prijava.ShowDialog();
        }
    }
}
