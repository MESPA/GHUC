namespace GHMNUNIDADDECAPACITACION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        IdDepartamentoss = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdDepartamentoss);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departamentoes");
        }
    }
}
