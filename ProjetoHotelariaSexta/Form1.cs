using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoHotelariaSexta {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) {
            lNomeQuarto1.Text = "";
            lDataEntradaQ1.Text = "";
            lDataSaidaQ1.Text = "";

            fQuarto1.BackColor = Color.SpringGreen;
        }

        private void btnReservas_Click(object sender, EventArgs e) {
            FrmReservas frmReservas = new FrmReservas();
            frmReservas.ShowDialog();
        }
    }
}
