// Chapter6.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "2.cpp"
#include "../../Lib/std_lib_facilities.h"

int main()
{
	try
	{
		double val = 0;
		while (cin) {
			cout << "> ";          // print prompt
			Token t = ts.get();
			if (t.kind == 'q') break;
			if (t.kind == ';')
				cout << "= " << val << '\n'; // print result
			else
				ts.putback(t);
			val = expression();
		}
	}
	catch (exception& e) {
		cerr << "error: " << e.what() << '\n';
		return 1;
	}
	catch (...) {
		cerr << "Oops: unknown exception!\n";
		return 2;
	}
}