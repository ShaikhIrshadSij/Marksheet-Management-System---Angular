using MarksheetApi.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class Users : CommonFields
  {
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
  }
}
