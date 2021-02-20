using System;
using HighSchool.DataAccessLayer;



namespace HighSchool.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TestConnection();
            ReadDatafromDB();
        }

        #region Demo 2

        //01. Demo: Introduction to ADO.NET
        public static void TestConnection()
        {
            Console.Clear();
            DataAccessLayerADO dal = new DataAccessLayerADO();
            if (dal.TestConnection())
            {
                Console.WriteLine("\n\n Connection successful \n");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured \n");
            }
        }

        public static void ReadDatafromDB() 
        {
            DataAccessLayerADO dal = new DataAccessLayerADO();
            if (dal.TestConnection())
            {
                string data1 = dal.ReadDataPerson1();
                string data2 = dal.ReadDataPerson();
                string data = dal.ReadDataRoles();
                Console.WriteLine("\n\n" + data + " \n");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured \n");
            }
        }

        #endregion


    }
}
