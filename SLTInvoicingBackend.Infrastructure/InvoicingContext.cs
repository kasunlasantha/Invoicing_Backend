namespace SLTInvoicingBackend.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SLTInvoicingBackend.Core;

    public partial class InvoicingContext : DbContext, IDatabaseContext
    {
        public InvoicingContext()
            : base("name=SLTInvoicingContext")
        {
            Configuration.ProxyCreationEnabled = false;//this is line to be added
        }

        public virtual DbSet<ACCOUNTCODE> ACCOUNTCODES { get; set; }
        public virtual DbSet<BILLINGCENTER> BILLINGCENTERs { get; set; }
        public virtual DbSet<CASHIER> CASHIERs { get; set; }
        public virtual DbSet<COSTCENTER> COSTCENTERs { get; set; }
        public virtual DbSet<DEFECTGOOD> DEFECTGOODS { get; set; }
        public virtual DbSet<EQUIPMENT> EQUIPMENTs { get; set; }
        public virtual DbSet<EQUIPMENTSERIAL> EQUIPMENTSERIALs { get; set; }
        public virtual DbSet<INVOICEDETAIL> INVOICEDETAILS { get; set; }
        public virtual DbSet<INVOICEHEADER> INVOICEHEADERs { get; set; }
        public virtual DbSet<OPERATIONSLOG> OPERATIONSLOGs { get; set; }
        public virtual DbSet<PRICEREVISION> PRICEREVISIONS { get; set; }
        public virtual DbSet<QUOTATIONDETAIL> QUOTATIONDETAILS { get; set; }
        public virtual DbSet<QUOTATIONHEADER> QUOTATIONHEADERs { get; set; }
        public virtual DbSet<REASON> REASONs { get; set; }
        public virtual DbSet<RETURNGOOD> RETURNGOODS { get; set; }
        public virtual DbSet<STOCK> STOCKs { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERS { get; set; }
        public virtual DbSet<TAX> TAXes { get; set; }
        public virtual DbSet<VENDOR> VENDORS { get; set; }
        public virtual DbSet<STOCKMGT> STOCKMGTs { get; set; }
        public virtual DbSet<ERP_INV_TRAN_TYPE> ERP_INV_TRAN_TYPE { get; set; }
        public virtual DbSet<ERP_PURPOSEOFUSE> ERP_PURPOSEOFUSE { get; set; }
        public virtual DbSet<ERP_INIT_CHECK> ERP_INIT_CHECK { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.CODEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.CODEUPPER)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.CODELOWER)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.ISBULK)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ACCOUNTCODE>()
                .Property(e => e.BASE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ACCOUNTCODE>()
                .HasMany(e => e.INVOICEDETAILS)
                .WithOptional(e => e.ACCOUNTCODE)
                .HasForeignKey(e => e.ACCODE);

            //modelBuilder.Entity<ACCOUNTCODE>()
            //    .HasMany(e => e.INVOICEHEADERs)
            //    .WithOptional(e => e.ACCOUNTCODE)
            //    .HasForeignKey(e => e.ACCODE);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_COSTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_PAYRECON)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_FILEGENSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_IP)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_LASTPID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_UN)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_PW)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.BC_REGIONCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.FILESEQNUM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.NEWCONNCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .Property(e => e.CURRENCY)
                .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
               .Property(e => e.ANNOUNCEMENT)
               .IsUnicode(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .HasMany(e => e.STOCKs)
                .WithRequired(e => e.BILLINGCENTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .HasMany(e => e.CASHIERs)
                .WithRequired(e => e.BILLINGCENTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILLINGCENTER>()
                .HasMany(e => e.EQUIPMENTSERIALs)
                .WithOptional(e => e.BILLINGCENTER)
                .HasForeignKey(e => e.BCCODE);

            modelBuilder.Entity<BILLINGCENTER>()
                .HasMany(e => e.INVOICEHEADERs)
                .WithOptional(e => e.BILLINGCENTER)
                .HasForeignKey(e => e.BCCODE);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_SERVICEID)
                .IsUnicode(false);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.BC_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_LEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CA_SEQ_NO)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CERTIFICATESERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.INVOSTATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CASHIER>()
                .Property(e => e.CRM_SEQ_NO)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COSTCENTER>()
                .Property(e => e.CENTERID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COSTCENTER>()
                .Property(e => e.CENTERCODE)
                .IsUnicode(false);

            modelBuilder.Entity<COSTCENTER>()
                .Property(e => e.CENTERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<COSTCENTER>()
                .HasMany(e => e.INVOICEHEADERs)
                .WithOptional(e => e.COSTCENTER)
                .HasForeignKey(e => e.COSTCODE);

            modelBuilder.Entity<COSTCENTER>()
                .HasMany(e => e.STOCKMGTs)
                .WithOptional(e => e.COSTCENTER)
                .HasForeignKey(e => e.COSTCODE);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.DEFECTNO)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.DEFSEQ)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.ITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.NOOFITEMS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.RETURNNEWITEMS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.STRUSER)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.PRINTSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.DEFECTSERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.NEWSERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.ERP_UPLOAD_STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.ERROR_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.TRYCOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.BCCODE)
                .IsUnicode(false);

            // added by kasun
            modelBuilder.Entity<DEFECTGOOD>()
                .Property(e => e.DEFECT_REASON)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.EQUID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.EQUCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.EQUNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.VENDOR)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.SUPPLIER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.BARCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.REORDERLEVEL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.REORDERQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.SELLING)
                 .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.MARKUP)
                 .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.COST)
                 .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.ACCOUNTSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.EQUTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.EQUBLOCK)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.WARRANTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.DEFECTGOODS)
                .WithOptional(e => e.EQUIPMENT)
                .HasForeignKey(e => e.ITEMCODE);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.STOCKs)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.EQUIPMENTSERIALs)
                .WithOptional(e => e.EQUIPMENT)
                .HasForeignKey(e => e.ITEMCODE);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.INVOICEDETAILS)
                .WithOptional(e => e.EQUIPMENT)
                .HasForeignKey(e => e.ITEMCODE);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.PRICEREVISIONS)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.RETURNGOODS)
                .WithOptional(e => e.EQUIPMENT)
                .HasForeignKey(e => e.ITEMCODE);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.STOCKMGTs)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENTSERIAL>()
                .Property(e => e.SERIALID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EQUIPMENTSERIAL>()
                .Property(e => e.INVONO)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENTSERIAL>()
                .Property(e => e.ITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENTSERIAL>()
                .Property(e => e.SERIALNO)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENTSERIAL>()
                .Property(e => e.BCCODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.INVODEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.ITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.ITEMSEQ)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.SERIALS)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.RECEIPTNO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.ACCODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.MOVEORDERNO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.ERP_UPLOAD_STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.TRYCOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.RETURN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.RETURN_MESSAGE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.IS_RETURNED)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.CANCEL_RETURN_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.CANCEL_RETURN_MESSAGE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.CANCEL_ERP_SENT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEDETAIL>()
                .Property(e => e.CANCEL_TRYCOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.INVOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.ISTAX)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.TAXSEQNO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.TAXID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.COSTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.ACCODE)
                 .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.INVOTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.CUSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.CUSTCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.REFNO)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.INVOICEUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.PRINTSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.CANCELSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.CANCELUSER)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.TRANSFERSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.UPLOADSTATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.BCCODE)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.ISPAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.RECEIPTSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.TRANSTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.PURPOSEOFUSE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
               .Property(e => e.RETURNINVNO)
               .IsUnicode(false);

            modelBuilder.Entity<INVOICEHEADER>()
                .Property(e => e.RETURNAMOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<INVOICEHEADER>()
                .HasMany(e => e.EQUIPMENTSERIALs)
                .WithOptional(e => e.INVOICEHEADER)
                .HasForeignKey(e => e.INVONO);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.SEQUENCE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.LOGINNAME)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.DIVISION)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.SIGNTEXT)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.SIGNATURE)
                .IsUnicode(false);

            modelBuilder.Entity<OPERATIONSLOG>()
                .Property(e => e.BCCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.PRICEPLANID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.EQUCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.DISCOUNTRS)
                .HasPrecision(15, 2);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.DISCOUNTPV)
                .HasPrecision(15, 2);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.ACTIVE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.CENTER)
                .IsUnicode(false);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.REVCOST)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.REVMARKUP)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.REVSELLING)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRICEREVISION>()
                .Property(e => e.EXSELLING)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.INVODEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.ITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.ITEMSEQ)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.SERIALS)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.RECEIPTNO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.ACCODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONDETAIL>()
                .Property(e => e.MOVEORDERNO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.INVOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.ISTAX)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.TAXSEQNO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.TAXID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.COSTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.ACCODE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.INVOTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.CUSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.CUSTCONTACT)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.REFNO)
                .IsUnicode(false);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.INVOICEUSER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.PRINTSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.CANCELSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.CANCELUSER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.TRANSFERSTAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.UPLOADSTATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<QUOTATIONHEADER>()
                .Property(e => e.BCCODE)
                .IsUnicode(false);

            modelBuilder.Entity<REASON>()
                .Property(e => e.ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REASON>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.RETURNNO)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.RETSEQ)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.ITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.NOOFITEMS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.OPTIONTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.NEWITEMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.NEWQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.STRUSER)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.RETURNSERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.NEWSERIAL)
                .IsUnicode(false);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.ERP_UPLOAD_STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.TRYCOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.ERROR_CODE)
                .IsUnicode(false);

            // center code is added by kasun
            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.CENTERCODE)
                .IsUnicode(false);

            // IS_COMPLETE is added by kasun
            modelBuilder.Entity<RETURNGOOD>()
                .Property(e => e.IS_COMPLETE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.STOCKID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.EQUCODE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.BC_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.RECEIVEDQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.SOLDQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.RESERVEDQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.DEFECTEDQTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.EQUTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.SUPPLIERID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.SUPPLIERCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.SUPPLIERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.CONTACTPERSON)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.TELEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SUPPLIER>()
                .HasMany(e => e.EQUIPMENTs)
                .WithOptional(e => e.SUPPLIER1)
                .HasForeignKey(e => e.SUPPLIER);

            modelBuilder.Entity<TAX>()
                .Property(e => e.TAXID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TAX>()
                .Property(e => e.TAXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<TAX>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TAX>()
                .Property(e => e.TAXVALUE)
                .HasPrecision(10, 8);

            modelBuilder.Entity<TAX>()
                .Property(e => e.CODEUPPER)
                .IsUnicode(false);

            modelBuilder.Entity<TAX>()
                .Property(e => e.CODELOWER)
                .IsUnicode(false);

            modelBuilder.Entity<TAX>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.VENDORID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.VENDORCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.VENDORNAME)
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.CONTACTPERSON)
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.TELEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<VENDOR>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENDOR>()
                .HasMany(e => e.EQUIPMENTs)
                .WithOptional(e => e.VENDOR1)
                .HasForeignKey(e => e.VENDOR);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.MGTID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.EQUCODE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.BC_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.COSTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.INVOICENO)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.RECEIVED_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.SOLD_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.RESERVED_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.DEFECTED_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.INCREASED_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.DECREASED_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.OPENING_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.CLOSING_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.STATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.ENTRYTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.REASONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.UPLOADSTATUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.EQUTYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCKMGT>()
                .Property(e => e.RETURN_QTY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ERP_INV_TRAN_TYPE>()
               .Property(e => e.TRAN_ID)
               .HasPrecision(38, 0);

            modelBuilder.Entity<ERP_INV_TRAN_TYPE>()
                .Property(e => e.TRAN_TYPE)
                .IsUnicode(false);

                 modelBuilder.Entity<ERP_PURPOSEOFUSE>()
                .Property(e => e.PURPOSEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ERP_PURPOSEOFUSE>()
                .Property(e => e.TRANSACTION_TYPE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ERP_PURPOSEOFUSE>()
                .Property(e => e.PURPOSE)
                .IsUnicode(false);

            modelBuilder.Entity<ERP_INIT_CHECK>()
               .Property(e => e.USERNAME)
               .IsUnicode(false);

            modelBuilder.Entity<ERP_INIT_CHECK>()
                .Property(e => e.OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<ERP_INIT_CHECK>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ERP_INIT_CHECK>()
                .Property(e => e.CENTRE)
                .IsUnicode(false);
        }
    }
}
