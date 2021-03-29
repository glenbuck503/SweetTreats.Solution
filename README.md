# Sweet Treats

<div align="center">
<img src="https://github.com/glenbuck503.png" width="200px" height="auto" >
</div>
<br>
<br>
<br>

#### 

#### By Glen Buck

## Description
This MVC webpage will present it's user with a splash screen with displays of all "Flavors" and "Treats" available. All CRUD functionality is present for both Treats and Flavors data and options are presented in an explorable fashion on the webpage. A user can also register and login into their own personal accounts using passwords. Only logged in users are able to utilize Create, Update, or Delete functionality of classes.

## Setup/Installation Requirements

Repository: https://github.com/glenbuck503/SweetTreats.Solution.git
1. In your terminal of choice or [GitHub's Desktop Application](https://desktop.github.com/) , clone the above repository from Github. For further explanation on how to clone this repository, please visit [GitHub's Documentation](https://docs.github.com/en/github/using-git/which-remote-url-should-i-use).
2. Ensure you are running .NET Core SDK by using the command dotnet --version in your terminal. If a version number is not presented, please visit [this download page for .NET 5 and install the applicable software for your OS](https://dotnet.microsoft.com/download/dotnet/5.0). 
3. Once you verify you are running a .NET 5, navigate in your terminal to Factory directory within the Factory.Solution directory you just cloned. Once there, run "dotnet build" in your terminal to build application within directory. 
4. In your terminal, while still in SweetTreats directory, run "dotnet restore."
5. You will require a text or code editor to complete the following steps. [VS Code is recommended](https://code.visualstudio.com/)


### _Installation: Database Recreation_

1. Ensure you are running MySQL Server 8 and MySQL WorkBench 8. If you are running windows, use the [Windows Installer ](https://dev.mysql.com/downloads/installer/) for MySQL and follow the instructions provided by the installer. For Macs, visit [MySQL Commuinity Downloads](https://dev.mysql.com/downloads/mysql/) and select macOS from the Operation Systems. This will be a manual installation. If you need additional assistance on this, please visit Epicodus's [Learn How to Program Article](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
2. Once you verify you have SQL installed, create a file called "appsettings.json" in the root directory Factory.Solution. Paste the following into this file.
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port={PORT OF SERVER};database=glen_buck;uid=root;pwd={PASSWORD OF SERVER};"
  }
}
```
3. In your terminal, run "dotnet ef database update"
### _Installation: General Use_

1. Back in your terminal in the SweetTreats production directory, type "dotnet run." The terminal will present local host routes for you to navigate to in your browser. An example would be "http://localhost:5000." Enter this into a web browser of choice to use this application. Keep the terminal running as it is being used to control the local server.
2. When finished, exit the terminal or use the command "CTRL C"(Windows) or "CMD C"(Mac) to shut down the local server.

## No known bugs as of 3/28/2021

## Support and contact details

For contact support, please email Glen Buck <a href = "mailto: glenbuck@gamil.com">Send Email</a>

## Technologies Used

- C# 9
- .NET 5.0.102
- SDK 8.0.19
- -Razor
- Bootstrap 4.5
- HTML 5 (CS version)/CSS3
- My SQL 8.0.19/WorkBench 8.0.19
- Entity Framework
- HTML Helper
- Identity Framework


### License

23423.332.22

Copyright (c) 2021 Glen Buck Inc.
