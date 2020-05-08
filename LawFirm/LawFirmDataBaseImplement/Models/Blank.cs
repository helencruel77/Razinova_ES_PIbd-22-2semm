using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LawFirmDataBaseImplement.Models
{
    public class Blank
    {
        public int Id { get; set; }

        [Required]
        public string BlankName { get; set; }

        [ForeignKey("BlankId")]
        public virtual List<ProductBlank> ProductBlanks { get; set; }
    }
}