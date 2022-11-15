#include <stdio.h>
#include <iostream>
#define MAXN 100 

using namespace std;

/* От 4 елемента ще генериране вариации по 2 елемента */
const unsigned n = 4; 
const unsigned k = 3;
int   taken[MAXN];
char  person[4] = {'B', 'M', 'C', 'A'};

void print(unsigned i) { 
  unsigned l;
  
  printf("( ");
  for (l = 0; l <= i - 1; l++){
    cout << person[taken[l]];
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
