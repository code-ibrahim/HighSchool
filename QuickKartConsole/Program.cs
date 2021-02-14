using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HighSchool.DataAccessLayerADO;

namespace QuickKartConsole
{
    class Program
    {

        #region MainMethod

        static void Main(string[] args)
        {
            TestConnection();
            //ValidateUserScalar();
            //Login();
        }

        #endregion

        #region Demo 2

        //01. Demo: Introduction to ADO.NET
        public static void TestConnection()
        {
            Console.Clear();
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.TestConnection())
            {
                Console.WriteLine("\n\n Connection successful \n");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured \n");
            }
        }

        #endregion

        #region Demo 3

        //01. Demo: Working with ExecuteScalar()
        public static void ValidateUserScalar()
        {
            //try
            //{
            //    QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();
            //    Console.Write("\n Please enter your EmailID : ");
            //    string emailId = Console.ReadLine();
            //    Console.Write("\n Please enter your password : ");
            //    string password = Console.ReadLine();
            //    bool result = dal.ValidateUser(emailId, password);
            //    if (result)
            //    {
            //        Console.WriteLine("Login Successful");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Login Failed");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Some error occurred. Please try again.");
            //}
        }

        //02. Working with user-defined functions
        public static int ValidateUser(string emailId, string password)
        {
            //try
            //{
            //    QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();

            //    int roleId = dal.ValidateUser(emailId, password);
            //    return roleId;

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Some error occurred. Please try again.");
            //}
            return -1;
        }

        //03. Login Functionality
        public static void Login()
        {
            try
            {
                string emailId = null;
                string password = null;

                Validation valObj = new Validation();
                while (true)
                {
                    Console.WriteLine("\n*********** Welcome to QuickKart************");
                    Console.WriteLine("\n\t Please login to continue\n");

                    if (valObj.IsEmpty(emailId))
                    {
                        Console.Write("\n\n Please enter your EmailID : ");
                        emailId = Console.ReadLine();

                        if (valObj.IsEmpty(emailId))
                        {
                            Console.WriteLine("\nEmail Id cannot be empty");
                            continue;
                        }
                    }

                    if (valObj.IsEmpty(password))
                    {
                        Console.Write("\n\n Please enter your Password : ");
                        password = Console.ReadLine();

                        if (valObj.IsEmpty(password))
                        {
                            Console.WriteLine("\nPassword cannot be empty");
                            continue;
                        }
                    }

                    int roleId = ValidateUser(emailId, password);

                    #region Admin Options
                    if (roleId == 1)
                    {

                        Console.WriteLine("\n\nYou have logged in as an administrator\n");
                        while (true)
                        {
                            Console.WriteLine("\n****Choose an option number from the menu****\n");
                            Console.WriteLine("1. View Categories");
                            Console.WriteLine("2. Add Category");
                            Console.WriteLine("3. View Products");
                            Console.WriteLine("4. Modify Categories ");

                            Console.Write("\nChoice: ");
                            var choice = Console.ReadLine();

                            int option = -1;
                            if (choice != "")
                            {
                                option = Convert.ToInt32(choice);
                                switch (option)
                                {
                                    case 1:
                                        ShowCategories();
                                        break;
                                    case 2:
                                        AddNewCategory();
                                        break;
                                    case 3:
                                        ViewProducts();
                                        break;
                                    case 4:
                                        ModifyCategory();
                                        break;
                                    default:
                                        Console.WriteLine("Please choose a valid option\n\n");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid menu option.\n\n");
                            }
                        }



                    }
                    #endregion

                    #region Customer Options
                    else if (roleId == 2)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n\n ********Start Shopping with Quick Kart*******\n\n");
                            Console.WriteLine("****Choose an option number from the menu****\n");

                            Console.WriteLine("1. View Categories");
                            Console.WriteLine("2. View all Products");
                            Console.WriteLine("3. View Products of a category");
                            Console.WriteLine("4. Purchase Products");
                            Console.Write("\nChoice: ");

                            var choice = Console.ReadLine();

                            int option = -1;
                            if (choice != "")
                            {
                                option = Convert.ToInt32(choice);
                                switch (option)
                                {
                                    case 1:
                                        ShowCategories();
                                        break;
                                    case 2:
                                        ShowProducts();
                                        break;
                                    case 3:
                                        ViewProducts();
                                        break;
                                    case 4:
                                        PurchaseProduct();
                                        break;
                                    default:
                                        Console.WriteLine("Please choose a valid option\n\n");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid menu option.\n\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\n Login Failed");
                        break;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.Write("Something went wrong!");
            }
        }

        #endregion

        #region Demo4

        // 01. Working with ExecuteReader()
        public static void ShowCategories()
        {
            //QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();
            //SqlDataReader reader = dal.FetchCategories();
            //Console.WriteLine("\n---Available Categories--\n\n");
            //Console.WriteLine("CategoryId    CategoryName");
            //Console.WriteLine("-----------------------------\n");
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("  " + reader["CategoryId"].ToString() + "\t\t" + reader["CategoryName"].ToString());
            //    }
            //}
        }

        #endregion

        #region Demo5

        //01. Working with ExecuteNonQuery()
        public static void AddNewCategory()
        {
            //QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();
            //Validation verObj = new Validation();
            //string categoryName = "";
            //while (true)
            //{
            //    if (categoryName == "")
            //    {
            //        Console.Write("\nPlease enter the Category Name: ");
            //        categoryName = Console.ReadLine();
            //        if (categoryName == "")
            //        {
            //            Console.Write("\nCategory name cannot be NULL");
            //            continue;
            //        }


            //        int status = dal.AddCategory(categoryName);

            //        if (status > 0)
            //        {
            //            Console.WriteLine("\n\nCategory added successfully\n\n");
            //        }
            //        else
            //        {
            //            Console.WriteLine("\n\nSome error occurred, please try again \n");
            //        }

            //        break;
            //    }
            //}
        }

        #endregion

        #region Demo6

        //05. Working with DataAdapter-Fill
        public static void ViewProducts()
        {
        //    Console.Clear();
        //    QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();
        //    Validation verObj = new Validation();
        //    Console.WriteLine("\n------------------View Products----------------\n\n\n");
        //    ShowCategories();
        //c1:
        //    Console.Write("\n\n Please choose a CategoryId: ");
        //    string categoryId = Console.ReadLine();
        //    if (verObj.IsEmpty(categoryId))
        //    {
        //        Console.WriteLine("\n\n Category Id cannot be null");
        //        goto c1;
        //    }
        //    if (!verObj.IsByte(categoryId))
        //    {
        //        Console.WriteLine("\n\n Category Id should be byte");
        //        goto c1;
        //    }
        //    byte cateId = Convert.ToByte(categoryId);
        //    DataTable products = dal.GetProducts(cateId);
        //    Console.WriteLine("\n\n ----Product Details----");
        //    Console.WriteLine("---------------------------------------------");
        //    if (products.Rows.Count != 0)
        //    {
        //        foreach (DataRow row in products.Rows)
        //        {
        //            Console.WriteLine("Product id: " + row["ProductId"].ToString());
        //            Console.WriteLine("Product Name: " + row["ProductName"].ToString());
        //            Console.WriteLine("Quantity: " + row[2].ToString());
        //            Console.WriteLine("Price: " + row[3].ToString());
        //            Console.WriteLine("------------------------------------\n");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Product details not found.... Try again...!!!\n");
        //    }
        }

        #endregion

        #region Demo7

        //01. Modify Category Menu
        private static void ModifyCategory()
        {
            //QuickKartDataAccessLayer.DataAccessLayer dal = new QuickKartDataAccessLayer.DataAccessLayer();
            //DataTable dtCategories = FetchCategorieswithDataAdapter();
            //while (true)
            //{
            //    Console.WriteLine("\nCategoryId\tCategoryName");
            //    Console.WriteLine("---------------------------------------------");
            //    foreach (DataRow row in dtCategories.Rows)
            //    {
            //        // Can't access DataRowState.Deleted rows
            //        if (row.RowState != DataRowState.Deleted)
            //        {
            //            Console.WriteLine(row["CategoryId"].ToString() + "\t" + row["CategoryName"].ToString());
            //        }
            //    }
            //    Console.WriteLine();

            //    Console.WriteLine("Choose one of the following options:");
            //    Console.WriteLine("<Note: you are now working in offline mode, please select 'Save changes' to update the database>");
            //    Console.WriteLine();
            //    int choice = -1;

            //    Console.WriteLine("1. Add a new Category");
            //    Console.WriteLine("2. Edit existing Category");
            //    Console.WriteLine("3. Delete a Category");
            //    Console.WriteLine("4. Save changes");
            //    Console.WriteLine("5. Go to previous Menu");
            //    Console.Write("\nChoice: ");
            //    choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            dtCategories = InsertCategory(dtCategories);
            //            break;
            //        case 2:
            //            dtCategories = UpdateCategory(dtCategories);
            //            break;
            //        case 3:
            //            dtCategories = DeleteCategory(dtCategories);
            //            break;
            //        case 4:
            //            dtCategories = dal.SaveChanges(dtCategories);
            //            if (dtCategories != null)
            //            {
            //                Console.WriteLine("Your changes have been saved in the Database");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Your changes could not be saved in the Database");
            //                continue;
            //            }
            //            break;
            //        case 5:
            //            return;
            //        default:
            //            Console.WriteLine("Invalid choice!");
            //            continue;
            //    }
            //}
        }

        //02. Working with InsertCommand
        private static DataTable InsertCategory(DataTable dtCategories)
        {
            return dtCategories;
        }

        #endregion

        #region Demo8

        //01. Working with UpdateCommand
        private static DataTable UpdateCategory(DataTable dtCategories)
        {
            return dtCategories;
        }

        #endregion

        #region Demo9

        //01. Working with DeleteCommand
        private static DataTable DeleteCategory(DataTable dtCategories)
        {
            return dtCategories;
        }

        #endregion


        #region Exercises

        #region Exercise1

        public static void ShowNewProductID()
        {
            //Console.Clear();
            //DataAccessLayer dal = new DataAccessLayer();
            //Console.WriteLine("\n\n New product id is : " + dal.GenerateNewProductId());
        }

        #endregion

        #region Exercise2

        public static void ShowProducts()
        {
            //DataAccessLayer dal = new DataAccessLayer();
            //SqlDataReader reader = dal.FetchProducts();
            //Console.WriteLine("\n---Available Products--\n\n");
            //Console.WriteLine("ProductId        Price      QuantityAvailable      ProductName");
            //Console.WriteLine("--------------------------------------------------------------------------------\n");
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("  " + reader["ProductId"].ToString() + "\t\t" + reader["Price"].ToString() + "\t\t" + reader["QuantityAvailable"].ToString() + "\t\t" + reader["ProductName"].ToString());
            //    }
            //}
        }

        #endregion

        #region Exercise3

        public static void PurchaseProduct()
        {
            //    Console.Clear();
            //    DataAccessLayer dal = new DataAccessLayer();
            //    //ViewProducts();
            //    Console.WriteLine("\n------------------Purchase Products----------------\n\n");
            //    Console.WriteLine("\n\n---Please enter the Purchase details---\n");
            //    Validation valObj = new Validation();
            //c1:
            //    Console.Write("\n\n Please enter your EmailID : ");
            //    string emailId = Console.ReadLine();
            //    if (valObj.IsEmpty(emailId))
            //    {
            //        Console.WriteLine("\nEmail Id cannot be NULL");
            //        goto c1;

            //    }
            //c2:
            //    Console.Write("\n Please enter the product Id: ");
            //    string productId = Console.ReadLine();
            //    if (valObj.IsEmpty(productId))
            //    {
            //        Console.WriteLine("\nProduct Id cannot be NULL");
            //        goto c2;

            //    }
            //c3:
            //    Console.Write("\n Please enter the quantity: ");
            //    string qty = Console.ReadLine();
            //    if (valObj.IsEmpty(qty))
            //    {
            //        Console.WriteLine("\nQuantity cannot be NULL");
            //        goto c3;

            //    }
            //    if (!valObj.IsInteger(qty))
            //    {
            //        Console.WriteLine("\nQuantity should be integer datatype");
            //        goto c3;

            //    }
            //    if (!valObj.ValidateGreaterThanZero(qty))
            //    {
            //        Console.WriteLine("\nQuantity should be greater than zero");
            //        goto c3;

            //    }
            //    int quantity = Convert.ToInt32(qty);
            //    long purchaseId = 0;
            //    int result = dal.PurchaseProduct(emailId, productId, quantity, out purchaseId);
            //    if (result == 1)
            //    {
            //        Console.WriteLine("\n\n You have successfully purchased this product. The purchase Id is : " + purchaseId + "\n");
            //    }
            //    else if (result == -1)
            //    {
            //        Console.WriteLine("\n\n Email id can't be null \n");
            //    }
            //    else if (result == -2)
            //    {
            //        Console.WriteLine("\n\n Email id is not valid \n");
            //    }
            //    else if (result == -3)
            //    {
            //        Console.WriteLine("\n\n Product id can't be null \n");
            //    }
            //    else if (result == -4)
            //    {
            //        Console.WriteLine("\n\n Product id is not valid \n");
            //    }
            //    else if (result == -5)
            //    {
            //        Console.WriteLine("\n\n Quantity is not valid \n");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\n\n Some error occured..please try again \n");
            //    }
        }

        #endregion

        #region Exercise4

        public static void UpdateBalance()
        {
        //    Console.Clear();
        //    DataAccessLayer dal = new DataAccessLayer();
        //    Validation valObj = new Validation();
        //    Console.WriteLine("\n------------------Update Balance----------------\n\n");
        //c1:
        //    Console.Write("\n Please enter the card number: ");
        //    string cno = Console.ReadLine();
        //    if (valObj.IsEmpty(cno))
        //    {
        //        Console.WriteLine("\nCard number Id cannot be NULL");
        //        goto c1;

        //    }
        //    if (!valObj.IsLong(cno))
        //    {
        //        Console.WriteLine("\nCard number should be int64 data type");
        //        goto c1;

        //    }
        //    Int64 cardNumber = Convert.ToInt64(cno);
        //c2:
        //    Console.Write("\n Please enter the name on card: ");
        //    string nameOnCard = Console.ReadLine();
        //    if (valObj.IsEmpty(nameOnCard))
        //    {
        //        Console.WriteLine("\nName on card cannot be NULL");
        //        goto c2;

        //    }
        //c3:
        //    Console.Write("\n Please enter the card type: ");
        //    string cardType = Console.ReadLine();
        //    if (valObj.IsEmpty(cardType))
        //    {
        //        Console.WriteLine("\nCard type cannot be NULL");
        //        goto c3;

        //    }
        //c4:
        //    Console.Write("\n Please enter the CVV number: ");
        //    string cvNo = Console.ReadLine();
        //    if (valObj.IsEmpty(cvNo))
        //    {
        //        Console.WriteLine("\nCVV number cannot be NULL");
        //        goto c4;

        //    }
        //    if (!valObj.IsInt16(cvNo))
        //    {
        //        Console.WriteLine("\nCVV number should be Int16 data type");
        //        goto c4;

        //    }
        //    Int16 cvvNo = Convert.ToInt16(cvNo);
        //c5:
        //    Console.Write("\n Please enter the expiry date: ");
        //    string date = Console.ReadLine();
        //    if (valObj.IsEmpty(date))
        //    {
        //        Console.WriteLine("\nExpiry date cannot be NULL");
        //        goto c5;

        //    }
        //    if (!valObj.IsDate(date))
        //    {
        //        Console.WriteLine("\nExpiry date should be date data type");
        //        goto c5;

        //    }

        //    DateTime expiryDate = Convert.ToDateTime(date);
        //c6:
        //    Console.Write("\n Please enter the price: ");
        //    string pri = Console.ReadLine();

        //    if (valObj.IsEmpty(pri))
        //    {
        //        Console.WriteLine("\nPrice cannot be NULL");
        //        goto c6;

        //    }
        //    if (!valObj.IsDecimal(pri))
        //    {
        //        Console.WriteLine("\nPrice should be decimal datatype");
        //        goto c6;

        //    }
        //    if (!valObj.ValidateGreaterThanZero(pri))
        //    {
        //        Console.WriteLine("\nPrice should be greater than zero");
        //        goto c6;

        //    }
        //    decimal price = Convert.ToDecimal(pri);
        //    int result = Convert.ToInt32(dal.UpdateBalance(cardNumber, nameOnCard, cardType, cvvNo, expiryDate, price));
        //    if (result == 1)
        //    {
        //        Console.WriteLine("\n\n Balance updated successfully \n");
        //    }
        //    else if (result == -1)
        //    {
        //        Console.WriteLine("\n\n Card number can't be null \n");
        //    }
        //    else if (result == -2)
        //    {
        //        Console.WriteLine("\n\n The card is not valid \n");
        //    }
        //    else if (result == -3)
        //    {
        //        Console.WriteLine("\n\n The name on card is not valid \n");
        //    }
        //    else if (result == -4)
        //    {
        //        Console.WriteLine("\n\n The card type is not valid \n");
        //    }
        //    else if (result == -5)
        //    {
        //        Console.WriteLine("\n\n The CVV number is not valid \n");
        //    }
        //    else if (result == -6)
        //    {
        //        Console.WriteLine("\n\n The expiry date is not valid \n");
        //    }
        //    else if (result == -7)
        //    {
        //        Console.WriteLine("\n\n Insufficient balance \n");
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n\n Some error occured..please try again \n");
        //    }
        }

        #endregion

        #region Exercise5

        public static void ViewCategories()
        {
            //Console.Clear();
            //DataAccessLayer dal = new DataAccessLayer();
            //Console.WriteLine("\n------------------View Categories----------------\n\n");
            //DataTable categories = dal.FetchCategorieswithDataAdapter();
            //Console.WriteLine("\n\n ----Category Details----");
            //Console.WriteLine("---------------------------------------------");
            //if (categories.Rows.Count != 0)
            //{
            //    foreach (DataRow row in categories.Rows)
            //    {
            //        Console.WriteLine("Category id: " + row["CategoryId"].ToString());
            //        Console.WriteLine("Category Name: " + row["CategoryName"].ToString());
            //        Console.WriteLine("------------------------------------\n");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("\nCategory details not found.... Try again...!!!\n");
            //}
        }

        #endregion

        #endregion
    }
}
