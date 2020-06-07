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
        public List<Sklad> Sklads { get; set; }
        public List<SkladBlank> SkladBlanks { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductBlank> ProductBlanks { get; set; }
        public List<Client> Clients { set; get; }
        private DataListSingleton()
        {
            Blanks = new List<Blank>();
            Sklads = new List<Sklad>();
            SkladBlanks = new List<SkladBlank>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductBlanks = new List<ProductBlank>();
            Clients = new List<Client>();
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