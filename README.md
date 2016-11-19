# SelfHost
SelfHost.dll

Данная библиотека включает в себя 3 класса: MenuItem, MenuController, Host

MenuItem - класс, хранящий в себе свойства: Id, Name, Price 
    

MenuController - класс, наследующий ApiController, предоставляет доступ к CRUD-операциям, содержит List<MenuItem> menu,
    реализует 5 методов  Get() - получает все элементы menu,
                                     Get(int id) - получает элемент menu с menuItem.Id == id, 
                                     Post(MenuItem item) - добавляет элемент MenuItem в menu,
                                     Put(int id, MenuItem item) - изменяет элемент с menuItem.Id == id на item,
                                     Delete(int id) - удаляет элемент menuItem.Id == id.
Последние 3 метода при успехе возвращают HTTP статус - 200 (OK), и при невыполнении запроса - 403 (Forbidden) 

Host - класс, содержащий метод, который запускает SelfHost

Как работать:
Создаем новый экземпляр Host с параметром addr - URL-адрес, выполняем метод StartSelfHost(), сервер запущен:

Host h = new Host("http://localhost:8080");
h.StartSelfHost();

доступ к элементам menu осуществляется по адресу http://localhost:8080/api/menu

В решении размещены 2 консольных приложения Server, Client  и библиотека классов SelfHost

 Server: запускает  SelfHost
 Client: выполняет все перечисленные методы.
