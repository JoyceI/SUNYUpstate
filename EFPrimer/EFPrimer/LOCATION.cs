namespace EFPrimer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.LOCATIONS")]
    public partial class LOCATION
    {
        public LOCATION()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LOCATION_ID { get; set; }

        [StringLength(40)]
        public string STREET_ADDRESS { get; set; }

        [StringLength(12)]
        public string POSTAL_CODE { get; set; }

        [Required]
        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(25)]
        public string STATE_PROVINCE { get; set; }

        [StringLength(2)]
        public string COUNTRY_ID { get; set; }

        public virtual COUNTRy COUNTRy { get; set; }

        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }
    }
}
