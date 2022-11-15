#include <stdio.h>
#define MAXN 100

/* От 4 елемента ще генериране вариации по 2 елемента */
const unsigned n = 3; 
const unsigned k = 2;
int taken[MAXN];

void print(unsigned i) { 
  unsigned l;
  
  printf("( ");
  for (l = 0; l <= i - 1; l++){
    printf("%u ", taken[l] + 1);
  }
  printf(")\n");
}

/* рекурсия */
void variate(unsigned i) {
  unsigned j;
  /* без if (i>=k) и return; тук (а само print(i); ако искаме всички
   * генерирания с дължина 1,2, …, k, а не само вариациите с дължина k */
  if (i >= k) {
    print(i);
    return;
  }
  for (j = 0; j < n; j++) {
    /* if (allowed(i)) { */
    taken[i] = j;
    variate(i + 1);
  }
}

int main(void) {
  variate(0);
  return 0;
}
