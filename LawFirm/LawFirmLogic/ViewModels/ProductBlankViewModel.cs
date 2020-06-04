using LawFirmLogic.Attributes;
using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    [DataContract]
    public class ProductBlankViewModel : BaseViewModel
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int BlankId { get; set; }

        [DataMember]
        [Column(title: "Бланк", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string BlankName { get; set; }

        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "BlankName",
            "Count"
        };
    }
}
