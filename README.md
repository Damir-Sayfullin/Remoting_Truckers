# Курсовая работа Truckers с использованием .Net Remoting
---
## Описание  
В проекте реализуется запуск сервера и подключение к нему клиента по двум защищенным каналам: TCP и HTTP.

## Содержание репозитория
Репозиторий содержит 2 проекта.
Запускать их в следующим порядке:
1. **Server**
2. **Truckers**

Truckers содержит 4 формы:
- **FormLogin** - форма авторизации, подключается по каналу HTTP
- **FormRegister** - форма регистрации, подключается по каналу HTTP
- **FormLogist** - панель управления логиста, подключается по каналу TCP
- **FormDriver** - панель управления водителя, подключается по каналу TCP

## Запуск
Перед запуском нужно указать путь базы данных в переменной **connectionString** в файлах:
- **Truckers/RemoteObjectTCP.cs**
- **Truckers/RemoteObjectHTTP.cs**

Пример:  
```C#
private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/Users/PC/Downloads/Truckers/Truckers/data/TruckersDB.mdb";
```
