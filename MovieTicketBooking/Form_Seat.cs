using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketBooking
{
    public partial class Form_Seat : Form
    {
        private string screeningID;
        Dictionary<Button, Color> originalColors = new Dictionary<Button, Color>();
        Button lastClickedButton = null;

        public Form_Seat(string screeningID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.screeningID = screeningID;
            loadColor();
            //test load color
        }
        public string GetSeat
        {
            get { return label9.Text; }
        }
        public string GetPrice
        {
            get { return ScreeningBUS.Instance.GetTicketPrice(screeningID); }
        }
        public void loadColor()
        {
            List<string> list = TicketsBUS.Instance.GetSeat(screeningID);
            foreach (string item in list)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        Button button = (Button)control;
                        if (button.Text == item)
                        {
                            button.BackColor = Color.Gray;
                            button.Enabled = false;
                        }
                    }
                }
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if(label9.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ghế!");
            }
        }
        //Dictionary<Button, Color> originalColors = new Dictionary<Button, Color>();
        //private void button_Click(object sender, EventArgs e)
        //{
        //    Button clickedButton = (Button)sender;

        //    if (!originalColors.ContainsKey(clickedButton))
        //    {
        //        // Lưu trữ màu ban đầu của Button nếu chưa được lưu trữ trước đó
        //        originalColors.Add(clickedButton, clickedButton.BackColor);
        //    }

        //    // Kiểm tra màu hiện tại của button
        //    if (clickedButton.BackColor == originalColors[clickedButton])
        //    {
        //        // Nếu màu là màu ban đầu, đổi lại màu của button thành màu vàng
        //        clickedButton.BackColor = Color.Yellow;
        //    }
        //    else
        //    {
        //        // Nếu màu không phải là màu ban đầu, thiết lập màu của button trở về màu ban đầu đã lưu trữ
        //        clickedButton.BackColor = originalColors[clickedButton];
        //    }
        //}
        //Dictionary<Button, Color> originalColors = new Dictionary<Button, Color>();
        //Button lastClickedButton = null;
        //private void button_Click(object sender, EventArgs e)
        //{
        //    Button clickedButton = (Button)sender;

        //    if (!originalColors.ContainsKey(clickedButton))
        //    {
        //        // Lưu trữ màu ban đầu của Button nếu chưa được lưu trữ trước đó
        //        originalColors.Add(clickedButton, clickedButton.BackColor);
        //    }
        //    // Kiểm tra màu hiện tại của button
        //    if (clickedButton.BackColor == originalColors[clickedButton])
        //    {
        //        // Nếu màu là màu ban đầu, đổi lại màu của button thành màu vàng
        //        clickedButton.BackColor = Color.Yellow;
        //        // Hiển thị Text của Button vào Label
        //        label9.Text = clickedButton.Text;
        //        // Xoá Text khỏi Label nếu Button được click lại
        //        if (clickedButton == lastClickedButton)
        //        {
        //            label1.Text = "";
        //            lastClickedButton = null;
        //        }
        //        else
        //        {
        //            lastClickedButton = clickedButton;
        //        }
        //    }
        //    else
        //    {
        //        // Nếu màu không phải là màu ban đầu, thiết lập màu của button trở về màu ban đầu đã lưu trữ
        //        clickedButton.BackColor = originalColors[clickedButton];
        //    }
        //}

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (!originalColors.ContainsKey(clickedButton))
            {
                // Lưu trữ màu ban đầu của Button nếu chưa được lưu trữ trước đó
                originalColors.Add(clickedButton, clickedButton.BackColor);
            }

            // Xoá màu vàng của Button cũ nếu đã có
            if (lastClickedButton != null && lastClickedButton.BackColor == Color.Yellow)
            {
                lastClickedButton.BackColor = originalColors[lastClickedButton];
            }

            // Kiểm tra màu hiện tại của button
            if (clickedButton.BackColor == originalColors[clickedButton])
            {
                // Nếu màu là màu ban đầu, đổi lại màu của button thành màu vàng
                clickedButton.BackColor = Color.Yellow;

                // Hiển thị Text của Button vào Label
                label9.Text = clickedButton.Text;

                lastClickedButton = clickedButton;
            }
            else
            {
                // Nếu màu không phải là màu ban đầu, thiết lập màu của button trở về màu ban đầu đã lưu trữ
                clickedButton.BackColor = originalColors[clickedButton];
            }
        }


    }
}
