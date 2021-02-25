namespace GHMNUNIDADDECAPACITACION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UnidaddeCaptacions", "fechasolicitud", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UnidaddeCaptacions", "fechasolicitud", c => c.DateTime(nullable: false));
        }
    }
}
