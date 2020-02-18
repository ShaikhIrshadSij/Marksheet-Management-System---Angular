using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class MarksheetDBContext : DbContext
  {
    public MarksheetDBContext() : base("DefaultConnection") { }

    public DbSet<BunchCounter> BunchCounters { get; set; }
    public DbSet<MarksheetErrors> MarksheetErrors { get; set; }
    public DbSet<Marksheets> Marksheets { get; set; }
    public DbSet<StudentErrors> StudentErrors { get; set; }
    public DbSet<Students> Students { get; set; }
    public DbSet<Users> Users { get; set; }
  }
}
