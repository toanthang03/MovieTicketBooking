using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketBooking
{
    public partial class Form_ViewAllMovie : Form
    {
        private String current_movieid = "NONE";
        public Form_ViewAllMovie()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            MovieBUS.Instance.ViewAll(dataGridView1);
            GerneBUS.Instance.LoadComboBox(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy dữ liệu
                string MOVIE_NAME = textBox1.Text;
                int DURATION = int.Parse(maskedTextBox1.Text);
                DateTime RELEASE_DATE = DateTime.ParseExact(maskedTextBox2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string DIRECTOR = textBox2.Text;
                int GERNE_ID = int.Parse(comboBox1.SelectedValue.ToString());
                //Kiểm tra dữ liệu

                //Thêm dữ liệu vào bảng
                MovieBUS.Instance.Insert(MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
                //MessageBox.Show(data, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Success", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lại dữ liệu
                MovieBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                string error = "Dữ liệu đầu vào không hợp lệ!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string convertToddMMyyyy(string date)
        {
            string[] dates = date.Split(' ');
            string[] MMddyyyy = dates[0].Split('/');
            string new_date = int.Parse(MMddyyyy[1]).ToString("00") + int.Parse(MMddyyyy[0]).ToString("00") + int.Parse(MMddyyyy[2]).ToString("0000");
            return new_date;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells[1].Value.ToString();
                    maskedTextBox1.Text = row.Cells[2].Value.ToString();
                    maskedTextBox2.Text = this.convertToddMMyyyy(row.Cells[3].Value.ToString());
                    textBox2.Text = row.Cells[4].Value.ToString();
                    comboBox1.SelectedValue = row.Cells[5].Value.ToString();

                    this.current_movieid = row.Cells[0].Value.ToString();
                    label8.Text = "MOVIE_ID SELECT: " + current_movieid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy dữ liệu
                string MOVIE_ID = this.current_movieid;
                //Kiểm tra dữ liệu

                //Xóa dữ liệu trong bảng
                MovieBUS.Instance.Delete(MOVIE_ID);
                //MessageBox.Show(data, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Success", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lại dữ liệu
                MovieBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                string error = "Xóa thất bại!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy dữ liệu
                string MOVIE_ID = this.current_movieid;
                string MOVIE_NAME = textBox1.Text;
                int DURATION = int.Parse(maskedTextBox1.Text);
                DateTime RELEASE_DATE = DateTime.ParseExact(maskedTextBox2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string DIRECTOR = textBox2.Text;
                int GERNE_ID = int.Parse(comboBox1.SelectedValue.ToString());
                string data = MOVIE_NAME + "\n" + DURATION + "\n" + RELEASE_DATE.ToString() + "\n" + DIRECTOR + "\n" + GERNE_ID;
                //Kiểm tra dữ liệu

                //Sữa dữ liệu trong bảng
                MovieBUS.Instance.Update(MOVIE_ID, MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
                //MessageBox.Show(data, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Success", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lại dữ liệu
                MovieBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                string error = "Dữ liệu đầu vào không hợp lệ, không thể sửa!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
