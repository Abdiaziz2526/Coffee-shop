using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_shop
{
    public partial class Form5 : Form
    {
       

        public Form5()
        {
            InitializeComponent();
        }
        private CoffeeShopEntities2 db = new CoffeeShopEntities2();
        //CoffeeShopEntities2 item = new CoffeeShopEntities2();

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Form2 form2 = new Form2();

            // Show Form2
            form2.Show();

            // Hide or close the current form if needed
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CoffeeShopEntities2())
                {
                    var newContact = new user
                    {
                        UserId = int.Parse(txtItemID.Text),
                        ItemName = txtItemName.Text,
                        CategoryID = txtCategoryID.Text,
                        Price = txtPrice.Text,
                    };

                    db.users.Add(newContact);

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

        private void Form5_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void Display(string searchValue = "")
        {
            if (searchValue == "")
            {
                var selectedRows = (from list in db.ServiceItems
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;
            }
            else
            {
                // Here you are using 'ItemName', but 'ItemName' is not a property of 'user'
                // I assume you want to filter based on some property of 'user', let's use 'UserName' as an example
                var selectedRows = (from list in db.users
                                    where list.UserName.Contains(searchValue)
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;
            }
        }
       


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
