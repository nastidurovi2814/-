using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class OrderFilterForm2 : Form
    {
        string connectionString = @"Server=NASTYA\MSSQLSERVER01;Database=РесторанБаза;Trusted_Connection=True;";

        public OrderFilterForm2()
        {
            InitializeComponent();
        }

        private void LoadOrders()
        {
            string query = "SELECT * FROM Заказы";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvOrders.DataSource = dt; // Привязка данных к DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Нет заказов для отображения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterOrders_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли заказ
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ в таблице.", "Ошибка");
                return;
            }

            // Проверяем, выбран ли статус
            if (cmbOrderStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус из списка.", "Ошибка");
                return;
            }

            // Получаем ID заказа и новый статус
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID_Заказа"].Value); // Замените "ID_Заказа" на точное имя столбца в таблице
            string newStatus = cmbOrderStatus.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Обновляем статус в базе данных
                    string query = "UPDATE Заказы SET Статус = @Status WHERE ID_Заказа = @OrderId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Статус обновлен успешно.", "Успех");
                        LoadOrders(); // Перезагружаем данные таблицы
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновлении статуса. Попробуйте снова.", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void OrderFilterForm2_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOrderStatus.Items.Clear();
                cmbOrderStatus.Items.AddRange(new[] { "Принят", "В процессе", "Завершен" });

                if (cmbOrderStatus.Items.Count > 0)
                {
                    cmbOrderStatus.SelectedIndex = 0;
                }

                // Загружаем данные из базы сразу при загрузке формы
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статусов или заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
