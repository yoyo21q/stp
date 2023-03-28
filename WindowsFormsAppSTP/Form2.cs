using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSTP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1_Leave(null, null); textBox2_Leave(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();
            if (Directory.Exists(Path.Combine(currentPath, "Users")))
            {
                if (Directory.Exists(Path.Combine(currentPath + "/Users/"+ $"{textBox1.Text}")))
                {
                    using (StreamReader sr = File.OpenText(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}.txt"))
                    {
                        string password;
                        password = sr.ReadLine();
                        MessageBox.Show($"{password}");
                    }
                }
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Имя пользователя")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Имя пользователя";
                textBox1.ForeColor = Color.Gray;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }
    }
}
