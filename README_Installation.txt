Проекты " BookStore_7" и " Angular-bookstore " на github.com

SERGMORZH           1081994EGORm



BookStore_7 - сделан на MVS  , WebApi используется для администратора ( пользователь "admin"  пароль "12345") Информация о заказах приходит на почту (имитация). Письма хранятся в папке C:\book_store_emails (должна быть предварительно создана).
Выполнен поиск по автору - если автор не найден - ответ "error 404"


Angular-bookstore - недоделан - только загружает список книг. Запускается с сервера Angular CLI   localhost:4200 запрос отправляет на http://localhost:40339/api/values/ (Должен быть  запущен BookStore_7 . Порт может быть другой - устанавливается в файлах 
.\app\book.service.ts 
и 
.\app\bookm.service.ts 