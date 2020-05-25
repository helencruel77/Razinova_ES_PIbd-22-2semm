﻿using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogics.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportProductBlankViewModel> ProductBlanks { get; set; }

        public List<ReportSkladBlankViewModel> SkladBlanks { get; internal set; }
    }
}