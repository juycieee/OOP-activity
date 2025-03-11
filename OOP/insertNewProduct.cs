using System;
using MySql.Data.MySqlClient;

namespace OOP
{
    class ManageProduct
    {
        public class InsertNewProduct
        {
            private string server = "localhost";
            private string database = "products";
            private string username = "products";
            private string password = "";
            private string connString;
            private bool isConnected = false;  // Flag to track connection
            private bool hasRowLimitError = false; // Flag to track if row limit error has been shown
            private const int MaxRows = 10;  // Maximum rows limit for the database

            public InsertNewProduct()
            {
                connString = $"Server={server};Database={database};User ID={username};Password={password};";
            }

            public void InsertData(string productName, int productPrice, string productDescription)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        // Check if connected, only display this message once
                        if (!isConnected)
                        {
                            Console.WriteLine("Connected to MySQL!");
                            isConnected = true;
                        }

                        // Check the current number of rows in the database
                        string countQuery = "SELECT COUNT(*) FROM products";
                        using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                        {
                            int rowCount = Convert.ToInt32(countCmd.ExecuteScalar());

                            // If the row count exceeds MaxRows, we skip the insertion and display the error
                            if (rowCount >= MaxRows)
                            {
                                if (!hasRowLimitError)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\r\n╔═╗┬─┐┬─┐┌─┐┬─┐                               \r\n║╣ ├┬┘├┬┘│ │├┬┘                               \r\n╚═╝┴└─┴└─└─┘┴└─                               \r\n╦┌┐┌┌─┐┌─┐┬─┐┌┬┐  ┌─┐┌─┐┬┬  ┌─┐┌┬┐            \r\n║│││└─┐├┤ ├┬┘ │   ├┤ ├─┤││  ├┤  ││            \r\n╩┘└┘└─┘└─┘┴└─ ┴   └  ┴ ┴┴┴─┘└─┘─┴┘            \r\n╔╦╗┌─┐─┐ ┬┬┌┬┐┬ ┬┌┬┐  ┬─┐┌─┐┬ ┬  ┬  ┬┌┬┐┬┌┬┐  \r\n║║║├─┤┌┴┬┘│││││ ││││  ├┬┘│ ││││  │  │││││ │   \r\n╩ ╩┴ ┴┴ └─┴┴ ┴└─┘┴ ┴  ┴└─└─┘└┴┘  ┴─┘┴┴ ┴┴ ┴   \r\n┌┬┐┌─┐┌┐┌  ┬─┐┌─┐┌─┐┌─┐┬ ┬┌─┐┌┬┐┬             \r\n │ ├┤ │││  ├┬┘├┤ ├─┤│  ├─┤├┤  │││             \r\n ┴ └─┘┘└┘  ┴└─└─┘┴ ┴└─┘┴ ┴└─┘─┴┘o             \r\n");
                                    hasRowLimitError = true; // Set the flag to true to avoid repeating the error
                                }
                                return;  // Exit the method early since row limit is reached
                            }
                        }

                        string query = "INSERT INTO products (productName, productPrice, productDescription) VALUES (@name, @price, @description) ";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", productName);
                            cmd.Parameters.AddWithValue("@price", productPrice);
                            cmd.Parameters.AddWithValue("@description", productDescription);

                            int rowsAffected = cmd.ExecuteNonQuery();


                            // Only display the success message once
                            if (rowsAffected >= 1 && rowsAffected <= 10)
                            {
                                Console.Clear();
                                Console.WriteLine("\r\n██████╗  █████╗ ████████╗ █████╗     ██╗███╗   ██╗███████╗███████╗██████╗ ████████╗███████╗██████╗  \r\n██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗    ██║████╗  ██║██╔════╝██╔════╝██╔══██╗╚══██╔══╝██╔════╝██╔══██╗ \r\n██║  ██║███████║   ██║   ███████║    ██║██╔██╗ ██║███████╗█████╗  ██████╔╝   ██║   █████╗  ██║  ██║ \r\n██║  ██║██╔══██║   ██║   ██╔══██║    ██║██║╚██╗██║╚════██║██╔══╝  ██╔══██╗   ██║   ██╔══╝  ██║  ██║ \r\n██████╔╝██║  ██║   ██║   ██║  ██║    ██║██║ ╚████║███████║███████╗██║  ██║   ██║   ███████╗██████╔╝ \r\n╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝    ╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═════╝  \r\n███████╗██╗   ██╗ ██████╗ ██████╗███████╗███████╗███████╗███████╗██╗   ██╗██╗     ██╗  ██╗   ██╗    \r\n██╔════╝██║   ██║██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██║   ██║██║     ██║  ╚██╗ ██╔╝    \r\n███████╗██║   ██║██║     ██║     █████╗  ███████╗███████╗█████╗  ██║   ██║██║     ██║   ╚████╔╝     \r\n╚════██║██║   ██║██║     ██║     ██╔══╝  ╚════██║╚════██║██╔══╝  ██║   ██║██║     ██║    ╚██╔╝      \r\n███████║╚██████╔╝╚██████╗╚██████╗███████╗███████║███████║██║     ╚██████╔╝███████╗███████╗██║       \r\n╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝╚══════╝╚══════╝╚══════╝╚═╝      ╚═════╝ ╚══════╝╚══════╝╚═╝       \r\n██╗    ██╗██╗████████╗██╗  ██╗██╗███╗   ██╗    ██████╗  █████╗ ███╗   ██╗ ██████╗ ███████╗██╗       \r\n██║    ██║██║╚══██╔══╝██║  ██║██║████╗  ██║    ██╔══██╗██╔══██╗████╗  ██║██╔════╝ ██╔════╝██║       \r\n██║ █╗ ██║██║   ██║   ███████║██║██╔██╗ ██║    ██████╔╝███████║██╔██╗ ██║██║  ███╗█████╗  ██║       \r\n██║███╗██║██║   ██║   ██╔══██║██║██║╚██╗██║    ██╔══██╗██╔══██║██║╚██╗██║██║   ██║██╔══╝  ╚═╝       \r\n╚███╔███╔╝██║   ██║   ██║  ██║██║██║ ╚████║    ██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗██╗       \r\n ╚══╝╚══╝ ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝       \r\n                                                                                                    \r\n");
                            }
                            else
                            {
                                Console.WriteLine("\r\n██████╗  █████╗ ████████╗ █████╗     ██╗███╗   ██╗███████╗███████╗██████╗ ████████╗██╗ ██████╗ ███╗   ██╗    \r\n██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗    ██║████╗  ██║██╔════╝██╔════╝██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║    \r\n██║  ██║███████║   ██║   ███████║    ██║██╔██╗ ██║███████╗█████╗  ██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║    \r\n██║  ██║██╔══██║   ██║   ██╔══██║    ██║██║╚██╗██║╚════██║██╔══╝  ██╔══██╗   ██║   ██║██║   ██║██║╚██╗██║    \r\n██████╔╝██║  ██║   ██║   ██║  ██║    ██║██║ ╚████║███████║███████╗██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║    \r\n╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝    ╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    \r\n ██████╗ ██╗   ██╗████████╗     ██████╗ ███████╗    ██████╗  █████╗ ███╗   ██╗ ██████╗ ███████╗              \r\n██╔═══██╗██║   ██║╚══██╔══╝    ██╔═══██╗██╔════╝    ██╔══██╗██╔══██╗████╗  ██║██╔════╝ ██╔════╝              \r\n██║   ██║██║   ██║   ██║       ██║   ██║█████╗      ██████╔╝███████║██╔██╗ ██║██║  ███╗█████╗                \r\n██║   ██║██║   ██║   ██║       ██║   ██║██╔══╝      ██╔══██╗██╔══██║██║╚██╗██║██║   ██║██╔══╝                \r\n╚██████╔╝╚██████╔╝   ██║       ╚██████╔╝██║         ██║  ██║██║  ██║██║ ╚████║╚██████╔╝███████╗              \r\n ╚═════╝  ╚═════╝    ╚═╝        ╚═════╝ ╚═╝         ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝              \r\n ██████╗ ██████╗     ███████╗ █████╗ ██╗██╗     ███████╗██████╗                                              \r\n██╔═══██╗██╔══██╗    ██╔════╝██╔══██╗██║██║     ██╔════╝██╔══██╗                                             \r\n██║   ██║██████╔╝    █████╗  ███████║██║██║     █████╗  ██║  ██║                                             \r\n██║   ██║██╔══██╗    ██╔══╝  ██╔══██║██║██║     ██╔══╝  ██║  ██║                                             \r\n╚██████╔╝██║  ██║    ██║     ██║  ██║██║███████╗███████╗██████╔╝██╗                                          \r\n ╚═════╝ ╚═╝  ╚═╝    ╚═╝     ╚═╝  ╚═╝╚═╝╚══════╝╚══════╝╚═════╝ ╚═╝                                          \r\n                                                                                                             \r\n");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
