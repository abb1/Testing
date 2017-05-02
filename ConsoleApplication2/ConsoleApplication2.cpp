// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <fstream>
#include <iostream>
using namespace std;


bool fexists(const char *filename)
{
	fstream ifile(filename);

	return (bool)ifile;
}
int main()
{
	char data[10];
	//ifstream ifile(filename);
	//if (ifile) {
		// The file exists, and is open for input
	//}

	if (true == fexists("C:\\Users\\inbakad\\Desktop\\testing\\AB Setup\\start_menu1.exe"))
	{
		cout << "File exists ";
	}
	else
	{
		cout << "File does not exist";
	}
	cin >> data;
    return 0;
	
}


