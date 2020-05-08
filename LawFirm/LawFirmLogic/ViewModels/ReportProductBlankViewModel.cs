using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    public class ReportProductBlankViewModel
    {
        public string BlankName { get; set; }
        public string ProductName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Products { get; set; }
    }
}