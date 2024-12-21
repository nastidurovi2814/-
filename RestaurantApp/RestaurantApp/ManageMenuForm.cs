using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class ManageMenuForm : Form
    {
        string connectionString = @"Server=NASTYA\MSSQLSERVER01;Database=РесторанБаза;Trusted_Connection=True;";

        public ManageMenuForm()
        {
            InitializeComponent();
        }

        private void LoadMenuItems()
        {
            string query = "SELECT * FROM меню";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvMenuItems.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Меню пустое", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки меню: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Блюдо");
            cmbCategory.Items.Add("Напиток");
            cmbCategory.Items.Add("Десерт");
        }

        private void dgvMenuItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenuItems.Rows[e.RowIndex];

                txtMenuItemId.Text = row.Cells["ID_Позиции"].Value.ToString();
                txtName.Text = row.Cells["Название"].Value.ToString();
                txtDescription.Text = row.Cells["Описание"].Value.ToString();
                cmbCategory.SelectedItem = row.Cells["Категория"].Value.ToString();

                string priceText = row.Cells["Цена"].Value.ToString();

                if (decimal.TryParse(priceText.Replace(',', '.'), out decimal price))
                {
                    numericPrice.Value = price;
                }
                else
                {
                    numericPrice.Value = 0;
                }
            }
        }

        private void btnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMenuItemId.Text, out int menuItemId))
            {
                string query = "DELETE FROM меню WHERE ID_Позиции = @menuItemId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@menuItemId", menuItemId);

                    try
                    {
                        conn.Open();
                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Позиция меню успешно удалена!");
                            LoadMenuItems();
                        }
                        else
                        {
                            MessageBox.Show("Позиция меню с указанным ID не найдена.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления позиции меню: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите корректную строку для удаления.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ManageMenuForm_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
            LoadCategories();

            numericPrice.Minimum = 0;
            numericPrice.Maximum = 1000000;
        }

        private void AddNewMenuItem_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            string category = cmbCategory.SelectedItem?.ToString() ?? "";
            decimal price = numericPrice.Value;

            // Проверка на пустое название и цену
            if (string.IsNullOrEmpty(name) || price <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            string query = "INSERT INTO меню (Название, Описание, Категория, Цена) VALUES (@name, @description, @category, @price)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@price", price);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Позиция меню успешно добавлена!");
                    LoadMenuItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка добавления позиции меню: " + ex.Message);
                }
            }
        }
    }
}
