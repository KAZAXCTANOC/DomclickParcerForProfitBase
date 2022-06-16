using DomclickParcer.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DomclickParcer.Controler
{
    /// <summary>
    /// Класс который работает с основой мировой экономики (Excel)
    /// </summary>
    public class ExcelController
    {
        Regex regex = new Regex(@"[^\p{IsCyrillic}\d\r\n]");
        private string NameObject { get; set; }
        private string Path 
        { 
            get 
            {
                //Тут забито гвозядми т.к. небыло смыла делать настройки
                return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\FilesFromParser\\" + regex.Replace(NameObject, "")+ "_" + Guid.NewGuid().ToString() + ".xlsx";
            } 
        }
        private List<FlatAtributes> NeedToWrite;
        public ExcelController(List<FlatAtributes> needToWrite)
        {
            NeedToWrite = needToWrite;
        }
        public ExcelController(string Path)
        {
            NameObject = Path;
        }
        public void PSave(List<PFlat> ListFlats)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage(Path))
            {
                int x = 2;

                ExcelWorksheet sheetCosts = excel.Workbook.Worksheets.Add("Costs");

                sheetCosts.Cells[1, 1].Value = "Стоимость";
                sheetCosts.Cells[1, 2].Value = "Стоимость за м2";
                sheetCosts.Cells[1, 3].Value = "Площадь";
                sheetCosts.Cells[1, 4].Value = "Сроки строительства";
                sheetCosts.Cells[1, 5].Value = "Кол-во комнат";

                foreach (var flat in ListFlats)
                {
                    sheetCosts.Cells[x, 1].Value = flat.Cost;
                    sheetCosts.Cells[x, 2].Value = flat.CostForSM2;
                    sheetCosts.Cells[x, 3].Value = flat.SM2;
                    sheetCosts.Cells[x, 4].Value = flat.Deadline;
                    sheetCosts.Cells[x, 5].Value = flat.Name;
                    x++;
                }

                excel.Save();
            }
        }

        public void WriteDocumet()
        {
            foreach (var element in NeedToWrite)
            {
                NameObject = element.Name;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excel = new ExcelPackage(Path))
                {
                    int x = 2;

                    ExcelWorksheet sheetCosts = excel.Workbook.Worksheets.Add("Costs");

                    sheetCosts.Cells[1, 1].Value = "Стоимость";
                    sheetCosts.Cells[1, 2].Value = "Стоимость за м2";
                    sheetCosts.Cells[1, 3].Value = "Площадь";
                    sheetCosts.Cells[1, 4].Value = "Сроки строительства";
                    sheetCosts.Cells[1, 5].Value = "Кол-во комнат";
                    foreach (var flat in element.Flats)
                    {
                        sheetCosts.Cells[x, 1].Value = flat.Cost;
                        sheetCosts.Cells[x, 2].Value = flat.CostFotM2;
                        sheetCosts.Cells[x, 3].Value = flat.SquareFootage;
                        sheetCosts.Cells[x, 4].Value = flat.Deadline;
                        sheetCosts.Cells[x, 5].Value = flat.Type;
                        x++;
                    }

                    excel.Save();
                }
            }
        }
    }
}
