using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Screening
    {
        private string SCREENING_ID;
        private DateTime SCREENING_DATES;
        private TimeSpan MOVIE_HOURS;
        private TimeSpan END_TIME;
        private string SCREENING_ROOM;
        private int TICKET_PRICES;
        private string MOVIE_ID;

        public Screening(string sCREENING_ID, DateTime sCREENING_DATES, TimeSpan mOVIE_HOURS, TimeSpan eND_TIME, string sCREENING_ROOM, int tICKET_PRICES, string mOVIE_ID)
        {
            this.SCREENING_ID = sCREENING_ID;
            this.SCREENING_DATES = sCREENING_DATES;
            this.MOVIE_HOURS = mOVIE_HOURS;
            this.END_TIME = eND_TIME;
            this.SCREENING_ROOM = sCREENING_ROOM;
            this.TICKET_PRICES = tICKET_PRICES;
            this.MOVIE_ID = mOVIE_ID;
        }

        public string SCREENING_ID1 { get => SCREENING_ID; set => SCREENING_ID = value; }
        public DateTime SCREENING_DATES1 { get => SCREENING_DATES; set => SCREENING_DATES = value; }
        public TimeSpan MOVIE_HOURS1 { get => MOVIE_HOURS; set => MOVIE_HOURS = value; }
        public TimeSpan END_TIME1 { get => END_TIME; set => END_TIME = value; }
        public string SCREENING_ROOM1 { get => SCREENING_ROOM; set => SCREENING_ROOM = value; }
        public int TICKET_PRICES1 { get => TICKET_PRICES; set => TICKET_PRICES = value; }
        public string MOVIE_ID1 { get => MOVIE_ID; set => MOVIE_ID = value; }
    }
}
