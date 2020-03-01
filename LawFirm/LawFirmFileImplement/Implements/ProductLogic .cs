using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmFileImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly FileDataListSingleton source;
        public ProductLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.ProductName ==
           model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть пакет документов с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Products.Count > 0 ? source.Blanks.Max(rec =>
               rec.Id) : 0;
                element = new Product { Id = maxId + 1 };
                source.Products.Add(element);
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;

            source.ProductBlanks.RemoveAll(rec => rec.ProductId == model.Id &&
           !model.ProductBlanks.ContainsKey(rec.BlankId));

            var updateBlanks = source.ProductBlanks.Where(rec => rec.ProductId ==
           model.Id && model.ProductBlanks.ContainsKey(rec.BlankId));
            foreach (var updateBlank in updateBlanks)
            {
                updateBlank.Count =
               model.ProductBlanks[updateBlank.BlankId].Item2;
                model.ProductBlanks.Remove(updateBlank.BlankId);
            }
            int maxPCId = source.ProductBlanks.Count > 0 ?
           source.ProductBlanks.Max(rec => rec.Id) : 0;
            foreach (var pc in model.ProductBlanks)
            {
                source.ProductBlanks.Add(new ProductBlank
                {
                    Id = ++maxPCId,
                    ProductId = element.Id,
                    BlankId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(ProductBindingModel model)
        {
            source.ProductBlanks.RemoveAll(rec => rec.ProductId == model.Id);
            Product element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            return source.Products
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                Price = rec.Price,
                ProductBlanks = source.ProductBlanks
            .Where(recPC => recPC.ProductId == rec.Id)
           .ToDictionary(recPC => recPC.BlankId, recPC =>
            (source.Blanks.FirstOrDefault(recC => recC.Id ==
           recPC.BlankId)?.BlankName, recPC.Count))
            })
            .ToList();
        }
    }
}