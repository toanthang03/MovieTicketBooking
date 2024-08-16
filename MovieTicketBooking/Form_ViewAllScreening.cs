using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace MovieTicketBooking
{
    public partial class Form_ViewAllScreening : Form
    {
        private string screening_id = "";
        private int row_select = 0;
        public Form_ViewAllScreening()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ScreeningBUS.Instance.ViewAll(dataGridView1, DateTime.Now);
            init();
        }
        public void init()
        {
            label1.Text = "CURRENT: " + dateTimePicker1.Value.ToString();
            //label2.Text = "CURRENT_ID: " + dataGridView1.Rows[0].Cells[0].Value.ToString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "CURRENT: " + dateTimePicker1.Value.ToString();
            ScreeningBUS.Instance.ViewAll(dataGridView1, dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_AddScreening form = new Form_AddScreening();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ScreeningBUS.Instance.ViewAll(dataGridView1, dateTimePicker1.Value);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.row_select = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                    this.screening_id = row.Cells[0].Value.ToString();
                    label2.Text = "CURRENT_ID: " + screening_id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy dữ liệu
                string SCREENING_ID = this.screening_id;
                //Kiểm tra dữ liệu

                //Xóa dữ liệu trong bảng
                ScreeningBUS.Instance.Delete(SCREENING_ID);
                //MessageBox.Show(data, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Success", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lại dữ liệu
                ScreeningBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                string error = "Xóa thất bại!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.screening_id == "")
            {
                MessageBox.Show("Vui lòng chọn dòng muốn sửa!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = dataGridView1.Rows[this.row_select];

                string SCREENING_ID = row.Cells[0].Value.ToString();
                DateTime SCREENING_DATES = Convert.ToDateTime(row.Cells[1].Value);
                string movie_hours = row.Cells[2].Value.ToString();
                TimeSpan MOVIE_HOURS = TimeSpan.Parse(movie_hours);
                String SCREENING_ROOM = row.Cells[4].Value.ToString();
                int TICKET_PRICES = int.Parse(row.Cells[5].Value.ToString());
                string MOVIE_ID = row.Cells[6].Value.ToString();

                Form_AddScreening form = new Form_AddScreening(SCREENING_ID, SCREENING_DATES, MOVIE_HOURS, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);
                form.Show();
            }
        }
    }
}
