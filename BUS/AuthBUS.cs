using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AuthBUS
    {
        private static AuthBUS instance;
        public static AuthBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthBUS();
                }
                return instance;
            }
        }

        private AuthBUS() { }

        public void Login(string username, string password)
        {
            try
            {
                AuthDAO.Instance.Login(username, password);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
