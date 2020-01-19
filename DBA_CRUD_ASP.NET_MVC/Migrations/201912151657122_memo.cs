    namespace DBA_CRUD_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Memos", "Title", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Memos", "Title", c => c.String());
        }
    }
}
