using LawFirmLogic.Attributes;
using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    [DataContract]
    public class ProductViewModel : BaseViewModel
    {
        [Column(title: "Название пакета документов", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ProductName { get; set; }

        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ProductBlanks { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ProductName",
            "Price"
        };
    }
}