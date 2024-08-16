using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketBooking
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                AuthBUS.Instance.Login(username, password);
                Form1 form = new Form1(username);
                form.send = new Form1.sendCloseForm(getCloseHomeForm);
                form.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công, kiểm tra thông tin đăng nhập.\n(" + ex.Message + ")", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void getCloseHomeForm(bool close)
        {
            if (close == true)
            {
                this.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void Form_Login_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Đặt lại trạng thái của form về bình thường
            }
        }
    }
}
