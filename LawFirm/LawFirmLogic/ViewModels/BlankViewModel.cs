using LawFirmLogic.Attributes;
using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    public class BlankViewModel : BaseViewModel
    {
        [Column(title: "Бланк", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string BlankName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "BlankName"
        };
    }
}