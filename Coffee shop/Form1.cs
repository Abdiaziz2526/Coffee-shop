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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check if both username and password are not empty
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Validate other criteria if needed
                if (IsValidUsername(username) && IsValidPassword(password))
                {
                    // Open another form (replace Form2 with the actual name of your second form)
                    Form2 form2 = new Form2();
                    form2.Show();

                    // Hide the current login form if needed
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }
        private bool IsValidUsername(string username)
        {
            // Add your username validation logic here
            return username.Length >= 3; // For example, require at least 3 characters
        }

        private bool IsValidPassword(string password)
        {
            // Add your password validation logic here
            return password.Length >= 6; // For example, require at least 6 characters
        }






    }
}
