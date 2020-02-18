using MarksheetApi.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class StudentErrors: CommonFields
  {
    [Key]
    public int StudentErrorId { get; set; }
    public string EnrollmentNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Semester { get; set; }
    public string Department { get; set; }
    public int BunchNumber { get; set; }
  }
}
