﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.BusinessLogics;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LawFirmRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IProductLogic _product;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IProductLogic product, MainLogic main)
        {
            _order = order;
            _product = product;
            _main = main;
        }
        [HttpGet]
        public List<ProductModel> GetProductList() => _product.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public ProductModel GetProduct(int productId) => Convert(_product.Read(new
       ProductBindingModel
        { Id = productId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private ProductModel Convert(ProductViewModel model)
        {
            if (model == null) return null;
            return new ProductModel
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Price = model.Price
            };
        }
    }
}