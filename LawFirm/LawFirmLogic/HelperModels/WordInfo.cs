using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogics.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<SkladViewModel> Sklads { get; set; }
    }
}