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
    public partial class Form_ViewAllTicket : Form
    {
        private string current_ticket = "";
        public Form_ViewAllTicket()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            TicketsBUS.Instance.ViewAll(dataGridView1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string Search = textBox3.Text;
                TicketsBUS.Instance.ViewAll(dataGridView1, Search);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TicketsBUS.Instance.ViewAll(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                TicketsBUS.Instance.Delete(this.current_ticket);
                TicketsBUS.Instance.ViewAll(dataGridView1);
                button4.Visible = false;
                MessageBox.Show("Hủy vé thành công!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string error = "Xóa thất bại!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                this.current_ticket = row.Cells[0].Value.ToString();
                button4.Visible = true;
                TicketsBUS.Instance.LoadDetailTicket(this.current_ticket, label10, label9, label14, label8, label11, label12, label16);
            }
        }
    }
}
