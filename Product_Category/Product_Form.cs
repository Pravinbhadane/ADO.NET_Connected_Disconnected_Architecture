using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Product_Category.Models;

namespace Product_Category
{
    public partial class Product_Form : Form
    {
        ProductCrud crud;
        public Product_Form()
        {
            
            InitializeComponent();
           crud = new ProductCrud();
        }

        List<Category> list;
        private void Product_Form_Load(object sender, EventArgs e)
        {
           list = crud.GetCategories();
            cmbCatname.DataSource = list;
            cmbCatname.DisplayMember = "Cname";
            cmbCatname.ValueMember = "Cid";

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Name = textPname.Text;
                p.Price = Convert.ToInt32(textPprice.Text);
                p.Cid = Convert.ToInt32(cmbCatname.SelectedValue);
                int res = crud.AddProduct(p);
                if (res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = crud.GetProductById(Convert.ToInt32(textId.Text));
                if (prod.Id > 0)
                {
                    foreach (Category item in list)
                    {
                        if (item.Cid == prod.Cid)
                        {
                            cmbCatname.Text = item.Cname;
                            break;
                        }
                    }
                    textPname.Text = prod.Name;
                    textPprice.Text = prod.Price.ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Id = Convert.ToInt32(textId.Text);
                p.Name = textPname.Text;
                p.Price = Convert.ToInt32(textPprice.Text);
                p.Cid = Convert.ToInt32(cmbCatname.SelectedValue);
                int res = crud.UpdateProduct(p);
                if (res > 0)
                {
                    MessageBox.Show("Record updated..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int res = crud.DeleteProduct(Convert.ToInt32(textId.Text));
                if (res > 0)
                {
                    MessageBox.Show("Record deleted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            {
                DataTable table = crud.GetAllProducts();
                dataGridView1.DataSource = table;
            }

        }
    }
}
