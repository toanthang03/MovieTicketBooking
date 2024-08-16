using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class TicketsBUS
    {
        public TicketsBUS() { }
        private static TicketsBUS instance;
        public static TicketsBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TicketsBUS();
                }
                return instance;
            }
        }
        public List<string> GetSeat(string SCREENING_ID)
        {
            try
            {
                return TicketsDAO.Instance.GetSeat(SCREENING_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Insert(string CHAIR, string SCREENING_ID, string EMPLOYEE_ID)
        {
            try
            {
                TicketsDAO.Instance.Insert(CHAIR, SCREENING_ID, EMPLOYEE_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void ViewAll(DataGridView dgv, string ticket_id = null)
        {
            if (ticket_id != null)
            {
                if (TicketsDAO.Instance.ViewAll(ticket_id).Count <= 0)
                    throw new ArgumentException("Không tìm thấy thông tin vé: " + ticket_id);
            }
            dgv.DataSource = TicketsDAO.Instance.ViewAll(ticket_id);
        }
        public void LoadDetailTicket(string ticket_id, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7)
        {
            object[] ticket = TicketsDAO.Instance.DetailTicket(ticket_id);
            List<Label> labels = new List<Label>();
            labels.Add(lb1);
            labels.Add(lb2);
            labels.Add(lb3);
            labels.Add(lb4);
            labels.Add(lb5);
            labels.Add(lb6);
            labels.Add(lb7);
            for (int i = 0; i < 2 * labels.Count; i += 2)
            {
                labels[i / 2].Text = ticket[i + 1].ToString();
            }
        }
        public void Delete(string ticket_id)
        {
            try
            {
                TicketsDAO.Instance.Delete(ticket_id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
