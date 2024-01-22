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
    public partial class Form2 : Form
    {
        private CoffeeShopEntities2 db = new CoffeeShopEntities2();
        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form3 = new Form3())
            {
                form3.ShowDialog();
            }

            // Optionally, hide Form2
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of Form4
            Form4 form4 = new Form4();

            // Show Form4
            form4.Show();

            // Hide or close the current form if needed
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            // Show Form5
            form5.Show();

            // Hide or close the current form if needed
            this.Hide();

        }
    }
}
