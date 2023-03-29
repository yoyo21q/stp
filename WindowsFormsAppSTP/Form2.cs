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
            textBox1_Leave(null, null); textBox2_Leave(null, null);// Визуальная часть текст боксов
        }

        private void button1_Click(object sender, EventArgs e)// Нажатие на кнопку входа
        {
            if(textBox1.Text!=null)// Проверка присутствия имени пользователя
            {
                if (!textBox1.Text.Contains(" "))// Проверка содержания имени пользователя на пробел
                {
                    if (textBox2.Text != null)// Проверка присутствия пароля
                    {
                        if (!textBox2.Text.Contains(" "))// Проверка пароля на содержание пробелов
                        {
                            string currentPath = Directory.GetCurrentDirectory();// Текущая директория программы
                            if (Directory.Exists(Path.Combine(currentPath, "Users")))// Проверка существования директории user
                            {
                                if (Directory.Exists(Path.Combine(currentPath + "/Users/" + $"{textBox1.Text}")))// Проверка существования директории имя пользователя
                                {
                                    using (StreamReader sr = File.OpenText(currentPath + "/Users" + $"/{textBox1.Text}/" + $"/{textBox1.Text}.txt"))// Открытие файла имени пользователя
                                    {
                                        string password;// пароль
                                        password = sr.ReadLine();// считываем пароль
                                        if (textBox2.Text == password) // Если поле текст бокс == пароль
                                        {

                                            MessageBox.Show("Вход выполнен!");
                                            Form3 fr3 = new Form3(textBox1.Text);
                                            fr3.Show();
                                            Hide();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль содержит пробелы!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль пустой!");
                    }
                }
                else
                {
                    MessageBox.Show("Имя пользователя содержит пробелы!");
                }
            }
            else 
            {
                MessageBox.Show("Имя пользователя пустое!");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
