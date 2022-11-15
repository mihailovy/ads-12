#include <stdio.h>
#include <string.h>

#define MAXN 100
#define MAX(a,b) (((a)>(b)) ? (a) : (b)) /* Връща по-големия аргумент */

char F[MAXN][MAXN]; /* Целева функция */
const char x[MAXN] = "acbcacbcaba";   /* Първа редица */
// const char y[MAXN] = "abacacacababa"; /* Втора редица */
const char y[MAXN] = "acbdddbdddcd"; /* Втора редица */


void displayF(unsigned m, unsigned n) {
  unsigned i,j;
  
  printf("\n");
  printf("====================\n");
  for (i = 0; i <= m; i++) {
    for (j = 0; j <= n; j++) {
      printf("%u ", F[i][j]);
    }
    printf("\n");
  }
  printf("====================\n");
}

/* Намира дължината на най-дългата обща подредица */
unsigned LCS_Length(void) {
  unsigned i, j, m, n;

  m = strlen(x); /* Дължина на първата редица */
  n = strlen(y); /* Дължина на втората редица */
  
  /* Начално инициализиране */
  for (i = 1; i <= m; i++) {
    F[i][0] = 0;
  }
  for (j = 0; j <= n; j++) {
    F[0][j] = 0;
  }
  
  displayF(m, n);

  /* Основен цикъл */
  for (i = 1; i <= m; i++) {
    for (j = 1; j <= n; j++) {
      if (x[i - 1] == y[j - 1]) {
        F[i][j] = F[i - 1][j - 1] + 1;
      } else {
        F[i][j] = MAX(F[i - 1][j], F[i][j - 1]);
      }
      displayF(m, n);
    }
  }
  
  displayF(m, n);
  
  return F[m][n];
}

int main(void) {
  printf("\nLength of the longest sub sequence: %u", LCS_Length());
  return 0;
}
