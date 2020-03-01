using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (var Order in source.Orders)
            {
                if (model != null)
                {
                    if (Order.Id == model.Id)
                    {
                        result.Add(CreateViewModel(Order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Order));
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
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}