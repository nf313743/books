#include <iostream>
#include <cmath>
using namespace std;

double discriminant(double a, double b, double c)
{
	double disc = (b*b) - (4*a*c);
	return disc;
}

void quadraticEqu(double a, double b, double c)
{
	double disc = discriminant(a,b,c);
	
	if(disc < 0)
	{
		cout << "There are 2 complex solutions";
		return;
	}
	
	double discRoot = sqrt(disc);
	
	double xPos = (discRoot + (-1*b)) / (2*a);
	double xNeg = (discRoot - (-1*b)) / (2*a);
	
	cout << "x: " << xPos << endl;
	cout << "x: " << xNeg << endl;
}

int main()
{
	double a = 8;
	double b = 25;
	double c = 13;
	
	quadraticEqu(a,b,c);
}