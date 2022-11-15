#include <stdio.h> 
#include <stdlib.h> 
#define MAXN 100 /* Максимален размер на дъската */

const unsigned n = 13; /* Размер на дъската */ 
unsigned col[MAXN] , RD[2*MAXN - 1], LD[2*MAXN], queens [MAXN]; /* Отпечатва намереното разположение на цариците */

/* Печата дъската */
void printBoard() { 
  unsigned i , j ;
  for (i = 0; i < n; i++) {
    printf("\n");
	for (j = 0; j < n; j++) {
	  if (queens[i] == j)
	    printf("x ");
	  else
	    printf(". ");
	}
  }
  printf("\n");
  exit(0);
}

/* Намира следваща позиция за поставяне на царица */
void generate(unsigned i) {
  unsigned j;
  if (i == n)
    printBoard();
  for (j = 0; j < n; j++)
    if (col[j] && RD[i + j] && LD[n + i - j]) {
	  col[j] = 0;
	  RD[i + j] = 0;
	  LD[n + i - j] = 0;
	  queens[i] = j;
	  generate(i + 1); 
	  col[j] = 1; 
	  RD[i + j] = 1; 
	  LD[n + i - j] = 1; 
	}
}

int main(void) { 
  unsigned i;
  for (i = 0; i < n; i++){
	col[i] = 1;
  }
  for (i = 0; i < (2*n - 1); i++) {
	RD[i] = 1;
  }
  for (i = 0; i < 2*n; i++) { 
	LD[i] = 1;
  }
  generate(0);
  printf("Задачата няма решение! \n");
  return 0;
}
