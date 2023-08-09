using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementApp.All_User_Controls
{
    public partial class ucRegistration : UserControl
    {
        function fn = new function();
        String query;
        int roomId;

        public ucRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);

            while (sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void cmbBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxRoomNumber.Items.Clear();
            txtPrice.Clear();
            query = "SELECT roomNo FROM rooms WHERE bed ='" + cmbBoxBed.Text + "' and roomType = '" + cmbBoxRoomType.Text + "' and booked = 'NO'";
            setComboBox(query, cmbBoxRoomNumber);

        }

        private void cmbBoxBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxRoomType.SelectedIndex = -1;
            cmbBoxRoomNumber.Items.Clear();
            txtPrice.Clear();
        }

        

        private void cmbBoxRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT price, roomid FROM rooms WHERE roomNo = '" + cmbBoxRoomNumber.Text + "'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            roomId = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void buttonAllocateRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text != "" && txtDob.Text != "" && txtNationality.Text != "" 
                && txtIdPassport.Text != "" && txtAddress.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String dob = txtDob.Text;
                String nationality = txtNationality.Text;
                String gender = cmbBoxGender.Text;
                String idPassport = txtIdPassport.Text;
                String address = txtAddress.Text;
                String checkIn = txtCheckIn.Text;

                query = "INSERT INTO customer (cname, mobile, nationality, gender, dob, id_passport, address, checkin, roomid) values ('" + name + "','" + mobile + "','" + nationality + "','" + gender + "','" + dob + "','" + idPassport + "','" + address + "','" + checkIn + "'," + roomId + ") UPDATE rooms SET booked = 'YES' WHERE roomNo = '" + cmbBoxRoomNumber.Text + "'";
                
                fn.setData(query," RoomNo " + cmbBoxRoomNumber.Text + " Allocation Successful.");
                clearAll();

            }
            else
            {
                MessageBox.Show("All fields are mandatory.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtAddress.Clear();
            cmbBoxRoomNumber.Items.Clear();
            txtContact.Clear(); 
            txtAddress.Clear();
            txtIdPassport.Clear();
            txtName.Clear();
            txtNationality.Clear();
            cmbBoxGender.SelectedIndex = -1;
            cmbBoxRoomType.SelectedIndex = -1;
            txtCheckIn.ResetText();
            cmbBoxBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void ucRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
