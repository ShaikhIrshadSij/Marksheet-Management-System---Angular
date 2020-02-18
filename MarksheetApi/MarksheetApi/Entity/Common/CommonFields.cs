using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarksheetApi.Entity.Common
{
  public class CommonFields
  {
    public string CreatedBy { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedTime { get; set; }
  }
}
