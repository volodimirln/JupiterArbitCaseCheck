# JupiterArbitCaseCheck 

👩‍💻 Система обработки и анализа данных об ответчиках и истицах в делах арбитражных судов

## Проблематика
Существующая система картотеки арбитражных дел имеет ряд серьезных проблем, а именно ошибки в ИНН и адресах у компаний участников дел, также неполнота данных о компаниях и доверенных лицах. Также, неудобный дизайн и ограничения по фильтрации и сортировки дел

## Задачи

♨️ создание модуля парсинга арбитражных дел

 📂 разработка и подключение модуля анализа и проверки данных истцов и ответчиков

 🔗 создание модуля авторизации и регистрации пользователей внутри системы

🧂 разработка функционала по сохранению данных о делах

 🐕‍🦺 разработка функционала по поиску, фильтрации и сортировки дел

🧪 сбор тестовых данных

🤖 разработка телеграм бота и функционала по рассылке арбитражных дел

🏃 разработка дополнительного функционала сайта

## Объекты

👨 авторизованный пользователь

💼 арбитражное дело

⚖️ арбитражный суд

🏺сохранённое дело

👽 не авторизованный пользователь

## Функционал

Основной функционал:
- парсинг арбитражных дел с сайта kad.arbitr.ru;
- анализ и уточнение данных по участникам в арбитражных делах;
- добавление/удаление сохраненых арбитражных дел в системе;
- рассылка арбитражных дел через телеграмм бота

Дополнительный функционал:
- просмотр арбитражных дел по регионам и судам;
- регистрация пользователя в рассылке арбитражных дел телеграм бота;
- просмотр сохраненых арбитражных дел;
- авторизация;
- хэширование пароля;
- сортировка и фильтрация арбитражных дел;
- статистика по арбитражным делам;
- поиск арбитражных дел по участникам;
и другие функции

## Особенности

Система может работать в локальной сети или на удаленном сервере, но при этом для ее работы необходим постоянный доступ к Интернету для парсинга, анализа и обработки данных об арбитражных делах

## Технологический стек

Сервер: ASP.Net Core API, .Net Core 7

Сервер базы данных: MySQL Server

Клиент: ReactJS

Клиент/Телеграм бот: ConsoleApp .Net Core 7

API разработано с подходом Code First

API разработано по паттерну MVC

## Тесты

--

## Локальный запуск

Для запуска системы необходимо сначала запустить сервер базы данных [MySQL Server](https://dev.mysql.com/downloads/installer/), создать нового пользователя и дать ему разрешение на создание и изменение баз данных на сервере. Затем необходимо [запустить API сервер](https://dotnet.microsoft.com/en-us/download) и указать в файле Model.cs адрес, логин и пароль сервера базы данных, после чего его запустить. 

Запуск API

```dotnet run```

Также после запуска API, при отсуствии дампа базы данных, можно выполнить запрос (/init) к серверу API для создания базы данных. После чего потребуется дополнительно 
установить web-сервер, например [nginx](https://docs.nginx.com/nginx/admin-guide/installing-nginx/installing-nginx-open-source/) или [Apache](https://httpd.apache.org/). 

Сборка сайта на ReactJS

```npm run build```

Затем выгрузить сборку сайта в папку web-сервера, после чего проверить работоспособность сайта.

Далее необходимо запустить консольное приложение телеграм бота на .Net Core и затем проверить его работоспособность.

Перед этим необходимо настроить файл в папке Data -  config.json и указать адрес API сервера и настроить файл tgtoken.txt указав токен телеграм бота.

Запуск приложения бота

```dotnet run```

В итоге, систему JupiterArbitCaseCheck можно запустить на одном или нескольких локальных серверах или удаленных, например отдельно сервер базы данных и API, сайт или же все компоненты системы на одном сервере 
## Автор
- [@volodimirln GitHub](https://github.com/volodimirln)
- [@volodimirln Vk](https://vk.com/volodimirln)
- [@volodimirln Tg](https://t.me/volodimirln)

## Лицензия

[MIT](https://choosealicense.com/licenses/mit/)


## Демонстрация

--

## Деплой

Развертывание происходит только со стороны сервера API и MySQL Server

## Приложение

Подробное описание проекта с макетами представленно в личном телеграм канале

Считалось, что именно Юпитер защищает римские законы и государство, являясь небесным правителем Рима

Разработано в рамках учебного проекта


## Значки

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
