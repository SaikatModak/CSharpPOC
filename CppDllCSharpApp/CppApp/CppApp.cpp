// CppApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#undef UNICODE
#include <windows.h>


typedef void(__cdecl *MYPROC)();

int main()
{
  HINSTANCE hGetProcIDDLL = LoadLibrary(TEXT("CppDll.dll"));
  //HINSTANCE hGetProcIDDLL = LoadLibrary(TEXT("CppDll.dll"));
  MYPROC ProcAdd = (MYPROC)GetProcAddress(hGetProcIDDLL, "HelloWorld");

  auto tmp = GetLastError();
  ProcAdd();
  FreeLibrary(hGetProcIDDLL);
    return 0;
}

