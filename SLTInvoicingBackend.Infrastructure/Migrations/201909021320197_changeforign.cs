namespace SLTInvoicingBackend.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeforign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SLT_ERPTEST2.ACCOUNTCODES",
                c => new
                    {
                        CODEID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CODE = c.String(maxLength: 7, unicode: false),
                        DESCRIPTION = c.String(maxLength: 128, unicode: false),
                        CREATEDDATE = c.DateTime(),
                        LASTUPDATE = c.DateTime(),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.CODEID);
            
            CreateTable(
                "SLT_ERPTEST2.INVOICEDETAILS",
                c => new
                    {
                        INVODEID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        INVOICENO = c.String(maxLength: 18, unicode: false),
                        ITEMCODE = c.String(maxLength: 12, unicode: false),
                        ITEMSEQ = c.Decimal(precision: 38, scale: 0),
                        QTY = c.Decimal(precision: 38, scale: 0),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        SERIALS = c.String(maxLength: 250, unicode: false),
                        RECEIPTNO = c.String(maxLength: 18, unicode: false),
                        ACCODE = c.Decimal(precision: 38, scale: 0),
                        UNITPRICE = c.Decimal(precision: 18, scale: 2),
                        MARKUPPRICE = c.Decimal(precision: 18, scale: 2),
                        COSTPRICE = c.Decimal(precision: 18, scale: 2),
                        UNITPRICED = c.Decimal(precision: 18, scale: 2),
                        UNITPRICEF = c.Decimal(precision: 18, scale: 2),
                        CODAAMOUNT = c.Decimal(precision: 18, scale: 2),
                        MOVEORDERNO = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.INVODEID)
                .ForeignKey("SLT_ERPTEST2.INVOICEHEADER", t => t.INVOICENO)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.ITEMCODE)
                .ForeignKey("SLT_ERPTEST2.ACCOUNTCODES", t => t.ACCODE)
                .Index(t => t.INVOICENO)
                .Index(t => t.ITEMCODE)
                .Index(t => t.ACCODE);
            
            CreateTable(
                "SLT_ERPTEST2.EQUIPMENT",
                c => new
                    {
                        EQUCODE = c.String(nullable: false, maxLength: 12, unicode: false),
                        EQUID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        EQUNAME = c.String(maxLength: 50, unicode: false),
                        VENDORCODE = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        SUPPLIERCODE = c.String(maxLength: 8, fixedLength: true, unicode: false),
                        REORDERLEVEL = c.Decimal(precision: 38, scale: 0),
                        REORDERQTY = c.Decimal(precision: 38, scale: 0),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                        LASTUPDATE = c.DateTime(),
                        ACCOUNTCODE = c.String(maxLength: 7, unicode: false),
                        BARCODE = c.String(maxLength: 32, unicode: false),
                        EQUTYPE = c.Decimal(precision: 38, scale: 0),
                        EQUBLOCK = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.EQUCODE)
                .ForeignKey("SLT_ERPTEST2.SUPPLIERS", t => t.SUPPLIERCODE)
                .ForeignKey("SLT_ERPTEST2.VENDORS", t => t.VENDORCODE)
                .Index(t => t.VENDORCODE)
                .Index(t => t.SUPPLIERCODE);
            
            CreateTable(
                "SLT_ERPTEST2.DEFECTGOODS",
                c => new
                    {
                        DEFFECTNO = c.String(nullable: false, maxLength: 14, unicode: false),
                        DEFSEQ = c.Decimal(nullable: false, precision: 38, scale: 0),
                        INVOICENO = c.String(maxLength: 50, unicode: false),
                        EQUCODE = c.String(maxLength: 12, unicode: false),
                        NOOFITEMS = c.Decimal(precision: 38, scale: 0),
                        RETURNNEWITEMS = c.Decimal(precision: 38, scale: 0),
                        RECORDDATE = c.DateTime(),
                        CA_ID = c.Decimal(precision: 38, scale: 0),
                        PRINTSTAT = c.Decimal(precision: 38, scale: 0),
                        DEFECTSERIAL = c.String(maxLength: 100, unicode: false),
                        NEWSERIAL = c.String(maxLength: 100, unicode: false),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.DEFFECTNO)
                .ForeignKey("SLT_ERPTEST2.CASHIER", t => t.CA_ID)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.EQUCODE)
                .Index(t => t.EQUCODE)
                .Index(t => t.CA_ID);
            
            CreateTable(
                "SLT_ERPTEST2.CASHIER",
                c => new
                    {
                        CA_ID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CA_SERVICEID = c.String(nullable: false, maxLength: 6, unicode: false),
                        CA_NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        CA_PASSWORD = c.String(nullable: false, maxLength: 32, unicode: false),
                        BC_CODE = c.String(nullable: false, maxLength: 4, unicode: false),
                        CA_LEVEL = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CA_SEQ_NO = c.Decimal(precision: 38, scale: 0),
                        CA_LOG_DATE = c.DateTime(),
                        CA_CLOSE_DATE = c.DateTime(),
                        STATUS = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CERTIFICATESERIAL = c.String(maxLength: 64, unicode: false),
                        CERTIFICATEEXPDATE = c.DateTime(),
                        INVOSTATUS = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CRM_SEQ_NO = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.CA_ID)
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BC_CODE)
                .Index(t => t.BC_CODE);
            
            CreateTable(
                "SLT_ERPTEST2.BILLINGCENTER",
                c => new
                    {
                        BC_CODE = c.String(nullable: false, maxLength: 4, unicode: false),
                        BC_COSTCODE = c.String(maxLength: 10, unicode: false),
                        BC_DESC = c.String(maxLength: 50, unicode: false),
                        BC_USERNAME = c.String(maxLength: 10, unicode: false),
                        BC_EODSTAMPED = c.Decimal(precision: 1, scale: 0),
                        BC_PAYRECON = c.Decimal(precision: 38, scale: 0),
                        BC_FILEGENSTAT = c.Decimal(precision: 38, scale: 0),
                        BC_IP = c.String(maxLength: 18, unicode: false),
                        BC_LASTPID = c.Decimal(precision: 38, scale: 0),
                        BC_UN = c.String(maxLength: 32, unicode: false),
                        BC_PW = c.String(maxLength: 64, unicode: false),
                        BC_REGIONCODE = c.String(maxLength: 4, unicode: false),
                        FILESEQNUM = c.Decimal(precision: 38, scale: 0),
                        NEWCONNCODE = c.String(maxLength: 10, unicode: false),
                        CURRENCY = c.String(maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.BC_CODE);
            
            CreateTable(
                "SLT_ERPTEST2.EQUIPMENTSERIAL",
                c => new
                    {
                        SERIALID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        INVONO = c.String(maxLength: 18, unicode: false),
                        ITEMCODE = c.String(maxLength: 12, unicode: false),
                        SERIALNO = c.String(maxLength: 75, unicode: false),
                        BCCODE = c.String(maxLength: 4, unicode: false),
                    })
                .PrimaryKey(t => t.SERIALID)
                .ForeignKey("SLT_ERPTEST2.INVOICEHEADER", t => t.INVONO)
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BCCODE)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.ITEMCODE)
                .Index(t => t.INVONO)
                .Index(t => t.ITEMCODE)
                .Index(t => t.BCCODE);
            
            CreateTable(
                "SLT_ERPTEST2.INVOICEHEADER",
                c => new
                    {
                        INVOICENO = c.String(nullable: false, maxLength: 18, unicode: false),
                        INVOID = c.Decimal(precision: 38, scale: 0),
                        ISTAX = c.Decimal(precision: 38, scale: 0),
                        TAXSEQNO = c.String(maxLength: 16, unicode: false),
                        TAXID = c.Decimal(precision: 38, scale: 0),
                        INVOICEDATE = c.DateTime(),
                        COSTCODE = c.String(maxLength: 4, unicode: false),
                        ACCODE = c.Decimal(precision: 38, scale: 0),
                        INVOTYPE = c.Decimal(precision: 38, scale: 0),
                        CUSTNAME = c.String(maxLength: 100, unicode: false),
                        CUSTCONTACT = c.String(maxLength: 100, unicode: false),
                        REFNO = c.String(maxLength: 50, unicode: false),
                        SUBTOTAL = c.Decimal(precision: 18, scale: 2),
                        DISCOUNTPRECENTAGE = c.Decimal(precision: 18, scale: 2),
                        DISCOUNT = c.Decimal(precision: 18, scale: 2),
                        VAT = c.Decimal(precision: 18, scale: 2),
                        TOTAL = c.Decimal(precision: 18, scale: 2),
                        INVOICEUSER = c.Decimal(precision: 38, scale: 0),
                        PRINTSTAT = c.Decimal(precision: 38, scale: 0),
                        CANCELSTAT = c.Decimal(precision: 38, scale: 0),
                        CANCELDATE = c.DateTime(),
                        CANCELUSER = c.Decimal(precision: 38, scale: 0),
                        TRANSFERSTAT = c.Decimal(precision: 38, scale: 0),
                        OTHERCHARGES = c.Decimal(precision: 18, scale: 2),
                        UPLOADSTATUS = c.Decimal(precision: 38, scale: 0),
                        PHDISCOUNT = c.Decimal(precision: 18, scale: 2),
                        RECEIPTDATE = c.DateTime(),
                        OTHERCHARGESVAT = c.Decimal(precision: 18, scale: 2),
                        VATDISCOUNT = c.Decimal(precision: 18, scale: 2),
                        BCCODE = c.String(maxLength: 4, unicode: false),
                    })
                .PrimaryKey(t => t.INVOICENO)
                .ForeignKey("SLT_ERPTEST2.COSTCENTER", t => t.COSTCODE)
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BCCODE)
                .ForeignKey("SLT_ERPTEST2.CASHIER", t => t.INVOICEUSER)
                .ForeignKey("SLT_ERPTEST2.CASHIER", t => t.CANCELUSER)
                .ForeignKey("SLT_ERPTEST2.ACCOUNTCODES", t => t.ACCODE)
                .Index(t => t.COSTCODE)
                .Index(t => t.ACCODE)
                .Index(t => t.INVOICEUSER)
                .Index(t => t.CANCELUSER)
                .Index(t => t.BCCODE);
            
            CreateTable(
                "SLT_ERPTEST2.COSTCENTER",
                c => new
                    {
                        CENTERCODE = c.String(nullable: false, maxLength: 4, unicode: false),
                        CENTERID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CENTERNAME = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CENTERCODE);
            
            CreateTable(
                "SLT_ERPTEST2.STOCKMGT",
                c => new
                    {
                        MGTID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        EQUCODE = c.String(nullable: false, maxLength: 12, unicode: false),
                        BC_CODE = c.String(maxLength: 4, unicode: false),
                        COSTCODE = c.String(maxLength: 4, unicode: false),
                        INVOICENO = c.String(maxLength: 20, unicode: false),
                        RECEIVED_QTY = c.Decimal(precision: 38, scale: 0),
                        SOLD_QTY = c.Decimal(precision: 38, scale: 0),
                        RESERVED_QTY = c.Decimal(precision: 38, scale: 0),
                        DEFECTED_QTY = c.Decimal(precision: 38, scale: 0),
                        INCREASED_QTY = c.Decimal(precision: 38, scale: 0),
                        DECREASED_QTY = c.Decimal(precision: 38, scale: 0),
                        OPENING_QTY = c.Decimal(precision: 38, scale: 0),
                        CLOSING_QTY = c.Decimal(precision: 38, scale: 0),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                        REFDATE = c.DateTime(),
                        ENTRYTYPE = c.Decimal(precision: 38, scale: 0),
                        REASONID = c.Decimal(precision: 38, scale: 0),
                        UPLOADSTATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => new { t.MGTID, t.EQUCODE })
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BC_CODE)
                .ForeignKey("SLT_ERPTEST2.REASON", t => t.REASONID)
                .ForeignKey("SLT_ERPTEST2.COSTCENTER", t => t.COSTCODE)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.EQUCODE)
                .Index(t => t.EQUCODE)
                .Index(t => t.BC_CODE)
                .Index(t => t.COSTCODE)
                .Index(t => t.REASONID);
            
            CreateTable(
                "SLT_ERPTEST2.REASON",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        DESCRIPTION = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SLT_ERPTEST2.PRICEREVISIONS",
                c => new
                    {
                        PRICEPLANID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        EQUCODE = c.String(nullable: false, maxLength: 12, unicode: false),
                        STARTING = c.DateTime(),
                        ENDING = c.DateTime(),
                        DISCOUNTRS = c.Decimal(precision: 15, scale: 2),
                        DISCOUNTPV = c.Decimal(precision: 15, scale: 2),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                        LASTUPDATE = c.DateTime(),
                        DESCRIPTION = c.String(maxLength: 50, unicode: false),
                        TYPE = c.Decimal(precision: 38, scale: 0),
                        ACTIVE = c.Decimal(precision: 38, scale: 0),
                        BC_CODE = c.String(maxLength: 4, unicode: false),
                        REVCOST = c.Decimal(precision: 38, scale: 0),
                        REVMARKUP = c.Decimal(precision: 38, scale: 0),
                        REVSELLING = c.Decimal(precision: 38, scale: 0),
                        EXSELLING = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.PRICEPLANID)
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BC_CODE)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.EQUCODE)
                .Index(t => t.EQUCODE)
                .Index(t => t.BC_CODE);
            
            CreateTable(
                "SLT_ERPTEST2.STOCK",
                c => new
                    {
                        STOCKID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        EQUCODE = c.String(nullable: false, maxLength: 12, unicode: false),
                        BC_CODE = c.String(nullable: false, maxLength: 4, unicode: false),
                        RECEIVEDQTY = c.Decimal(precision: 38, scale: 0),
                        SOLDQTY = c.Decimal(precision: 38, scale: 0),
                        RESERVEDQTY = c.Decimal(precision: 38, scale: 0),
                        DEFECTEDQTY = c.Decimal(precision: 38, scale: 0),
                        EQUTYPE = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.STOCKID)
                .ForeignKey("SLT_ERPTEST2.BILLINGCENTER", t => t.BC_CODE)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.EQUCODE)
                .Index(t => t.EQUCODE)
                .Index(t => t.BC_CODE);
            
            CreateTable(
                "SLT_ERPTEST2.OPERATIONSLOG",
                c => new
                    {
                        SEQUENCE = c.Decimal(nullable: false, precision: 38, scale: 0, identity: true),
                        EVENTDATE = c.DateTime(),
                        EVENTTIME = c.DateTime(),
                        LOGINNAME = c.Decimal(precision: 38, scale: 0),
                        DIVISION = c.String(maxLength: 20, unicode: false),
                        OPERATION = c.String(maxLength: 50, unicode: false),
                        DESCRIPTION = c.String(maxLength: 128, unicode: false),
                        SIGNTEXT = c.String(maxLength: 255, unicode: false),
                        SIGNATURE = c.String(unicode: false, storeType: "long"),
                    })
                .PrimaryKey(t => t.SEQUENCE)
                .ForeignKey("SLT_ERPTEST2.CASHIER", t => t.LOGINNAME)
                .Index(t => t.LOGINNAME);
            
            CreateTable(
                "SLT_ERPTEST2.RETURNGOODS",
                c => new
                    {
                        RETURNNO = c.String(nullable: false, maxLength: 14, unicode: false),
                        RETSEQ = c.Decimal(precision: 38, scale: 0),
                        INVOICENO = c.String(maxLength: 50, unicode: false),
                        EQUCODE = c.String(maxLength: 12, unicode: false),
                        NOOFITEMS = c.Decimal(precision: 38, scale: 0),
                        OPTIONTYPE = c.Decimal(precision: 38, scale: 0),
                        RECORDDATE = c.DateTime(),
                        CA_ID = c.Decimal(precision: 38, scale: 0),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        RETURNSERIAL = c.String(maxLength: 100, unicode: false),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.RETURNNO)
                .ForeignKey("SLT_ERPTEST2.CASHIER", t => t.CA_ID)
                .ForeignKey("SLT_ERPTEST2.EQUIPMENT", t => t.EQUCODE)
                .Index(t => t.EQUCODE)
                .Index(t => t.CA_ID);
            
            CreateTable(
                "SLT_ERPTEST2.SUPPLIERS",
                c => new
                    {
                        SUPPLIERCODE = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        SUPPLIERID = c.Decimal(precision: 38, scale: 0),
                        SUPPLIERNAME = c.String(maxLength: 64, unicode: false),
                        ADDRESS = c.String(maxLength: 128, unicode: false),
                        CONTACTPERSON = c.String(maxLength: 64, unicode: false),
                        TELEPHONE = c.String(maxLength: 32, unicode: false),
                        FAX = c.String(maxLength: 50, unicode: false),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.SUPPLIERCODE);
            
            CreateTable(
                "SLT_ERPTEST2.VENDORS",
                c => new
                    {
                        VENDORCODE = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        VENDORID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        VENDORNAME = c.String(maxLength: 64, unicode: false),
                        ADDRESS = c.String(maxLength: 128, unicode: false),
                        CONTACTPERSON = c.String(maxLength: 64, unicode: false),
                        TELEPHONE = c.String(maxLength: 32, unicode: false),
                        FAX = c.String(maxLength: 50, unicode: false),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.VENDORCODE);
            
            CreateTable(
                "SLT_ERPTEST2.TAX",
                c => new
                    {
                        TAXID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        TAXCODE = c.String(maxLength: 20, unicode: false),
                        DESCRIPTION = c.String(maxLength: 128, unicode: false),
                        TAXVALUE = c.Decimal(precision: 18, scale: 2),
                        CREATEDATE = c.DateTime(),
                        LASTUPDATE = c.DateTime(),
                        STATUS = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.TAXID);
            
            CreateTable(
                "SLT_ERPTEST2.QUOTATIONDETAILS",
                c => new
                    {
                        INVODEID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        INVOICENO = c.String(maxLength: 18, unicode: false),
                        ITEMCODE = c.String(maxLength: 12, unicode: false),
                        ITEMSEQ = c.Decimal(precision: 38, scale: 0),
                        QTY = c.Decimal(precision: 38, scale: 0),
                        AMOUNT = c.Decimal(precision: 18, scale: 2),
                        SERIALS = c.String(maxLength: 250, unicode: false),
                        RECEIPTNO = c.String(maxLength: 18, unicode: false),
                        ACCODE = c.Decimal(precision: 38, scale: 0),
                        UNITPRICE = c.Decimal(precision: 18, scale: 2),
                        MARKUPPRICE = c.Decimal(precision: 18, scale: 2),
                        COSTPRICE = c.Decimal(precision: 18, scale: 2),
                        UNITPRICED = c.Decimal(precision: 18, scale: 2),
                        UNITPRICEF = c.Decimal(precision: 18, scale: 2),
                        CODAAMOUNT = c.Decimal(precision: 18, scale: 2),
                        MOVEORDERNO = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.INVODEID)
                .ForeignKey("SLT_ERPTEST2.QUOTATIONHEADER", t => t.INVOICENO)
                .Index(t => t.INVOICENO);
            
            CreateTable(
                "SLT_ERPTEST2.QUOTATIONHEADER",
                c => new
                    {
                        INVOICENO = c.String(nullable: false, maxLength: 18, unicode: false),
                        INVOID = c.Decimal(precision: 38, scale: 0),
                        ISTAX = c.Decimal(precision: 38, scale: 0),
                        TAXSEQNO = c.String(maxLength: 16, unicode: false),
                        TAXID = c.Decimal(precision: 38, scale: 0),
                        INVOICEDATE = c.DateTime(),
                        COSTCODE = c.String(maxLength: 4, unicode: false),
                        ACCODE = c.Decimal(precision: 38, scale: 0),
                        INVOTYPE = c.Decimal(precision: 38, scale: 0),
                        CUSTNAME = c.String(maxLength: 100, unicode: false),
                        CUSTCONTACT = c.String(maxLength: 100, unicode: false),
                        REFNO = c.String(maxLength: 50, unicode: false),
                        SUBTOTAL = c.Decimal(precision: 18, scale: 2),
                        DISCOUNTPRECENTAGE = c.Decimal(precision: 18, scale: 2),
                        DISCOUNT = c.Decimal(precision: 18, scale: 2),
                        VAT = c.Decimal(precision: 18, scale: 2),
                        TOTAL = c.Decimal(precision: 18, scale: 2),
                        INVOICEUSER = c.Decimal(precision: 38, scale: 0),
                        PRINTSTAT = c.Decimal(precision: 38, scale: 0),
                        CANCELSTAT = c.Decimal(precision: 38, scale: 0),
                        CANCELDATE = c.DateTime(),
                        CANCELUSER = c.Decimal(precision: 38, scale: 0),
                        TRANSFERSTAT = c.Decimal(precision: 38, scale: 0),
                        OTHERCHARGES = c.Decimal(precision: 18, scale: 2),
                        UPLOADSTATUS = c.Decimal(precision: 38, scale: 0),
                        PHDISCOUNT = c.Decimal(precision: 18, scale: 2),
                        RECEIPTDATE = c.DateTime(),
                        OTHERCHARGESVAT = c.Decimal(precision: 18, scale: 2),
                        VATDISCOUNT = c.Decimal(precision: 18, scale: 2),
                        BCCODE = c.String(maxLength: 4, unicode: false),
                    })
                .PrimaryKey(t => t.INVOICENO);
            
            CreateTable(
                "dbo.ATMAP",
                c => new
                    {
                        TAXID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        CODEID = c.Decimal(nullable: false, precision: 38, scale: 0),
                    })
                .PrimaryKey(t => new { t.TAXID, t.CODEID })
                .ForeignKey("SLT_ERPTEST2.TAX", t => t.TAXID, cascadeDelete: true)
                .ForeignKey("SLT_ERPTEST2.ACCOUNTCODES", t => t.CODEID, cascadeDelete: true)
                .Index(t => t.TAXID)
                .Index(t => t.CODEID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SLT_ERPTEST2.QUOTATIONDETAILS", "INVOICENO", "SLT_ERPTEST2.QUOTATIONHEADER");
            DropForeignKey("dbo.ATMAP", "CODEID", "SLT_ERPTEST2.ACCOUNTCODES");
            DropForeignKey("dbo.ATMAP", "TAXID", "SLT_ERPTEST2.TAX");
            DropForeignKey("SLT_ERPTEST2.INVOICEHEADER", "ACCODE", "SLT_ERPTEST2.ACCOUNTCODES");
            DropForeignKey("SLT_ERPTEST2.INVOICEDETAILS", "ACCODE", "SLT_ERPTEST2.ACCOUNTCODES");
            DropForeignKey("SLT_ERPTEST2.EQUIPMENT", "VENDORCODE", "SLT_ERPTEST2.VENDORS");
            DropForeignKey("SLT_ERPTEST2.EQUIPMENT", "SUPPLIERCODE", "SLT_ERPTEST2.SUPPLIERS");
            DropForeignKey("SLT_ERPTEST2.STOCK", "EQUCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.STOCKMGT", "EQUCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.PRICEREVISIONS", "EQUCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.INVOICEDETAILS", "ITEMCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.EQUIPMENTSERIAL", "ITEMCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.DEFECTGOODS", "EQUCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.RETURNGOODS", "EQUCODE", "SLT_ERPTEST2.EQUIPMENT");
            DropForeignKey("SLT_ERPTEST2.RETURNGOODS", "CA_ID", "SLT_ERPTEST2.CASHIER");
            DropForeignKey("SLT_ERPTEST2.OPERATIONSLOG", "LOGINNAME", "SLT_ERPTEST2.CASHIER");
            DropForeignKey("SLT_ERPTEST2.INVOICEHEADER", "CANCELUSER", "SLT_ERPTEST2.CASHIER");
            DropForeignKey("SLT_ERPTEST2.INVOICEHEADER", "INVOICEUSER", "SLT_ERPTEST2.CASHIER");
            DropForeignKey("SLT_ERPTEST2.DEFECTGOODS", "CA_ID", "SLT_ERPTEST2.CASHIER");
            DropForeignKey("SLT_ERPTEST2.STOCK", "BC_CODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropForeignKey("SLT_ERPTEST2.PRICEREVISIONS", "BC_CODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropForeignKey("SLT_ERPTEST2.INVOICEHEADER", "BCCODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropForeignKey("SLT_ERPTEST2.EQUIPMENTSERIAL", "BCCODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropForeignKey("SLT_ERPTEST2.INVOICEDETAILS", "INVOICENO", "SLT_ERPTEST2.INVOICEHEADER");
            DropForeignKey("SLT_ERPTEST2.EQUIPMENTSERIAL", "INVONO", "SLT_ERPTEST2.INVOICEHEADER");
            DropForeignKey("SLT_ERPTEST2.STOCKMGT", "COSTCODE", "SLT_ERPTEST2.COSTCENTER");
            DropForeignKey("SLT_ERPTEST2.STOCKMGT", "REASONID", "SLT_ERPTEST2.REASON");
            DropForeignKey("SLT_ERPTEST2.STOCKMGT", "BC_CODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropForeignKey("SLT_ERPTEST2.INVOICEHEADER", "COSTCODE", "SLT_ERPTEST2.COSTCENTER");
            DropForeignKey("SLT_ERPTEST2.CASHIER", "BC_CODE", "SLT_ERPTEST2.BILLINGCENTER");
            DropIndex("dbo.ATMAP", new[] { "CODEID" });
            DropIndex("dbo.ATMAP", new[] { "TAXID" });
            DropIndex("SLT_ERPTEST2.QUOTATIONDETAILS", new[] { "INVOICENO" });
            DropIndex("SLT_ERPTEST2.RETURNGOODS", new[] { "CA_ID" });
            DropIndex("SLT_ERPTEST2.RETURNGOODS", new[] { "EQUCODE" });
            DropIndex("SLT_ERPTEST2.OPERATIONSLOG", new[] { "LOGINNAME" });
            DropIndex("SLT_ERPTEST2.STOCK", new[] { "BC_CODE" });
            DropIndex("SLT_ERPTEST2.STOCK", new[] { "EQUCODE" });
            DropIndex("SLT_ERPTEST2.PRICEREVISIONS", new[] { "BC_CODE" });
            DropIndex("SLT_ERPTEST2.PRICEREVISIONS", new[] { "EQUCODE" });
            DropIndex("SLT_ERPTEST2.STOCKMGT", new[] { "REASONID" });
            DropIndex("SLT_ERPTEST2.STOCKMGT", new[] { "COSTCODE" });
            DropIndex("SLT_ERPTEST2.STOCKMGT", new[] { "BC_CODE" });
            DropIndex("SLT_ERPTEST2.STOCKMGT", new[] { "EQUCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEHEADER", new[] { "BCCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEHEADER", new[] { "CANCELUSER" });
            DropIndex("SLT_ERPTEST2.INVOICEHEADER", new[] { "INVOICEUSER" });
            DropIndex("SLT_ERPTEST2.INVOICEHEADER", new[] { "ACCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEHEADER", new[] { "COSTCODE" });
            DropIndex("SLT_ERPTEST2.EQUIPMENTSERIAL", new[] { "BCCODE" });
            DropIndex("SLT_ERPTEST2.EQUIPMENTSERIAL", new[] { "ITEMCODE" });
            DropIndex("SLT_ERPTEST2.EQUIPMENTSERIAL", new[] { "INVONO" });
            DropIndex("SLT_ERPTEST2.CASHIER", new[] { "BC_CODE" });
            DropIndex("SLT_ERPTEST2.DEFECTGOODS", new[] { "CA_ID" });
            DropIndex("SLT_ERPTEST2.DEFECTGOODS", new[] { "EQUCODE" });
            DropIndex("SLT_ERPTEST2.EQUIPMENT", new[] { "SUPPLIERCODE" });
            DropIndex("SLT_ERPTEST2.EQUIPMENT", new[] { "VENDORCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEDETAILS", new[] { "ACCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEDETAILS", new[] { "ITEMCODE" });
            DropIndex("SLT_ERPTEST2.INVOICEDETAILS", new[] { "INVOICENO" });
            DropTable("dbo.ATMAP");
            DropTable("SLT_ERPTEST2.QUOTATIONHEADER");
            DropTable("SLT_ERPTEST2.QUOTATIONDETAILS");
            DropTable("SLT_ERPTEST2.TAX");
            DropTable("SLT_ERPTEST2.VENDORS");
            DropTable("SLT_ERPTEST2.SUPPLIERS");
            DropTable("SLT_ERPTEST2.RETURNGOODS");
            DropTable("SLT_ERPTEST2.OPERATIONSLOG");
            DropTable("SLT_ERPTEST2.STOCK");
            DropTable("SLT_ERPTEST2.PRICEREVISIONS");
            DropTable("SLT_ERPTEST2.REASON");
            DropTable("SLT_ERPTEST2.STOCKMGT");
            DropTable("SLT_ERPTEST2.COSTCENTER");
            DropTable("SLT_ERPTEST2.INVOICEHEADER");
            DropTable("SLT_ERPTEST2.EQUIPMENTSERIAL");
            DropTable("SLT_ERPTEST2.BILLINGCENTER");
            DropTable("SLT_ERPTEST2.CASHIER");
            DropTable("SLT_ERPTEST2.DEFECTGOODS");
            DropTable("SLT_ERPTEST2.EQUIPMENT");
            DropTable("SLT_ERPTEST2.INVOICEDETAILS");
            DropTable("SLT_ERPTEST2.ACCOUNTCODES");
        }
    }
}
