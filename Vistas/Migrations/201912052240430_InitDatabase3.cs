namespace Vistas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdServicio = c.Int(nullable: false),
                        Pago_Id = c.Int(nullable: false),
                        costo = c.Single(nullable: false),
                        Duracion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pago", t => t.Pago_Id, cascadeDelete: false)
                .ForeignKey("dbo.Servicio", t => t.IdServicio, cascadeDelete: false)
                .Index(t => t.IdServicio)
                .Index(t => t.Pago_Id);
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        metodoPago = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        correo = c.String(),
                        celular = c.String(),
                        nombres = c.String(),
                        apellidos = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Single(nullable: false),
                        Imagen = c.String(),
                        Informacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dia = c.Int(nullable: false),
                        Horarioid = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Encargado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombres = c.String(),
                        apellidos = c.String(),
                        celular = c.String(),
                        correo = c.String(),
                        cargo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EncargadoId = c.Int(nullable: false),
                        Horas = c.String(),
                        Disponibilidad = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Encargado", t => t.EncargadoId, cascadeDelete: false)
                .Index(t => t.EncargadoId);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoraInicio = c.String(),
                        HoraFin = c.String(),
                        IdUser = c.Int(nullable: false),
                        IdEncargado = c.Int(nullable: false),
                        IdServicio = c.Int(nullable: false),
                        Dia = c.Int(nullable: false),
                        DetalleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Detalle", t => t.DetalleId, cascadeDelete: false)
                .ForeignKey("dbo.Encargado", t => t.IdEncargado, cascadeDelete: false)
                .ForeignKey("dbo.Servicio", t => t.IdServicio, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: false)
                .Index(t => t.IdUser)
                .Index(t => t.IdEncargado)
                .Index(t => t.IdServicio)
                .Index(t => t.DetalleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "IdUser", "dbo.User");
            DropForeignKey("dbo.Reserva", "IdServicio", "dbo.Servicio");
            DropForeignKey("dbo.Reserva", "IdEncargado", "dbo.Encargado");
            DropForeignKey("dbo.Reserva", "DetalleId", "dbo.Detalle");
            DropForeignKey("dbo.Horario", "EncargadoId", "dbo.Encargado");
            DropForeignKey("dbo.Detalle", "IdServicio", "dbo.Servicio");
            DropForeignKey("dbo.Detalle", "Pago_Id", "dbo.Pago");
            DropForeignKey("dbo.Pago", "IdUsuario", "dbo.User");
            DropIndex("dbo.Reserva", new[] { "DetalleId" });
            DropIndex("dbo.Reserva", new[] { "IdServicio" });
            DropIndex("dbo.Reserva", new[] { "IdEncargado" });
            DropIndex("dbo.Reserva", new[] { "IdUser" });
            DropIndex("dbo.Horario", new[] { "EncargadoId" });
            DropIndex("dbo.Pago", new[] { "IdUsuario" });
            DropIndex("dbo.Detalle", new[] { "Pago_Id" });
            DropIndex("dbo.Detalle", new[] { "IdServicio" });
            DropTable("dbo.Reserva");
            DropTable("dbo.Horario");
            DropTable("dbo.Encargado");
            DropTable("dbo.Day");
            DropTable("dbo.Servicio");
            DropTable("dbo.User");
            DropTable("dbo.Pago");
            DropTable("dbo.Detalle");
        }
    }
}
