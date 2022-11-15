#include <iostream>

using namespace std;

int main()
{
  unsigned long amount, rmainder, b100, b50, b20, b10, b5, b2, b1;

  // Брой банкноти
  b100 = 0; 
  b50  = 0;
  b20  = 0;
  b10  = 0;
  b5   = 0;
  b2   = 0;
  b1   = 0;
  
  // Вход
  amount    = 3367;
  remainder = amount;

  b100         = remainder / 100;
  remainder    = remainder % 100;
  b50          = remainder / 50;
  remainder    = remainder % 50;
  b20          = remainder / 20;
  remainder    = remainder % 20;
  b10          = remainder / 10;
  remainder    = remainder % 10;
  b5           = remainder / 5;
  remainder    = remainder % 5;
  b2           = remainder / 2;
  remainder    = remainder % 2;
  b1           = remainder / 1;
  remainder    = remainder % 1;
  
  // Изход
  cout << "100-> " << b100 << "\n";
  cout << "50 -> " << b50  << "\n";
  cout << "20 -> " << b20  << "\n";
  cout << "10 -> " << b10  << "\n";
  cout << "5  -> " << b5   << "\n";
  cout << "2  -> " << b2   << "\n";
  cout << "1  -> " << b1   << "\n";
}



