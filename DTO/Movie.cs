using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Movie
    {
        private string MOVIE_ID;
        private string MOVIE_NAME;
        private int DURATION;
        private DateTime RELEASE_DATE;
        private string DIRECTOR;
        private int GERNE_ID;


        public Movie(string MOVIE_ID, string MOVIE_NAME, int DURATION, DateTime RELEASE_DATE, string DIRECTOR, int GERNE_ID)
        {
            this.MOVIE_ID = MOVIE_ID;
            this.MOVIE_NAME = MOVIE_NAME;
            this.DURATION = DURATION;
            this.RELEASE_DATE = RELEASE_DATE;
            this.DIRECTOR = DIRECTOR;
            this.GERNE_ID = GERNE_ID;
        }
        public string MOVIE_ID1 { get => MOVIE_ID; set => MOVIE_ID = value; }
        public string MOVIE_NAME1 { get => MOVIE_NAME; set => MOVIE_NAME = value; }
        public int DURATION1 { get => DURATION; set => DURATION = value; }
        public DateTime RELEASE_DATE1 { get => RELEASE_DATE; set => RELEASE_DATE = value; }
        public string DIRECTOR1 { get => DIRECTOR; set => DIRECTOR = value; }
        public int GERNE_ID1 { get => GERNE_ID; set => GERNE_ID = value; }

    }
}
