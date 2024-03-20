using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uchebnaya
{
    public partial class FormRegistraciya : Form
    {
        public FormRegistraciya()
        {
            InitializeComponent();
            uchebnayaEntities context = new uchebnayaEntities();
            var rollist = context.Users.ToList();

            comboBoxRol.DataSource = rollist;
            comboBoxRol.DisplayMember = "Name";
            comboBoxRol.ValueMember = "role";
        }

        private Users GetUsers()
        {
            Users users = new Users();

            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите Логин!");
                return null;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите Пароль!");
                return null;
            }

            if (string.IsNullOrEmpty(comboBoxRol.Text))
            {
                MessageBox.Show("Выберите Роль!");
                return null;
            }

            users.login = textBoxLogin.Text;
            users.password = textBoxPassword.Text;
            users.role = comboBoxRol.Text;

            return users;
        }

        private void buttonRegistraciya_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привет, мир!");
            var user = GetUsers();

            if (user != null)
            {
                uchebnayaEntities context = new uchebnayaEntities();

                var userss = context.Users.FirstOrDefault(x => x.login == user.login && x.password == user.password);

                if (userss == null)
                {
                    userss = user;
                    context.Users.Add(userss);
                    context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Такой Пользователь уже существует!");
                }
            }
        }

        private void buttonNazad_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormRegistraciya_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
