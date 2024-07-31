using HtmlAgilityPack;
using JupiterWebAPI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace JupiterWebAPI.Services
{
    public class Parcing
    {
       
        public static string Parce(string city, int count, string datefrom, string dateto, string search, string wasmjs)
        {
            string tokenofd = "83M50SKzEGAhLkJ3";
            WebClient httpClient = new WebClient();
            string wasm = httpClient.DownloadString("https://kad.arbitr.ru");
            string wasmpr = wasm.Substring(0, Math.Min(wasm.Length, 3610));
            HtmlDocument wasmsrc = new HtmlDocument();
            wasmsrc.LoadHtml(wasmpr.Substring(3510));

            HtmlNode scriptNode = wasmsrc.DocumentNode.SelectSingleNode("//script");
            string link = "";
            if (scriptNode != null)
            {
                link = scriptNode.GetAttributeValue("src", "");
            }

            string token =  httpClient.DownloadString($"https://kad.arbitr.ru{link}");
            token = token.Substring(93605);
            token = token.Substring(0, token.Length - 28793);
            token = token.Split(',')[1].Trim(' ');
            token = token.Substring(1);
            token = token.Substring(0, token.Length - 1);

            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            var client = new HttpClient(handler);
            string cookies = "wasm="+wasmjs+";";
            cookies += "CUID=357a34e8-6f04-401e-ab0e-93e505396302:oke74fd7FuIriBKcqb81KA==;pr_fp=905d5b586a34449bbfa4d64bd20b92db85ce906c3096f26d4dddd6d97f1bd71c;rcid=4a585d30-3c30-4d81-b07c-e411fad99b19";
            client.DefaultRequestHeaders.Add("Cookie", cookies);
            string cityparam = $"[\"{city}\"]";
            if (!string.IsNullOrEmpty(datefrom)) { datefrom = "\"" + datefrom + "T00:00:00\""; } else { datefrom = "null"; }
            if (!string.IsNullOrEmpty(dateto)) { dateto = "\"" + dateto + "T00:00:00\""; } else { dateto = "null"; }
            if (!string.IsNullOrEmpty(search)) { search = "{Name: \"" + search + "\", Type: -1, ExactMatch: true}"; }
            string a = "{\"Page\":1,\"Count\":25,\"Courts\":"+cityparam+",\"DateFrom\":"+datefrom+", \"DateTo\":"+dateto+",\"Sides\":[],\"Judges\":[],\"CaseNumbers\":[],\"WithVKSInstances\":false}";
            HttpContent httpContent = new StringContent(a, Encoding.UTF8, "application/json");
            var response =  client.PostAsync("https://kad.arbitr.ru/Kad/SearchInstances", httpContent).Result;
            string rs =  response.Content.ReadAsStringAsync().Result;
 

            var html = rs;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var caseList = new List<ArbitrationCaseShort>();

            doc.LoadHtml(html);

            var rows = doc.DocumentNode.SelectNodes("//tr");
            try
            {
                if (rows != null)
                {
                    foreach (var row in rows.Take(5))
                    {
                        var dateNode = row.SelectSingleNode(".//div[@class='civil']/span");
                        var caseLinkNode = row.SelectSingleNode(".//a[@class='num_case']");
                        var judgeNode = row.SelectSingleNode(".//div[@class='judge']");
                        var courtNode = row.SelectSingleNode(".//td[@class='court']/div/div[2]");
                        var plaintiffNode = row.SelectSingleNode(".//td[@class='plaintiff']/div/div/span");
                        var respondentNode = row.SelectSingleNode(".//td[@class='respondent']/div/div/span/span/strong");
                        var addresNode = row.SelectSingleNode(".//td[@class='respondent']/div/div/span/span");
                        //js-rolloverHtml

                        if (dateNode != null && caseLinkNode != null && judgeNode != null && courtNode != null && plaintiffNode != null && respondentNode != null)
                        {
                            string region = "";
                            if (city == "KRASNODAR")
                            {
                                region = "23";
                            }
                            else if(city == "ROSTOV")
                            {
                                region = "61";
                            }
                            else if (city == "STAVROPOL")
                            {
                                region = "26";
                            }
                            else if (city == "KRYM")
                            {
                                region = "91";
                            }
                            string rsearch = httpClient.DownloadString($"https://api.ofdata.ru/v2/search?key=Wu9oTkSakE3oHupQ&by=name&obj=org&query={Regex.Replace(respondentNode.InnerText.Trim(), "&quot;", "\"")}&region="+ region);
                            Root root = JsonConvert.DeserializeObject<Root>(rsearch);
                            string addrcode = "";
                            string adr = addresNode.InnerText.Trim().Substring(respondentNode.InnerText.Trim().Length).ToString();
                             adr = adr.Substring(respondentNode.InnerText.Trim().Length).Trim(' ');
                             addrcode = adr.Substring(0, Math.Min(adr.Length, 6));
                            string inn = "";
                            string kpp = "";
                            string ogrn = "";
                            string sr = "";
                            string srj = "";

                            //Данные скрыты
                                Запись rec = root.data.Записи.Where(p => p.ЮрАдрес.Substring(0, Math.Min(p.ЮрАдрес.Length, 6)).Contains(addrcode)).FirstOrDefault();
                                if (rec != null)
                                {
                                    inn = rec.ИНН;
                                    kpp = rec.КПП;
                                    ogrn = rec.ОГРН;
                                    sr = rec.Руковод.FirstOrDefault().ФИО;
                                    srj = rec.Руковод.FirstOrDefault().НаимДолжн;
                                }
                                else
                                {
                                    rec = root.data.Записи.FirstOrDefault();
                                    if (rec != null)
                                    {
                                        inn = rec.ИНН;
                                        kpp = rec.КПП;
                                        ogrn = rec.ОГРН;
                                        sr = rec.Руковод.FirstOrDefault().ФИО;
                                        srj = rec.Руковод.FirstOrDefault().НаимДолжн;
                                    }
                                }
                            string phones = "";

                            string emails = "";
                            string cs = "";
                            string web = "";
                            if (inn != "")
                            {
                                string rsearchinc = httpClient.DownloadString($"https://api.ofdata.ru/v2/company?key=cD1XsQf5B2924Efq&inn=" + inn);
                                RootInc rootinc = JsonConvert.DeserializeObject<RootInc>(rsearchinc);
                                if (rootinc.data.Контакты.Тел != null)
                                {
                                    phones = string.Join(", ", rootinc.data.Контакты.Тел);
                                }
                                if (rootinc.data.Контакты.Емэйл != null)
                                {
                                    emails = string.Join(", ", rootinc.data.Контакты.Емэйл);
                                }
                                if (rootinc.data.Контакты.ВебСайт != null)
                                {
                                    web = string.Join(", ", rootinc.data.Контакты.ВебСайт);
                                }
                                try
                                 {
                                     string rsearcases = httpClient.DownloadString("https://api.ofdata.ru/v2/legal-cases?key=Wu9oTkSakE3oHupQ&inn=" + inn);
                                     RootObject rootcases = JsonConvert.DeserializeObject<RootObject>(rsearcases);
                                     string t = rootcases.company.ОГРН;
                                     string k = rootcases.data.ЗапВсего.ToString();
                                     string f = rootcases.company.Статус.ToString();
                                     cs = $"аналитика по делам: {k} всего дел в архиве";
                                         foreach (Запись1 record in rootcases.data.Записи.Take(3))
                                         {
                                             cs += record.Дата + " " + record.Номер + " " + record.Ист.FirstOrDefault().Наим + " " + record.СуммИск + " ";
                                         }
                                     rsearcases = "";
                                 }
                                 catch { }
                            }

                            var caseInfo = new ArbitrationCaseShort
                            {
                                Court = courtNode.InnerText.Trim(),
                                CaseNumber = caseLinkNode.InnerText.Trim(),
                                Plaintiff = plaintiffNode.InnerText.Trim(),
                                Respondent = respondentNode.InnerText.Trim(),
                                Date = dateNode.InnerText.Trim(),
                                Judge = judgeNode.InnerText.Trim(),
                                Address = addresNode.InnerText.Trim().Substring(respondentNode.InnerText.Trim().Length).ToString(),
                                INNRespondent = inn,
                                KPPRespondent = kpp,
                                OGRNRespondent = ogrn,
                                SupervisorRespondent = sr,
                                SupervisorJobRespondent = srj,
                                СaseLink = caseLinkNode.Attributes["href"].Value.ToString(),
                                Phones = phones, 
                                Webs = web,
                                Emails = emails,
                                Cases = cs
                            };
                            caseList.Add(caseInfo);


                        }
                    }

                    List<ArbitrationCaseShort> result = new List<ArbitrationCaseShort>();

                    foreach (var caseInfo in caseList)
                    {
                        string plaintiff = caseInfo.Plaintiff.Substring(105).TrimStart(' ').TrimEnd(' ');
                        string respondent = "";
                        if (!caseInfo.Address.TrimStart(' ').Contains("Данные скрыты"))
                        {
                            respondent = Regex.Replace(caseInfo.Respondent, "&quot;", "\"") + ", адрес: " + caseInfo.Address + ", ИНН: " +
                           caseInfo.INNRespondent + ", ОГРН: " + caseInfo.OGRNRespondent + ", КПП: " + caseInfo.KPPRespondent + ", телефон:" + caseInfo.Phones + " " + caseInfo.SupervisorJobRespondent + " " + caseInfo.SupervisorRespondent + " "+ caseInfo.Webs + " "+ caseInfo.Emails+ " "+ caseInfo.Cases;

                        }
                        else
                        {
                            respondent = Regex.Replace(caseInfo.Respondent, "&quot;", "\"") + " Данные скрыты";
                        }
                        result.Add(new ArbitrationCaseShort { Date = caseInfo.Date, Judge = caseInfo.Judge.Replace("  ", ""), СaseLink = caseInfo.СaseLink.Replace("  ", ""), Court = caseInfo.Court, CaseNumber = caseInfo.CaseNumber, Plaintiff = plaintiff.Substring(0, plaintiff.Length - 1).Replace("  ", "").Replace("&quot;", "\""), Respondent = respondent, });
                    }
                    return JsonConvert.SerializeObject(result);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
