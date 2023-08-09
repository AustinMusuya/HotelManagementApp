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
    public partial class ucCheckOut : UserControl
    {
        String query;
        function fn = new function();
        public ucCheckOut()
        {
            InitializeComponent();
        }

        private void ucCheckOut_Load(object sender, EventArgs e)
        {
            query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.id_passport, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price" +
                " FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE check_out = 'NO'";

            //query = "Select * FROM customer WHERE check_out = 'NO'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
       
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.id_passport, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price" +
                " FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE cname LIKE '" + txtName.Text + "%' AND check_out = 'NO'"; //we have used % to be able to enable the search feature based on user input on the text box
            
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        
        }

        int id;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCustomerName.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNumber.Text = DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                if (MessageBox.Show("Are You Sure You Want to Check Out Customer?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cDate = txtCheckOutDate.Text;
                    
                    query = "UPDATE customer SET check_out = 'YES', checkout = '" + cDate + "' WHERE cid = " + id + " UPDATE rooms SET booked = 'NO' WHERE roomNo = '" + txtRoomNumber.Text + "' ";

                    fn.setData(query, "Check out Successful");
                    ucCheckOut_Load(this, null);
                    clearAll();                
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtRoomNumber.Clear();
            txtCustomerName.Clear();
            txtCheckOutDate.ResetText();
        }

        private void ucCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
