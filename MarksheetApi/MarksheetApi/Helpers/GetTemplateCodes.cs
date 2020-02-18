using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MarksheetApi.Helpers
{
  public class GetTemplateCodes
  {
    public static string GetTemplateString(Templates templateCode)
    {
      StreamReader objStreamReader;
      string path = "";
      switch (templateCode)
      {
        case Templates.MarksheetApproved:
          path = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\MarksheetApproved.html";
          break;
        case Templates.MarksheetDisapproved:
          path = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\MarksheetDisapproved.html";
          break;
        case Templates.MarksheetUploadErrors:
          path = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\MarksheetUploadErrors.html";
          break;
        case Templates.StudentUploadErrors:
          path = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\StudentUploadErrors.html";
          break;
        case Templates.ExceptionMailTemplate:
          path = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\ExceptionMailTemplate.html";
          break;
        default:
          break;
      }
      if (!string.IsNullOrEmpty(path))
      {
        objStreamReader = File.OpenText(path);
        string emailText = objStreamReader.ReadToEnd();
        objStreamReader.Close();
        objStreamReader = null;
        objStreamReader = null;
        return emailText;
      }
      else
      {
        objStreamReader = null;
        return string.Empty;
      }
    }
  }
  public enum Templates
  {
    MarksheetApproved = 1,
    MarksheetDisapproved = 2,
    MarksheetUploadErrors = 3,
    StudentUploadErrors = 4,
    ExceptionMailTemplate = 5
  }
}
