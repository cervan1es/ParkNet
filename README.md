# Parking Management System - ParkNet
This is a system developed in ASP.NET 8 for the integrated management of parking lots by ParkNet, a service company. The system allows clients to perform operations such as registration, purchase of passes, balance loading, entry/exit from parking lots, and activity history checking. The administrator has additional functionalities for managing parking lots, clients, and pricing.

## Technologies

- Git
- Drawio
- Visual Studio
- SQL Management Studio
- ASP.NET 8 (Razor Pages Framework)

## Database - Diagram
![Entities Organization](https://github.com/cervan1es/ParkNet/blob/main/Assets/Diagram%20Update.PNG?raw=true)

## Key Features
### Client
1. Registration and Login: Clients can register and log in to the system by presenting a valid driver's license and credit card.
2. Purchase of Passes: Possibility to purchase monthly, quarterly, semi-annual, or annual passes in specific parking lots.
3. Balance Loading and Withdrawal: Clients can load and withdraw balance at any time, with withdrawal restriction if they have their car parked without a pass.
4. Entry/Exit from Parking Lots: Upon entering a parking lot, the client chooses the desired spot and payment is automatically processed upon exit.
5. Activity History Checking: Clients can check the history of all their activities.

### Administrator

1. Parking Lot Management: Registration of new parking lots, editing relevant information, and importing parking lot layouts through text files.
2. Client Management: Consultation of client records and possibility of sending emails, for example, when the balance is negative.
3. Profit Checking: Viewing profits grouped by period.
4. Pricing Management: Changes in pricing for passes and parking spots for each parking lot.

### Implementation

- ASP.NET 8: Used as the primary framework for development.
- Entity Framework: Used as an ORM for data access and update.
- Repository/Service Pattern: Code organization for separation of concerns.
- Testing: Test project to validate parking pricing and parking lot import.
- Git Repository: GitHub repository for version control of the code.
- Logging: Implementation of logging for recording exceptions and critical information.

## Running the Project

To run the project locally, follow these instructions:

### Prerequisites

Make sure you have the following installed on your machine:

- .NET SDK compatible with ASP.NET 8.
- Git for version control.

### Steps
If using Visual Studio, simply open the project soluction

If using Terminal:

1. **Clone the Repository**: `git clone https://github.com/yourusername/parknet.git`

2. **Navigate to the Project Directory**: `cd parknet/ParkNet_Ricardo.Campos`

3. **Run the Application**: `dotnet run`

4. **Access the Application**:
Once the application is running, open your web browser and go to http://localhost:7063 to access the ParkNet application.

6. **Stop the Application**:
To stop the application, press Ctrl + C in the terminal where the application is running.

## Additional Notes

- Ensure that the database connection strings in the project are configured correctly according to your local setup.
>**Database Connection**:
The application is configured to use a local SQL Server database via the connection string specified in the environment variable or in the _appsettings.json_ file. Ensure that the connection string is correctly configured to point to your local SQL Server instance. If you wish to use a different local database, you will need to modify the connection string in the _appsettings.json_ file accordingly.
- For advanced usage or deployment, refer to the official documentation of ASP.NET and Entity Framework.

By following these steps, you should be able to clone the project, run it locally, and access the ParkNet application through your web browser.
