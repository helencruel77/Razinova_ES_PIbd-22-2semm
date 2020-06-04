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
    public class ClientViewModel : BaseViewModel
    {
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { set; get; }

        [Column(title: "Почта", width: 150)]
        [DataMember]
        public string Email { set; get; }

        [DataMember]
        public string Password { set; get; }

        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "Email"
        };
    }
}