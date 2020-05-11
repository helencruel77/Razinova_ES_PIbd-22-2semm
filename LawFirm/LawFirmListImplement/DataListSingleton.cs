using LawFirmListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Blank> Blanks { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductBlank> ProductBlanks { get; set; }
        public List<Client> Clients { set; get; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
        private DataListSingleton()
        {
            Blanks = new List<Blank>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductBlanks = new List<ProductBlank>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}