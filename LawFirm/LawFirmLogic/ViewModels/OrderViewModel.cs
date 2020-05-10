using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [DisplayName("Id клиента")]
        public int ClientId { set; get; }
        [DataMember]
        [DisplayName("ФИО клиента")]
        public string ClientFIO { set; get; }
        [DataMember]
        [DisplayName("Пакет документов")] public string ProductName { get; set; }
        [DataMember]
        [DisplayName("Количество")] public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")] public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")] public OrderStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")] public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")] public DateTime? DateImplement { get; set; }
    }
}