namespace JupiterWebAPI.Models
{
    public class ArbitrationCaseShort
    {

        public string Date { get; set; }
        public string СaseLink { get; set; }
        public string Judge { get; set; }
        public string Court { get; set; }
        public string CaseNumber { get; set; }
        public string Plaintiff { get; set; }


        public string Respondent { get; set; }

        public string INNRespondent { get; set; }
        public string KPPRespondent { get; set; }
        public string Address { get; set; }
        public string SupervisorRespondent { get; set; }
        public string SupervisorJobRespondent { get; set; }
        public string OGRNRespondent { get; set; }
        public string Phones { get; set; }
        public string Webs { get; set; }
        public string Emails { get; set; }
        public string Cases { get; set; }
    }
    public class Руковод
    {
        public string ФИО { get; set; }
        public string ИНН { get; set; }
        public string ВидДолжн { get; set; }
        public string НаимДолжн { get; set; }
        public bool Недост { get; set; }
        public bool ДисквЛицо { get; set; }
    }

    public class Учред
    {
        public List<object> ФЛ { get; set; }
        public List<object> РосОрг { get; set; }
        public List<object> ИнОрг { get; set; }
        public List<object> ПИФ { get; set; }
        public List<object> РФ { get; set; }
    }

    public class Запись
    {
        public string ОГРН { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string НаимСокр { get; set; }
        public string НаимПолн { get; set; }
        public string ДатаРег { get; set; }
        public string Статус { get; set; }
        public string РегионКод { get; set; }
        public string ЮрАдрес { get; set; }
        public string ОКВЭД { get; set; }
        public List<Руковод> Руковод { get; set; }
        public Учред Учред { get; set; }
    }

    public class Данные
    {
        public int ЗапВсего { get; set; }
        public int СтрВсего { get; set; }
        public int СтрТекущ { get; set; }
        public List<Запись> Записи { get; set; }
    }

    public class Root
    {
        public Данные data { get; set; }
    }
    public class Статус
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class Регион
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class ЮрАдрес
    {
        public string НасПункт { get; set; }
        public string АдресРФ { get; set; }
        public object ИдГАР { get; set; } // здесь тип может быть любым, в зависимости от реальных данных
        public bool Недост { get; set; }
    }

    public class ОКВЭД
    {
        public string Код { get; set; }
        public string Наим { get; set; }
        public string Версия { get; set; }
    }

    public class ОКВЭДДоп
    {
        public string Код { get; set; }
        public string Наим { get; set; }
        public string Версия { get; set; }
    }

    public class ОКОПФ
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class ОКФС
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class ОКОГУ
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class ОКАТО
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class ОКТМО
    {
        public string Код { get; set; }
        public string Наим { get; set; }
    }

    public class РегФНС
    {
        public string КодОрг { get; set; }
        public string НаимОрг { get; set; }
        public string АдресОрг { get; set; }
    }

    public class РегПФР
    {
        public string ДатаРег { get; set; }
        public string РегНомер { get; set; }
        public string КодОрг { get; set; }
        public string НаимОрг { get; set; }
    }

    public class РегФСС
    {
        // Здесь могут быть аналогичные свойства как в классе РегФНС
    }
   
        // предыдущие свойства

        public class КонтактыОбъект
        {
            public string[] Тел { get; set; }
            public string[] Емэйл { get; set; }
            public string ВебСайт { get; set; }
        }

    

    public class Data
    {
        public string ОГРН { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string ОКПО { get; set; }
        public string ДатаРег { get; set; }
        public string ДатаОГРН { get; set; }
        public string НаимСокр { get; set; }
        public object НаимАнгл { get; set; } // здесь тип может быть любым, в зависимости от реальных данных
        public string НаимПолн { get; set; }
        public Статус Статус { get; set; }
        public Регион Регион { get; set; }
        public ЮрАдрес ЮрАдрес { get; set; }
        public ОКВЭД ОКВЭД { get; set; }
        public ОКВЭД[] ОКВЭДДоп { get; set; }
        public ОКОПФ ОКОПФ { get; set; }
        public ОКФС ОКФС { get; set; }
        public ОКОГУ ОКОГУ { get; set; }
        public ОКАТО ОКАТО { get; set; }
        public ОКТМО ОКТМО { get; set; }
        public РегФНС РегФНС { get; set; }
        public РегПФР РегПФР { get; set; }
        public РегФСС РегФСС { get; set; }
        public КонтактыОбъект Контакты { get; set; }

    }

    public class RootInc
    {
        public Data data { get; set; }
    }



   



    public class Company
    {
        public string ОГРН { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string НаимСокр { get; set; }
        public string НаимПолн { get; set; }
        public DateTime ДатаРег { get; set; }
        public string Статус { get; set; }
        public string РегионКод { get; set; }
        public string ЮрАдрес { get; set; }
        public string ОКВЭД { get; set; }
    }

    public class Record
    {
        public string Номер { get; set; }
        public string UUID { get; set; }
        public string СтрКАД { get; set; }
        public DateTime Дата { get; set; }
        public string Суд { get; set; }
        public List<Company> Ист { get; set; }
        public List<Company> Ответ { get; set; }
        public double СуммИск { get; set; }
    }

    public class DataCase
    {
        public int ЗапВсего { get; set; }
        public int СтрВсего { get; set; }
        public int СтрТекущ { get; set; }
        public List<Record> Записи { get; set; }
    }

    
}
