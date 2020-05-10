using LawFirmBusinessLogics.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogics.BindingModels
{
    public class SkladBindingModel
    {
        public int? Id { get; set;}

        public string SkladName { get; set; }

        public List<SkladBlankBindingModel> SkladBlanks { get; set; }
    }
}
