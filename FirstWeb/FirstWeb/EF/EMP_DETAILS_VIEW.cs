namespace FirstWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.EMP_DETAILS_VIEW")]
    public partial class EMP_DETAILS_VIEW
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string JOB_ID { get; set; }

        public int? MANAGER_ID { get; set; }

        public short? DEPARTMENT_ID { get; set; }

        public short? LOCATION_ID { get; set; }

        [StringLength(2)]
        public string COUNTRY_ID { get; set; }

        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string LAST_NAME { get; set; }

        public decimal? SALARY { get; set; }

        public decimal? COMMISSION_PCT { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string DEPARTMENT_NAME { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(35)]
        public string JOB_TITLE { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(25)]
        public string STATE_PROVINCE { get; set; }

        [StringLength(40)]
        public string COUNTRY_NAME { get; set; }

        [StringLength(25)]
        public string REGION_NAME { get; set; }
    }
}
