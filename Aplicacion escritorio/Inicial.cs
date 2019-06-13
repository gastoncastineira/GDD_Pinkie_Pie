using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Hide();
            new Acceso.Login().Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Hide();
            new Acceso.EnrutarFuncion("CLIENTE", "cliente").Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
