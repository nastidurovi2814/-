namespace RestaurantApp
{
    partial class MainPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.btnManageOrders = new System.Windows.Forms.Button();
            this.btnManageMenu = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewMenu = new System.Windows.Forms.Button();
            this.btnOrderFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManageOrders
            // 
            this.btnManageOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnManageOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageOrders.Location = new System.Drawing.Point(138, 55);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(85, 45);
            this.btnManageOrders.TabIndex = 0;
            this.btnManageOrders.Text = "Заказы";
            this.btnManageOrders.UseVisualStyleBackColor = false;
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);
            // 
            // btnManageMenu
            // 
            this.btnManageMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnManageMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMenu.Location = new System.Drawing.Point(134, 116);
            this.btnManageMenu.Name = "btnManageMenu";
            this.btnManageMenu.Size = new System.Drawing.Size(85, 45);
            this.btnManageMenu.TabIndex = 1;
            this.btnManageMenu.Text = "Управление меню";
            this.btnManageMenu.UseVisualStyleBackColor = false;
            this.btnManageMenu.Click += new System.EventHandler(this.btnManageMenu_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(138, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(305, 116);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Назад";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-146, -154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(657, 366);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(262, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Меню";
            // 
            // btnViewMenu
            // 
            this.btnViewMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnViewMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMenu.Location = new System.Drawing.Point(305, 55);
            this.btnViewMenu.Name = "btnViewMenu";
            this.btnViewMenu.Size = new System.Drawing.Size(85, 45);
            this.btnViewMenu.TabIndex = 19;
            this.btnViewMenu.Text = "Меню";
            this.btnViewMenu.UseVisualStyleBackColor = false;
            this.btnViewMenu.Click += new System.EventHandler(this.btnViewMenu_Click);
            // 
            // btnOrderFilter
            // 
            this.btnOrderFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnOrderFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderFilter.Location = new System.Drawing.Point(404, 55);
            this.btnOrderFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOrderFilter.Name = "btnOrderFilter";
            this.btnOrderFilter.Size = new System.Drawing.Size(85, 45);
            this.btnOrderFilter.TabIndex = 20;
            this.btnOrderFilter.Text = "Статус";
            this.btnOrderFilter.UseVisualStyleBackColor = false;
            this.btnOrderFilter.Click += new System.EventHandler(this.btnOrderFilter_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 210);
            this.Controls.Add(this.btnOrderFilter);
            this.Controls.Add(this.btnViewMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnManageMenu);
            this.Controls.Add(this.btnManageOrders);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPanel";
            this.Text = "Администрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnManageMenu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewMenu;
        private System.Windows.Forms.Button btnOrderFilter;
    }
}