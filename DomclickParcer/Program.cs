using DomclickParcer.Controler;
using DomclickParcer.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace DomclickParcer
{
    class Program
    {
        public static int CountIterration = 0;
        public static bool isFinished = false;
        static void Main(string[] args)
        {
            //Без этих настроек сайт домклика просто выкидывает или в тупую не отрывает (защита от ботов там просто на космическом уровне)
            #region Настройки запуска хрома
            var options = new ChromeOptions();
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36");
            options.AddArgument("--remote-debugging-port=9232");
            options.AddArgument("--window-size=1500,920");
            options.AddArguments("--disable-infobars");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors");
            options.AddArgument("no-sandbox");
            var service = ChromeDriverService.CreateDefaultService();
            
            //Чтобы лишний раз не писал об ошибках SSl
            service.HideCommandPromptWindow = true;
            #endregion

            //Тот самый элемент что и имитирует работу человека
            var driver = new ChromeDriver(service, options);

            //Класс для работы с java скриптами в браузере
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Если запускать сразу из консоли то сразу блочат доступ навесегда(или дают второй шанс, но потом тоже блочат на какое-то веремя)
            js.ExecuteScript("window.open('https://domclick.ru/search?deal_type=sale&category=living&offer_type=complex&with_domclick_offers=1&address=1d1463ae-c80f-4d19-9331-a1b68a85b553&aids=2299&from=topline2020&offset=0')");

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[0]);
            driver.Close();
            driver.SwitchTo().Window(windowHandles[1]);


            bool test = false;

            if (test)
            {
                //Тут были тесты с выгрузкой на OneDrive
            }
            else
            {
                Thread.Sleep(5000);
                Console.Clear();
                Logging($"{DateTime.Now}");

                var flatAtributes = new List<FlatAtributes>();

                ///Тут все збито вручную т.к. постоянно нужно хилить парсер и удобней искать ошибки. Опять же предпологалось временно, но времени что-то менять нет
                #region Обекты парсинга

                #region ЖК Солнечный-3
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/solnechnyi-3__60802", Name = "ЖК Солнечный-3" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >= 3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена обработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #region ЖК Екатерининский парк
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/ekaterininskii-park__108023", Name = "ЖК Екатерининский парк" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >= 3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена обработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #region Притяжние
                ParcePritajenie(driver);
                #endregion

                #region ЖК Брусника в Академическом
                flatAtributes = new List<FlatAtributes>();
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/brusnika-v-akademicheskom__116309", Name = "ЖК Брусника в Академическом" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >=3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена обработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #region ЖК ОЛИМПИКА
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/zhk-olimpika__116251", Name = "ЖК ОЛИМПИКА" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >= 3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена обработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #region ЖК Ленина, 8
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/lenina-8__111760", Name = "ЖК Ленина, 8" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >= 3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена обработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #region ЖК Жилой район Солнечный
                flatAtributes = new List<FlatAtributes>();
                flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/zhiloi-raion-solnechnyi__115058", Name = "ЖК Жилой район Солнечный" });
                while (isFinished == false)
                {
                    isFinished = CreateParsing(flatAtributes, driver);
                    CountIterration++;
                    if (CountIterration >= 3)
                    {
                        isFinished = true;
                    }
                }
                CountIterration = 0;
                Logging($"Закончена побработка {flatAtributes[0].Name}");
                isFinished = false;
                #endregion

                #endregion

                ///Комплексы которые не смогли пережить 24 ферваля
                #region Non used path (ЖК Хохрякова, ЖК КОНСТРУКТИВИЗМА)

                //flatAtributes = new List<FlatAtributes>();
                //flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/khokhriakova__116391", Name = "ЖК Хохрякова" });
                //while (isFinished == false)
                //{
                //    isFinished = CreateParsing(flatAtributes, driver);
                //    CountIterration++;
                //    if (CountIterration >= 3)
                //    {
                //        isFinished = true;
                //    }
                //}
                //CountIterration = 0;
                //Console.WriteLine($"Закончена обработка {flatAtributes[0].Name}");

                //flatAtributes = new List<FlatAtributes>();
                //flatAtributes.Add(new FlatAtributes { Href = "https://ekaterinburg.domclick.ru/complexes/zhk-konstruktivizma__116257?from_similar=116251", Name = "ЖК КОНСТРУКТИВИЗМА" });
                //while (isFinished == false)
                //{
                //    isFinished = CreateParsing(flatAtributes, driver);
                //    CountIterration++;
                //    if (CountIterration >= 3)
                //    {
                //        isFinished = true;
                //    }
                //}
                //CountIterration = 0;
                //Console.WriteLine($"Закончена обработка {flatAtributes[0].Name}");
                //isFinished = false;
                #endregion

            }
            driver.Close();
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        #region +-Логирование (скорее -)
        /// <summary>
        /// Какое-то подобие логирования, которое тут и подрузомевалось с самого начала но я не успел(как и всегда принципе)
        /// </summary>
        /// <param name="str">То что будет в выводе консоли</param>
        public static void Logging(string str)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]: {str}");
        }
        #endregion

        #region Метод парсинга копмлекса, на данный момент заточен под один комплекс
        /// <summary>
        /// Меотод который и парсит сайт состоит из двух методов LoadFlatHrefs - метод для получения всех ссылок на все квартиры в комплексе и LoadFlats - метод который и парсит все квартиры
        /// </summary>
        /// <param name="flatAtributes">Сейчас это ссылка на нужный нам комплекс. Изначально в этом параметре был полный список комплексов но позже для лучшей отловки проблем было решено что лучше тут будет по одной ссылке на один комплекс, но класс тогда не успел сменить и так оно на всегда и осталось</param>
        /// <param name="driver">Класс драйвера, который и работает с хромом</param>
        /// <returns></returns>
        public static bool CreateParsing(List<FlatAtributes> flatAtributes, ChromeDriver driver)
        {
            try
            {
                flatAtributes = LoadFlatHrefs(flatAtributes, driver);
                flatAtributes = LoadFlats(flatAtributes, driver);

                if (flatAtributes.Count == 0)
                    return false;

                if (flatAtributes[0].Hrefs.Count == 0)
                    return false;

                ExcelController excel = new ExcelController(flatAtributes);
                excel.WriteDocumet();
            }
            catch (Exception e)
            {
                Logging(e.Message);
                Logging("Перезапуск");
                return false;
            }
            return true;
        }
        #endregion

        #region Метод перелистывания квартир в комплексе
        /// <summary>
        /// Метод получающий из ссылки на комплекс список ссылкок на квартиры в нём 
        /// </summary>
        /// <param name="driver">Класс драйвера, который и работает с хромом</param>
        /// <param name="residentialComplexHresfs">Ссылка на комплекс и кваритры в нём. Изначально задумовалось что тут будет полный список комплексов с сылками на квартиры в комплексе но сейчас это ссылка на один комплекс с квартирами в нём, опять же потомучто не успел</param>
        /// <returns>Неполный список ссылок на квартиры (в котрых как в троянском коне может быть 100+ квартир) и наименование комплекса</returns>
        public static List<FlatAtributes> GetFlatAtributes(ChromeDriver driver, List<ResidentialComplexHresf> residentialComplexHresfs)
        {
            List<FlatAtributes> flagsAttributes = new List<FlatAtributes>();
            foreach (var residentialComplex in residentialComplexHresfs)
            {
                driver.Navigate().GoToUrl(residentialComplex.HrefForTown);
                var complexSnippet_complexNames = driver.FindElements(By.ClassName("complexSnippet_complexName"));
                var FlatAtributes = driver.FindElements(By.ClassName("complexSnippet_flatsCount"));
                var countPage = Convert.ToInt32(driver.FindElements(By.ClassName("TMIxJ")).Last().Text);
                for (int i = 0; i < countPage; i++)
                {
                    int ii = 0;
                    foreach (var item2 in FlatAtributes)
                    {
                        string Name = complexSnippet_complexNames[ii].Text;
                        if (residentialComplex.HrefsForHouses.Contains(Name))
                        {
                            flagsAttributes.Add(new FlatAtributes
                            {
                                Href = item2.GetAttribute("href"),
                                Name = complexSnippet_complexNames[ii].Text
                            });
                        }
                        ii++;
                    }
                    driver.Navigate().GoToUrl("https://domclick.ru/search?deal_type=sale&category=living&offer_type=complex&with_domclick_offers=1&address=1d1463ae-c80f-4d19-9331-a1b68a85b553&aids=2299&from=topline2020&offset=" +
                        $"{i + 1}0");
                    FlatAtributes = driver.FindElements(By.ClassName("complexSnippet_flatsCount"));
                    complexSnippet_complexNames = driver.FindElements(By.ClassName("complexSnippet_complexName"));
                    Thread.Sleep(1000);
                }
            }

            return flagsAttributes;
        }
        #endregion

        #region Метод перелистывания списка кватир для получнеия полного списка квартир
        
        /// <summary>
        /// Метод который получает из неполного списка квартир полный список всех квартир комплекса
        /// </summary>
        /// <param name="flatAtributes"></param>
        /// <param name="driver">Класс драйвера, который и работает с хромом</param>
        /// <returns>Полный список ссылок на квартиры и наименование комплекса</returns>
        public static List<FlatAtributes> LoadFlatHrefs(List<FlatAtributes> flatAtributes, ChromeDriver driver)
        {
            foreach (var item in flatAtributes)
            {
                driver.Navigate().GoToUrl(item.Href);
                var roomsLayoutsList_roomTitleContents = driver.FindElements(By.ClassName("roomsLayoutsList_roomTitleContent"));
                foreach (var roomsLayoutsList_roomTitleContent in roomsLayoutsList_roomTitleContents)
                {
                    IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
                    javascriptExecutor.ExecuteScript("arguments[0].click();", roomsLayoutsList_roomTitleContent);

                    var sc_pagination_roots = driver.FindElements(By.ClassName("sc_pagination_root"));
                    IWebElement sc_pagination_root = null;
                    try
                    {
                        sc_pagination_root = sc_pagination_roots[0];
                    }
                    catch{}

                    if (sc_pagination_roots.Count > 1 )
                    {
                        sc_pagination_root = sc_pagination_roots[0];
                        var buttons = sc_pagination_root.FindElements(By.ClassName("sc_pagination_button"));
                        for (int i = 1; i <= Convert.ToInt32(sc_pagination_root.FindElements(By.ClassName("sc_pagination_button")).Last().Text); i++)
                        {
                            buttons = sc_pagination_root.FindElements(By.ClassName("sc_pagination_button"));
                            javascriptExecutor.ExecuteScript("arguments[0].click();", buttons.Where(el => el.Text == i.ToString()).FirstOrDefault());
                            Thread.Sleep(1000);
                        
                            var roomsLayoutsList_roomLayouts = driver.FindElements(By.ClassName("roomsLayoutsList_roomLayout"));

                            foreach (var roomsLayoutsList_roomLayout in roomsLayoutsList_roomLayouts)
                            {
                                try
                                {
                                    item.Hrefs.Add(roomsLayoutsList_roomLayout.GetAttribute("href"));
                                }
                                catch 
                                {
                                    item.Hrefs.Add("Error");
                                }
                            }

                            sc_pagination_roots = driver.FindElements(By.ClassName("sc_pagination_root"));
                            sc_pagination_root = sc_pagination_roots[0];
                        }
                    }
                    else
                    {
                        var roomsLayoutsList_roomLayouts = driver.FindElements(By.ClassName("roomsLayoutsList_roomLayout"));
                        foreach (var roomsLayoutsList_roomLayout in roomsLayoutsList_roomLayouts)
                        {
                            item.Hrefs.Add(roomsLayoutsList_roomLayout.GetAttribute("href"));
                        }
                    }
                    javascriptExecutor.ExecuteScript("arguments[0].click();", roomsLayoutsList_roomTitleContent);
                    Thread.Sleep(2000);

                }
            }
            return flatAtributes;
        }

        #endregion

        #region Парсер Притяжения. Парсер в парсере (смешно, нет?, а должно быть, но мне вот не смешно, ну как и вам :) )

        /// <summary>
        /// Метод который парсит сайт притяжения т.к. его нет на домклике
        /// </summary>
        /// <param name="driver"></param>
        public static void ParcePritajenie(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("https://притяжение-екб.рф/kvartiry/?page=3000");
            ExcelController excelController = new ExcelController("притяжение-екб");
            var flats = driver.FindElements(By.ClassName("parametric-results__loader"));
            List<PFlat> ListFlats = new List<PFlat>();

            for (int i = 0; i < flats.Count; i += 7)
            {
                string name = "0";
                if (flats[i + 1].Text.Contains("Трехкомнатная квартира"))
                {
                    name = "3";
                }
                if (flats[i + 1].Text.Contains("Двухкомнатная квартира"))
                {
                    name = "2";
                }
                if (flats[i + 6].Text.AsEnumerable().Any(ch => char.IsLetter(ch)))
                {
                    ListFlats.Add(new PFlat
                    {
                        Name = name,
                        SM2 = flats[i + 3].Text,
                        Deadline = flats[i + 5].Text,
                        Cost = "",
                        CostForSM2 = ""
                    });
                }
                else
                {
                    ListFlats.Add(new PFlat
                    {
                        Name = name,
                        SM2 = flats[i + 3].Text,
                        Deadline = flats[i + 5].Text,
                        Cost = flats[i + 6].Text.Replace(" ", ""),
                        CostForSM2 = Math.Round(Convert.ToDouble(flats[i + 6].Text.Replace(" ", "")) / Convert.ToDouble(flats[i + 3].Text.Replace('.', ',')), 2).ToString()
                    });
                }
            }
            excelController.PSave(ListFlats);
            Logging($"Закончена обработка притяжение-екб.рф");
        }
        #endregion

        #region Метод отпаршивания квартиры

        /// <summary>
        /// Метод каоторый заходит в ссылку на квартиру и парсит данные из неёё
        /// </summary>
        /// <param name="flatAtributes">Список квартир и название комплекса</param>
        /// <param name="driver">Класс драйвера, который и работает с хромом</param>
        /// <returns>Отпарвшенный список квартир и наименование комплекса</returns>
        public static List<FlatAtributes> LoadFlats(List<FlatAtributes> flatAtributes, ChromeDriver driver)
        {
            foreach (var flatAtribute in flatAtributes)
            {
                flatAtribute.Hrefs = flatAtribute.Hrefs.GroupBy(x => x).Select(y => y.FirstOrDefault()).ToList();
                foreach (var HrefOnFlat in flatAtribute.Hrefs)
                {
                    if (HrefOnFlat == "Error")
                    {
                        continue;
                    }
                    driver.Navigate().GoToUrl(HrefOnFlat);
                    var complexInfo_buildingInfoItems = driver.FindElements(By.ClassName("complexInfo_buildingInfoItem"));
                    var complexInfo_buildingInfoItem = complexInfo_buildingInfoItems.Where(el => el.GetAttribute("data-test-id") == "constructionPeriod").FirstOrDefault();

                    string deadLine = "";
                    try
                    {
                        deadLine = complexInfo_buildingInfoItem.FindElement(By.ClassName("complexInfo_itemValue")).Text;
                    } catch {}

                    //Переменная отвечает за проверку 
                    IWebElement webElement = null;
                    try {webElement = driver.FindElement(By.ClassName("flatSelection_title"));} catch {}

                    var sc_flatInfoList = driver.FindElement(By.ClassName("sc_flatInfoList"));
                    var sc_flatInfoList_rows = sc_flatInfoList.FindElements(By.ClassName("sc_flatInfoList_row"));
                    
                    string Type = "";
                    string SquareFootage = "";

                    foreach (var sc_flatInfoList_row in sc_flatInfoList_rows)
                    {
                        if (sc_flatInfoList_row.FindElement(By.ClassName("sc_flatInfoList_rowLabel")).Text.Contains("Общая площадь"))
                        {
                            SquareFootage = sc_flatInfoList_row.FindElement(By.ClassName("sc_flatInfoList_rowValue")).Text;
                        }
                    }

                    foreach (var sc_flatInfoList_row in sc_flatInfoList_rows)
                    {
                        if (sc_flatInfoList_row.FindElement(By.ClassName("sc_flatInfoList_rowLabel")).Text.Contains("Комнат"))
                        {
                            Type = sc_flatInfoList_row.FindElement(By.ClassName("sc_flatInfoList_rowValue")).Text;
                        }
                    }



                    if (webElement != null)
                    {
                        int countButtons = 0;
                        ReadOnlyCollection<IWebElement> sc_pagination_buttons = null;
                        try
                        {
                            sc_pagination_buttons = driver.FindElements(By.ClassName("sc_pagination_button"));
                            countButtons = Convert.ToInt32(sc_pagination_buttons.Last().Text);
                        }
                        catch 
                        {
                            countButtons = 0;
                        }

                        //Проверка на кол-во страниц на сайте квартиры 
                        if (countButtons != 0)
                        {
                            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
                            for (int i = 1; i <= countButtons; i++)
                            {
                                javascriptExecutor.ExecuteScript("arguments[0].click();", sc_pagination_buttons.Where(el => el.Text == i.ToString()).FirstOrDefault());
                                Thread.Sleep(1000);

                                //много квартир с кнопками
                                var flatSelection_flatCards = driver.FindElements(By.ClassName("flatSelection_flatCard"));
                                foreach (var flatSelection_flatCard in flatSelection_flatCards)
                                {
                                    flatAtribute.Flats.Add(new Flat
                                    {
                                        Cost = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_cardPrice")).Text,
                                        CostFotM2 = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_cardArea")).Text,
                                        SquareFootage = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_infoItemValue")).Text,
                                        Deadline = deadLine,
                                        Type = Type
                                    });
                                }
                            }
                        }
                        else
                        {

                            //много квартир без кнопок
                            var flatSelection_flatCards = driver.FindElements(By.ClassName("flatSelection_flatCard"));
                            foreach (var flatSelection_flatCard in flatSelection_flatCards)
                            {
                                flatAtribute.Flats.Add(new Flat 
                                { 
                                    Cost = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_cardPrice")).Text,
                                    CostFotM2 = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_cardArea")).Text,
                                    SquareFootage = flatSelection_flatCard.FindElement(By.ClassName("flatSelection_infoItemValue")).Text,
                                    Deadline = deadLine,
                                    Type = Type
                                });
                            }
                        }
                    }
                    else
                    {
                        //одна квартира
                        var el = driver.FindElement(By.ClassName("shortSummary_barePrice")).Text;
                        var el2 = driver.FindElement(By.ClassName("shortSummary_bareSqaurePrice")).Text;

                        flatAtribute.Flats.Add(new Flat
                        {
                            Cost = el,
                            CostFotM2 = el2,
                            SquareFootage = SquareFootage,
                            Deadline = deadLine,
                            Type = Type
                        });
                    }
                }
            }
            return flatAtributes;
        }
        #endregion
    }
}
