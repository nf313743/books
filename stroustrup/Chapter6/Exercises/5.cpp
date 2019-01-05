#include <vector>
#include <iostream>
#include <string>
#include <boost/version.hpp>
using namespace std;

string getWord();
void verb(string str);
void noun(string str);
void conjunction(string str);
void sentence(string str);

vector<string> vecWords;
int currentIndex = 0;
int maxIndex = 0;
string current_word;


string getWord()
{
    cin >> current_word;
    return current_word;
}



void verb(string str)
{
    if(str == "fly" || str == "swim")
    {
        return;
    }    
    cout << "verb" << endl;
    throw;
}

void noun(string str)
{   
    if(str == "birds" || str == "fish")
    {
        string str = getWord();
        verb(str);
        return;
    }
    cout << "noun:" << str << endl;
    throw;
}

void conjunction(string str)
{
    if(str == "but")
    {
        string str = getWord();
        sentence(str);
        return;
    }
    
    cout << "conjunction" << endl;
    throw;
}

void sentence(string str)
{
    noun(str);
}

int main()
{
    try
    {
        while(cin)
        {

            
            string str = getWord();
            
            if(str == ".")
            {
                break;
            }
            
            sentence(str);
            
            str = getWord();
            
            if(str == ".")
            {
                break;
            }
            
            conjunction(str);
        }
    
        cout << "This is a valid sentence" << endl;
    }
    catch(...)
    {
        cout << "Invalid sentence!!!" << endl;
    }
    
    return 0;
}

