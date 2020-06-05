using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmBusinessLogics.ViewModels
{
    public class SkladViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string SkladName { get; set; }
        public List<SkladBlankViewModel> SkladBlanks { get; set; }
    }
}
