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
    public partial class Form_AddScreening : Form
    {
        private string screening_id = "";
        public Form_AddScreening(string sCREENING_ID = null, DateTime? sCREENING_DATES = null, TimeSpan? mOVIE_HOURS = null, string sCREENING_ROOM = null, int? tICKET_PRICES = null, string mOVIE_ID = null)
        {
            InitializeComponent();
            MovieBUS.Instance.LoadComboBox(comboBox2);
            loadDataUpdate(sCREENING_ID, sCREENING_DATES, mOVIE_HOURS, sCREENING_ROOM, tICKET_PRICES, mOVIE_ID);
            screening_id = sCREENING_ID == null ? "" : sCREENING_ID;
        }

        private void loadDataUpdate(string sCREENING_ID = null, DateTime? sCREENING_DATES = null, TimeSpan? mOVIE_HOURS = null, string sCREENING_ROOM = null, int? tICKET_PRICES = null, string mOVIE_ID = null)
        {
            label6.Text = sCREENING_ID == null ? "" : "SCREENING_ID :" + sCREENING_ID;
            if (mOVIE_ID != null)
            {
                comboBox2.SelectedValue = mOVIE_ID;
            }
            if (sCREENING_DATES != null)
            {
                dateTimePicker1.Value = sCREENING_DATES.Value;
            }
            if (mOVIE_HOURS != null)
            {
                maskedTextBox1.Text = mOVIE_HOURS.ToString();
            }
            if (sCREENING_ROOM != null)
            {
                comboBox1.Text = sCREENING_ROOM;
            }
            if (tICKET_PRICES != null)
            {
                maskedTextBox2.Text = tICKET_PRICES.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MOVIE_ID = comboBox2.SelectedValue.ToString();
                DateTime SCREENING_DATES = dateTimePicker1.Value;
                string movie_hours = maskedTextBox1.Text;
                TimeSpan MOVIE_HOURS = TimeSpan.Parse(movie_hours);
                String SCREENING_ROOM = comboBox1.Text;
                int TICKET_PRICES = int.Parse(maskedTextBox2.Text);
                //string input = MOVIE_ID + "\n" + SCREENING_DATES.ToString() + "\n" + MOVIE_HOURS.ToString() + "\n" + SCREENING_ROOM + "\n" + TICKET_PRICES.ToString();
                //MessageBox.Show(input);
                //Insert
                ScreeningBUS.Instance.Insert(SCREENING_DATES, MOVIE_HOURS, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);
                this.Close();
            }
            catch (Exception ex)
            {
                string error = "Dữ liệu đầu vào không hợp lệ!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string MOVIE_ID = comboBox2.SelectedValue.ToString();
                DateTime SCREENING_DATES = dateTimePicker1.Value;
                string movie_hours = maskedTextBox1.Text;
                TimeSpan MOVIE_HOURS = TimeSpan.Parse(movie_hours);
                String SCREENING_ROOM = comboBox1.Text;
                int TICKET_PRICES = int.Parse(maskedTextBox2.Text);
                //string input = MOVIE_ID + "\n" + SCREENING_DATES.ToString() + "\n" + MOVIE_HOURS.ToString() + "\n" + SCREENING_ROOM + "\n" + TICKET_PRICES.ToString();
                //MessageBox.Show(input);
                //Insert
                ScreeningBUS.Instance.Update(this.screening_id, SCREENING_DATES, MOVIE_HOURS, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);
                this.Close();
            }
            catch (Exception ex)
            {
                string error = "Dữ liệu đầu vào không hợp lệ, không thể sửa!!!\n" + "(" + ex.Message + ")";
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
