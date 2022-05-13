using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDataModelDemo
{
    public partial class EmployeeForm : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            {

                EmployeeTable employeeTable = new EmployeeTable();
                employeeTable.Name = txtName.Text;
                employeeTable.Designation = txtDesignation.Text;
                employeeTable.Salary = Convert.ToInt32(txtSalary.Text);

                dbcontext.EmployeeTables.Add(employeeTable);

                dbcontext.SaveChanges();
                MessageBox.Show("done");
            }
           /* catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeTable employeeTable = dbcontext.EmployeeTables.Find(Convert.ToInt32(txtID.Text));
                if(employeeTable != null)
                {
                    txtName.Text = employeeTable.Name;
                    txtDesignation.Text = employeeTable.Designation;
                    txtSalary.Text = employeeTable.Salary.ToString();
                }
                else
                {
                    MessageBox.Show("Record Not Found");
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
                EmployeeTable employeeTable = dbcontext.EmployeeTables.Find(Convert.ToInt32(txtID.Text));
                if (employeeTable != null)
                {
                    employeeTable.Name = txtName.Text;
                    employeeTable.Salary = Convert.ToInt32(txtSalary.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("updated");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeTable employeeTable = dbcontext.EmployeeTables.Find(Convert.ToInt32(txtID.Text));
                if (employeeTable != null)
                {
                    dbcontext.EmployeeTables.Remove(employeeTable);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");
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
    }
}
