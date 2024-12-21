using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Enabled = false; // Деактивируем кнопку входа по умолчанию
            txtLogin.TextChanged += ValidateInput;
            txtPassword.TextChanged += ValidateInput;
        }

        // Метод для проверки заполненности полей
        private void ValidateInput(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        // Метод для хеширования пароля с использованием SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Обработчик нажатия кнопки "Войти"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Хэшируем введённый пароль
            string hashedPassword = HashPassword(password);

            // Запрос для получения информации о пользователе
            string query = "SELECT ID_Роли, Пароль FROM Пользователи WHERE Логин = @login";

            string connectionString = @"Server=NASTYA\MSSQLSERVER01;Database=РесторанБаза;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login); // Добавляем параметр для логина

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Получаем захешированный пароль из базы данных
                        string storedHash = reader["Пароль"].ToString();

                        // Сравниваем хеши паролей
                        if (storedHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase))
                        {
                            int roleId = (int)reader["ID_Роли"];
                            MainPanel mainPanel = new MainPanel(roleId);
                            this.Hide();
                            mainPanel.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка подключения к базе данных.");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
