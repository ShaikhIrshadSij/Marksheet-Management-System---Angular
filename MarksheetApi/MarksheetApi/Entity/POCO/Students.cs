using MarksheetApi.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class Students : CommonFields
  {
    [Key]
    public int StudentId { get; set; }
    public string EnrollementNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UploadType { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Semester { get; set; }
    public bool IsActive { get; set; }
    public string TransferBy { get; set; }
    public DateTime? TransferTime { get; set; }
    public int BunchNumber { get; set; }
  }
}
