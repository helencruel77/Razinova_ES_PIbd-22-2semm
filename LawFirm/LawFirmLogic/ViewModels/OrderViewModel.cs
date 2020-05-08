﻿using LawFirmLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Пакет документов")] public string ProductName { get; set; }

        [DisplayName("Количество")] public int Count { get; set; }

        [DisplayName("Сумма")] public decimal Sum { get; set; }

        [DisplayName("Статус")] public OrderStatus Status { get; set; }

        [DisplayName("Дата создания")] public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")] public DateTime? DateImplement { get; set; }
    }
}