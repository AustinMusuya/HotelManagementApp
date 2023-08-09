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
    public partial class ucRooms : UserControl
    {
        function fn = new function();
        String query;
        public ucRooms()
        {
            InitializeComponent();
        }

        private void ucRooms_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && cmbBoxRoomType.Text != "" && txtPrice.Text != "" && cmbBoxBed.Text != "")
            {
                String roomNo = txtRoomNo.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                String roomType = cmbBoxRoomType.Text;
                String bed = cmbBoxBed.Text;

                query = "INSERT INTO rooms (roomNo, roomType, bed, price) VALUES ('" + roomNo + "','" + roomType + "','" + bed + "','" + price + "')";

                fn.setData(query, "Room Added");

                ucRooms_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill all Fields.", " Warning! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtPrice.Clear();
            txtRoomNo.Clear();
            cmbBoxBed.SelectedIndex = -1;
            cmbBoxRoomType.SelectedIndex = -1;

        }

        private void ucRooms_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
