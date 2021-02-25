namespace GHMNUNIDADDECAPACITACION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidaddeCaptacions", "Region", c => c.String());
            AlterColumn("dbo.UnidaddeCaptacions", "filial", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UnidaddeCaptacions", "filial", c => c.Int(nullable: false));
            DropColumn("dbo.UnidaddeCaptacions", "Region");
        }
    }
}
