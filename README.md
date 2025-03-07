# TestUdv
Для успешного тестирования проекта нужно:
1. Изменить в файле appsettings.Development.json строку "TestUdvDbContext": "Host=localhost;Port=5432;Database=TestUdv;Username=;Password=", указав свои Username и Password.
2. Получить Ownerid из ссылки любого поста личной страницы или сообщества. К примеру: https://vk.com/wall-215279260_1387, -215279260 - Ownerid.
3. Получить свой access Token на сайте https://vkhost.github.io/.
