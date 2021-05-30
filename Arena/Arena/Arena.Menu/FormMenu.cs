using System;
using System.Windows.Forms;

namespace Arena.Menu
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
