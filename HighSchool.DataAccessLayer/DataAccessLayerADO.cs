using System;
using Microsoft.Data.Sqlite;
using System.Data;

namespace HighSchool.DataAccessLayer
{
    public class DataAccessLayerADO
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

        public string ReadDataPerson1()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool";

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
                    data = data + rObj["PersonID"] + " " + rObj["FirstName"] + " " + rObj["LastName"] + " " + rObj["UserPassword"] + " " + rObj["RoleId"] + " " + rObj["Gender"] + " " + rObj["DateOfBirth"] + " " + rObj["Address"] + "\n";
                }
            }
            catch(Exception ex)
            {
                data = "";
            }
            finally
            {
                //conTest.Close();
            }
            return data;
        }


        public string ReadDataPerson()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool";

            var conTest = new SqliteConnection(connectionStringBuilder.ConnectionString);
            string data = "";
            try
            {
                DataTable dtObj = new DataTable();
                var conStingBuilder = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                conStingBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool";
                var conObj = new System.Data.SQLite.SQLiteConnection(conStingBuilder.ConnectionString);
                //System.Data.SQLite.SQLiteConnection conObj = new System.Data.SQLite.SQLiteConnection();
                System.Data.SQLite.SQLiteCommand cmdObj = new System.Data.SQLite.SQLiteCommand("select * from person;", conObj);
                //SqliteDataAdapter daObj;
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(cmdObj);
                dAdapter.Fill(dtObj);

                foreach (DataRow i in dtObj.Rows)
                {
                    data = data + i["PersonID"] + " " + i["FirstName"] + " " + i["LastName"] + " " + i["UserPassword"] + " " + i["RoleId"] + " " + i["Gender"] + " " + i["DateOfBirth"] + " " + i["Address"] + "\n";
                }


                //conTest.Open();
                //data = "";
                //var selectCmd = conTest.CreateCommand();
                //selectCmd.CommandText = "select * from person;";
                //SqliteDataReader rObj = null;
                //rObj = selectCmd.ExecuteReader(CommandBehavior.CloseConnection);
                //while (rObj.Read())
                //{
                //    data = "\n" + data + rObj["PersonID"] + " " + rObj["FirstName"] + " " + rObj["LastName"] + " " + rObj["UserPassword"] + " " + rObj["RoleId"] + " " + rObj["Gender"] + " " + rObj["DateOfBirth"] + " " + rObj["Address"];
                //}
            }
            catch(Exception ex)
            {
                data = "";
            }
            finally
            {
                //conTest.Close();
            }
            return data;
        }


        public string ReadDataRoles()
        {
            string data = "";
            try
            {
                DataTable dtObj = new DataTable();
                var conStingBuilder = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                conStingBuilder.DataSource = "C:/Users/INDIAN/Documents/DB/HighSchool";
                var conObj = new System.Data.SQLite.SQLiteConnection(conStingBuilder.ConnectionString);
                //System.Data.SQLite.SQLiteConnection conObj = new System.Data.SQLite.SQLiteConnection();
                System.Data.SQLite.SQLiteCommand cmdObj = new System.Data.SQLite.SQLiteCommand("select * from roles;", conObj);
                //SqliteDataAdapter daObj;
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(cmdObj);
                dAdapter.Fill(dtObj);

                foreach (DataRow i in dtObj.Rows)
                {
                    data = data + i["RoleId"] + " " + i["RoleName"] + "\n";
                }

            }
            catch (Exception ex)
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
