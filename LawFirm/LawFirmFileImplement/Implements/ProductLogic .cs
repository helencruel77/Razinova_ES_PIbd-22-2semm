using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
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
            Product temp = model.Id.HasValue ? null : new Product { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть пакет документов с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= temp.Id)
                {
                    temp.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    temp = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (temp == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, temp);
            }
            else
            {
                source.Products.Add(CreateModel(model, temp));
            }
        }

        private Product CreateModel(ProductBindingModel model, Product temp)
        {
            temp.ProductName = model.ProductName;
            temp.Price = model.Price;
            int maxSFId = 0;
            for (int i = 0; i < source.ProductBlanks.Count; ++i)
            {
                if (source.ProductBlanks[i].Id > maxSFId)
                {
                    maxSFId = source.ProductBlanks[i].Id;
                }
                if (source.ProductBlanks[i].ProductId == temp.Id)
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
            foreach (var sf in model.ProductBlanks)
            {
                source.ProductBlanks.Add(new ProductBlank
                {
                    Id = ++maxSFId,
                    ProductId = temp.Id,
                    BlankId = sf.Key,
                    Count = sf.Value.Item2
                });
            }
            return temp;
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
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in source.Products)
            {
                if (model != null)
                {
                    if (product.Id == model.Id)
                    {
                        result.Add(CreateViewModel(product));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(product));
            }
            return result;
        }

        private ProductViewModel CreateViewModel(Product product)
        {
            Dictionary<int, (string, int)> ProductBlanks = new Dictionary<int, (string, int)>();
            foreach (var sf in source.ProductBlanks)
            {
                if (sf.ProductId == product.Id)
                {
                    string BlankName = string.Empty;
                    foreach (var Blank in source.Blanks)
                    {
                        if (sf.BlankId == Blank.Id)
                        {
                            BlankName = Blank.BlankName;
                            break;
                        }
                    }
                    ProductBlanks.Add(sf.BlankId, (BlankName, sf.Count));
                }
            }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductBlanks = ProductBlanks
            };
        }
    }
}
