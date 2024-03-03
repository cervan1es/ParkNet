# Parking Management System - ParkNet
This is a system developed in ASP.NET 8 for the integrated management of parking lots by ParkNet, a service company. The system allows clients to perform operations such as registration, purchase of passes, balance loading, and activity history checking. The administrator has additional functionalities for managing parking lots, clients, and pricing.

⚠️ ATTENTION ⚠️


When starting the program for the first time, you need to register an Admin account with the following Email: 'admin@parknet.com'

- Ensure that the database connection strings in the project are configured correctly according to your local setup.
>**Database Connection**:
The application is configured to use a local SQL Server database via the connection string specified in the environment variable or in the _appsettings.json_ file. Ensure that the connection string is correctly configured to point to your local SQL Server instance. If you wish to use a different local database, you will need to modify the connection string in the _appsettings.json_ file accordingly.

By following these steps, you should be able to clone the project, run it locally, and access the ParkNet application through your web browser.


## Technologies

- Git
- Drawio
- Visual Studio
- SQL Management Studio
- ASP.NET 8 (Razor Pages Framework)

## Database - Diagram
![Entities Organization](https://github.com/cervan1es/ParkNet/blob/main/Assets/ParkNetDiagram.png?raw=true)

## Key Features
### Client
1. Registration and Login: Clients can register and log in to the system by presenting a valid driver's license and credit card.
2. Purchase of Passes: Possibility to purchase monthly, quarterly, semi-annual, or annual passes in specific parking lots.
3. Balance Loading and Withdrawal: Clients can load and withdraw balance at any time, with withdrawal restriction if they have their car parked without a pass.
4. Activity History Checking: Clients can check the history of all their activities.

### Administrator

1. Parking Lot Management: Registration of new parking lots, editing relevant information, and importing parking lot layouts through text files.
2. Profit Checking: Viewing profits grouped by period.
3. Pricing Management: Changes in pricing for passes and parking spots for each parking lot.

### Implementation

- ASP.NET 8: Used as the primary framework for development.
- Entity Framework: Used as an ORM for data access and update.
- Repository/Service Pattern: Code organization for separation of concerns.
- Git Repository: GitHub repository for version control of the code.

## Running the Project

To run the project locally, follow these instructions:


### Steps
If using Visual Studio, simply open the project soluction

If using Terminal:

1. **Clone the Repository**: `git clone https://github.com/yourusername/parknet.git`

2. **Navigate to the Project Directory**: `cd parknet/PARKNET`

3. **Run the Application**: `dotnet run`

4. **Access the Application**:
Once the application is running, open your web browser and go to http://localhost:7232 to access the ParkNet application.

6. **Stop the Application**:
To stop the application, press Ctrl + C in the terminal where the application is running.

## Additional Notes


