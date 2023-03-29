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
    public partial class Form3 : Form
    {
        public string user_name;// Имя пользователя
        public Form3(string user_name_local)
        {
            InitializeComponent();
            user_name = user_name_local;
        }
        public void ComboBox_Load()
        {
            string currentPath = Directory.GetCurrentDirectory();// Берём координаты текущей директории
            int sch = Convert.ToInt32(File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}.txt").Skip(2).First());// Берём количество существующих файлов/нумерация
            for (int i = 0; i < Convert.ToInt32(sch); i++)
            {
                Name = File.ReadLines(currentPath + "/Users" + $"/{user_name}/" + $"/{user_name}_Data{i}.txt").Skip(0).First();
                comboBox1.Items.Add($"{Name}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 fr4 = new Form5();
            fr4.user_name = user_name;// Переносим данные о имени пользователя в другую форму/форму добавления заметок
            fr4.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
