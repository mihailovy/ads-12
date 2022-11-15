#include <stdio.h>
#define MAX 200

int matrix[MAX][MAX]; // Двумерен масив 
int n;

void init(void) {
  int i,j;
  
  for (i = 0; i < n; i++) {
    for (j = 0; j < n; j++) {
      matrix[i][j] = 0;
    }
  } 
}

int main(void) {
  // Елементарен насочен граф, който използва двумерен масив. 

  //           +---------+
  //           |         V
  // 1(0) ---> 2(1) ---> 3(2) ---> 4(3)
  // |         ^  
  // +---------+
  
  init();
  
  n = 4;
  
  matrix[0][1] = 1;
  matrix[1][2] = 1;
  matrix[2][3] = 1;
  matrix[0][1] = 1;
  matrix[1][2] = 1;
}

