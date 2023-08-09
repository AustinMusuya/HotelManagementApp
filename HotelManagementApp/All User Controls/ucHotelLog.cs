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
    public partial class ucHotelLog : UserControl
    {
        function fn = new function();
        String query;
        public ucHotelLog()
        {
            InitializeComponent();
        }

        private void cmbBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxSearchBy.SelectedIndex == 0)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.id_passport, customer.address, customer.checkin, customer.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid";
                getRecords(query);
            }
            else if (cmbBoxSearchBy.SelectedIndex == 1)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.id_passport, customer.address, customer.checkin, customer.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE checkout is null";
                getRecords(query);

            }
            else if ( cmbBoxSearchBy.SelectedIndex == 2)
            {
                query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.id_passport, customer.address, customer.checkin, customer.checkout, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomid WHERE checkout is not null";
                getRecords(query);
            }

        }

        private void getRecords(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
