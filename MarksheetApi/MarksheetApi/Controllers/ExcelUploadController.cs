using MarksheetApi.Entity.POCO;
using MarksheetApi.Loggers;
using MarksheetApi.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace MarksheetApi.Controllers
{
  public class ExcelUploadController : ApiController
  {
    private readonly MarksheetDBContext _context;
    public ExcelUploadController()
    {
      _context = new MarksheetDBContext();
    }
    [Route("api/excelupload/marksheet")]
    [HttpPost]
    public IHttpActionResult UploadMarksheet()
    {
      try
      {
        int totalCount = 0;
        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count > 0)
        {
          try
          {
            string identityUser = httpRequest.Headers["Email"];
            int bunchNumber = Convert.ToInt32(ConfigurationManager.AppSettings["MarksheetBunchCounter"]);
            string uploadedFileName = string.Empty;
            foreach (string file in httpRequest.Files)
            {
              HttpPostedFile postedFile = httpRequest.Files[file];
              if (httpRequest.Browser.Browser.ToUpper() == "IE" || httpRequest.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
              {
                string[] testfiles = postedFile.FileName.Split(new char[] { '\\' });
                uploadedFileName = testfiles[testfiles.Length - 1];
              }
              else
              {
                uploadedFileName = postedFile.FileName;
              }
              var newName = uploadedFileName.Split('.');
              uploadedFileName = newName[0] + "_" + DateTime.Now.Ticks.ToString() + "." + newName[1];
              var uploadRootFolderInput = AppDomain.CurrentDomain.BaseDirectory + "\\ExcelUploads";
              Directory.CreateDirectory(uploadRootFolderInput);
              var directoryFullPathInput = uploadRootFolderInput;
              uploadedFileName = Path.Combine(directoryFullPathInput, uploadedFileName);
              postedFile.SaveAs(uploadedFileName);
              string xlsFile = uploadedFileName;
              if (newName[1] == "xls")
              {
                uploadedFileName = ConvertXLS_XLSX(uploadedFileName);
                if (File.Exists(xlsFile))
                  File.Delete(xlsFile);
              }
              var excelData = ReadMarksheetExcel(uploadedFileName);
              if (excelData != null)
              {
                totalCount = excelData.Count;
                foreach (var item in excelData)
                {
                  Marksheets marksheets = new Marksheets
                  {
                    EnrollementNo = item.EnrollmentNo,
                    StatementNo = item.StatementNo,
                    Year = item.Year,
                    Month = item.Month,
                    CreatedTime = DateTime.Now,
                    CreatedBy = identityUser,
                    BunchNumber = bunchNumber,
                    UploadType = "Excel Upload",
                    Semester = Convert.ToInt32(item.Semester),
                    Department = item.Department
                  };
                  _context.Marksheets.Add(marksheets);
                }
                _context.SaveChanges();
                BunchCounter marksheetBunch = new BunchCounter()
                {
                  BunchNumber = bunchNumber,
                  BunchType = "Marksheet",
                  BunchUploadedBy = identityUser,
                  BunchUploadTime = DateTime.Now,
                  BunchTotal = totalCount
                };
                _context.BunchCounters.Add(marksheetBunch);
                _context.SaveChanges();
                bunchNumber++;
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
                webConfigApp.AppSettings.Settings["MarksheetBunchCounter"].Value = bunchNumber.ToString();
                webConfigApp.Save();
              }
              else
              {
                return Ok(new
                {
                  status = false,
                  message = "Failed to upload the file to server"
                });
              }
            }
          }
          catch (Exception ex)
          {
            Logs.ExcelLogs(ex);
            return Ok(new
            {
              status = false,
              message = ex.Message
            });
          }
        }
        return Ok(new
        {
          status = true,
          message = $"{totalCount} marksheets uploaded successfully"
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

    public static string ConvertXLS_XLSX(string file)
    {
      FileInfo fileInfo = new FileInfo(file);
      var app = new Microsoft.Office.Interop.Excel.Application();
      var xlsFile = fileInfo.FullName;
      var wb = app.Workbooks.Open(xlsFile);
      var xlsxFile = xlsFile + "x";
      wb.SaveAs(Filename: xlsxFile, FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
      wb.Close();
      app.Quit();
      return xlsxFile;
    }
    public List<ReadMarksheetDTO> ReadMarksheetExcel(string FilePath)
    {
      try
      {
        List<ReadMarksheetDTO> excelData = new List<ReadMarksheetDTO>();
        FileInfo existingFile = new FileInfo(FilePath);
        using (ExcelPackage package = new ExcelPackage(existingFile))
        {
          ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
          int rowCount = worksheet.Dimension.End.Row;
          for (int row = 1; row <= rowCount; row++)
          {
            try
            {
              string[] getMonthYear = worksheet.Cells[row, 4].Value.ToString().Trim().Split(' ');
              string getDepartment = worksheet.Cells[row, 2].Value.ToString().Trim().Substring(7, 2);
              string departmentName = getDepartment == "07" ? "Computer" : getDepartment == "02" ? "Automobile" : getDepartment == "11" ? "EC" : getDepartment == "19" ? "Mechanical" : getDepartment == "09" ? "Electrical" : "Civil";
              excelData.Add(new ReadMarksheetDTO()
              {
                EnrollmentNo = worksheet.Cells[row, 2].Value.ToString().Trim(),
                Semester = worksheet.Cells[row, 3].Value.ToString().Trim(),
                Month = getMonthYear[0],
                Year = getMonthYear[1],
                StatementNo = worksheet.Cells[row, 5].Value.ToString().Trim(),
                Department = departmentName
              });
            }
            catch (Exception ex)
            {
              Logs.ExcelLogs(ex);
              continue;
            }
          }
        }
        return excelData;
      }
      catch (Exception ex)
      {
        Logs.ExcelLogs(ex);
        return null;
      }
    }
  }
}
