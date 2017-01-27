namespace FirstWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.REGIONS")]
    public partial class REGION
    {
        public REGION()
        {
            COUNTRIES = new HashSet<COUNTRy>();
        }

        [Key]
        public decimal REGION_ID { get; set; }

        [StringLength(25)]
        public string REGION_NAME { get; set; }

        public virtual ICollection<COUNTRy> COUNTRIES { get; set; }
    }
}
