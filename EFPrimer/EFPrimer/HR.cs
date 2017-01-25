namespace EFPrimer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HR : DbContext
    {
        public HR()
            : base("name=HR")
        {
        }

        public virtual DbSet<COUNTRy> COUNTRIES { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<JOB_HISTORY> JOB_HISTORY { get; set; }
        public virtual DbSet<JOB> JOBS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<REGION> REGIONS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.COUNTRY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.REGION_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEPARTMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EMPLOYEES)
                .WithOptional(e => e.DEPARTMENT)
                .HasForeignKey(e => e.DEPARTMENT_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PHONE_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.SALARY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.COMMISSION_PCT)
                .HasPrecision(2, 2);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.EMPLOYEES1)
                .WithOptional(e => e.EMPLOYEE1)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOB_HISTORY>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.JOB_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .HasMany(e => e.EMPLOYEES)
                .WithRequired(e => e.JOB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOB>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.JOB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.STREET_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.POSTAL_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.STATE_PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCT_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.CATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRICE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCT_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGION_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGION_NAME)
                .IsUnicode(false);
        }
    }
}
