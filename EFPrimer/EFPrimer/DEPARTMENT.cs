namespace EFPrimer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.DEPARTMENTS")]
    public partial class DEPARTMENT
    {
        public DEPARTMENT()
        {
            EMPLOYEES = new HashSet<EMPLOYEE>();
            JOB_HISTORY = new HashSet<JOB_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short DEPARTMENT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string DEPARTMENT_NAME { get; set; }

        public int? MANAGER_ID { get; set; }

        public short? LOCATION_ID { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual ICollection<EMPLOYEE> EMPLOYEES { get; set; }

        public virtual ICollection<JOB_HISTORY> JOB_HISTORY { get; set; }
    }
}
