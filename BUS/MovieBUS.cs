using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class MovieBUS
    {
        private static MovieBUS instance;
        public static MovieBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovieBUS();
                }
                return instance;
            }
        }

        private MovieBUS() { }

        public void ViewAll(DataGridView dgv)
        {
            dgv.DataSource = MovieDAO.Instance.ViewAll();
        }
        public void ViewAllName(DataGridView dgv)
        {
            dgv.DataSource = MovieDAO.Instance.GetMoviesWithSceenings();
        }
        public void LoadComboBox(ComboBox cb)
        {
            cb.DisplayMember = "MOVIE_NAME1";
            cb.ValueMember = "MOVIE_ID1";
            cb.DataSource = MovieDAO.Instance.ViewAll();
        }
        public void Insert(string MOVIE_NAME, int DURATION,DateTime RELEASE_DATE, string DIRECTOR, int GERNE_ID)
        {
            try
            {
                MovieDAO.Instance.Insert(MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        public void Delete(string MOVIE_ID)
        {
            try
            {
                MovieDAO.Instance.Delete(MOVIE_ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        public void Update(string MOVIE_ID, string MOVIE_NAME, int DURATION, DateTime RELEASE_DATE, string DIRECTOR, int GERNE_ID)
        {
            try
            {
                MovieDAO.Instance.Update(MOVIE_ID, MOVIE_NAME, DURATION, RELEASE_DATE, DIRECTOR, GERNE_ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
