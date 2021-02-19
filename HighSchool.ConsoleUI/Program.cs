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
            Class1 dal = new Class1();
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
            Class1 dal = new Class1();
            if (dal.TestConnection())
            {
                string data1 = dal.ReadDataPerson1();
                string data = dal.ReadDataPerson();
                Console.WriteLine("\n\n " + data + " \n");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured \n");
            }
        }

        #endregion


    }
}
