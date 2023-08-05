# Truckers - Client-Server Application in WinForms using .NET Remoting
### <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/blob/main/README-ru.md>На русском</a>
## About the Project
<p align="center">
    <a href=https://learn.microsoft.com/ru-ru/dotnet/csharp/><img src="https://img.shields.io/badge/C%23-662179?style=for-the-badge" alt="C# Version"></a>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/releases/tag/v1.0.0><img src="https://img.shields.io/badge/Version-1.0.0-green?style=for-the-badge" alt="Version"></a><br>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/stargazers><img src="https://img.shields.io/github/stars/Damir-Sayfullin/Remoting_Truckers?style=for-the-badge&color=yellow&label=Stars" alt="Stars"></a>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/watchers><img src="https://img.shields.io/github/watchers/Damir-Sayfullin/Remoting_Truckers?style=for-the-badge&label=Watchers" alt="Watchers"></a>
</p>

The Truckers project is a graphical application created using WinForms and .NET Remoting in the C# programming language. It implements launching a server and connecting clients to it through two secure channels: TCP and HTTP. The application allows users to register and authenticate within the system. After authentication, users can perform various cargo-related operations based on their roles. For instance, a logistician can add, remove, and edit cargoes, while a driver can take on deliveries, complete or cancel them. Additionally, drivers can view information about their current deliveries within the application. Cargo and user data are stored in a database.  
<img src="https://i.ibb.co/jg6N4ZH/Login.png" alt="Login" height=300>
<img src="https://i.ibb.co/Tw9H6fz/Driver.png" alt="Driver" height=300>

## Installation
To install and run the Truckers project, follow these steps:
1. Clone the repository using `git clone https://github.com/Damir-Sayfullin/Remoting_Truckers.git` or download the project from the release assets.
2. Open `Truckers.sln` from the `Truckers` folder using Visual Studio.
3. In the `Server` folder, locate the file `RemoteObjectHTTP.cs` and open it.
4. Edit the `connectionString` variable by providing the correct path to the database. It's located in the project folder at `Truckers/data/TruckersDB.mdb`. Example:
```C#
private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/Users/PC/Desktop/test/Truckers/data/TruckersDB.mdb";
```
5. Perform steps 3-4 for the `RemoteObjectTCP.cs` file as well.
6. Start the `Server` project, and then launch the `Truckers` project.

## Usage
- Upon launching the application, the authentication window will appear. Enter your username and password, then click `Войти`.
- If you don't have an account, click `Зарегистрироваться`. Fill in the fields and click `Отправить`. After successful registration, click the `Авторизоваться` button, enter your login credentials, and click `Войти`.
- If you log in as a logistician:
  - Select an `ID` to view cargo information.
  - Click `Обновить` to load information from the database.
  - Click `Сохранить` to save modified cargo data for the selected ID.
  - Click `Добавить` to add a new cargo based on the provided information. (Note: Before clicking `Добавить`, make sure to fill in cargo details. The `ID` field can be any value.)
  - Click `Удалить` to remove cargo based on the selected ID.
  - Click `Выйти из системы` to exit your account.
- If you log in as a driver:
  - Select an `ID` to view cargo information.
  - Click `Текущий груз` to view information about your current cargo, if applicable.
  - Click `Принять` to accept cargo based on the selected ID. This action will assign your ID to the `ID водителя` field, and the `Статус` field will change to "on the way".
  - Click `Отказаться` to decline your current cargo. It's not necessary to select a cargo ID. The `ID водителя` field will be assigned the default value "0" (no driver), and the `Статус` field will change to the default value "ready for unloading".
  - Click `Доставить` to complete the delivery of your current cargo. It's not necessary to select a cargo ID. The `ID водителя` field will be assigned the default value "0" (no driver), and the `Статус` field will change to "delivered".
  - Click `Выйти из системы` to exit your account.
- The application includes error protection. For instance, you cannot assign a driver ID to a cargo if the driver already has a cargo. A driver cannot accept a new cargo if they already have an ongoing delivery. Additionally, a driver cannot take a cargo if it's already assigned to another driver or has been delivered (status "delivered").

## Documentation
### Project "Truckers"
The **Truckers** project comprises 4 forms:
- **FormLogin** - Authentication form, connected via HTTP.
- **FormRegister** - Registration form, connected via HTTP.
- **FormLogist** - Logistician control panel, connected via TCP.
- **FormDriver** - Driver control panel, connected via TCP.
### FormLogin
`public FormLogin()` - Constructor for the FormLogin form.  
`private void ConnectToServer()` - Method to establish a connection to the server.  
`private void button1_Click(object sender, EventArgs e)` - Event handler for the "Войти" button click.  
`private void button2_Click(object sender, EventArgs e)` - Event handler for the password hide button click.  
`private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)` - Event handler for the "Зарегистрироваться" link click.  
### FormRegister
`public FormRegister(FormLogin formLogin, RemoteObjectHTTP remoteHTTP)` - Constructor for the FormRegister form.  
`private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)` - Event handler for the "Авторизоваться" link click.  
`private void button1_Click(object sender, EventArgs e)` - Event handler for the "Отправить" button click.  
`private void button2_Click(object sender, EventArgs e)` - Event handler for the password hide button click.  
### FormLogist
`public FormLogist(FormLogin formLogin, string username)` - Constructor for the FormLogist form.  
`private void ConnectToServer()` - Method to establish a connection to the server.  
`private void CargoReload()` - Method to refresh the list of cargoes.  
`private void buttonReload_Click(object sender, EventArgs e)` - Event handler for the "Обновить" button click.  
`private void comboBox_ID_SelectedValueChanged(object sender, EventArgs e)` - Event handler for the selection of an ID from the dropdown list.  
`private void buttonExit_Click(object sender, EventArgs e)` - Event handler for the "Выйти из системы" button click.  
`private void buttonSave_Click(object sender, EventArgs e)` - Event handler for the "Сохранить" button click.  
`private void buttonAdd_Click(object sender, EventArgs e)` - Event handler for the "Добавить" button click.  
`private void buttonDelete_Click(object sender, EventArgs e)` - Event handler for the "Удалить" button click.  
### FormDriver
`public FormDriver(FormLogin formLogin, string username, int ID)` - Constructor for the FormDriver form.  
`private void ConnectToServer()` - Method to establish a connection to the server.  
`private void CargoReload()` - Method to refresh the list of cargoes.  
`private void comboBox_ID_SelectedValueChanged(object sender, EventArgs e)` - Event handler for the selection of an ID from the dropdown list.  
`private void buttonExit_Click(object sender, EventArgs e)` - Event handler for the "Выйти из системы" button click.  
`private void buttonCurrent_Click(object sender, EventArgs e)` - Event handler for the "Текущий груз" button click.  
`private void buttonAccept_Click(object sender, EventArgs e)` - Event handler for the "Принять" button click.  
`private void buttonCancel_Click(object sender, EventArgs e)` - Event handler for the "Отказаться" button click.  
`private void buttonDelivery_Click(object sender, EventArgs e)` - Event handler for the "Доставить" button click.

### Project "Server"
The **Server** project contains 2 **.cs** files:
- **RemoteObjectHTTP.cs** - Connection via HTTP channel.
- **RemoteObjectTCP.cs** - Connection via TCP channel.
### RemoteObjectHTTP.cs
`public string Authorization(string login, string password)` - Method to find users by login and password. Returns the count of users with the given login and password.
`public string Registration(string name, string login, string password, string post)` - Method for user registration. Returns "0" if registration is successful, "1" if a user with the same login already exists.
`public string GetUsername(string login)` - Method to retrieve the username based on login. Returns the username.
`public int GetID(string login)` - Method to retrieve the user ID based on login. Returns the user ID.
`public override object InitializeLifetimeService()` - Method to initialize the sponsor.
### RemoteObjectTCP.cs
`public DataTable Logist_CargoReload()` - Method to retrieve the database. Returns a DataTable.
`public string Logist_CargoSave(string ID, string DriverID, string Status, string Cargo, string Weight, string From, string To)` - Method to modify cargo data in the database based on ID. Returns "0" if the modification is successful.
`public string Logist_CargoAdd(string DriverID, string Status, string Cargo, string Weight, string From, string To)` - Method to add records to the database. Returns "0" if the addition is successful.
`public string Logist_CargoDelete(string ID)` - Method to delete a record from the database based on ID. Returns "0" if the deletion is successful.
`public string Logist_GetDriversCount(string DriverID)` - Method to find the count of cargos based on driver ID. Returns the count of cargos.
`public DataTable Driver_GetCargo(string DriverID)` - Method to retrieve cargo data based on driver ID. Returns a DataTable.
`public int Driver_GetDriverID(string ID)` - Method to retrieve the driver ID based on cargo ID. Returns the driver ID if the cargo has a driver, and "0" if the cargo has not been assigned a driver yet.
`public int Driver_CargoAccept(string ID, string DriverID)` - Method for a driver to accept cargo based on cargo ID and driver ID. Returns "0" if successful, and "1" if the cargo has already been delivered.
`public int Driver_CargoCancel(string DriverID)` - Method for a driver to cancel cargo acceptance based on driver ID. Returns "0" if successful.
`public int Driver_CargoDelivery(string DriverID)` - Method for a driver to mark cargo as delivered based on driver ID. Returns "0" if successful.
`public override object InitializeLifetimeService()` - Method to initialize the sponsor.
