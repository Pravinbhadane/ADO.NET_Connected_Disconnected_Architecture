using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Product_Category.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Product_Category.Models
{
    public partial class Employee_Form : Form
    {
        EmployeeCrud empCrud;
        public Employee_Form()
        {
            InitializeComponent();
            empCrud = new EmployeeCrud();
        }

        List<Department> list;
        private void Employee_Form_Load(object sender, EventArgs e)
        {
            list = empCrud.GetDepartments();
            cmbDept .DataSource = list;
            cmbDept.DisplayMember = "D_name";
            cmbDept.ValueMember = "D_id";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.E_name = txtName.Text;
                emp.E_salary = Convert.ToInt32(txtSalary.Text);
                emp.D_id= Convert.ToInt32(cmbDept.SelectedValue);
                int res = empCrud.AddEmployee(emp);
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
                Employee empl = empCrud.GetEmployeeById(Convert.ToInt32(txtId.Text));
                if (empl.E_id > 0)
                {
                    foreach (Department item in list)
                    {
                        if (item.D_id == empl.D_id)
                        {
                            cmbDept.Text = item.D_name;
                            break;
                        }
                    }
                    txtName.Text = empl.E_name;
                    txtSalary.Text = empl.E_salary.ToString();

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
                Employee emp = new Employee();
                emp.E_id = Convert.ToInt32(txtId.Text);
                emp.E_name = txtName.Text;
                emp.E_salary = Convert.ToInt32(txtSalary.Text);
                emp.D_id = Convert.ToInt32(cmbDept.SelectedValue);
                int res = empCrud.UpdateEmployee(emp);
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

                int res = empCrud.DeleteEmployee(Convert.ToInt32(txtId.Text));
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
                DataTable table = empCrud.GetAllEmployees();
                dataGridView1.DataSource = table;
            }
        }
    }
}
