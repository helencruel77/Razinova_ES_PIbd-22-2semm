﻿using LawFirmLogic.Enums;
using LawFirmFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LawFirmFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string BlankFileName = "Blank.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ProductFileName = "Product.xml";
        private readonly string ProductBlankFileName = "ProductBlank.xml";
        public List<Blank> Blanks { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductBlank> ProductBlanks { get; set; }
        private FileDataListSingleton()
        {
            Blanks = LoadBlanks();
            Orders = LoadOrders();
            Products = LoadProducts();
            ProductBlanks = LoadProductBlanks();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveBlanks();
            SaveOrders();
            SaveProducts();
            SaveProductBlanks();

        }
        private List<Blank> LoadBlanks()
        {
            var list = new List<Blank>();
            if (File.Exists(BlankFileName))
            {
                XDocument xDocument = XDocument.Load(BlankFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Blank
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        BlankName = elem.Element("BlankName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Product> LoadProducts()
        {
            var list = new List<Product>();
            if (File.Exists(ProductFileName))
            {
                XDocument xDocument = XDocument.Load(ProductFileName);
                var xElements = xDocument.Root.Elements("Product").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Product
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductName = elem.Element("ProductName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<ProductBlank> LoadProductBlanks()
        {
            var list = new List<ProductBlank>();
            if (File.Exists(ProductBlankFileName))
            {
                XDocument xDocument = XDocument.Load(ProductBlankFileName);
                var xElements = xDocument.Root.Elements("ProductBlank").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new ProductBlank
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        BlankId = Convert.ToInt32(elem.Element("BlankId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveBlanks()
        {
            if (Blanks != null)
            {
                var xElement = new XElement("Blanks");
                foreach (var blank in Blanks)
                {
                    xElement.Add(new XElement("Blank",
                    new XAttribute("Id", blank.Id),
                    new XElement("BlankName", blank.BlankName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(BlankFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ProductId", order.ProductId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveProducts()
        {
            if (Products != null)
            {
                var xElement = new XElement("Products");
                foreach (var product in Products)
                {
                    xElement.Add(new XElement("Product",
                    new XAttribute("Id", product.Id),
                    new XElement("ProductName", product.ProductName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductFileName);
            }
        }
        private void SaveProductBlanks()
        {
            if (ProductBlanks != null)
            {
                var xElement = new XElement("ProductBlanks");
                foreach (var productBlank in ProductBlanks)
                {
                    xElement.Add(new XElement("ProductBlank",
                    new XAttribute("Id", productBlank.Id),
                    new XElement("ProductId", productBlank.ProductId),
                    new XElement("BlankId", productBlank.BlankId),
                    new XElement("Count", productBlank.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductBlankFileName);
            }
        }

    }
}