using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LawFirmFileImplement.Models
{
    public class ProductBlank
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
    }
}