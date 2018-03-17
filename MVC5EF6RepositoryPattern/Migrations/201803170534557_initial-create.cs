namespace MVC5EF6RepositoryPattern.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "drone.Flights",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    TakeOff = c.DateTime(nullable: false),
                    Weather = c.Int(nullable: false),
                    Duration = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("drone.Flights");
        }
    }
}
