namespace VideoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'21b3a1a0-3468-47d9-a1d0-35cbb0c1499a', N'admin@vidly.com', 0, N'AI3NWfrDih6ruy8ak17SYl8xrPegLudWJXZ00aMwI92A3N3BrYD8xfjc/u6sXSjNMw==', N'aad1fe50-9e30-4cbd-b03e-3cec699f89b7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'840beb59-565a-4fac-b1bc-b80fa1e7721e', N'guest@vidly.com', 0, N'AAWRIe/qP3pAb3cH8LsPyF6Qn7BDAOOoWo41150TKfQPEJGEnQ9b4Vz2Am/YX4CfUA==', N'299582da-691b-435e-b310-15f1a4b61ab9', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0e61bed-e43a-40ca-a94c-af41be202aa3', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21b3a1a0-3468-47d9-a1d0-35cbb0c1499a', N'a0e61bed-e43a-40ca-a94c-af41be202aa3')


");
        }
        
        public override void Down()
        {
        }
    }
}
