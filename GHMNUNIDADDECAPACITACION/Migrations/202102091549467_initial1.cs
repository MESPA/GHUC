namespace GHMNUNIDADDECAPACITACION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filiales",
                c => new
                    {
                        IdFilial = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Abreviacion = c.String(nullable: false, maxLength: 2),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.IdFilial);
            
            CreateTable(
                "dbo.UnidaddeCaptacions",
                c => new
                    {
                        idUnidaddeCaptacion = c.Int(nullable: false, identity: true),
                        filial = c.Int(nullable: false),
                        departamento = c.String(),
                        puestoempleado = c.String(),
                        fechasolicitud = c.DateTime(nullable: false),
                        Areadepartamento = c.String(),
                        cursorequerido = c.String(),
                        importanciacurso = c.String(),
                        cantidadempleados = c.Int(nullable: false),
                        fechacreacion = c.DateTime(nullable: false),
                        estadosolicitud = c.Int(nullable: false),
                        usuariocreacion = c.String(),
                    })
                .PrimaryKey(t => t.idUnidaddeCaptacion);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnidaddeCaptacions");
            DropTable("dbo.Filiales");
        }
    }
}
