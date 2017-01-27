namespace FirstWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.VW_EMPSAL")]
    public partial class VW_EMPSAL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string LAST_NAME { get; set; }

        public decimal? SALARY { get; set; }

        public short? DEPARTMENT_ID { get; set; }

        [StringLength(7)]
        public string PCTofDept { get; set; }
    }
}
