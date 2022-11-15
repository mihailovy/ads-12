#include <stdio.h>
#define MAXN 100
const unsigned n = 7;

const unsigned s[MAXN] = { 3, 7,   5,  9, 13, 15, 17};
const unsigned f[MAXN] = { 8, 10, 12, 14, 15, 19, 20};

void solve(void) {
  unsigned i = 1, j = 1;
  printf("Chosen lectures: %u ", 1);
   while (j++ <= n)
     if (s[j - 1] > f[i - 1])
       printf("%u ", i = j);
     printf("\n");
}

int main(void) {
  solve();
  return 0;
}
