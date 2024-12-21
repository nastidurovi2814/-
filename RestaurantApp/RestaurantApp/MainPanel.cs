using System;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class MainPanel : Form
    {
        private int userRole;

       
        private bool isManageOrdersFormOpen = false;
        private bool isManageMenuFormOpen = false;
        private bool isViewMenuFormOpen = false;
        private bool isOrderFilterFormOpen = false;

        public MainPanel(int role)
        {
            InitializeComponent();
            userRole = role;
            ConfigureRoleAccess();
        }

      
        private void ConfigureRoleAccess()
        {
            
            btnManageOrders.Visible = false;
            btnManageMenu.Visible = false;
            btnViewMenu.Visible = false;
            btnOrderFilter.Visible = false;

            // видимость кнопок в зависимости от роли пользователя
            switch (userRole)
            {
                case 1: // Администратор
                    btnManageOrders.Visible = true;
                    btnManageMenu.Visible = true;
                    btnViewMenu.Visible = true;
                    btnOrderFilter.Visible = true;
                    break;

                case 2: // Официант
                    btnManageOrders.Visible = true;
                    btnViewMenu.Visible = true;
                    btnOrderFilter.Visible = true;
                    break;

                case 3: // Повар
                    btnViewMenu.Visible = true;
                    btnOrderFilter.Visible = true;
                    break;

                default:
                    MessageBox.Show("Неизвестная роль пользователя. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

       
        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            
            if (!isManageOrdersFormOpen)
            {
                ManageOrdersForm manageOrdersForm = new ManageOrdersForm();
                manageOrdersForm.FormClosed += (s, args) => isManageOrdersFormOpen = false; // Установка флаг в false при закрытии
                this.Hide(); // Скрыть текущую форму
                manageOrdersForm.ShowDialog(); // Показываем форму как модальное окно
                isManageOrdersFormOpen = false;
                this.Show(); // Показать текущую форму после закрытия модальной
            }
            else
            {
                
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ManageOrdersForm)
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
        }

       
        private void btnManageMenu_Click(object sender, EventArgs e)
        {
            if (!isManageMenuFormOpen)
            {
                ManageMenuForm manageMenuForm = new ManageMenuForm();
                manageMenuForm.FormClosed += (s, args) => isManageMenuFormOpen = false; 
                this.Hide(); 
                manageMenuForm.ShowDialog(); 
                isManageMenuFormOpen = false;
                this.Show();
            }
            else
            {
                
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ManageMenuForm)
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
        }

        
        private void btnViewMenu_Click(object sender, EventArgs e)
        {
            if (!isViewMenuFormOpen)
            {
                ViewMenuForm viewMenuForm = new ViewMenuForm();
                viewMenuForm.FormClosed += (s, args) => isViewMenuFormOpen = false; 
                this.Hide(); 
                viewMenuForm.ShowDialog(); 
                isViewMenuFormOpen = false;
                this.Show(); 
            }
            else
            {
               
                foreach (Form form in Application.OpenForms)
                {
                    if (form is ViewMenuForm)
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
        }

        
        private void btnOrderFilter_Click(object sender, EventArgs e)
        {
            if (!isOrderFilterFormOpen)
            {
                OrderFilterForm2 orderFilterForm = new OrderFilterForm2();
                orderFilterForm.FormClosed += (s, args) => isOrderFilterFormOpen = false; 
                this.Hide(); 
                orderFilterForm.ShowDialog(); 
                isOrderFilterFormOpen = false;
                this.Show(); 
            }
            else
            {
                
                foreach (Form form in Application.OpenForms)
                {
                    if (form is OrderFilterForm2)
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
        }

        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void ShowAccessDeniedMessage()
        {
            MessageBox.Show("У вас нет доступа к этой функции.", "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
