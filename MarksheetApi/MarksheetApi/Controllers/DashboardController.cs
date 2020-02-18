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
  public class DashboardController : ApiController
  {
    private readonly MarksheetDBContext _context;
    public DashboardController()
    {
      _context = new MarksheetDBContext();
    }
    [Route("api/dashboard/overview")]
    [HttpGet]
    public IHttpActionResult DashboardOverview(string filterYear, string filterSemester)
    {
      try
      {
        var formData = HttpContext.Current.Request.Form;
        int semester = Convert.ToInt32(filterSemester);
        var dashboardOverViewList = _context.Marksheets.Where(x => (string.IsNullOrEmpty(filterYear) || x.Year == filterYear) && (semester == 0 || x.Semester == semester)).GroupBy(x => new { x.Department }).Select(group => new
        {
          Department = group.Key.Department,
          IssuedMarksheet = group.Count(x => x.IsApproved == true),
          UnIssuedMarksheet = group.Count(x => x.IsApproved == false)
        }).ToList();
        return Ok(new
        {
          status = true,
          data = dashboardOverViewList
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
