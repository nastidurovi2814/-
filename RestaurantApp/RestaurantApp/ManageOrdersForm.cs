using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class ManageOrdersForm : Form
    {
        string connectionString = @"Server=NASTYA\MSSQLSERVER01;Database=РесторанБаза;Trusted_Connection=True;";

        public ManageOrdersForm()
        {
            InitializeComponent();
        }

        private void ManageOrdersForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Загрузка категорий и статусов заказа
                cmbOrderStatus.Items.Clear();
                cmbOrderStatus.Items.AddRange(new[] { "Принят", "В процессе", "Завершен" });

                // Устанавливаем DropDownList, чтобы пользователь не мог ввести собственное значение
                cmbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList;

                if (cmbOrderStatus.Items.Count > 0)
                {
                    cmbOrderStatus.SelectedIndex = 0;
                }

                // Загружаем меню в ComboBox
                LoadMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMenu()
        {
            try
            {
                string query = "SELECT ID_Позиции, Название FROM Меню";  // Получаем ID и Название блюд

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Заполнение ComboBox с блюдами
                    cmbMenu.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbMenu.Items.Add(new ComboBoxItem
                        {
                            Text = row["Название"].ToString(),
                            Value = row["ID_Позиции"]
                        });
                    }

                    // Устанавливаем DropDownList для меню
                    cmbMenu.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (cmbMenu.Items.Count > 0)
                    {
                        cmbMenu.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке меню: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Класс для хранения данных ComboBox (Название блюда и его ID)
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка введенного номера стола
                if (!int.TryParse(txtTableNumber.Text, out int tableNumber))
                {
                    MessageBox.Show("Пожалуйста, введите корректный номер стола.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tableNumber < 1 || tableNumber > 20)  // Ограничение на номер стола от 1 до 20
                {
                    MessageBox.Show("Номер стола должен быть в пределах от 1 до 20.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string orderStatus = cmbOrderStatus.SelectedItem?.ToString();
                int waiterId = 1; // ID официанта (можно изменить в зависимости от текущего вошедшего пользователя)

                if (string.IsNullOrEmpty(orderStatus))
                {
                    MessageBox.Show("Пожалуйста, выберите статус заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Генерация уникального номера заказа
                string orderNumber = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Вставляем заказ в таблицу "Заказы"
                string orderQuery = "INSERT INTO Заказы (Номер_Заказа, ДатаВремя, Номер_Стола, ID_Официанта, Статус) " +
                                    "VALUES (@orderNumber, @orderDate, @tableNumber, @waiterId, @orderStatus)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(orderQuery, conn);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@tableNumber", tableNumber);
                    cmd.Parameters.AddWithValue("@waiterId", waiterId);
                    cmd.Parameters.AddWithValue("@orderStatus", orderStatus);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Добавляем выбранное блюдо и количество в состав заказа
                ComboBoxItem selectedMenuItem = cmbMenu.SelectedItem as ComboBoxItem;
                if (selectedMenuItem != null)
                {
                    int menuItemId = (int)selectedMenuItem.Value;
                    int quantity = (int)numQuantity.Value;  // Используем NumericUpDown для количества

                    // Вставляем позиции в таблицу "Состав_Заказа"
                    string insertOrderItemQuery = "INSERT INTO Состав_Заказа (ID_Заказа, ID_Позиции, Количество) " +
                                                  "VALUES ((SELECT ID_Заказа FROM Заказы WHERE Номер_Заказа = @orderNumber), @menuItemId, @quantity)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(insertOrderItemQuery, conn);
                        cmd.Parameters.AddWithValue("@orderNumber", orderNumber);  // Используем номер заказа
                        cmd.Parameters.AddWithValue("@menuItemId", menuItemId);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Заказ добавлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtTableNumber.Clear();
            cmbOrderStatus.SelectedIndex = -1;
            cmbMenu.SelectedIndex = -1;
            numQuantity.Value = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //  MainPanel mainPanel = new MainPanel(1);
            this.Close();
            //mainPanel.Show();
        }
    }
}