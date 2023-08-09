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
    public partial class FormReception : Form
    {
        public FormReception()
        {
            InitializeComponent();
            //the lines of code below result to the transparency effects of the panels, quite stylish eeh? ;)
            panel6.BackColor = Color.FromArgb(125, Color.Black);
            panel3.BackColor = Color.FromArgb(145, Color.Green);
            panel1.BackColor = Color.FromArgb(145, Color.Green);
            panel5.BackColor = Color.FromArgb(145, Color.Green);
        }

        private void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Log Out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }           
        }

        private void buttonReception_Click(object sender, EventArgs e)
        {
            MovePanel(buttonReception);
            ucReception1.Visible = true;
            ucReception1.BringToFront();
        }

        private void buttonCustomerRegistration_Click(object sender, EventArgs e)
        {
            MovePanel(buttonCustomerRegistration);
            ucRegistration1.Visible = true;
            ucRegistration1.BringToFront();
        }

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            MovePanel(buttonRoom);
            ucRooms1.Visible = true;
            ucRooms1.BringToFront();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            MovePanel(buttonSettings);
            ucSettings1.Visible = true;
            ucSettings1.BringToFront();
        }

        private void buttonCustomerCheckout_Click(object sender, EventArgs e)
        {
            MovePanel(buttonCustomerCheckout);
            ucCheckOut1.Visible = true;
            ucCheckOut1.BringToFront();
        }

        private void buttonHotelLog_Click(object sender, EventArgs e)
        {
            MovePanel(buttonHotelLog);
            ucHotelLog1.Visible = true;
            ucHotelLog1.BringToFront();
        }
    }
}
