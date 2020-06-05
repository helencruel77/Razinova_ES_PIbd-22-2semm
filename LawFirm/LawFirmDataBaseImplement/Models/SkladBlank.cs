using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LawFirmDataBaseImplement.Models
{
    public class SkladBlank
    {
        public int Id { get; set; }

        public int SkladId { get; set; }

        public int BlankId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Blank Blank { get; set; }

        public virtual Sklad Sklad { get; set; }
    }
}
