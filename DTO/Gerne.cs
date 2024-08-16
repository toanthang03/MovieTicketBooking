using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Gerne
    {
        private string GERNE_ID;
        private string GERNE_NAME;


        public Gerne(string GERNE_ID, string GERNE_NAME)
        {
            this.GERNE_ID = GERNE_ID;
            this.GERNE_NAME = GERNE_NAME;
        }
        public string GERNE_ID1 { get => GERNE_ID; set => GERNE_ID = value; }
        public string GERNE_NAME1 { get => GERNE_NAME; set => GERNE_NAME = value; }
    }
}
