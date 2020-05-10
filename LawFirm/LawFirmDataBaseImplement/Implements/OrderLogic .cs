﻿using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LawFirmDataBaseImplement.Models;
using LawFirmLogic.Enums;

namespace LawFirmDataBaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order { };
                    context.Orders.Add(element);
                }
                element.Count = model.Count;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                element.ClientId = model.ClientId.Value;
                element.ImplementerId = model.ImplementerId;
                element.ProductId = model.ProductId;
                element.Status = model.Status;
                element.Sum = model.Sum;
                context.SaveChanges();

            }
        }


        public void Delete(OrderBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
          model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
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
                    ImplementerFIO = rec.ImplementerId.HasValue ?
               rec.Implementer.ImplementerFIO : string.Empty,
                    ProductName = rec.Product.ProductName
                })
               .ToList();
            }

        }

    }
}