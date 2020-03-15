using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.BindingModels
{
    public class SkladBlankBindingModel
    {
        public int Id { get; set; }
        public int SkladId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
    }
}
