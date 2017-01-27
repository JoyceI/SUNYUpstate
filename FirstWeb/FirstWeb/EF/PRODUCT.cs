namespace FirstWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.PRODUCTS")]
    public partial class PRODUCT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PRODUCT_ID { get; set; }

        [StringLength(200)]
        public string PRODUCT_NAME { get; set; }

        [StringLength(500)]
        public string PRODUCT_DESC { get; set; }

        [StringLength(100)]
        public string CATEGORY { get; set; }

        public decimal? PRICE { get; set; }

        [StringLength(30)]
        public string PRODUCT_STATUS { get; set; }
    }
}
