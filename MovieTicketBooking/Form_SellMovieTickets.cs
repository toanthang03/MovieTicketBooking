using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketBooking
{
    public partial class Form_SellMovieTickets : Form
    {
        private string screeningID;
        private string ticketPrice;

        private List<string> vipSeats = new List<string>(){
            "B04", "B05", "B06", "B07", "B08", "B09", "B10",
            "C04", "C05", "C06", "C07", "C08", "C09", "C10",
            "D04", "D05", "D06", "D07", "D08", "D09", "D10",
        };
        //private List<string>  regularSeats = new List<string>(){
        //    "A01", "A02", "A03", "A04", "A05",
        //    "A06", "A07", "A08", "A09", "A10"
        //};
        private List<string> doubleSeats = new List<string>(){
            "E01", "E02", "E03", "E04", "E05", "E06"
        };
        public Form_SellMovieTickets()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            MovieBUS.Instance.ViewAllName(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                ScreeningBUS.Instance.LoadComboBox(comboBox1, row.Cells[0].Value.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScreeningBUS.Instance.GetMovieHours(textBox2, comboBox1.SelectedValue.ToString());
            ScreeningBUS.Instance.GetRoom(textBox3, comboBox1.SelectedValue.ToString());
            screeningID = comboBox1.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int checkSeat(string seat)
        {
            if (vipSeats.Contains(seat))
            {
                return 20000;
            }
            else if (doubleSeats.Contains(seat))
            {
                return 25000;
            }
            return 10000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form_Seat form = new Form_Seat(screeningID);
                form.ShowDialog();
                string seat = form.GetSeat;
                textBox5.Text = seat;
                ticketPrice = form.GetPrice;
                int totalPrice = int.Parse(ticketPrice) + checkSeat(seat);
                string formattedPrice = totalPrice.ToString("#,##0");
                textBox4.Text = formattedPrice + " VND";
                //textBox4.Text = (int.Parse(ticketPrice) + checkSeat(seat)).ToString();
            }
            else
            {
                   MessageBox.Show("Vui lòng chọn phim!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            // Lọc các ký tự không phải là số
            string filteredText = string.Concat(text.Where(char.IsDigit));

            // Kiểm tra giá trị nếu văn bản không rỗng
            if (!string.IsNullOrEmpty(filteredText))
            {
                int value = int.Parse(filteredText);
                // Chỉ cho phép giá trị từ 1 đến 9
                if (value < 1 || value > 9)
                {
                    // Hiển thị cảnh báo hoặc thực hiện hành động phù hợp
                    MessageBox.Show("Vui lòng chỉ nhập số từ 1 đến 9!");
                    // Có thể xóa giá trị không hợp lệ từ TextBox
                    textBox.Text = filteredText.Substring(0, filteredText.Length - 1);
                    // Đặt con trỏ vào cuối văn bản
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        //mai test add ticket
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox5.Text != "")
            {
                TicketsBUS.Instance.Insert(textBox5.Text, screeningID, "NV1");
                textBox5.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Đã thêm vé!");
            }else
            {
                MessageBox.Show("Vui lòng chọn ghế!");
            }

        }
    }
}
