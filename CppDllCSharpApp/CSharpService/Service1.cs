using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CSharpService
{
  static class NativeMethods
  {
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string dllToLoad);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);



    [DllImport("kernel32.dll")]
    public static extern bool FreeLibrary(IntPtr hModule);
  }

  public partial class Service1 : ServiceBase
  {
    public Service1()
    {
      InitializeComponent();
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void Method();

    protected override void OnStart(string[] args)
    {
      IntPtr pDll = NativeMethods.LoadLibrary(@"E:\Personal\Learning\C_Sharp\CppDllCSharpAp\Debug\CppDll.dll");
      IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "HelloWorld");
      Method helloWorld = (Method)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Method));
      try
      {
        helloWorld();
      }
      catch (Exception e)
      {
        Console.Out.WriteLine(e.InnerException);
      }

      NativeMethods.FreeLibrary(pDll);
    }

    protected override void OnStop()
    {
    }
  }
}
