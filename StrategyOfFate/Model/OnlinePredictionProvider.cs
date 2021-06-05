using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    public class OnlinePredictionProvider : IPredictionProvider
    {

        struct ZodiacRange
        {
            public YearDayRange Range;
            public string Name;

            public ZodiacRange (YearDayRange range, string name)
            {
                Name = name; Range = range;
            }

        }

        readonly private ZodiacRange[] ranges = {
                new ZodiacRange(new YearDayRange(new YearDay(21,03), new YearDay(20,04)), "aries"), //овен
                new ZodiacRange(new YearDayRange(new YearDay(21,04), new YearDay(21,05)), "taurus"), // телец
                new ZodiacRange(new YearDayRange(new YearDay(22,05), new YearDay(21,06)), "gemini"), // близнецы
                new ZodiacRange(new YearDayRange(new YearDay(22,06), new YearDay(22,07)), "cancer"), // рак
                new ZodiacRange(new YearDayRange(new YearDay(23,07), new YearDay(23,08)), "leo"), // лев
                new ZodiacRange(new YearDayRange(new YearDay(24,08), new YearDay(23,09)), "virgo"), // дева
                new ZodiacRange(new YearDayRange(new YearDay(24,09), new YearDay(23,10)), "libra"), // весы
                new ZodiacRange(new YearDayRange(new YearDay(24,10), new YearDay(22,11)), "scorpio"), // скорпион
                new ZodiacRange(new YearDayRange(new YearDay(23,11), new YearDay(21,12)), "sagittarius"), // стелец
                new ZodiacRange(new YearDayRange(new YearDay(22,12), new YearDay(20,01)), "capricorn"), // козерог
                new ZodiacRange(new YearDayRange(new YearDay(21,01), new YearDay(18,02)), "aquarius"), // водолей
                new ZodiacRange(new YearDayRange(new YearDay(19,02), new YearDay(20,03)), "pisces") // рыбы
            };

        private string GenerateMailRuURIFromBirthDate(DateTime date)
        {
            var bDate = Properties.Settings.Default.BirthDate;
            var bYearDay = new YearDay(bDate.Day, bDate.Month);
            var template = "https://horo.mail.ru/prediction/{0}/today/";
            string signName = "aries";
            for (int i = 0; i < 12; i++)
            {
                if (PredictionSelectorHelper.CheckIsYearDayInRange(ranges[i].Range, bYearDay))
                {
                    signName = ranges[i].Name;
                    break;
                }
            }
            return string.Format(template, signName);
        }

        private string DownloadPage(string urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream,
                        Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return data;
            } 
            else
            {
                throw new Exception("Не удалось установить соединение.");
            }
        }

        private string ParsePredictionText(string fullCode)
        {
            var extractRegex = new Regex("(?<=<div class=\"article__item article__item_alignment_left article__item_html\">)(.*)(?=<\\/p>)");
            string tmp = extractRegex.Match(fullCode).Value.Replace("<p>", "").Replace(@"</p>", ""); 
            return tmp; 
        }

        public string GetPredictionByBirthDate()
        {
            var bDate = Properties.Settings.Default.BirthDate;
            if (bDate == DateTime.MinValue) { return "Нет данных";  }
            var mailUri = GenerateMailRuURIFromBirthDate(bDate);
            string pageCode;
            try
            {
                pageCode = DownloadPage(mailUri);
            } catch (Exception ex)
            {
                return ex.Message;
            }
            return ParsePredictionText(pageCode);
        }
    }
}
