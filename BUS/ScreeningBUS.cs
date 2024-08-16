using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ScreeningBUS
    {
        private static ScreeningBUS instance;
        public static ScreeningBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreeningBUS();
                }
                return instance;
            }
        }

        private ScreeningBUS() { }
        public void LoadComboBox(ComboBox cb, string movie_id)
        {
            cb.DisplayMember = "SCREENING_DATES1";
            cb.ValueMember = "SCREENING_ID1";
            cb.DataSource = ScreeningDAO.Instance.GetAllByMovieId(movie_id);
        }
        //public void GetTicketPrice(TextBox tb, string screening_id)
        //{
        //    tb.Text = ScreeningDAO.Instance.GeticketPrice(screening_id);
        //}
        public string GetTicketPrice(string screening_id)
        {
            return ScreeningDAO.Instance.GeticketPrice(screening_id);
        }
        public void GetMovieHours(TextBox tb, string screening_id)
        {
            tb.Text = ScreeningDAO.Instance.GetMovieHours(screening_id);
        }

        public void GetRoom(TextBox tb, string screening_id)
        {
            tb.Text = ScreeningDAO.Instance.GetRoom(screening_id);
        }

        public void ViewAll(DataGridView dgv, DateTime? date = null)
        {
            dgv.DataSource = ScreeningDAO.Instance.ViewAll(date);
        }
        public void Insert(DateTime SCREENING_DATES, TimeSpan MOVIE_HOURS, String SCREENING_ROOM, int TICKET_PRICES, string MOVIE_ID)
        {
            try
            {
                ScreeningDAO.Instance.Insert(SCREENING_DATES, MOVIE_HOURS, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Delete(string SCREENING_ID)
        {
            try
            {
                ScreeningDAO.Instance.Delete(SCREENING_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Update(string sCREENING_ID, DateTime sCREENING_DATES, TimeSpan mOVIE_HOURS, string sCREENING_ROOM, int tICKET_PRICES, string mOVIE_ID)
        {
            try
            {
                ScreeningDAO.Instance.Update(sCREENING_ID, sCREENING_DATES, mOVIE_HOURS, sCREENING_ROOM, tICKET_PRICES, mOVIE_ID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
