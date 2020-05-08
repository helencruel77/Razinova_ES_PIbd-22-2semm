using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    public class BlankViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название бланка")]
        public string BlankName { get; set; }
    }
}