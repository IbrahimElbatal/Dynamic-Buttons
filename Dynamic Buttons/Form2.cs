using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dynamic_Buttons
{
    public partial class Form2 : Form
    {
        private Button _btn;
        public Form2(Button btn)
        {
            this._btn = btn;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtText.Text = _btn.Text;
            txtX.Text = _btn.Location.X.ToString();
            txtY.Text = _btn.Location.Y.ToString();
            cmxBackColor.Text = _btn.BackColor.Name == "Control" ? "" : _btn.BackColor.Name;
            cmxForeColor.Text = _btn.ForeColor.Name == "ControlText" ? "" : _btn.ForeColor.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _btn.Text = txtText.Text;
            _btn.Location = new Point(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text));
            _btn.BackColor = Utility.GetColor(cmxBackColor.Text.ToLower());
            _btn.ForeColor = Utility.GetColor(cmxForeColor.Text.ToLower());

            new Form1(_btn).Refresh();
            this.Close();
        }

    }
}
