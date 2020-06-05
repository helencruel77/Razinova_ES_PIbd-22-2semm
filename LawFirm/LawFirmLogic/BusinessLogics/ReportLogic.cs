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
            List<ReportProductBlankViewModel> list = new List<ReportProductBlankViewModel>();
            foreach (var product in productLogic.Read(null))
            {
                foreach (var blank in product.ProductBlanks)
                {
                    list.Add(new ReportProductBlankViewModel()
                    {
                        ProductName = product.ProductName,
                        BlankName = blank.Value.Item1,
                        TotalCount = blank.Value.Item2
                    });
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
               ProductName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .GroupBy(x => x.DateCreate)
           .ToList();
        }

        public List<ReportOrdersViewModel> GetOrders()
        {
            return orderLogic.Read(null)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ProductName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
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
                Orders = GetOrders()
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