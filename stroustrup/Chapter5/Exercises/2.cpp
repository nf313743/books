#include <iostream>
using namespace std;

double cToK(double c)
{
	int k = c + 273.15;
	return k;
}

int main()
{
	double c = 0;
	cin >> c;
	
	if(c < -273.15)
	{
		cout << "Too cold" << endl;
	}
	else
	{
		double k = cToK(c);
		cout << k << endl;
	}
}