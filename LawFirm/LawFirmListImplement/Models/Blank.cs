using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawFirmListImplement.Models
{
    public class Blank
    {
        public int Id { get; set; }

        public string BlankName { get; set; }
    }
}