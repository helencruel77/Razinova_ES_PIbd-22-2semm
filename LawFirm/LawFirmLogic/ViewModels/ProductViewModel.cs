﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LawFirmLogic.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название пакета документов")] public string ProductName { get; set; }

        [DisplayName("Цена")] public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductBlanks { get; set; }
    }
}