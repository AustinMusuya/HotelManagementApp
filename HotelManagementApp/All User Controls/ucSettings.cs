using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementApp.All_User_Controls
{
    public partial class ucSettings : UserControl
    {
        String query;
        function fn = new function();
        public ucSettings()
        {
            InitializeComponent();
        }

        private void ucSettings_Load(object sender, EventArgs e)
        {
            getMaxId();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                getEmployeeData(DataGridViewEmployeeDetails);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                getEmployeeData(DataGridViewDeleteEmployee);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != "")
            {
                if (MessageBox.Show("Are You sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){ }
                {
                    query = "DELETE FROM employees WHERE eid = " + txtEmployeeID.Text + "";
                    fn.setData(query, "Record Deleted");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobileNo.Text != "" && txtUserName.Text != "" && txtPassword.Text != "" && cmbBoxGender.Text != "")
            {
                String name = txtName.Text;
                Int64 mobileNo = Int64.Parse(txtMobileNo.Text);
                String userName = txtUserName.Text;
                String gender = cmbBoxGender.Text;
                String password = txtPassword.Text;

                query = "INSERT INTO employees (ename, mobile, gender, username, password) VALUES ('" + name + "', " + mobileNo + ",'" + gender + "', '" + userName + "', '" + password + "')";
                fn.setData(query, "Employee Registered");
                clearAll();
                getMaxId();

            }
            else
            {
                MessageBox.Show("Please Fill all Fields To Proceed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ucSettings_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        //===== METHOD TO GET MAX EMPLOYEE ID IN THE SETTING UC FORM ======
        public void getMaxId()
        {
            query = "SELECT max(eid) FROM employees";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }
        }

        public void getEmployeeData(DataGridView dgv)
        {
            query = "SELECT * FROM employees";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            txtPassword.Clear();
            cmbBoxGender.SelectedIndex = -1;
            txtUserName.Clear();
        }

    }
}
