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
    public partial class OdabirUloge : Form
    {
        

        public OdabirUloge()
        {
            InitializeComponent();
            this.CenterToParent();
        }

      

        private void OdabirUloge_Load(object sender, EventArgs e)
        {

        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRazrednik_Click(object sender, EventArgs e)
        {
            IzbornikRazrednika izbornikrazrednika = new IzbornikRazrednika();
            this.Hide();
            izbornikrazrednika.ShowDialog();
            this.Close();
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            IzbornikProfesora izbornikprofesora = new IzbornikProfesora();
            this.Hide();
            izbornikprofesora.ShowDialog();
            this.Close();

        }
    }
}
