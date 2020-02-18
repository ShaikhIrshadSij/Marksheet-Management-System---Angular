using MarksheetApi.Entity.POCO;
using MarksheetApi.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MarksheetApi.Controllers
{
  public class UsersController : ApiController
  {
    private readonly MarksheetDBContext _context;
    public UsersController()
    {
      _context = new MarksheetDBContext();
    }
    [Route("api/users/validatelogin")]
    [HttpPost]
    public IHttpActionResult ValidateLogin()
    {
      try
      {
        var formData = HttpContext.Current.Request.Form;
        string userName = formData["UserName"];
        string password = formData["Password"];
        var isUserExist = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        if (isUserExist != null)
        {
          return Ok(new
          {
            status = true,
            user = isUserExist
          });
        }
        return Ok(new
        {
          status = false,
          message = "User not found"
        });
      }
      catch (Exception ex)
      {
        Logs.ControllerLogs(ex);
        return Ok(new
        {
          status = false,
          message = ex.Message
        });
      }
    }
  }
}
