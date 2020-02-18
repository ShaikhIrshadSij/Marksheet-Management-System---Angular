using MarksheetApi.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class MarksheetErrors : CommonFields
  {
    [Key]
    public int MarksheetErrorId { get; set; }
    public string EnrollmentNo { get; set; }
    public string Semester { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string Department { get; set; }
    public string StatementNo { get; set; }
    public int BunchNumber { get; set; }
  }
}
