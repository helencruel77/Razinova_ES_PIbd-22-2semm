using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LawFirmDataBaseImplement.Models
{
    public class Sklad
    {
        public int Id { get; set; }

        [Required]
        public string SkladName { get; set; }

        public virtual List<SkladBlank> SkladBlank { get; set; }
    }
}
