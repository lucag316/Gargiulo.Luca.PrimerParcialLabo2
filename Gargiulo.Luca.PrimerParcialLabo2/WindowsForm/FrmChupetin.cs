using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class FrmChupetin : Form
    {
        private Chupetin chupetin;

        public Chupetin Chupetin
        {
            get { return this.chupetin; }
        }

        public FrmChupetin()
        {
            InitializeComponent();
        }

        private void FrmChupetin_Load(object sender, EventArgs e)
        {

        }
    }
}
