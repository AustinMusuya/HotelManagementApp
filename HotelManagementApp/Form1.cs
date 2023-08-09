using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementApp
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(175, Color.Black);
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "SELECT username, password FROM employees WHERE username =  '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
            DataSet ds =  fn.getData(query);

            
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblError.Visible = false;

                FormReception rs = new FormReception();
                this.Hide();
                rs.Show();
            }
            else
            {
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
