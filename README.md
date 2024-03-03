# Parking Management System - ParkNet
This is a system developed in ASP.NET 8 for the integrated management of parking lots by ParkNet, a service company. The system allows clients to perform operations such as registration, purchase of passes, balance loading, and activity history checking. The administrator has additional functionalities for managing parking lots, clients, and pricing.

## ⚠️ ATTENTION 




❗️ 1.  Ensure that the database connection strings in the project are configured correctly according to your local setup.
>**Database Connection**:
The application is configured to use a local SQL Server database via the connection string specified in the environment variable or in the _appsettings.json_ file. Ensure that the connection string is correctly configured to point to your local SQL Server instance. If you wish to use a different local database, you will need to modify the connection string in the _appsettings.json_ file accordingly.

By following these steps, you should be able to clone the project, run it locally, and access the ParkNet application through your web browser.

❗️ 2. When starting the program for the first time, you need to register an Admin account with the following Email: 'admin@parknet.com'

❗️ 3. When the Admin is creating the 'Permit Pariff', make sure you specify the Vehicle Type ('C' for Car and 'M' for Motorbike), the Permit type (Daily, Weekly, Montlhy or Anual) and its respective price.

See an example of the recommended format below:

### ' Car - Daily Permit | 2€ '

______________________________________________________________________

## Also note that:

- The 'Withdraw' button in 'Balance - Transactions' will only appear if the customer logged in doesn't have any Permit currently active or if its Balance is above 0€

- As I restarted this project but used the same git folder, on GitHub it appears two projects, but when it repository is pulled, it will pull only one folder and it will run normally on the machine.
______________________________________________________________________
## Technologies

- Git
- Drawio
- Visual Studio
- SQL Management Studio
- ASP.NET 8 (Razor Pages Framework)

## Database - Diagram
⚠️ This Diagram doesn't represent the Database layout used for final version of this project but it displayed here for evaluation purposes for the project presentation.

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
