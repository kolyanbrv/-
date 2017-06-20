using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hall_Effect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void constTempButton_Click(object sender, EventArgs e)
        {
            HallForm hForm = new HallForm();
            hForm.Show();
        }

        private void varTempButton_Click(object sender, EventArgs e)
        {
            OhmForm oForm = new OhmForm();
            oForm.Show();
        }
    }
}
