using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Core.DomainServices.Filtering
{
    public class FilteredList <T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
