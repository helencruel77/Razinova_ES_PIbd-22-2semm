using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { set; get; }
        public string ClientFIO { set; get; }
        public int ProductId { get; set; }
        public int? ImplementerId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
        public bool? FreeOrders { get; set; }
    }
}