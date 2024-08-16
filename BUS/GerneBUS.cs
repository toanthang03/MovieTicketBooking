using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class GerneBUS
    {
        private static GerneBUS instance;
        public static GerneBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GerneBUS();
                }
                return instance;
            }
        }

        private GerneBUS() { }

        public void ViewAll(DataGridView dgv)
        {
            dgv.DataSource = GerneDAO.Instance.ViewAll();
        }
        public void LoadComboBox(ComboBox cb)
        {
            cb.DisplayMember = "GERNE_NAME1";
            cb.ValueMember = "GERNE_ID1";
            cb.DataSource = GerneDAO.Instance.ViewAll();
        }
        public void Insert(string gerne_name)
        {
            try
            {
                GerneDAO.Instance.Insert(gerne_name);
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
                GerneDAO.Instance.Update(gerne_id, gerne_name);
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
                GerneDAO.Instance.Delete(gerne_id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
