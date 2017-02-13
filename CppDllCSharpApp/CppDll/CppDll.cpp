// CppDll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <iostream>

extern "C" {
  __declspec(dllexport) void HelloWorld();
}

void HelloWorld()
{
  std::cout << "Hello";
  int *p = NULL;
  throw std::invalid_argument("received negative value");
  //try
  //{
  //  throw std::invalid_argument("received negative value");
  //}
  //catch (...)
  //{
  //  std::cout << "exception";
  //}
}


