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

    
    public partial class FrmChicle : Form
    {
        private Chicle chicle;

        public Chicle Chicle
        {
            get { return this.chicle; }
        }

        public FrmChicle()
        {
            InitializeComponent();
        }

        private void FrmChicle_Load(object sender, EventArgs e)
        {

        }
    }
}
