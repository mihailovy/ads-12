#include <stdio.h>
#include <string.h>

#define MAX 100
#define LEFT 1
#define UP 2
#define UPLEFT 3

char F[MAX][MAX]; /* Целева функция */
char b[MAX][MAX]; /* Указател към предходен елемент */
const char x[MAX] = "acbcacbcaba";   /* Първа редица */
const char y[MAX] = "abacacacababa"; /* Втора редица */


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

void displayB(unsigned m, unsigned n) {
  unsigned i,j;
  
  printf("\n");
  printf("====================\n");
  for (i = 0; i <= m; i++) {
    for (j = 0; j <= n; j++) {
      if (b[i][j] == UPLEFT) {
        printf("D ");
      }
      if (b[i][j] == UP) {
        printf("U ");
      }
      if (b[i][j] == LEFT) {
        printf("L ");
      }
      if (b[i][j] == 0) {
        printf("  ");
      }
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

  /* Основен цикъл */
  for (i = 1; i <= m; i++) {
    for (j = 1; j <= n; j++) {
      if (x[i - 1] == y[j - 1]) {
        /* Съвпадение на елемент горе-ляво (диагонал) */
        F[i][j] = F[i - 1][j - 1] + 1;
        b[i][j] = UPLEFT;
      } else if (F[i - 1][j] >= F[i][j - 1]) {
        /*Съвпадение по елемент горе */
        F[i][j] = F[i - 1][j];
        b[i][j] = UP;
      } else {
        /* Съвпадение по елемент ляво*/
        F[i][j] = F[i][j - 1];
        b[i][j] = LEFT;
      }
      displayB(m, n);
    }
  }
  return F[m][n];
}

/* Намира една възможна максимална обща подредица (обърната)
 * Бележка: итеративно решение без рекурсия */
void printLCS(void) {
  unsigned i = strlen(x), j = strlen(y);
  while (i > 0 && j > 0){
    switch (b[i][j]) {
      case UPLEFT:
        /* Интересува ни съвпадение само по диагонал нагоре и наляво */
        printf("%c", x[i - 1]); 
        i--;
        j--;
        break;
      case UP:
        i--;
        break;
      case LEFT:
        j--;
    }
  }
}

/* Намира една възможна максимална обща подредица 
 * Бележка: решение с рекурсивна функция */
void printLCS2(unsigned i, unsigned j) {
  if (0 == i || 0 == j) {
    return;
  }
  if (UPLEFT == b[i][j]) {
    printLCS2(i - 1, j - 1);
    printf("%c", x[i - 1]);
  } else if (UP == b[i][j]) {
    printLCS2(i - 1, j);
  } else {
    printLCS2(i, j - 1);
  }
}

/* Намира една възможна максимална обща подредица
 * Бележка: тук не се ползва масива b, а целевата функция и x, y */
void printLCS3(unsigned i, unsigned j) {
  if (0 == i || 0 == j)
    return;
  if (x[i - 1] == y[j - 1]) {
    printLCS3(i - 1, j - 1);
    printf("%c", x[i - 1]);
  } else if (F[i][j] == F[i - 1][j])
    printLCS3(i - 1, j);
  else
    printLCS3(i, j - 1);
}

int main(void) {
  printf("\nLength of the longest common subsequence: %u", LCS_Length());
  printf("\nPrintLCS: maximal subsequence (in back order): ");
  printLCS();
  printf("\nPrintLCS2: Maximal common subsequence: ");
  printLCS2(strlen(x), strlen(y));
  printf("\nPrintLCS3: Maximal common subsequence: ");
  printLCS3(strlen(x), strlen(y));
  return 0;
}
