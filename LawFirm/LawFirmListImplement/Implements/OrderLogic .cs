using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using LawFirmListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LawFirmLogic.Enums;

namespace LawFirmListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var order in source.Orders)
            {

                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }

        private Order CreateModel(OrderBindingModel model, Order tempOrder)
        {
            tempOrder.ProductId = model.ProductId == 0 ? tempOrder.ProductId : model.ProductId;
            tempOrder.Count = model.Count;
            tempOrder.ClientId = model.ClientId == 0 ? tempOrder.ClientId : (int)model.ClientId;
            tempOrder.ClientFIO = model.ClientFIO;
            tempOrder.Sum = model.Sum;
            tempOrder.Status = model.Status;
            tempOrder.DateCreate = model.DateCreate;
            tempOrder.DateImplement = model.DateImplement;
            return tempOrder;
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();

            foreach (var order in source.Orders)
            {
                if (
                    model != null && order.Id == model.Id
                    || model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo
                    || model.ClientId.HasValue && order.ClientId == model.ClientId
                    || model.FreeOrders.HasValue && model.FreeOrders.Value
                    || model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется
                )
                {
                    result.Add(CreateViewModel(order));
                    break;
                }

                result.Add(CreateViewModel(order));
            }

            return result;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string ProductName = "";
            for (int j = 0; j < source.Products.Count; ++j)
            {
                if (source.Products[j].Id == order.ProductId)
                {
                    ProductName = source.Products[j].ProductName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ProductName = ProductName,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}