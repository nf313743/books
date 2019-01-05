// Stroustrup.cpp : Defines the entry point for the console application.
//

#include <vector>
#include <iostream>
#include <string>
#include "stdafx.h"
using namespace std;

void exercise12()
{
	vector<int> numList = { 1,2,3,4 };
	bool running = true;

	while (running)
	{
		cout << "Have a guess:" << endl;
		int input;
		cin >> input;

		vector<int> inputList;
		inputList.push_back(input / 1000);
		inputList.push_back((input % 1000) / 100);
		inputList.push_back((input % 100) / 10);
		inputList.push_back((input % 10));

		int bull = 0;
		int cow = 0;

		for (int i = 0; i < 4; ++i)
		{
			for (int j = 0; j < 4; ++j)
			{
				if (numList[i] == inputList[j])
				{
					if (i == j)
						++bull;
					else
						++cow;
				}
			}
		}

		if (bull == 4)
		{
			cout << "You got it!" << endl;
			return;
		}

		cout << "You got " << bull << " bulls and " << cow << " cows." << endl;
		bull = 0;
		cow = 0;
	}
}

int main()
{
	exercise12();

    return 0;
}

