using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using LawFirmFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LawFirmLogic.Enums;
using LawFirmDataBaseImplement;

namespace LawFirmFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;
        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order element;
            if (model.Id.HasValue)
            {
                element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec =>
               rec.Id) : 0;
                element = new Order { Id = maxId + 1 };
                source.Orders.Add(element);
            }
            element.ProductId = model.ProductId == 0 ? element.ProductId : model.ProductId;
            element.ClientId = model.ClientId == null ? element.ClientId : (int)model.ClientId;
            element.ImplementerId = model.ImplementerId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
        }


        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id ==
          model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                return context.Orders
                .Where(rec => model == null || (rec.Id == model.Id &&
               model.Id.HasValue) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate
               >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
               (model.FreeOrders.HasValue && model.FreeOrders.Value &&
               !rec.ImplementerId.HasValue) ||
                (model.ImplementerId.HasValue && rec.ImplementerId ==
               model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ImplementerId = rec.ImplementerId,
                    ProductId = rec.ProductId,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                    ProductName = rec.Product.ProductName
                })
               .ToList();
            }
        }
    }
}