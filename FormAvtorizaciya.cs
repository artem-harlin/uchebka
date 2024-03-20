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
    public partial class FormAvtorizaciya : Form
    {
        public FormAvtorizaciya()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegistraciyua_Click(object sender, EventArgs e)
        {
            FormRegistraciya formRegistraciya = new FormRegistraciya();
            formRegistraciya.ShowDialog();
            
        }

        private void buttonVoiti_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string parol = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(parol))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            try
            {
                using (uchebnayaEntities cont = new uchebnayaEntities())
                {
                    var res = cont.Users.Where(x => x.login == login && x.password == parol).FirstOrDefault();

                    if (res != null)
                    {
                        MessageBox.Show("Авторизация прошла успешно!");

                        var userROLE = res.role;

                        if (userROLE == "Сотрудник")
                        {
                            FormOknoSotrudnika formOknoSotrudnika = new FormOknoSotrudnika();
                            this.Hide();
                            formOknoSotrudnika.Show();
                        }
                        else if (userROLE == "Предприятие")
                        {
                            FormPredpriyatie formPredpriyatie = new FormPredpriyatie();
                            this.Hide();
                            formPredpriyatie.Show();
                        }
                        else if (userROLE == "Безработный")
                        {
                            FormResume formResume = new FormResume();
                            this.Hide();
                            formResume.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неизвестная роль пользователя!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
