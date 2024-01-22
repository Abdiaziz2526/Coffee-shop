using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Coffee_shop
{
    public partial class Form3 : Form
    {
        private CoffeeShopEntities2 db = new CoffeeShopEntities2();
        public Form3()
        {
            InitializeComponent();

        }
        
        //contactAppEntities db = new contactAppEntities();
        // CoffeeShopEntities db = new CoffeeShopEntities();
        

        private void Form3_Load(object sender, EventArgs e)
        {
            Display();

        }
        private void Display(string searchValue = "")
        {
            if (searchValue == "")
            {
                var selectedRows = (from list in db.users
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;
            }
            else
            {
                var selectedRows = (from list in db.users
                                    where list.UserName.Contains(searchValue)
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;

            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];



        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CoffeeShopEntities2())
                {
                    var newUser = new user
                    {
                        UserId = int.Parse(txtUserID.Text),
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        UserType = txtUserType.Text,
                    };

                    db.users.Add(newUser);

                    int rowsAffected = db.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Saved");
                        Display(); // Display the updated data in the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to save user.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                int userID = int.Parse(txtUserID.Text);
                var userToUpdate = db.users.FirstOrDefault(u => u.UserId == userID);

                if (userToUpdate != null)
                {
                    userToUpdate.UserName = txtUserName.Text;
                    userToUpdate.Password = txtPassword.Text;
                    userToUpdate.UserType = txtUserType.Text;

                    int rowsAffected = db.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated");
                        Display(); // Display the updated data in the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user.");
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error updating user: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Form2 form2 = new Form2();

            // Show Form2
            form2.Show();

            // Hide or close the current form if needed
            this.Hide(); 

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}


