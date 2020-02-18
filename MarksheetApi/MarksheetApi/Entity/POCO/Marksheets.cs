using MarksheetApi.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class Marksheets : CommonFields
  {
    [Key]
    public int MarksheetId { get; set; }
    public string EnrollementNo { get; set; }
    public string Department { get; set; }
    public string StatementNo { get; set; }
    public string Year { get; set; }
    public string Month { get; set; }
    public string UploadType { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? ApprovedTime { get; set; }
    public DateTime? DisapprovedTime { get; set; }
    public string ApprovedBy { get; set; }
    public string DisApprovedBy { get; set; }
    public string Remarks { get; set; }
    public string DisapprovedReason { get; set; }
    public bool IsApprovedMailSent { get; set; }
    public bool IsDisapprovedMailSent { get; set; }
    public int Semester { get; set; }
    public int BunchNumber { get; set; }
  }
}
