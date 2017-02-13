using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace CSharpApp
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

  class Program
  {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void Method();

    static void Main(string[] args)
    {
      IntPtr pDll = NativeMethods.LoadLibrary(@"E:\Personal\Learning\C_Sharp\CppDllCSharpAp\Debug\CppDll.dll");
      IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "HelloWorld");
      Method helloWorld = (Method)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall,typeof(Method));
      try
      {
        helloWorld();
      }
      catch(Exception e)
      {
        Console.Out.WriteLine(e.InnerException);
      }

      NativeMethods.FreeLibrary(pDll);

      while (true) ;
    }
  }
}
