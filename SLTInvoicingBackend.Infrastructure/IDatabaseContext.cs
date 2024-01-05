using SLTInvoicingBackend.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLTInvoicingBackend.Infrastructure
{
    public interface IDatabaseContext
    {
        DbSet<ACCOUNTCODE> ACCOUNTCODES { get; set; }
        DbSet<BILLINGCENTER> BILLINGCENTERs { get; set; }
        DbSet<CASHIER> CASHIERs { get; set; }
        DbSet<COSTCENTER> COSTCENTERs { get; set; }
        DbSet<DEFECTGOOD> DEFECTGOODS { get; set; }
        DbSet<EQUIPMENT> EQUIPMENTs { get; set; }
        DbSet<EQUIPMENTSERIAL> EQUIPMENTSERIALs { get; set; }
        DbSet<INVOICEDETAIL> INVOICEDETAILS { get; set; }
        DbSet<INVOICEHEADER> INVOICEHEADERs { get; set; }
        DbSet<OPERATIONSLOG> OPERATIONSLOGs { get; set; }
        DbSet<PRICEREVISION> PRICEREVISIONS { get; set; }
        DbSet<QUOTATIONDETAIL> QUOTATIONDETAILS { get; set; }
        DbSet<QUOTATIONHEADER> QUOTATIONHEADERs { get; set; }
        DbSet<REASON> REASONs { get; set; }
        DbSet<RETURNGOOD> RETURNGOODS { get; set; }
        DbSet<STOCK> STOCKs { get; set; }
        DbSet<SUPPLIER> SUPPLIERS { get; set; }
        DbSet<TAX> TAXes { get; set; }
        DbSet<VENDOR> VENDORS { get; set; }
        DbSet<STOCKMGT> STOCKMGTs { get; set; }
        DbSet<ERP_INV_TRAN_TYPE> ERP_INV_TRAN_TYPE { get; set; }
        DbSet<ERP_PURPOSEOFUSE> ERP_PURPOSEOFUSE { get; set; }
        DbSet<ERP_INIT_CHECK> ERP_INIT_CHECK { get; set; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);
        Database Database { get; }
        void Dispose();
    }
}
