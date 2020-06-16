using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dynamic_Buttons
{
    public partial class Form1 : Form
    {
        private Button _btn;
        List<Button> controlls = new List<Button>();
        public Form1(Button btn)
        {
            this._btn = btn;
            LoadControls();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var point = 10;
            int length = Convert.ToInt32(txtNumber.Text);

            for (int i = 0; i < length; i++)
            {
                CreateButton(i, null, point);
                point += 30;
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_btn != null)
            {
                var buttons = this.Controls.Find(_btn.Name, false);
                var button = buttons.FirstOrDefault(b => b.Name == _btn.Name);
                if (button != null)
                {
                    button.Location = _btn.Location;
                    button.BackColor = _btn.BackColor;
                    button.ForeColor = _btn.ForeColor;
                }
            }

        }
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {

            string path = Path.GetFullPath("Data.txt");
            using (var writer = new StreamWriter(path))
            {
                writer.Flush();
                foreach (var button in controlls)
                {
                    writer.WriteLine($"{button.Text},{button.Location.X},{button.Location.Y},{button.BackColor.Name},{button.ForeColor.Name}");
                }
            }

            MessageBox.Show(@"Settings Saved Successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath("Data.txt");
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Empty);
            }
            this.Close();
        }
        private void LoadControls()
        {
            using (var reader = new StreamReader(Path.GetFullPath("Data.txt")))
            {
                var splitWithLine = reader.ReadToEnd()
                    .Split(new[] { Environment.NewLine }
                        , StringSplitOptions.None);

                foreach (var s in splitWithLine)
                {
                    var i = 0;
                    var splitWithComma = s.Split(new[] { ',' });
                    if (splitWithComma[0] == "")
                    {
                        return;
                    }
                    else
                    {
                        CreateButton(i, splitWithComma, 0);
                        i++;
                    }
                }
            }
        }

        private void CreateButton(int i, string[] splitWithComma, int point)
        {
            var button = new Button();
            button.Name = "button_" + (new Random().Next(10000));


            if (splitWithComma == null)
            {
                button.Location = new Point(10, point);
                button.Text = @"button_" + (i + 1);
                controlls.Add(button);
                point += 30;
            }
            else
            {
                button.Text = splitWithComma[0];
                var x = int.Parse(splitWithComma[1]);
                var y = int.Parse(splitWithComma[2]);
                button.Location = new Point(x, y);

                button.BackColor = Utility.GetColor(splitWithComma[3] == "Control" ? "silver" : splitWithComma[3].ToLower());
                button.ForeColor = Utility.GetColor(splitWithComma[4] == "ControlText" ? "black" : splitWithComma[4].ToLower());
            }

            button.Click += (sender, args) => { new Form2(button).ShowDialog(); };
            this.Controls.Add(button);
        }

    }
}
