#include <iostream>

using namespace std;

int main()
{
  unsigned long int amount    = 298;
  unsigned long int remainder;
  //                                0   1   2   3  4  5  
  unsigned int banknotes[6]     = {100, 50, 20, 5, 2, 1};
  unsigned int numBanknotes[6]  = {  0,  0,  0, 0, 0, 0};
  //
  remainder = amount;
  for (int i = 0; i < 6; i++) {
    numBanknotes[i] = remainder / banknotes[i];
    remainder       = remainder % banknotes[i];
    cout << numBanknotes[i] << " * " << " лв." << "\n";
  }
}



