namespace JupiterWebAPI.Models
{
    using System;
    using System.Collections.Generic;

    public class Company1
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

    public class ИстComponent
    {
        public string ИНН { get; set; }
        public string Наим { get; set; }
        public string Адрес { get; set; }
    }

    public class ОтветComponent
    {
        public string ИНН { get; set; }
        public string Наим { get; set; }
        public string Адрес { get; set; }
    }

    public class Запись1
    {
        public string Номер { get; set; }
        public string UUID { get; set; }
        public string СтрКАД { get; set; }
        public DateTime Дата { get; set; }
        public string Суд { get; set; }
        public List<ИстComponent> Ист { get; set; }
        public List<ОтветComponent> Ответ { get; set; }
        public decimal СуммИск { get; set; }
    }

    public class Data1
    {
        public int ЗапВсего { get; set; }
        public int СтрВсего { get; set; }
        public int СтрТекущ { get; set; }
        public List<Запись1> Записи { get; set; }
    }

    public class Meta
    {
        public string status { get; set; }
        public int today_request_count { get; set; }
        public decimal balance { get; set; }
    }

    public class RootObject
    {
        public Company1 company { get; set; }
        public Data1 data { get; set; }
        public Meta meta { get; set; }
    }
}
