using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LawFirmListImplement.Models
{
    public class ProductBlank
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BlankId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Blank Blank { get; set; }
        public virtual Product Product { get; set; }
    }
}