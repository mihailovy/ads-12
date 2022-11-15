#include <stdio.h>

// Максимален брой стойности в масив
#define MAXN 200

// Брой стойности в масива
const unsigned n = 10;

// Масив от цели числа
// unsigned array[MAXN] = {12, 45, 67, 888, 123, 134, 56, 89, 124, 34};
unsigned array[MAXN] = {12, 34, 45, 56, 67, 89, 123, 124, 134, 888};
 
// Линейно търсене в несортиран масив
int main(void) {
  unsigned i;
  unsigned find = 56; // Търсим индекса на 56
  
  for (i = 0; i < n; i++) {
    if (array[i] == find) {
      printf("Index of number %u is: %u\n", find, i);
      break;     
    }
  }
  
}
// Извод:
// 1. максимален брой операции if при линейно търсене е n;
// 2. При голям обем на данните този тип търсене е бавно.
