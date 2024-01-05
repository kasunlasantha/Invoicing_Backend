﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices
{
    public interface IStockMgtRepository : IDisposable
    {
        STOCKMGT CREATE(STOCKMGT stock);
    }
}
