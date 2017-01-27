namespace FirstWeb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.JOB_HISTORY")]
    public partial class JOB_HISTORY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime START_DATE { get; set; }

        public DateTime END_DATE { get; set; }

        [Required]
        [StringLength(10)]
        public string JOB_ID { get; set; }

        public short? DEPARTMENT_ID { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual JOB JOB { get; set; }
    }
}
