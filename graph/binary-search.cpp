#include <stdio.h>

// Максимален брой стойности в масив
#define MAXN 200

// Брой стойности в масива
const unsigned n = 10;

// Масив от цели числа
unsigned array[MAXN] = {12, 34, 45, 56, 67, 89, 123, 124, 134, 888};
 
// Двоично търсене в сортиран масив
int main(void) {
  unsigned checks = 0;
  unsigned left;      // ляв индекс
  unsigned right;     // десен индекс
  unsigned middle;    // среден индекс
  unsigned find = 56; // Търсим индекса на 12
  
  left   = 0;
  right  = n-1;
  while (left < right-1) {
    middle = (left + right)/2;
    checks++;
    if (find == array[middle]) {
       printf("Index of number %u is: %u\n", find, middle);
       printf("Number of checks: %u\n", checks);
       break;
    } else if(find < array[middle]) {
      right = middle;
    } else if(find > array[middle]) {
      left = middle;
    }
  }
}
// Извод:
// 1.Броя на проверките log (2, n)
// 2.В порядъци по-бързо от линейното

