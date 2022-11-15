#include <stdio.h>
#define MAXN 100

const unsigned n = 5; 
const unsigned k = 3;
unsigned mp[MAXN];

void print(unsigned length) {
   unsigned i;
   for (i = 0; i < length; i++) {
     printf("%u ", mp[i]);
   }
   printf("\n");
}

void comb(unsigned i, unsigned after) {
  unsigned j;
  if (i > k) {
    return;
  }
  for (j = after + 1; j <= n; j++) {
    mp[i - 1] = j;
    if (i == k) {
      print(i);
    }
    comb(i + 1, j);
  }
}

int main(void) {
  printf("C(%u,%u): \n", n, k);
  comb(1, 0);
  return 0;
}
