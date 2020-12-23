﻿namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentLastName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "studentCode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Students", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Students", "studentAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "studentAddress", c => c.String(nullable: false));
            DropColumn("dbo.Students", "UpdateDate");
            DropColumn("dbo.Students", "CreateDate");
            DropColumn("dbo.Students", "Enabled");
            DropColumn("dbo.Students", "studentCode");
            DropColumn("dbo.Students", "studentLastName");
        }
    }
}
