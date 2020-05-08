using LawFirmLogic.BindingModels;
using LawFirmLogic.HelperModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IBlankLogic blankLogic;
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic, IBlankLogic blankLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.blankLogic = blankLogic;
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

        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Products = productLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
               // Orders = GetOrders(model)
            });
        }

        public void SaveProductComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список пакетов документов с бланками",
                ProductBlanks = GetProductBlank()
            });
        }
    }
}