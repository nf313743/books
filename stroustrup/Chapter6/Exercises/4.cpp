#include <vector>
#include <iostream>
#include <string>
using namespace std;

class NameValue {
public:
    string name;
    double value;     // for numbers: a value
  
   NameValue(string name, double value)     // make a Token from a char and a double
        :name(name), value(value) { }
};


int main()
{

    vector<NameValue> vecNameValue;
    
    while (cin) 
    {
        string name;
        double value;
        
        cout << "Enter name: ";
        cin >> name ;
        
        if(name == "")
            break;
        
        cout << "Enter value: ";
        cin >> value;
        
        NameValue nv(name, value);
        
        bool alreadyExists = false;
        
        for(vector<NameValue>::iterator it = vecNameValue.begin(); it != vecNameValue.end(); ++it)
        {
            string n = it->name;
            if(n == name)
            {
                alreadyExists = true;
                break;
            }
        }
        
        if(alreadyExists)
        {
            cout << "name already exists" << endl;
        }
        else
        {
            vecNameValue.push_back(nv);
        }
        
        cout << "List so far: " << endl;
        for(vector<NameValue>::iterator it = vecNameValue.begin(); it != vecNameValue.end(); ++it)
        {
           cout << it->name << ": " << it->value << endl;
        }
        
     
    }
}

