using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MarksheetApi.Loggers
{
  public class Logs
  {
    public static void ExcelLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      //Mailer.SendExceptionEmail(lines, "Excel Logs");
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ExcelLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ExcelLogs\\" + "ExcelLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
    public static void ExcelMapLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      //Mailer.SendExceptionEmail(lines, "Excel Map Logs");
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ExcelMapLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ExcelMapLogs\\" + "ExcelMapLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
    public static void ControllerLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      //Mailer.SendExceptionEmail(lines, "Controller Logs");
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ControllerLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\ControllerLogs\\" + "ControllerLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
    public static void DatabaseLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      //Mailer.SendExceptionEmail(lines, "Database Logs");
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\DatabaseLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\DatabaseLogs\\" + "DatabaseLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
    public static void MailLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\MailLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\MailLogs\\" + "MailLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
    public static void MarksheetLogs(Exception ex)
    {
      string lines = "Error occured at " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\r\n";
      lines += "****************************************************************** \r\n";
      lines += "ErrorMessage: " + ex.Message?.ToString() + " \r\n";
      lines += "StackTrace: " + ex.StackTrace?.ToString() + " \r\n";
      lines += "InnerException: " + ex.InnerException?.ToString() + " \r\n";
      //Mailer.SendExceptionEmail(lines, "Marksheet Logs");
      string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\MarksheetLogs";
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLogs\\MarksheetLogs\\" + "MarksheetLog_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
      if (!File.Exists(filePath))
      {
        using (StreamWriter sw = File.CreateText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
      else
      {
        using (StreamWriter sw = File.AppendText(filePath))
        {
          sw.WriteLine(lines);
        }
      }
    }
  }
}
