using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TicketsDAO
    {
        private static TicketsDAO instance;
        public static TicketsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TicketsDAO();
                }
                return instance;
            }
        }
        private TicketsDAO() { }
        public List<String> GetSeat(string SCREENING_ID)
        {
            List<String> list = new List<string>();
            string sql = "SELECT CHAIR FROM TICKETS WHERE SCREENING_ID = '" + SCREENING_ID + "'";
            DataTable dt = DataProvider.Instance.executeQuery(sql);

            foreach (DataRow item in dt.Rows)
            {
                string chair = item["CHAIR"].ToString();
                list.Add(chair);
            }
            return list;
        }
        public void Insert(string CHAIR, string SCREENING_ID, string EMPLOYEE_ID)
        {
            try
            {
                Tickets ticket = new Tickets("", CHAIR, SCREENING_ID, EMPLOYEE_ID);
                string sql = "ADD_TICKET";
                object[] parameters = new object[] {
                    "@CHAIR", ticket.CHAIR1,
                    "@SCREENING_ID", ticket.SCREENING_ID1,
                    "@EMPLOYEE_ID", ticket.EMPLOYEE_ID1
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public List<Tickets> ViewAll(string ticket_id = null)
        {
            List<Tickets> tickets = new List<Tickets>();
            string sql = "SELECT * FROM V_TICKETS";
            if (ticket_id != null)
            {
                sql += " WHERE TICKET_ID = '" + ticket_id + "'";
            }
            DataTable dt = DataProvider.Instance.executeQuery(sql);
            foreach (DataRow item in dt.Rows)
            {
                string TICKET_ID = item["TICKET_ID"].ToString();
                string CHAIR = item["CHAIR"].ToString();
                string SCREENING_ID = item["SCREENING_ID"].ToString();
                string EMPLOYEE_ID = item["EMPLOYEE_ID"].ToString();
                DateTime CREATE_DATE = Convert.ToDateTime(item["CREATE_DATE"]);

                Tickets ticket = new Tickets(TICKET_ID, CHAIR, SCREENING_ID, EMPLOYEE_ID, CREATE_DATE);
                tickets.Add(ticket);
            }
            return tickets;
        }
        public object[] DetailTicket(string ticket_id)
        {
            string sql = "SELECT * FROM V_DETAIL_TICKET WHERE TICKET_ID = '" + ticket_id + "'";
            DataTable dt = DataProvider.Instance.executeQuery(sql);
            DataRow item = dt.Rows[0];
            string TICKET_ID = item["TICKET_ID"].ToString();
            string MOVIE_NAME = item["MOVIE_NAME"].ToString();
            string SCREENING_DATES = item["SCREENING_DATES"].ToString();
            string TIME_SCREEN = item["MOVIE_HOURS"].ToString() + " - " + item["END_TIME"].ToString();
            string SCREENING_ROOM = item["SCREENING_ROOM"].ToString();
            string CHAIR = item["CHAIR"].ToString();
            int PRICES_TICKET = int.Parse(item["TICKET_PRICES"].ToString());
            string TICKET_PRICES = string.Format("{0:N0} VNĐ", PRICES_TICKET);
            object[] ticket = new object[]
            {
                "TICKET_ID", TICKET_ID,
                "MOVIE_NAME", MOVIE_NAME,
                "SCREENING_DATES", SCREENING_DATES,
                "TIME_SCREEN", TIME_SCREEN,
                "SCREENING_ROOM", SCREENING_ROOM,
                "CHAIR", CHAIR,
                "TICKET_PRICES", TICKET_PRICES
            };
            return ticket;
        }
        public void Delete(string tICKET_ID)
        {
            try
            {
                string sql = "REMOVE_TICKET";
                object[] parameters = new object[] {
                    "@TicketId", tICKET_ID
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
