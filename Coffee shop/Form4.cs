using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_shop
{
    public partial class Form4 : Form
    {
        private CoffeeShopEntities2 db = new CoffeeShopEntities2();


        public Form4()
        {
            InitializeComponent();
           
        }
        //CoffeeShopEntities Cate = new CoffeeShopEntities();
        //CoffeeShopEntities2 cate = new CoffeeShopEntities2();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CoffeeShopEntities2())
                {
                    // Assuming Category class has properties CategoryID and CategoryName
                    var newCategory = new Category
                    {
                        CategoryID = int.Parse(txtCategoryID.Text),
                        CategoryName = txtCategoryName.Text,
                    };

                    db.Categories.Add(newCategory);

                    int rowsAffected = db.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Saved");
                        Display(); // Display the updated data in the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to save category.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Display();

        }
        private void Display(string searchValue = "")
        {
            if (searchValue == "")
            {
                var selectedRows = (from list in db.Categories
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;
            }
            else
            {
                var selectedRows = (from list in db.Categories
                                    where list.CategoryName.Contains(searchValue)
                                    select list).ToList();
                dataGridView1.DataSource = selectedRows;
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
    }
}
