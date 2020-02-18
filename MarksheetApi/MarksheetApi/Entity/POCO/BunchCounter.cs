using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.POCO
{
  public class BunchCounter
  {
    [Key]
    public int BunchCounterId { get; set; }
    public int BunchNumber { get; set; }
    public string BunchUploadedBy { get; set; }
    public DateTime BunchUploadTime { get; set; }
    public int BunchTotal { get; set; }
    public string BunchType { get; set; }
  }
}
