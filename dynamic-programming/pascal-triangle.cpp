#include <stdio.h>
#define MAX 200
unsigned long m[MAX];

void displayM(unsigned n) {
  unsigned i;
  printf("\n");
  printf("m = ");
  for (i = 0; i <= n; i++) {
    printf("%d,", m[i]);
  }
  printf("\n");
}

unsigned long binom(unsigned n, unsigned k) { 
  unsigned i, j;
  for (i = 0; i <= n; i++) {
    m[i] = 1;
    if (i > 1) {
      if (k < i - 1) {
        j = k;
      } else {
        j = i - 1;
      }
      for (; j >= 1; j--) {
        m[j] += m[j - 1];
        displayM(n);
      }
    }
  }
  return m[k];
}

int main() {
  printf("Binom =  %d", binom( ??? , ??? ));  
}
