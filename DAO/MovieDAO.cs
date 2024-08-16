using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class MovieDAO
    {
        private static MovieDAO instance;
        public static MovieDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieDAO();
                }
                return instance;
            }
        }

        private MovieDAO() { }

        public List<Movie> GetMoviesWithSceenings()
        {
            List<Movie> movies = new List<Movie>();
            string sql = "SELECT DISTINCT M.* FROM MOVIES M INNER JOIN SCREENINGS S ON M.MOVIE_ID = S.MOVIE_ID WHERE S.SCREENING_DATES > CAST(GETDATE() AS DATE) OR (S.SCREENING_DATES = CAST(GETDATE() AS DATE) AND S.MOVIE_HOURS >= CAST(GETDATE() AS TIME));";
            DataTable dt = DataProvider.Instance.executeQuery(sql);
            foreach (DataRow item in dt.Rows)
            {
                string MOVIE_ID = item["MOVIE_ID"].ToString();
                string MOVIE_NAME = item["MOVIE_NAME"].ToString();
                int DURATION = int.Parse(item["DURATION"].ToString());
                DateTime RELEASE_DATE = Convert.ToDateTime(item["RELEASE_DATE"]);
                string DIRECTOR = item["DIRECTOR"].ToString();
                int GERNE_ID = int.Parse(item["GERNE_ID"].ToString());

                Movie movie = new Movie(MOVIE_ID, MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);

                movies.Add(movie);
            }
            return movies;
        }

        public List<Movie> ViewAll()
        {
            List<Movie> movies = new List<Movie>();
            string sql = "SELECT * FROM V_MOVIES";
            DataTable dt = DataProvider.Instance.executeQuery(sql);
            foreach (DataRow item in dt.Rows)
            {
                string MOVIE_ID = item["MOVIE_ID"].ToString();
                string MOVIE_NAME = item["MOVIE_NAME"].ToString();
                int DURATION = int.Parse(item["DURATION"].ToString());
                DateTime RELEASE_DATE = Convert.ToDateTime(item["RELEASE_DATE"]);
                string DIRECTOR = item["DIRECTOR"].ToString();
                int GERNE_ID = int.Parse(item["GERNE_ID"].ToString());

                Movie movie = new Movie(MOVIE_ID, MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);

                movies.Add(movie);
            }
            return movies;
        }
        public void Insert(string MOVIE_NAME, int DURATION, DateTime RELEASE_DATE, string DIRECTOR, int GERNE_ID)
        {
            try
            {
                Movie movie = new Movie("", MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
                string sql = "ADD_MOVIE";
                object[] parameters = new object[] {
                    "@MovieName", movie.MOVIE_NAME1,
                    "@Duration", movie.DURATION1,
                    "@ReleaseDate", movie.RELEASE_DATE1,
                    "@Director", movie.DIRECTOR1,
                    "@GenreID", movie.GERNE_ID1
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Delete(string MOVIE_ID)
        {
            try
            {
                string sql = "DELETE_MOVIE";
                object[] parameters = new object[] {
                    "@MovieId", MOVIE_ID
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Update(string MOVIE_ID, string MOVIE_NAME, int DURATION, DateTime RELEASE_DATE, string DIRECTOR, int GERNE_ID)
        {
            try
            {
                Movie movie = new Movie(MOVIE_ID, MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
                string sql = "UPDATE_MOVIE";
                object[] parameters = new object[] {
                    "@MovieId", movie.MOVIE_ID1,
                    "@MovieName", movie.MOVIE_NAME1,
                    "@Duration", movie.DURATION1,
                    "@ReleaseDate", movie.RELEASE_DATE1,
                    "@Director", movie.DIRECTOR1,
                    "@GenreID", movie.GERNE_ID1
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
