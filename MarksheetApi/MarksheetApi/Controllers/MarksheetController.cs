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
  public class MarksheetController : ApiController
  {
    private readonly MarksheetDBContext _context;
    public MarksheetController()
    {
      _context = new MarksheetDBContext();
    }
    [Route("api/marksheets")]
    [HttpGet]
    public IHttpActionResult GetMarksheetData()
    {
      var httpRequest = HttpContext.Current.Request;
      try
      {
        string search = httpRequest.Params["searchFilter"];
        //string draw = httpRequest.Form.GetValues("draw")[0];
        string order = httpRequest.Params["orderColumn"];
        string orderDir = httpRequest.Params["orderDir"];
        int startRec = Convert.ToInt32(httpRequest.Params["pageNumber"]);
        int pageSize = Convert.ToInt32(httpRequest.Params["pageSize"]);
        var marksheetData = _context.Marksheets.ToList();
        int totalRecords = marksheetData.Count;
        if (!string.IsNullOrEmpty(search) &&
            !string.IsNullOrWhiteSpace(search))
        {
          marksheetData = marksheetData.Where(p => p.EnrollementNo.ToString().ToLower().Contains(search.ToLower()) ||
              p.StatementNo.ToString().ToLower().Contains(search.ToLower()) ||
              p.Year.ToString().ToLower().Contains(search.ToLower()) ||
              p.Month.ToString().ToLower().Contains(search.ToLower()) ||
              p.ApprovedTime.ToString().ToLower().Contains(search.ToLower()) ||
              p.DisapprovedTime.ToString().ToLower().Contains(search.ToLower()) ||
              p.IsApproved.ToString().ToLower().Contains(search.ToLower()) ||
              p.Semester.ToString().ToLower().Contains(search.ToLower())
           ).ToList();
        }

        marksheetData = SortGetMarksheetData(order, orderDir, marksheetData);

        int recFilter = marksheetData.Count;
        marksheetData = marksheetData.Skip(startRec).Take(pageSize).ToList();
        var modifiedData = marksheetData.Select(d => new
        {
          enrollementNo = d.EnrollementNo,
          statementNo = d.StatementNo,
          year = d.Year,
          month = d.Month,
          semester = d.Semester,
          approvedTime = d.ApprovedTime,
          disapprovedTime = d.DisapprovedTime,
          isApproved = d.IsApproved,
          marksheetId = d.MarksheetId
        });
        return Ok(new
        {
          count = Convert.ToInt32(totalRecords),
          recordsTotal = totalRecords,
          recordsFiltered = recFilter,
          rows = modifiedData
        });
      }
      catch (Exception ex)
      {
        Logs.ControllerLogs(ex);
        return Ok(new
        {
          count = 0,
          recordsTotal = "",
          recordsFiltered = 0,
          rows = ""
        });
      }
    }
    private List<Marksheets> SortGetMarksheetData(string order, string orderDir, List<Marksheets> data)
    {
      List<Marksheets> list = new List<Marksheets>();
      try
      {
        switch (order)
        {
          case "EnrollementNo":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EnrollementNo).ToList() : data.OrderBy(p => p.EnrollementNo).ToList();
            break;
          case "StatementNo":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.StatementNo).ToList() : data.OrderBy(p => p.StatementNo).ToList();
            break;
          case "Year":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Year).ToList() : data.OrderBy(p => p.Year).ToList();
            break;
          case "Month":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Month).ToList() : data.OrderBy(p => p.Month).ToList();
            break;
          case "Semester":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Semester).ToList() : data.OrderBy(p => p.Semester).ToList();
            break;
          case "ApprovedTime":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ApprovedTime).ToList() : data.OrderBy(p => p.ApprovedTime).ToList();
            break;
          case "DisapprovedTime":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DisapprovedTime).ToList() : data.OrderBy(p => p.DisapprovedTime).ToList();
            break;
          case "IsApproved":
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.IsApproved).ToList() : data.OrderBy(p => p.IsApproved).ToList();
            break;
          default:
            list = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EnrollementNo).ToList() : data.OrderBy(p => p.EnrollementNo).ToList();
            break;
        }
      }
      catch (Exception ex)
      {
        Logs.ControllerLogs(ex);
      }
      return list;
    }
  }
}
