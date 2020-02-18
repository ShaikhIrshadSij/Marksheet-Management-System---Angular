namespace MarksheetApi.Migrations
{
  using MarksheetApi.Entity.POCO;
  using System;
  using System.Configuration;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<MarksheetApi.Entity.POCO.MarksheetDBContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(MarksheetApi.Entity.POCO.MarksheetDBContext context)
    {
      var defaultUserName = ConfigurationManager.AppSettings["DefaultUserName"];
      var isUserExist = context.Users.FirstOrDefault(x => x.UserName == defaultUserName);
      if (isUserExist == null)
      {
        Users users = new Users
        {
          UserName = defaultUserName,
          Password = ConfigurationManager.AppSettings["DefaultPassword"],
          Name = "Admin User",
          Email = defaultUserName,
          ImageUrl = "/Content/adminuser",
          CreatedBy = "Default User",
          CreatedTime = DateTime.Now
        };
        context.Users.Add(users);
        context.SaveChanges();
      }
    }
  }
}
