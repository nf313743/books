#include <iostream>
#include <vector>
using namespace std;

int main()
{
	double n;
	vector<double> list;
	vector<double> diffList;
	
	cout << "Enter how many you want to sum" << endl;	
	cin >> n;
	while(n <=0)
	{
		cout << "Must be greater than 0.  Try again." << endl;
		cin >> n;
	}
	
	cout << "Enter some numbers" << endl;
	bool addDiff = false;
	int index = 0;
	
	for(double inVal; cin>>inVal;)
	{
		list.push_back(inVal);
		
		if(index > 0)
		{
			double diff = list[index] - list[index -1];
			diffList.push_back(diff);
			
		}
		++index;
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
	
	for(int i = 0; i < n; ++i)
	{
		cout << diffList[i] << endl;
	}
}