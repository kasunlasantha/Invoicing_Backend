namespace SLTInvoicingBackend.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("SLTCRM.ERP_INIT_CHECK")]
    public partial class ERP_INIT_CHECK
    {
        [StringLength(10)]
        public string USERNAME { get; set; }

        [Key]
        public DateTime DATETIME { get; set; }

        [StringLength(500)]
        public string OPERATION { get; set; }

        [StringLength(5)]
        public string STATUS { get; set; }

        [StringLength(20)]
        public string CENTRE { get; set; }
    }
}
