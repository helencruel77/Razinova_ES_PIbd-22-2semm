using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmListImplement.Models;
using System;
using System.Collections.Generic;

namespace LawFirmListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;
        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product tempProduct = model.Id.HasValue ? null : new Product { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть пакет документов с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Products.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(ProductBindingModel model)
        {
            for (int i = 0; i < source.ProductBlanks.Count; ++i)
            {
                if (source.ProductBlanks[i].ProductId == model.Id)
                {
                    source.ProductBlanks.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductBlanks.Count; ++i)
            {
                if (source.ProductBlanks[i].Id > maxPCId)
                {
                    maxPCId = source.ProductBlanks[i].Id;
                }
                if (source.ProductBlanks[i].ProductId == product.Id)
                {
                    if
                    (model.ProductBlanks.ContainsKey(source.ProductBlanks[i].BlankId))
                    {
                        source.ProductBlanks[i].Count =
                        model.ProductBlanks[source.ProductBlanks[i].BlankId].Item2;

                        model.ProductBlanks.Remove(source.ProductBlanks[i].BlankId);
                    }
                    else
                    {
                        source.ProductBlanks.RemoveAt(i--);
                    }
                }
            }
            foreach (var pc in model.ProductBlanks)
            {
                source.ProductBlanks.Add(new ProductBlank
                {
                    Id = ++maxPCId,
                    ProductId = product.Id,
                    BlankId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var blank in source.Products)
            {
                if (model != null)
                {
                    if (blank.Id == model.Id)
                    {
                        result.Add(CreateViewModel(blank));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(blank));
            }
            return result;
        }
        private ProductViewModel CreateViewModel(Product product)
        {
            Dictionary<int, (string, int)> productBlanks = new Dictionary<int,
           (string, int)>();
            foreach (var pc in source.ProductBlanks)
            {
                if (pc.ProductId == product.Id)
                {
                    string blankName = string.Empty;
                    foreach (var blank in source.Blanks)
                    {
                        if (pc.BlankId == blank.Id)
                        {
                            blankName = blank.BlankName;
                            break;
                        }
                    }
                    productBlanks.Add(pc.BlankId, (blankName, pc.Count));
                }
            }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductBlanks = productBlanks
            };
        }

    }
}