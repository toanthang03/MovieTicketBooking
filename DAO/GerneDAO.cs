using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GerneDAO
    {
        private static GerneDAO instance;
        public static GerneDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GerneDAO();
                }
                return instance;
            }
        }

        private GerneDAO() { }

        public List<Gerne> ViewAll()
        {
            List<Gerne> gernes = new List<Gerne>();
            string sql = "SELECT * FROM V_GERNES";
            DataTable dt = DataProvider.Instance.executeQuery(sql);
            foreach (DataRow item in dt.Rows)
            {
                string GERNE_ID = item["GERNE_ID"].ToString();
                string GERNE_NAME = item["GERNE_NAME"].ToString();

                Gerne gerne = new Gerne(GERNE_ID, GERNE_NAME);

                gernes.Add(gerne);
            }
            return gernes;
        }
        public void Insert(string gerne_name)
        {
            try
            {
                string sql = "ADD_GERNE";
                object[] parameters = new object[] {
                    "@GerneName", gerne_name
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Update(int gerne_id, string gerne_name)
        {
            try
            {
                string sql = "RENAME_GERNE";
                object[] parameters = new object[] {
                    "@GerneId", gerne_id,
                    "@GerneName", gerne_name
                };
                DataProvider.Instance.executeProcedure(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Delete(int gerne_id)
        {
            try
            {
                string sql = "DELETE_GERNE";
                object[] parameters = new object[] {
                    "@GerneId", gerne_id
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
