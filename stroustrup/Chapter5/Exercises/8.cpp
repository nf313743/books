#include <iostream>
#include <vector>
using namespace std;

int main()
{
	double n;
	vector<double> list;
	
	cout << "Enter how many you want to sum" << endl;	
	cin >> n;
	while(n <=0)
	{
		cout << "Must be greater than 0.  Try again." << endl;
		cin >> n;
	}
	
	cout << "Enter some numbers" << endl;
	
	for(double inVal; cin>>inVal;)
	{
		list.push_back(inVal);
	}
	
	if(n > list.size())
	{
		cout << "Too few numbers" << endl;
	}
			
	double sum = 0;
	
	for(int i = 0; i < n; ++i)
	{
		sum += list[i];
	}
	
	cout << "Result: " << sum << endl;
}