using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawFirmRestAPI
{
    public class ProductModel
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public decimal Price { set; get; }
    }
}