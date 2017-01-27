namespace FirstWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDEPARTMENT_OWNERColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HR.COUNTRIES",
                c => new
                    {
                        COUNTRY_ID = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        COUNTRY_NAME = c.String(maxLength: 40, unicode: false),
                        REGION_ID = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.COUNTRY_ID)
                .ForeignKey("HR.REGIONS", t => t.REGION_ID)
                .Index(t => t.REGION_ID);
            
            CreateTable(
                "HR.LOCATIONS",
                c => new
                    {
                        LOCATION_ID = c.Decimal(nullable: false, precision: 5, scale: 0),
                        STREET_ADDRESS = c.String(maxLength: 40, unicode: false),
                        POSTAL_CODE = c.String(maxLength: 12, unicode: false),
                        CITY = c.String(nullable: false, maxLength: 30, unicode: false),
                        STATE_PROVINCE = c.String(maxLength: 25, unicode: false),
                        COUNTRY_ID = c.String(maxLength: 2, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.LOCATION_ID)
                .ForeignKey("HR.COUNTRIES", t => t.COUNTRY_ID)
                .Index(t => t.COUNTRY_ID);
            
            CreateTable(
                "HR.DEPARTMENTS",
                c => new
                    {
                        DEPARTMENT_ID = c.Decimal(nullable: false, precision: 5, scale: 0),
                        DEPARTMENT_NAME = c.String(nullable: false, maxLength: 30, unicode: false),
                        DEPARTMENT_OWNER = c.String(),
                        MANAGER_ID = c.Decimal(precision: 10, scale: 0),
                        LOCATION_ID = c.Decimal(precision: 5, scale: 0),
                    })
                .PrimaryKey(t => t.DEPARTMENT_ID)
                .ForeignKey("HR.EMPLOYEES", t => t.MANAGER_ID)
                .ForeignKey("HR.LOCATIONS", t => t.LOCATION_ID)
                .Index(t => t.MANAGER_ID)
                .Index(t => t.LOCATION_ID);
            
            CreateTable(
                "HR.EMPLOYEES",
                c => new
                    {
                        EMPLOYEE_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FIRST_NAME = c.String(maxLength: 20, unicode: false),
                        LAST_NAME = c.String(nullable: false, maxLength: 25, unicode: false),
                        EMAIL = c.String(nullable: false, maxLength: 25, unicode: false),
                        PHONE_NUMBER = c.String(maxLength: 20, unicode: false),
                        HIRE_DATE = c.DateTime(nullable: false),
                        JOB_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        SALARY = c.Decimal(precision: 8, scale: 2),
                        COMMISSION_PCT = c.Decimal(precision: 2, scale: 2),
                        MANAGER_ID = c.Decimal(precision: 10, scale: 0),
                        DEPARTMENT_ID = c.Decimal(precision: 5, scale: 0),
                    })
                .PrimaryKey(t => t.EMPLOYEE_ID)
                .ForeignKey("HR.EMPLOYEES", t => t.MANAGER_ID)
                .ForeignKey("HR.JOBS", t => t.JOB_ID)
                .ForeignKey("HR.DEPARTMENTS", t => t.DEPARTMENT_ID)
                .Index(t => t.JOB_ID)
                .Index(t => t.MANAGER_ID)
                .Index(t => t.DEPARTMENT_ID);
            
            CreateTable(
                "HR.JOBS",
                c => new
                    {
                        JOB_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        JOB_TITLE = c.String(nullable: false, maxLength: 35, unicode: false),
                        MIN_SALARY = c.Decimal(precision: 10, scale: 0),
                        MAX_SALARY = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.JOB_ID);
            
            CreateTable(
                "HR.JOB_HISTORY",
                c => new
                    {
                        EMPLOYEE_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        START_DATE = c.DateTime(nullable: false),
                        END_DATE = c.DateTime(nullable: false),
                        JOB_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        DEPARTMENT_ID = c.Decimal(precision: 5, scale: 0),
                    })
                .PrimaryKey(t => new { t.EMPLOYEE_ID, t.START_DATE })
                .ForeignKey("HR.DEPARTMENTS", t => t.DEPARTMENT_ID)
                .ForeignKey("HR.JOBS", t => t.JOB_ID)
                .ForeignKey("HR.EMPLOYEES", t => t.EMPLOYEE_ID)
                .Index(t => t.EMPLOYEE_ID)
                .Index(t => t.JOB_ID)
                .Index(t => t.DEPARTMENT_ID);
            
            CreateTable(
                "HR.REGIONS",
                c => new
                    {
                        REGION_ID = c.Decimal(nullable: false, precision: 38, scale: 0),
                        REGION_NAME = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.REGION_ID);
            
            CreateTable(
                "HR.EMP_DETAILS_VIEW",
                c => new
                    {
                        EMPLOYEE_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        JOB_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        LAST_NAME = c.String(nullable: false, maxLength: 25, unicode: false),
                        DEPARTMENT_NAME = c.String(nullable: false, maxLength: 30, unicode: false),
                        JOB_TITLE = c.String(nullable: false, maxLength: 35, unicode: false),
                        CITY = c.String(nullable: false, maxLength: 30, unicode: false),
                        MANAGER_ID = c.Decimal(precision: 10, scale: 0),
                        DEPARTMENT_ID = c.Decimal(precision: 5, scale: 0),
                        LOCATION_ID = c.Decimal(precision: 5, scale: 0),
                        COUNTRY_ID = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        FIRST_NAME = c.String(maxLength: 20, unicode: false),
                        SALARY = c.Decimal(precision: 8, scale: 2),
                        COMMISSION_PCT = c.Decimal(precision: 2, scale: 2),
                        STATE_PROVINCE = c.String(maxLength: 25, unicode: false),
                        COUNTRY_NAME = c.String(maxLength: 40, unicode: false),
                        REGION_NAME = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => new { t.EMPLOYEE_ID, t.JOB_ID, t.LAST_NAME, t.DEPARTMENT_NAME, t.JOB_TITLE, t.CITY });
            
            CreateTable(
                "HR.PRODUCTS",
                c => new
                    {
                        PRODUCT_ID = c.Decimal(nullable: false, precision: 5, scale: 0),
                        PRODUCT_NAME = c.String(maxLength: 200, unicode: false),
                        PRODUCT_DESC = c.String(maxLength: 500, unicode: false),
                        CATEGORY = c.String(maxLength: 100, unicode: false),
                        PRICE = c.Decimal(precision: 10, scale: 2),
                        PRODUCT_STATUS = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.PRODUCT_ID);
            
            CreateTable(
                "HR.VW_EMPSAL",
                c => new
                    {
                        EMPLOYEE_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LAST_NAME = c.String(nullable: false, maxLength: 25, unicode: false),
                        FIRST_NAME = c.String(maxLength: 20, unicode: false),
                        SALARY = c.Decimal(precision: 8, scale: 2),
                        DEPARTMENT_ID = c.Decimal(precision: 5, scale: 0),
                        PCTofDept = c.String(maxLength: 7, unicode: false),
                    })
                .PrimaryKey(t => new { t.EMPLOYEE_ID, t.LAST_NAME });
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.COUNTRIES", "REGION_ID", "HR.REGIONS");
            DropForeignKey("HR.DEPARTMENTS", "LOCATION_ID", "HR.LOCATIONS");
            DropForeignKey("HR.EMPLOYEES", "DEPARTMENT_ID", "HR.DEPARTMENTS");
            DropForeignKey("HR.JOB_HISTORY", "EMPLOYEE_ID", "HR.EMPLOYEES");
            DropForeignKey("HR.JOB_HISTORY", "JOB_ID", "HR.JOBS");
            DropForeignKey("HR.JOB_HISTORY", "DEPARTMENT_ID", "HR.DEPARTMENTS");
            DropForeignKey("HR.EMPLOYEES", "JOB_ID", "HR.JOBS");
            DropForeignKey("HR.EMPLOYEES", "MANAGER_ID", "HR.EMPLOYEES");
            DropForeignKey("HR.DEPARTMENTS", "MANAGER_ID", "HR.EMPLOYEES");
            DropForeignKey("HR.LOCATIONS", "COUNTRY_ID", "HR.COUNTRIES");
            DropIndex("HR.JOB_HISTORY", new[] { "DEPARTMENT_ID" });
            DropIndex("HR.JOB_HISTORY", new[] { "JOB_ID" });
            DropIndex("HR.JOB_HISTORY", new[] { "EMPLOYEE_ID" });
            DropIndex("HR.EMPLOYEES", new[] { "DEPARTMENT_ID" });
            DropIndex("HR.EMPLOYEES", new[] { "MANAGER_ID" });
            DropIndex("HR.EMPLOYEES", new[] { "JOB_ID" });
            DropIndex("HR.DEPARTMENTS", new[] { "LOCATION_ID" });
            DropIndex("HR.DEPARTMENTS", new[] { "MANAGER_ID" });
            DropIndex("HR.LOCATIONS", new[] { "COUNTRY_ID" });
            DropIndex("HR.COUNTRIES", new[] { "REGION_ID" });
            DropTable("HR.VW_EMPSAL");
            DropTable("HR.PRODUCTS");
            DropTable("HR.EMP_DETAILS_VIEW");
            DropTable("HR.REGIONS");
            DropTable("HR.JOB_HISTORY");
            DropTable("HR.JOBS");
            DropTable("HR.EMPLOYEES");
            DropTable("HR.DEPARTMENTS");
            DropTable("HR.LOCATIONS");
            DropTable("HR.COUNTRIES");
        }
    }
}
