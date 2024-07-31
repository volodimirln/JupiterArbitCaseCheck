using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Net;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    private static ITelegramBotClient _botClient;

    private static ReceiverOptions _receiverOptions;

    private static Configuration config;

    public static string wasm = "";
    static async Task Main()
    {

        config = new Configuration();
        _botClient = new TelegramBotClient(config.telegramToken);
        _receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] 
            {
                UpdateType.Message,
            },
            ThrowPendingUpdates = true,
        };

        using var cts = new CancellationTokenSource();

        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
       
        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"{me.FirstName} запущен!");
        await SendPlanMessafes(_botClient);
        await Task.Delay(-1);
    }
    private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
    {
        var ErrorMessage = error switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => error.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
    private static int count = 0;
    public static async Task SendPlanMessafes(ITelegramBotClient botClient)
    {
        while (true)
        {
            

           if (DateTime.Compare(DateTime.Now, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 38, 0)) > 0 && count == 0)
            {
                count = 1;
            }
            if (count == 1)
            {
                if (wasm != "")
                {
                    WebClient Client = new WebClient();
                    Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    Client.Headers[HttpRequestHeader.Authorization] = "Bearer " + config.jwttoken;
                    List<ArbitrationCaseShort> caseshortdata = JsonConvert.DeserializeObject<List<ArbitrationCaseShort>>(Client.UploadString(config.domain + "/arbitcase?count=10&city=KRASNODAR&wasm=" + wasm, ""));
                    string data = "\nДела в арбитражном суде Краснодарского края" +
                        "\n";
                    if (caseshortdata != null)
                    {
                        foreach (ArbitrationCaseShort caseshort in caseshortdata)
                        {
                            data += $"\n⚡️{caseshort.CaseNumber}" +
                                $"\nЧто входит в услугу:" +
                                $"\n✔️ Суд: {caseshort.Court}" +
                                $"\n✔️ Истец: {caseshort.Plaintiff}" +
                                $"\n✔️ Ответчик: {caseshort.Respondent}" +
                                $"\n✔️ Дата обращения: {DateTime.Now.ToString("dd.MM.yyyy")}" +
                                $"\n" +
                                $"\n";

                        }
                        await _botClient.SendTextMessageAsync(
                                               config.devChatId, data);
                                        count = 0;
                        return;
                    }
                    else
                    {
                        await _botClient.SendTextMessageAsync(
                                               config.devChatId, "Дела в арбитражном суде Краснодарского края - не найдены");
                        count = 0;
                        return;
                    }
                }
                else
                {
                    await _botClient.SendTextMessageAsync(
                                       config.devChatId, "Не установлен ключ");
                    count = 0;
                    return;
                }
 /*               await _botClient.SendTextMessageAsync(
                                        config.devChatId, "test");
                count = 0;
                return;*/
            }

            await Task.Delay(1000);

        }
    }
    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        var message = update.Message;
                        var user = message.From;

                        Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                        var chat = message.Chat;

                        switch (message.Type)
                        {
                            case MessageType.Text:
                                {
                                    if (message.Text == "/start")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id, $"Здравствуйте, {user.FirstName}! Вас приветствует бот для юристов Юпитер!" +
                                            $"\n" +
                                            $"\n✨ В нем собраны дела арбитражных судов по Южному Федеральному округу из государственной системы" +
                                            $"\nДела которые можно получить из следующих регионов: Краснодарский край, Ставропольский край, Республика крам и Ростовская обрасть" +
                                            $"\n" +
                                            $"\n⚡️Также для получения полного списка команд, восользуйтесь командой /help или откройте список команд в Телеграмм" +
                                            $"\nТакже для авторизации в системе и получении личных сообщений от бота с делами каждый день авторизуйтесь на сайте системы Юпитер и отправьте ключ в бота" +
                                            $"\nСписок команд /help" +
                                            $"\n" +
                                            $"\n Чтобы добавить ключ для доступа к делам используйте команду kеу:<ключ>"
                                            ); ;
                                        return;
                                    }
                                    if (message.Text == "/about")
                                    {
                                        await botClient.SendTextMessageAsync(
                                           chat.Id, $"О себе" +
                                           $"\n" +
                                           $"\n✨ Бот юридический-помощник Юпитер" +
                                           $"\n" +
                                           $"\n⚡️Актуальные данные по арбитражным делам Южного Федерального Округа " +
                                           $"\n" 
                                           ); ;
                                        return;
                                    }
                                   
                                    if (message.Text == "/help" || message.Text.ToLower() == "команды")
                                    {
                                        await botClient.SendTextMessageAsync(
                                         chat.Id, $"Команды\n" +
                                         $"\nКак пользоваться ботом:" +
                                         $"\n" +
                                         $"\n🌟 /start - запуск бота " +
                                         $"\n" +
                                         $"\nЗапустите бота и сразу начните получать информацио о дела в разных регионах" +
                                         $"\n" +
                                         $"\n🏔 /caseskrd - дела по Краснодарскому краю" +
                                         $"\n" +
                                         $"\nДела, которые доступны в системе Арбитражного суда Краснодарского края" +
                                         $"\n" +
                                         $"\n🏞 /casesstr - дела по Ставропольскому краю" +
                                         $"\n" +
                                         $"\nДела, которые доступны в системе Арбитражного суда Ставвропольского края" +
                                         $"\n" +
                                         $"\n🌊 /caseskrm - дела по Республике Крым" +
                                         $"\n" +
                                         $"\nДела, которые доступны в системе Арбитражного суда Республики Крым" +
                                         $"\n" +
                                         $"\n🏭 /casesrst - дела по Ростовской области" +
                                         $"\n" +
                                         $"\nДела, которые доступны в системе Арбитражного суда Ростовской области" +
                                         $"\n" +
                                         $"\n👉 /about - о боте" +
                                         $"\n" +
                                         $"\nУзнайти подробнее про систему Юпитер"+
                                         $"\n" +
                                         $"\n🆘 /help - команды" +
                                         $"\n" +
                                         $"\nНаходитесь сейчас в этом месте" +
                                         $"\n" +
                                         $"\n Чтобы добавить ключ используйте команду kеу:<ключ>"
                                         ); ;
                                        return;
                                    }
                                    if (message.Text.Contains("key:"))
                                    {
                                        wasm = message.Text.Substring(4);
                                        await botClient.SendTextMessageAsync(
                                                chat.Id, "Ключ сохранен"
                                                );
                                        return;
                                    }
                                        if (message.Text.Contains("jp://"))
                                    {
                                        try
                                        {
                                            var cli = new WebClient();
                                            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                                            cli.Headers[HttpRequestHeader.Authorization] = "Bearer " + message.Text.Substring(5);
                                            string tokenweb = cli.UploadString(config.domain + "/auth/checktoken", "");
                                            if (bool.Parse(tokenweb))
                                            {
                                                var filePath = Path.Combine("Data/config.json");

                                                Config configuration = new Config();
                                                using (StreamReader reader = new StreamReader(filePath))
                                                {
                                                    string text = reader.ReadToEnd();
                                                    configuration = System.Text.Json.JsonSerializer.Deserialize<Config>(text);
                                                    reader.Close();
                                                }

                                                configuration.chatId = Convert.ToInt64(chat.Id);
                                                using (StreamWriter writer = new StreamWriter(filePath))
                                                {
                                                    writer.Write(System.Text.Json.JsonSerializer.Serialize<Config>(configuration));
                                                    writer.Close();
                                                }
                                                var filePathToken = Path.Combine("Data/token.txt");
                                                using (StreamWriter writeToken = new StreamWriter(filePathToken))
                                                {
                                                    writeToken.Write(message.Text.Substring(5));
                                                }
                                                config = new Configuration();

                                                await botClient.SendTextMessageAsync(
                                                chat.Id, "Токен авторизован"
                                                );
                                            }
                                            else
                                            {
                                                await botClient.SendTextMessageAsync(
                                                chat.Id, "Ошибка авторизации"
                                                );
                                            }
                                        }
                                        catch
                                        {
                                            await botClient.SendTextMessageAsync(
                                               chat.Id, "Ошибка авторизации"
                                               );
                                        }
                                        
                                        return;
                                    }
                                    if (message.Text == "/caseskrd")
                                    {
                                        if (wasm != "")
                                        {
                                        WebClient Client = new WebClient();
                                        Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                                        Client.Headers[HttpRequestHeader.Authorization] = "Bearer " + config.jwttoken;
                                        List<ArbitrationCaseShort> caseshortdata = JsonConvert.DeserializeObject<List<ArbitrationCaseShort>>(Client.UploadString(config.domain + "/arbitcase?count=10&city=KRASNODAR&wasm="+wasm, ""));
                                        string data = "\nДела в арбитражном суде Краснодарского края" +
                                            "\n";
                                            if (caseshortdata != null)
                                            {
                                                foreach (ArbitrationCaseShort caseshort in caseshortdata)
                                                {
                                                    data += $"\n⚡️{caseshort.CaseNumber}" +
                                                        $"\nЧто входит в услугу:" +
                                                        $"\n✔️ Суд: {caseshort.Court}" +
                                                        $"\n✔️ Истец: {caseshort.Plaintiff}" +
                                                        $"\n✔️ Ответчик: {caseshort.Respondent}" +
                                                        $"\n✔️ Дата обращения: {DateTime.Now.ToString("dd.MM.yyyy")}" +
                                                        $"\n" +
                                                        $"\n";

                                                }
                                                await _botClient.SendTextMessageAsync(
                                                                        chat.Id, data);
                                                return;
                                            }
                                            else
                                            {
                                                await _botClient.SendTextMessageAsync(
                                                                       chat.Id, "Дела в арбитражном суде Краснодарского края - не найдены");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            await _botClient.SendTextMessageAsync(
                                                               chat.Id, "Не установлен ключ");
                                            return;
                                        }
                                       
                                    }
                                    if (message.Text == "/casesstr")
                                    {
                                        if (wasm != "")
                                        {
                                            WebClient Client = new WebClient();
                                            Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                                            Client.Headers[HttpRequestHeader.Authorization] = "Bearer " + config.jwttoken;
                                            List<ArbitrationCaseShort> caseshortdata = JsonConvert.DeserializeObject<List<ArbitrationCaseShort>>(Client.UploadString(config.domain + "/arbitcase?count=10&city=STAVROPOL", ""));
                                            string data = "\nДела в арбитражном суде Ставропольского края" +
                                                "\n";
                                            if (caseshortdata != null)
                                            {
                                                foreach (ArbitrationCaseShort caseshort in caseshortdata)
                                            {
                                                data += $"\n⚡️{caseshort.CaseNumber}" +
                                                    $"\nЧто входит в услугу:" +
                                                    $"\n✔️ Суд: {caseshort.Court}" +
                                                    $"\n✔️ Истец: {caseshort.Plaintiff}" +
                                                    $"\n✔️ Ответчик: {caseshort.Respondent}" +
                                                    $"\n✔️ Дата обращения: {DateTime.Now.ToString("dd.MM.yyyy")}" +
                                                    $"\n" +
                                                    $"\n";

                                            }

                                            await _botClient.SendTextMessageAsync(
                                                                    chat.Id, data);
                                            return;
                                            }
                                            else
                                            {
                                                await _botClient.SendTextMessageAsync(
                                                                       chat.Id, "Дела в арбитражном суде Ставропольского края - не найдены");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            await _botClient.SendTextMessageAsync(
                                                               chat.Id, "Не установлен ключ");
                                            return;
                                        }
                                    }
                                    if (message.Text == "/caseskrm")
                                    {
                                        if (wasm != "")
                                        {
                                            WebClient Client = new WebClient();
                                        Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                                        Client.Headers[HttpRequestHeader.Authorization] = "Bearer " + config.jwttoken;
                                        List<ArbitrationCaseShort> caseshortdata = JsonConvert.DeserializeObject<List<ArbitrationCaseShort>>(Client.UploadString(config.domain + "/arbitcase?count=10&city=KRYM", ""));
                                        string data = "\nДела в арбитражном суде Республики крым" +
                                            "\n";
                                            if (caseshortdata != null)
                                            {
                                                foreach (ArbitrationCaseShort caseshort in caseshortdata)
                                        {
                                            data += $"\n⚡️{caseshort.CaseNumber}" +
                                                $"\nЧто входит в услугу:" +
                                                $"\n✔️ Суд: {caseshort.Court}" +
                                                $"\n✔️ Истец: {caseshort.Plaintiff}" +
                                                $"\n✔️ Ответчик: {caseshort.Respondent}" +
                                                $"\n✔️ Дата обращения: {DateTime.Now.ToString("dd.MM.yyyy")}" +
                                                $"\n" +
                                                $"\n";

                                        }
                                            await _botClient.SendTextMessageAsync(
                                                                        chat.Id, data);
                                            return;
                                            }
                                            else
                                            {
                                                await _botClient.SendTextMessageAsync(
                                                                       chat.Id, "Дела в арбитражном суде Республики крым - не найдены");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            await _botClient.SendTextMessageAsync(
                                                               chat.Id, "Не установлен ключ");
                                            return;
                                        }
                                    }
                                    if (message.Text == "/casesrst")
                                    {
                                        if (wasm != "")
                                        {
                                            WebClient Client = new WebClient();
                                            Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                                            Client.Headers[HttpRequestHeader.Authorization] = "Bearer " + config.jwttoken;
                                            List<ArbitrationCaseShort> caseshortdata = JsonConvert.DeserializeObject<List<ArbitrationCaseShort>>(Client.UploadString(config.domain + "/arbitcase?count=10&city=ROSTOV", ""));
                                            string data = "\nДела в арбитражном суде Ростотвской области" +
                                                "\n";
                                            if (caseshortdata != null)
                                            {
                                                foreach (ArbitrationCaseShort caseshort in caseshortdata)
                                            {
                                                data += $"\n⚡️{caseshort.CaseNumber}" +
                                                    $"\nЧто входит в услугу:" +
                                                    $"\n✔️ Суд: {caseshort.Court}" +
                                                    $"\n✔️ Истец: {caseshort.Plaintiff}" +
                                                    $"\n✔️ Ответчик: {caseshort.Respondent}" +
                                                    $"\n✔️ Дата обращения: {DateTime.Now.ToString("dd.MM.yyyy")}" +
                                                    $"\n" +
                                                    $"\n";

                                            }
                                            await _botClient.SendTextMessageAsync(
                                                                    chat.Id, data);
                                            return;
                                            }
                                            else
                                            {
                                                await _botClient.SendTextMessageAsync(
                                                                       chat.Id, "Дела в арбитражном суде Ростотвской области - не найдены");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            await _botClient.SendTextMessageAsync(
                                                               chat.Id, "Не установлен ключ");
                                            return;
                                        }
                                    }

                                    return;
                                }



                            // Добавил default , чтобы показать вам разницу типов Message
                            default:
                                {
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        $"\n😔Извините, но я Вас не понимаю, пожалуйста попробуйте еще раз" +
                                        $"\n" +
                                        $"\n🤔Пока, что я не умею выполнять данные команды, но научусь"); ;
                                    return;
                                }
                        }

                        return;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}