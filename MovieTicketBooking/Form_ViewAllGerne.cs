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
    public partial class Form_ViewAllGerne : Form
    {
        private int current_gerne_id = 0;
        public Form_ViewAllGerne()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            GerneBUS.Instance.ViewAll(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gerne_name = textBox1.Text;
                GerneBUS.Instance.Insert(gerne_name);
                MessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GerneBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại\n(" + ex.Message + ")", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int gerne_id = this.current_gerne_id;
                string gerne_name = textBox1.Text;
                GerneBUS.Instance.Update(gerne_id, gerne_name);
                MessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GerneBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại\n(" + ex.Message + ")", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int gerne_id = this.current_gerne_id;
                GerneBUS.Instance.Delete(gerne_id);
                MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                GerneBUS.Instance.ViewAll(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại\n(" + ex.Message + ")", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                this.current_gerne_id = int.Parse(row.Cells[0].Value.ToString());
                textBox1.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}
