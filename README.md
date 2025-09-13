# Chatbox-Order-Tracker-Capstone-

📌 Overview 
This is my capstone project, a chatbot designed to provide order status and delivery updates for a hospital print center. Users can enter their order number, and the bot retrieves delivery details from a real-time MySQL database.

ℹ️ Note: This README provides a project overview and setup guide.  
> A more detailed README for the **chatbox code** is included in the repository files.

💻 **Tech stack:** 
- C#, Visual Basic
-.NET Framework (Echobot .NET)
- MySQL (database + dump file provided)
- Bot Framework v4 (Microsoft)
- Visual Studio 2019
- Bot Framework Emulator
    
🚀 Features 
- An interactive chatbot that asks for order numbers.
- Pulls customer and delivery data directly from MySQL.
- Supports debugging and testing via Bot Framework Emulator.
- Designed to simulate a real-world hospital print center use case.
  
⚙️ Setup Instructions (Custom) To run this project locally, you’ll need: 
- Visual Studio 2019
- Bot Framework v4 Emulator
- Bot Framework v4 SDK (Framework 5.0 for compatibility with VS2019 + MySQL)
- MySQL Workbench 8.0 ### Database Setup
- Import the provided **dump file** into MySQL.
- This creates sample tables with customer and driver information.
- ### Connection String The connection string is located under Dialogs/Operations/CheckOrderDialog.
- Default configuration:
csharp
string connectionString = 
"Server=localhost;Port=3306;Database=your_database_name;User Id=root;Password=password;";
You can adjust only the port/username/password as needed. Default port: 3306.

Running the Bot
Open the solution in Visual Studio.

At the top bar, choose CoreBot (not IIS Express).

Press Debug/Run → a browser window will open with “Your Bot is Ready.”

Copy the URL from that page into the Bot Framework Emulator.

In the Emulator, start chatting with the bot and test with sample order numbers from the database.

🧠 Bot Framework Capabilities
This project extends the Bot Framework v4 Core Bot Sample. It demonstrates:

Using LUIS for AI-driven natural language understanding.

Multi-turn conversations with Dialogs.

Handling interruptions (Help, Cancel).

Prompting and validating user input.

Prerequisites for LUIS
.NET SDK 6.0

Azure CLI

LUIS App setup with LuisAppId, LuisAPIKey, and LuisAPIHostName in appsettings.json.

🧪 Testing the Bot
Install Bot Framework Emulator (v4.5.0 or later).

Open the bot in the Emulator using URL:

bash
Copy code
http://localhost:3978/api/messages
☁️ Deployment
This bot can be deployed to Azure Bot Service for production use.
See: Deploy your bot to Azure.

🎯 Lessons Learned
Bridging frontend chatbot simulators with backend databases.

Designing conversational flows and handling user input.

Deploying and testing bots with Microsoft’s Bot Framework.

👩‍💻 Author
Destiny M. Rhodes
