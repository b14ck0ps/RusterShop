# Food Collection and Distribution Management System for NGOs

The Food Collection and Distribution Management System for NGOs is a web application designed to automate and track the process of collecting and distributing unused food from restaurants in Dhaka city. This system allows restaurants to open a collection request for food they want to donate, with an expiration date for the food. The NGO will then assign an employee to collect the food and distribute it to those in need. The system also tracks all collection requests and their details.

## Technologies Used
- .NET Framework 4.8.1
- Bootstrap 5
- Microsoft SQL Server

## Features
- NGOs can manage their information in the system.
- Restaurants can open a collection request for food they want to donate, with an expiration date for the food.
- Employees can manage their information in the system.
- Employees can be assigned to collect and distribute food.
- The system tracks all collection requests and their details, such as the restaurant, the expiration date of the food, and the assigned employee.
- The system tracks the food that has been collected, such as the quantity and the date of collection.
- The system tracks the food that has been distributed, such as the recipient and the date of distribution.

## Database Schema
- NGOs: contains details about the NGO
- Restaurants: contains details about the restaurants that donate food
- Employees: contains details about the employees who collect and distribute food
- Food Collection Requests: contains details about the food collection requests, such as the restaurant, the expiration date of the food, and the assigned employee
- Collected Food: contains details about the food that has been collected, such as the quantity and the date of collection
- Food Distribution: contains details about the food that has been distributed, such as the recipient and the date of distribution.

## Installation and Setup
To install and run this application, follow these steps:
1. Clone the repository: `git clone https://github.com/b14ck0ps/WasteFoodManagementSystem.git`
2. Open the solution in Visual Studio.
3. Change the connection string in the `Web.config` file to point to your Microsoft SQL Server instance.
4. Build and run the application in Visual Studio.


