using System;
using Microsoft.Data.Sqlite;
using System.Data;

namespace HighSchool.DataAccessLayer
{
    public class Class1
    {
        public bool TestConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool;";

            var conTest = new SqliteConnection(connectionStringBuilder.ConnectionString);
            //conTest.ConnectionString = "Data Source=.;Initial Catalog=QuickKart_ADO; Integrated Security=SSPI";
            bool status = false;
            try
            {
                conTest.Open();
                status = true;
            }
            catch
            {
                status = false;
            }
            finally
            {
                conTest.Close();
            }
            return status;
        }

        public string ReadData()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool;";

            var conTest = new SqliteConnection(connectionStringBuilder.ConnectionString);
            string data;
            try
            {
                conTest.Open();
                data = "";
                var selectCmd=conTest.CreateCommand();
                selectCmd.CommandText = "select * from person;";
                SqliteDataReader rObj = null;
                rObj = selectCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rObj.Read()) 
                {
                    data = "\n" + data + rObj["PersonID"] + " " + rObj["LastName"] + " " + rObj["FirstName"] + " " + rObj["HireDate"] + " " + rObj["EnrollmentDate"] + " " + rObj["Discriminator"];
                }
            }
            catch
            {
                data = "";
            }
            finally
            {
                //conTest.Close();
            }
            return data;
        }
    }
}
