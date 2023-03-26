using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsAppSTP
{
    public partial class Form1 : Form
    {
        public string user_name;
        public string user_password;
        public string user_mail;
        public Form1()
        {
            InitializeComponent();
         textBox1_Leave(null,null); textBox2_Leave(null, null); textBox3_Leave(null, null); textBox4_Leave(null, null);
        
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
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = Color.Gray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Повторите пароль")
            {
                textBox3.Clear();
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Повторите пароль";
                textBox3.ForeColor = Color.Gray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Почта")
            {
                textBox4.Clear();
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Почта";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currentPath, "Users")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath, "Users"));
            }
            if (!Directory.Exists(Path.Combine(currentPath+ "/Users", $"{textBox1.Text}")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath+"/Users", $"{textBox1.Text}"));
            }
            using (StreamWriter fayl = new StreamWriter(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}.txt"))
            {
                await fayl.WriteLineAsync($"{textBox2.Text};");
                await fayl.WriteLineAsync($"{textBox4.Text};");
            }
            user_name = textBox1.Text;
            user_password = textBox2.Text;
            user_mail = textBox4.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
