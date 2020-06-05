using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.HelperModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmBusinessLogics.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISkladLogic skladLogic;
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic, ISkladLogic skladLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.skladLogic = skladLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportProductBlankViewModel> GetProductBlank()
        {
            var products = productLogic.Read(null);
            var list = new List<ReportProductBlankViewModel>();

            foreach (var product in products)
            {
                foreach (var pc in product.ProductBlanks)
                {
                    var record = new ReportProductBlankViewModel
                    {
                        ProductName = product.ProductName,
                        BlankName = pc.Value.Item1,
                        TotalCount = pc.Value.Item2
                    };

                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportSkladBlankViewModel> GetSkladBlanks()
        {
            var sklads = skladLogic.GetList();
            var list = new List<ReportSkladBlankViewModel>();

            foreach (var sklad in sklads)
            {
                foreach (var wc in sklad.SkladBlanks)
                {
                    var record = new ReportSkladBlankViewModel
                    {
                        SkladName = sklad.SkladName,
                        BlankName = wc.BlankName,
                        Count = wc.Count
                    };

                    list.Add(record);
                }
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Products = productLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductBlanksToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список пакетов с документами",
                ProductBlanks = GetProductBlank()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveSkladsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Products = null,
                Sklads = skladLogic.GetList()
            });
        }

        public void SaveSkladBlanksToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список бланков в складах",
                Orders = null,
                Sklads = skladLogic.GetList()
            });
        }

        public void SaveBlanksToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Бланки",
                ProductBlanks = null,
                SkladBlanks = GetSkladBlanks()
            });
        }
    }
}