using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarksheetApi.Models
{
  public class ReadMarksheetDTO
  {
    public string EnrollmentNo { get; set; }
    public string Semester { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string StatementNo { get; set; }
    public string Department { get; set; }
  }
}
