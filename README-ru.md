# Truckers - клиент-серверное приложение на WinForms с использованием .NET Remoting
### <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/blob/main/README.md>In English</a>
## О проекте
<p align="center">
    <a href=https://learn.microsoft.com/ru-ru/dotnet/csharp/><img src="https://img.shields.io/badge/C%23-662179?style=for-the-badge" alt="Python Version"></a>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/releases/tag/v1.0.0><img src="https://img.shields.io/badge/Версия-1.0.0-green?style=for-the-badge" alt="Version"></a><br>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/stargazers><img src="https://img.shields.io/github/stars/Damir-Sayfullin/Remoting_Truckers?style=for-the-badge&color=yellow&label=%D0%97%D0%B2%D0%B5%D0%B7%D0%B4%D1%8B" alt="Stars"></a>
    <a href=https://github.com/Damir-Sayfullin/Remoting_Truckers/watchers><img src="https://img.shields.io/github/watchers/Damir-Sayfullin/Remoting_Truckers?style=for-the-badge&label=%D0%9F%D1%80%D0%BE%D1%81%D0%BC%D0%BE%D1%82%D1%80%D1%8B" alt="Watchers"></a>
</p>
 
Проект Truckers представляет собой графическое приложение, созданное с использованием WinForms и .NET Remoting на языке C#. В нём реализуется запуск сервера и подключение к нему клиента по двум защищенным каналам: TCP и HTTP. Приложение позволяет пользователям регистрироваться и авторизовываться с системе. После авторизации, пользователи могут выполнять различные операции с грузами, в зависимости от должности. Например, у логиста есть возможность добавлять, удалять, редактировать грузы, а водитель может взять груз в доставку, завершить или отменить её. Также водитель может посмотреть в приложении информацию о текущем грузе. Данные о грузах и пользователях сохраняются в базе данных.  
<img src="https://i.ibb.co/jg6N4ZH/Login.png" alt="Login" height=300>
<img src="https://i.ibb.co/Tw9H6fz/Driver.png" alt="Driver" height=300>

## Установка
Для установки и запуска проекта Truckers нужно выполнить следующие действия:
1. Склонируйте репозиторий с помощью `git clone https://github.com/Damir-Sayfullin/Remoting_Truckers.git` или скачайте проект в ассетах релиза.
2. Запустите `Truckers.sln` из папки `Truckers` с помощью Visual Studio.
3. Найдите в папке `Server` файл `RemoteObjectHTTP.cs` и откройте его.
4. Отредактируйте переменную `connectionString`, записав туда корректный путь к базе данных. Он находится в папке проекта по пути `Truckers/data/TruckersDB.mdb`. Пример:  
```C#
private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/Users/PC/Desktop/test/Truckers/data/TruckersDB.mdb";
```
5. Выполните шаги 3-4 для файла `RemoteObjectTCP.cs`.
6. Запустить проект `Server`, а затем и `Truckers`.

## Использование
- При запуске приложения откроется окно авторизации. Введите логин, пароль и нажмите `Войти`.
- Если у вас нет учетной записи, нажмите `Зарегистрироваться`. Заполните поля и нажмите `Отправить`. После успешной регистрации нажмите кнопку `Авторизоваться`, введите логин, пароль и нажмите `Войти`.
- Если вы вошли как логист:
  - Выберите `ID`, чтобы увидеть информацию о грузе.
  - Нажмите `Обновить`, чтобы загрузить информацию с базы данных.
  - Нажмите `Сохранить`, чтобы сохранить измененные данные о грузе по выбранному ID.
  - Нажмите `Добавить`, чтобы добавить новый груз на основе заполненных данных о грузе. (Внимание! Перед нажатием кнопки `Добавить` нужно заполнить данные о грузе. Поле `ID` может быть любым.)
  - Нажмите `Удалить`, чтобы удалить груз по выбранному ID.
  - Нажмите `Выйти из системы`, чтобы выйти из учетной записи.
- Если вы вошли как водитель:
  - Выберите `ID`, чтобы увидеть информацию о грузе.
  - Нажмите `Текущий груз`, чтобы увидеть информацию о вашем текущем грузе, если такой имеется.
  - Нажмите `Принять`, чтобы принять груз по выбранному ID. При этом в поле `ID водителя` присвоится ваш ID, а поле `Статус` изменится на "on the way"(в пути).
  - Нажмите `Отказаться`, чтобы отказаться от вышего текущего груза. При этом необязательно выбирать ID груза. В поле `ID водителя` присвоится значение по умолчанию "0"(без водителя), а поле `Статус` изменится на значение по умолчанию "ready for unloading"(готов к выгрузке).
  - Нажмите `Доставить`, чтобы завершить доставку вашего текущего груза. При этом необязательно выбирать ID груза. В поле `ID водителя` присвоится значение по умолчанию "0"(без водителя), а поле `Статус` изменится на "delivered"(доставлен).
  - Нажмите `Выйти из системы`, чтобы выйти из учетной записи.
- В приложении предусмотрена защита от ошибок. Например, нельзя присвоить грузу ID водителя, если у этого водителя уже есть груз. Водитель не может принять новый груз, если у него уже есть текущий. Также, водитель не может взять груз, если у этого груза уже есть другой водитель, или он уже был доставлен (статус "delivered").

## Документация
### Проект "Truckers"
Проект **Truckers** содержит 4 формы:
- **FormLogin** - форма авторизации, подключается по каналу HTTP.
- **FormRegister** - форма регистрации, подключается по каналу HTTP.
- **FormLogist** - панель управления логиста, подключается по каналу TCP.
- **FormDriver** - панель управления водителя, подключается по каналу TCP.
### FormLogin
`public FormLogin()` - конструктор формы FormLogin.  
`private void ConnectToServer()` - метод установки соединения с сервером.  
`private void button1_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Войти".  
`private void button2_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки скрытия пароля.  
`private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)` - обработчик события на нажатие кнопки "Зарегистрироваться".  
### FormRegister
`public FormRegister(FormLogin formLogin, RemoteObjectHTTP remoteHTTP)` - конструктор формы FormRegister.  
`private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)` - обработчик события на нажатие кнопки "Авторизоваться".  
`private void button1_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Отправить".  
`private void button2_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки скрытия пароля.  
### FormLogist
`public FormLogist(FormLogin formLogin, string username)` - конструктор формы FormLogist.  
`private void ConnectToServer()` - метод установки соединения с сервером.  
`private void CargoReload()` - метод обновления списка грузов.  
`private void buttonReload_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Обновить".  
`private void comboBox_ID_SelectedValueChanged(object sender, EventArgs e)` - обработчик события на выбор ID в выпадающем списке.  
`private void buttonExit_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Выйти из системы".  
`private void buttonSave_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Сохранить".  
`private void buttonAdd_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Добавить".  
`private void buttonDelete_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Удалить".  
### FormDriver
`public FormDriver(FormLogin formLogin, string username, int ID)` - конструктор формы FormDriver.  
`private void ConnectToServer()` - метод установки соединения с сервером.  
`private void CargoReload()` - метод обновления списка грузов.  
`private void comboBox_ID_SelectedValueChanged(object sender, EventArgs e)` - обработчик события на выбор ID в выпадающем списке.  
`private void buttonExit_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Выйти из системы".  
`private void buttonCurrent_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Текущий груз".  
`private void buttonAccept_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Принять".  
`private void buttonCancel_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Отказаться".  
`private void buttonDelivery_Click(object sender, EventArgs e)` - обработчик события на нажатие кнопки "Доставить".  

### Проект "Server"
Проект **Server** содержит 2 файла **.cs**:
- **RemoteObjectHTTP.cs** - подключение по каналу HTTP
- **RemoteObjectTCP.cs** - подключение по каналу TСP
### RemoteObjectHTTP.cs
`public string Autorization(string login, string password)` - метод для поиска пользователей по логину и паролю. Возвращает количество пользователей с таким логином и паролем.  
`public string Registration(string name, string login, string password, string post)` - метод для регистрации пользователя. Возвращает "0" - если регистрация успешна, "1" - если пользователь с таким логином уже существует.  
`public string GetUsername(string login)` - метод для получения имени пользователя по логину. Возвращает имя пользователя.  
`public int GetID(string login)` - метод для получения ID пользователя по логину. Возвращает ID пользователя.  
`public override object InitializeLifetimeService()` - метод для инициализации спонсора.  
### RemoteObjectTCP.cs
`public DataTable Logist_CargoReload()` - метод для получение базы данных. Возвращает таблицу DataTable.  
`public string Logist_CargoSave(string ID, string DriverID, string Status, string Cargo, string Weight, string From, string To)` - метод для изменения данных груза в базе данных по ID. Возвращает "0" - если изменение прошло успешно.  
`public string Logist_CargoAdd(string DriverID, string Status, string Cargo, string Weight, string From, string To)` - метод для добавления записей в базу данных. Возвращает "0" - если добавление прошло успешно.  
`public string Logist_CargoDelete(string ID)` - метод для удаления записи из базы данных по ID. Возвращает "0" - если удаление прошло успешно.  
`public string Logist_GetDriversCount(string DriverID)` - метод для поиска количества грузов по ID водителя. Возвращает количество грузов.  
`public DataTable Driver_GetCargo(string DriverID)` - метод для получение данных о грузе по ID водителя. Возвращает таблицу DataTable.  
`public int Driver_GetDriverID(string ID)` - метод для получение ID водителя по ID груза. Возвращает ID водителя - если у груза есть водитель и "0" - если водитель еще не назначен этому грузу.  
`public int Driver_CargoAccept(string ID, string DriverID)` - метод для принятия груза по ID груза и ID водителя. Возвращает "0" - если все прошло успешно и "1" - если груз уже был доставлен ранее.  
`public int Driver_CargoCancel(string DriverID)` - метод для отказа от груза по ID водителя. Возвращает "0" - если все прошло успешно.  
`public int Driver_CargoDelivery(string DriverID)` - метод для доставки груза по ID водителя. Возвращает "0" - если все прошло успешно.  
`public override object InitializeLifetimeService()` - метод для инициализации спонсора.
