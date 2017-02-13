using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace GetCaps
{
  class Program
  {
    static void Main(string[] args)
    {
      string printerName = "";
      string filePath = "";

      for (int i = 0; i < args.Length;i++ )
      {
        if (args[i].Equals("/P") && i+1 < args.Length)
        {
          printerName = args[i+1];
        }
        else if (args[i].Equals("/F") && i + 1 < args.Length)
        {
          filePath = args[i + 1];
        }
      }

      PrintQueue queue = null;
      if (printerName.Equals(String.Empty))
        queue = LocalPrintServer.GetDefaultPrintQueue();
      else
        queue = new PrintQueue(new System.Printing.PrintServer(), printerName);

      System.Printing.PrintCapabilities printcap = queue.GetPrintCapabilities();

      var ms = queue.GetPrintCapabilitiesAsXml(queue.UserPrintTicket);

      if (filePath.Equals(String.Empty))
        filePath = "C:\\Temp\\Caps.xml";

      FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
      ms.WriteTo(file);
      file.Close();
      ms.Close();
    }
  }
}
