using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Threading.Tasks;

//Code when the customer clicks on the check order button

namespace Capstone_ChatBot.Dialogs.Operations
{
    public class CheckOrderDialog : ComponentDialog
    {//My connection string I use for MySQL. You might have to change some items to fit yours. 
        private readonly string connectionString = "Server=localhost;Port=3306;Database=printshopordersinfo;User=root;Password=password;SslMode=none";

        public CheckOrderDialog() : base(nameof(CheckOrderDialog))
        {
            var waterfallSteps = new WaterfallStep[]
            {
                async (stepContext, cancellationToken) =>
                {
                    return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions
                    {
                        Prompt = MessageFactory.Text("Please enter your order number:")
                    }, cancellationToken);
                },

              

      async (stepContext, cancellationToken) =>
    {
        //Fetch order number
        var orderNumber = stepContext.Result.ToString();

        // Fetch customer name based on order number
        var customerName = GetCustomerNameFromDatabase(orderNumber);
        await stepContext.Context.SendActivityAsync(MessageFactory.Text($"Hello, {customerName}!"), cancellationToken);

        //Fetch Order Status based on order number
        var orderStatus = GetOrderStatusFromDatabase(orderNumber);
        await stepContext.Context.SendActivityAsync(MessageFactory.Text($"Your order status is the following: {orderStatus}"), cancellationToken);

        // Add logic to retrieve printing stage and driver information based on delivery location
        var deliveryLocation = GetLocationFromDatabase(orderNumber);

        //Fetch printing information
        var printingInfo = GetPrintingInfoFromDatabase(deliveryLocation);
        await stepContext.Context.SendActivityAsync(MessageFactory.Text(printingInfo), cancellationToken);

        //Fetch location and drivers infomation
        var location = GetLocationFromDatabase(orderNumber);
        var driverInfo = GetDriverInfoFromDatabase(location);
        await stepContext.Context.SendActivityAsync(MessageFactory.Text(driverInfo), cancellationToken);

        return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
    }
};



            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new TextPrompt(nameof(TextPrompt)));

            InitialDialogId = nameof(WaterfallDialog);
        }

        //Retrieve customer name to greet them
        private string GetCustomerNameFromDatabase(string orderNumber)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `CustomerName` FROM `customesprintorder` WHERE `OrderNumber` = @Ordernumber", connection))
                {
                    command.Parameters.AddWithValue("@Ordernumber", orderNumber);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["CustomerName"].ToString();
                        }
                    }
                }
            }

            return "Customer Name Not Found";
        }

        //Order status information retrieved print out info
        private string GetOrderStatusFromDatabase(string orderNumber)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `PrintStatus` FROM `customesprintorder` WHERE `OrderNumber` = @OrderNumber", connection))
                {
                    command.Parameters.AddWithValue("@OrderNumber", orderNumber);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return $"Your Print Status is:  {reader["PrintStatus"].ToString()}";
                        }
                    }
                }
            }

            return "Order Not Found";
        }

        //Get the location of where the job will be shipped print out info
        private string GetLocationFromDatabase(string orderNumber)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `Location` FROM `customesprintorder` WHERE `OrderNumber` = @OrderNumber", connection))
                {
                    command.Parameters.AddWithValue("@OrderNumber", orderNumber);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Location"].ToString();
                        }
                    }
                }
            }

            return null; // Handle appropriately if location is not found
        }

        //To get the printing information that include location and status print out info
        private string GetPrintingInfoFromDatabase(string location)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `PrintStatus` FROM `customesprintorder` WHERE `Location` = @Location", connection))
                {
                    command.Parameters.AddWithValue("@Location", location);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return $"Print Status Location: {location}, \n {reader["PrintStatus"].ToString()}";
                        }
                    }
                }
            }

            return "Printing information not found for the given location.";
        }

        //Code to retrieve the Drivers information print out info
        private string GetDriverInfoFromDatabase(string location)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT `DriversName`, `DriversNumber` FROM `driversinfo` WHERE `Location` = @Location", connection))
                {
                    command.Parameters.AddWithValue("@Location", location);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string driverName = reader["DriversName"].ToString();
                            string driverNumber = reader["DriversNumber"].ToString();

                            return $"Driver Information for the following: \nLocation {location}, \nDriver's Name - {driverName}, \nCall the following number to get in contact with your driver: 777-{driverNumber}";
                        }
                    }
                }
            }

            return "Driver information not found for the given location.";
        }
    }
}