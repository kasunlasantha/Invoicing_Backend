﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLTInvoicingBackend.WebAPI.DTOs
{
    public class ReportDTO
    {
        public string BCENTERNAME { get; set; }
        public string DATETO { get; set; }
        public string DATEFROM { get; set; }
    }
}