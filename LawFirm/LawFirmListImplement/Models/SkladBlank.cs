using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmListImplement.Models
{
    public class SkladBlank
    {
        public int Id { get; set; }
        public int SkladId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
    }
}
