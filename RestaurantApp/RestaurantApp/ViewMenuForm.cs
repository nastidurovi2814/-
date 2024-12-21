using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class ViewMenuForm : Form
    {
        
        string connectionString = @"Server=NASTYA\MSSQLSERVER01;Database=РесторанБаза;Trusted_Connection=True;";

        public ViewMenuForm()
        {
            InitializeComponent();
        }

        
        private void LoadMenuItems()
        {
            string query = "SELECT * FROM Меню";
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

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        
        }

        
        private void ViewMenuForm_Load(object sender, EventArgs e)
        {
            LoadMenuItems();
        }
    }
}
