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
    public partial class Form1 : Form
    {
        public delegate void sendCloseForm(bool close);
        public sendCloseForm send;
        public Form1(string username = null)
        {

            InitializeComponent();
            Init(username);
        }
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init(string username = null)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            if (!username.Contains("sa"))
            {
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form_ViewAllMovie form = new Form_ViewAllMovie();
            form.Show();
            //this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_ViewAllGerne form = new Form_ViewAllGerne();
            form.Show();
            //this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_ViewAllScreening form = new Form_ViewAllScreening();
            form.Show();
            //this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_SellMovieTickets form = new Form_SellMovieTickets();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_ViewAllTicket form = new Form_ViewAllTicket();
            form.Show();
        }
        private void OpenChildForm(Form child_form)
        {
            child_form.TopLevel = false;
            child_form.FormBorderStyle = FormBorderStyle.None;
            child_form.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(child_form);
            child_form.BringToFront();
            child_form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form_SellMovieTickets form = new Form_SellMovieTickets();
            this.OpenChildForm(form);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form_ViewAllTicket form = new Form_ViewAllTicket();
            this.OpenChildForm(form);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form_ViewAllScreening form = new Form_ViewAllScreening();
            this.OpenChildForm(form);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form_ViewAllMovie form = new Form_ViewAllMovie();
            this.OpenChildForm(form);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form_ViewAllGerne form = new Form_ViewAllGerne();
            this.OpenChildForm(form);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (send != null)
            {
                send(true);
                this.Close();
            }
        }
    }
}
