using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmDataBaseImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        public void CreateOrUpdate(ProductBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Product element = context.Products.FirstOrDefault(rec =>
                       rec.ProductName == model.ProductName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть пакет документов с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Products.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Product();
                            context.Products.Add(element);
                        }
                        element.ProductName = model.ProductName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productBlanks = context.ProductBlanks.Where(rec
                           => rec.ProductId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.ProductBlanks.RemoveRange(productBlanks.Where(rec =>
                            !model.ProductBlanks.ContainsKey(rec.BlankId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateBlank in productBlanks)
                            {
                                updateBlank.Count =
                               model.ProductBlanks[updateBlank.BlankId].Item2;

                                model.ProductBlanks.Remove(updateBlank.BlankId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.ProductBlanks)
                        {
                            context.ProductBlanks.Add(new ProductBlank
                            {
                                ProductId = element.Id,
                                BlankId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }

                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.ProductBlanks.RemoveRange(context.ProductBlanks.Where(rec =>
                        rec.ProductId == model.Id));
                        Product element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Products.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                return context.Products
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new ProductViewModel
               {
                   Id = rec.Id,
                   ProductName = rec.ProductName,
                   Price = rec.Price,
                   ProductBlanks = context.ProductBlanks
               .Where(recPC => recPC.ProductId == rec.Id)
               .ToDictionary(recPC => recPC.BlankId, recPC =>
                (recPC.Blank?.BlankName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}