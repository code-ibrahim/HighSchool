using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HighSchool.DataAccessLayerADO
{
    public class DataAccessLayer
    {
        SqlConnection connection1 = new SqlConnection();
        //connection1.

        public bool TestConnection()
        {
            SqlConnection conQuickKart = new SqlConnection();
            conQuickKart.ConnectionString = "Data Source=.;Initial Catalog=QuickKart_ADO; Integrated Security=SSPI";
            bool status = false;
            try
            {
                conQuickKart.Open();
                status = true;
            }
            catch
            {
                status = false;
            }
            finally
            {
                conQuickKart.Close();
            }
            return status;
        }
    }


}
