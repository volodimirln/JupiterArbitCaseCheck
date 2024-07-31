using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Telegram.Bot.Types;

public class Configuration 
{
    public  string telegramToken = "";
    public  long chatId = 0;
    public  long devChatId = 0;
    public string domain = "";
    public string token = "";
    public string jwttoken = "";

    public Configuration(){

        Console.WriteLine("Конфигурация клиента");
        var filePath = Path.Combine("Data/config.json");
        var filePathTGToken = Path.Combine("Data/tgtoken.txt");


        using (StreamReader reader = new StreamReader(filePath))
        {
            string text =  reader.ReadToEnd();
            Config? config = System.Text.Json.JsonSerializer.Deserialize<Config>(text);
            chatId = config.chatId;
            devChatId = config.devChatId;
            domain = config.domain;
            var filePathToken = Path.Combine("Data/token.txt");
            using (StreamReader readerToken = new StreamReader(filePathToken))
            {
                jwttoken = readerToken.ReadToEnd();
            }
            using (StreamReader readerToken = new StreamReader(filePathTGToken))
            {
                telegramToken = readerToken.ReadToEnd();
            }
        }
    }
}


    