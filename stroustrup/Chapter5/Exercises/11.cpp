#include <iostream>
#include <limits>
using namespace std;

void LoopFib()
{
	int prev = 0;
	int num = 1;
	cout << "Limit is: " << numeric_limits<int>::max() << endl;
	try
	{
		while(true)
		{


			if(num < 0)
			{

				cout << prev << endl;

				return 0;
			}

			if(num < 35)
				cout << num << endl;

			int oldNum = num;
			num = num + prev;
			prev = oldNum;

		}
	}
	catch(...)
	{

	}
}

int recursiveFib(int x)
{
	if(x == 1)
	{
		return 1;
	}
	recursiveFib(x-1)+ recursiveFib(x-2)
}

int main()
{
	cout << recursiveFib(5) <<endl;

	return 0;
}
