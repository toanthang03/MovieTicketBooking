using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tickets
    {
        private string TICKET_ID;
        private string CHAIR;
        private string SCREENING_ID;
        private string EMPLOYEE_ID;
        private DateTime CREATE_DATE;

        public Tickets(string tICKET_ID, string cHAIR, string sCREENING_ID, string eMPLOYEE_ID, DateTime cREATE_DATE)
        {
            this.TICKET_ID = tICKET_ID;
            this.CHAIR = cHAIR;
            this.SCREENING_ID = sCREENING_ID;
            this.EMPLOYEE_ID = eMPLOYEE_ID;
            this.CREATE_DATE1 = cREATE_DATE;
        }
        public Tickets(string TICKET_ID, string CHAIR, string SCREENING_ID, string EMPLOYEE_ID)
        {
            this.TICKET_ID = TICKET_ID;
            this.CHAIR = CHAIR;
            this.SCREENING_ID = SCREENING_ID;
            this.EMPLOYEE_ID = EMPLOYEE_ID;
        }

        public string TICKET_ID1 { get => TICKET_ID; set => TICKET_ID = value; }
        public string CHAIR1 { get => CHAIR; set => CHAIR = value; }
            
        public string SCREENING_ID1 { get => SCREENING_ID; set => SCREENING_ID = value; }
        public string EMPLOYEE_ID1 { get => EMPLOYEE_ID; set => EMPLOYEE_ID = value; }
        public DateTime CREATE_DATE1 { get => CREATE_DATE; set => CREATE_DATE = value; }
    }

}
