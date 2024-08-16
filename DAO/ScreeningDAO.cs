using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ScreeningDAO
    {
        private static ScreeningDAO instance;
        public static ScreeningDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreeningDAO();
                }
                return instance;
            }
        }

        private ScreeningDAO() { }

        public string GeticketPrice(string screening_id)
        {
            string sql = "SELECT TICKET_PRICES FROM V_SCREENINGS WHERE SCREENING_ID = '" + screening_id + "'";
            object[] parameters = null;
            DataTable dt = DataProvider.Instance.executeQuery(sql, parameters);

            // Kiểm tra xem có dữ liệu trả về không
            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên và cột "TICKET_PRICES"
                string ticketPrice = dt.Rows[0]["TICKET_PRICES"].ToString();

                // Trả về giá vé của suất chiếu
                return ticketPrice;
            }
            else
            {
                // Trả về null nếu không có dữ liệu trả về
                return null;
            }
        }

        public string GetRoom(string screening_id)
        {
            string sql = "SELECT SCREENING_ROOM FROM V_SCREENINGS WHERE SCREENING_ID = '" + screening_id + "'";
            object[] parameters = null;
            //return DataProvider.Instance.executeQuery(sql, parameters).ToString();
            DataTable dt = DataProvider.Instance.executeQuery(sql, parameters);

            // Kiểm tra xem có dữ liệu trả về không
            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên và cột "SCREENING_ROOM"
                string room = dt.Rows[0]["SCREENING_ROOM"].ToString();

                // Trả về phòng chiếu của suất chiếu
                return room;
            }
            else
            {
                // Trả về null nếu không có dữ liệu trả về
                return null;
            }
        }
        public string GetMovieHours(string screening_id)
        {
            string sql = "SELECT MOVIE_HOURS FROM V_SCREENINGS WHERE SCREENING_ID = '" + screening_id + "'";
            object[] parameters = null;
            //return DataProvider.Instance.executeQuery(sql, parameters).ToString();
            DataTable dt = DataProvider.Instance.executeQuery(sql, parameters);

            // Kiểm tra xem có dữ liệu trả về không
            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên và cột "MOVIE_HOURS"
                string movieHours = dt.Rows[0]["MOVIE_HOURS"].ToString();

                // Trả về giờ của bộ phim
                return movieHours;
            }
            else
            {
                // Trả về null nếu không có dữ liệu trả về
                return null;
            }
        }
        //Data Source=TOAN-THANG;Initial Catalog=RapPhim;Persist Security Info=True;User ID=sa

        public List<Screening> GetAllByMovieId(string movieId)
        {
            List<Screening> screenings = new List<Screening>();
            string sql = "SELECT * FROM V_SCREENINGS WHERE MOVIE_ID = '" + movieId + "' AND SCREENING_DATES > CAST(GETDATE() AS DATE) OR (MOVIE_ID = '" + movieId + "'  AND SCREENING_DATES = CAST(GETDATE() AS DATE) AND MOVIE_HOURS >= CAST(GETDATE() AS TIME));";
            DataTable dt = new DataTable();
            object[] parameters = null;
            dt = DataProvider.Instance.executeQuery(sql, parameters);
            foreach (DataRow item in dt.Rows)
            {
                string SCREENING_ID = item["SCREENING_ID"].ToString();
                DateTime SCREENING_DATES = Convert.ToDateTime(item["SCREENING_DATES"]);
                TimeSpan MOVIE_HOURS = TimeSpan.Parse(item["MOVIE_HOURS"].ToString());
                TimeSpan END_TIME = TimeSpan.Parse(item["END_TIME"].ToString());
                string SCREENING_ROOM = item["SCREENING_ROOM"].ToString();
                int TICKET_PRICES = int.Parse(item["TICKET_PRICES"].ToString());
                string MOVIE_ID = item["MOVIE_ID"].ToString();

                Screening screening = new Screening(SCREENING_ID, SCREENING_DATES, MOVIE_HOURS, END_TIME, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);

                screenings.Add(screening);
            }
            return screenings;
        }
        public List<Screening> ViewAll(DateTime? date = null)
        {
            List<Screening> screenings = new List<Screening>();
            string sql = "SELECT * FROM V_SCREENINGS";
            DataTable dt = new DataTable();
            object[] parameters = null;
            if (date != null)
            {
                sql += " WHERE SCREENING_DATES = '" + date?.ToString("yyyy-MM-dd") + "'";
            }
            sql += " ORDER BY SCREENING_ROOM";
            dt = DataProvider.Instance.executeQuery(sql, parameters);
            foreach (DataRow item in dt.Rows)
            {
                string SCREENING_ID = item["SCREENING_ID"].ToString();
                DateTime SCREENING_DATES = Convert.ToDateTime(item["SCREENING_DATES"]);
                TimeSpan MOVIE_HOURS = TimeSpan.Parse(item["MOVIE_HOURS"].ToString());
                TimeSpan END_TIME = TimeSpan.Parse(item["END_TIME"].ToString());
                string SCREENING_ROOM = item["SCREENING_ROOM"].ToString();
                int TICKET_PRICES = int.Parse(item["TICKET_PRICES"].ToString());
                string MOVIE_ID = item["MOVIE_ID"].ToString();

                Screening screening = new Screening(SCREENING_ID, SCREENING_DATES, MOVIE_HOURS, END_TIME, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);

                screenings.Add(screening);
            }
            return screenings;
        }
        public void Insert(DateTime SCREENING_DATES, TimeSpan MOVIE_HOURS, String SCREENING_ROOM, int TICKET_PRICES, string MOVIE_ID)
        {
            try
            {
                Screening screening = new Screening(null, SCREENING_DATES, MOVIE_HOURS, MOVIE_HOURS, SCREENING_ROOM, TICKET_PRICES, MOVIE_ID);
                string sql = "ADD_SCREENING";
                object[] parameters = new object[] {
                    "@ScreeningDate", screening.SCREENING_DATES1,
                    "@MovieHours", screening.MOVIE_HOURS1,
                    "@ScreenRoom", screening.SCREENING_ROOM1,
                    "@TicketPrice", screening.TICKET_PRICES1,
                    "@MovieId", screening.MOVIE_ID1
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
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
                string sql = "DELETE_SCREENING";
                object[] parameters = new object[] {
                    "@ScreeningId", SCREENING_ID
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
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
                Screening screening = new Screening(sCREENING_ID, sCREENING_DATES, mOVIE_HOURS, mOVIE_HOURS, sCREENING_ROOM, tICKET_PRICES, mOVIE_ID);
                string sql = "UPDATE_SCREENING";
                object[] parameters = new object[] {
                    "@ScreeningId", screening.SCREENING_ID1,
                    "@ScreeningDate", screening.SCREENING_DATES1,
                    "@MovieHours", screening.MOVIE_HOURS1,
                    "@ScreenRoom", screening.SCREENING_ROOM1,
                    "@TicketPrice", screening.TICKET_PRICES1,
                    "@MovieId", screening.MOVIE_ID1
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
