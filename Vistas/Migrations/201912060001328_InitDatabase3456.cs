namespace Vistas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase3456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horario", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reserva", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserva", "Fecha");
            DropColumn("dbo.Horario", "Fecha");
        }
    }
}
