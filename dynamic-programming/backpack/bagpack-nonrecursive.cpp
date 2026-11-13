#include <string.h>
#include <stdio.h>

#define MAXN 30        /* Максимален брой предмети */
#define MAXM 1000      /* Максимална вместимост на раницата */

char set[MAXM][MAXN];  /* Множество от предмети за k = 1..M */
/*
N=       1  2  3  4  5  6  7  8 - брой предмети
       1             1
       2
       3 
.
.
.
M-1 = 69
      тегло
*/

/* Целева "функция" - това е масив с максимален брой елементи MAXM и 
 * реален брой елементи M:
 *                      0,              1, ...          (М-1)
 * Fn[M] = NOT_CALCULATED, NOT_CALCULATED, ... NOT_CALCULATED
 */
unsigned Fn[MAXM];    

/* Данни за екземплярите */
              /* Индекс:  0,  1,  2,  3,  4,  5,  6,  7,  8 */
//const unsigned m[MAXN] = {0,  5, 15,  5, 10, 10,  5,  5, 20}; /* Тегла */
//const unsigned c[MAXN] = {0,  5,  3,  9,  1,  2,  7,  1, 12}; /* Стойности */
              /*  k-m[i]:    65, 55, 65, 60, 60, 65, 65, 50*/

/*               Индекс:  0,  1,  2,  3,  4,  5,  6, 7,  8 */
const unsigned m[MAXN] = {0, 30, 15, 50, 10, 20, 40, 5 , 65}; /* Тегла */
const unsigned c[MAXN] = {0,  3,  3,  3,  3,  3,  3, 12, 3 }; /* Стойности */

/* Данни за раницата */
const unsigned M = 70; /* Обща вместимост на раницата */
const unsigned N = 8;  /* Брой предмети */

void displayFn() {
  unsigned i;
  
  printf("\n\nFn[%u]\n", M);
  for (i = 0; i <= M; i++){
    printf("%u => %u, ", i, Fn[i]);
  } 
}

void displaySet() {
  unsigned i, j;
  
  printf("\n\n");
  for (i = 1; i <= M; i++) {
    for (j = 1; j <= N; j++) {
      printf(" %u", set[i][j]);
    }
    printf("\n");
  } 
}

void calculate(void) {
  unsigned maxValue; /* Максимална постигната стойност */
  unsigned maxIndex; /* Индекс, за който е постигната */
  unsigned i, j, sumM;
  
  /* Иниц. на множествата предмети */
  memset(set, 0, sizeof(set)); 
  
  sumM = m[1];
  for (i = 2; i <= N; i++) {
    sumM += m[i];
  }
  if (sumM <= M) {
    printf("You can take all items\n");
    return; 
  }
  
  /* Пресмятане на стойностите на целевата функция */
  for (i = 1; i <= M; i++) { /* цикъл по вертикала */
    /* Търсим макс. стойност на Fn(i), цикъл от 1 до 70 по теглото */
    maxValue = maxIndex = 0;
    for (j = 1; j <= N; j++) { /* цикъл по хоризонтала */
      /* Цикъл по номер на предмета */
      /* текущата маса на определен предмет да е по-голяма от масата, за която циклим в i */
      if (m[j] <= i && !set[i - m[j]][j]) {
        /* i - m[j]  допълението на текущата маса винаги е попожително */
        if (c[j] + Fn[i - m[j]] > maxValue) {
          maxValue = c[j] + Fn[i - m[j]]; /* Максилмална стойност */
          maxIndex = j;                   /* Индекс на максималната стойност */
        }
      }
    }
 
    if (maxIndex > 0) { /* Има ли предмет с тегло по-малко от i? */
      Fn[i] = maxValue;
      /* Новото множество set[i] се получава от set[i-m[maxIndex]]
       * чрез добавяне на елемента maxIndex */
      memcpy(set[i], set[i - m[maxIndex]], N);
      set[i][maxIndex] = 1;
     }
     
     if (Fn[i] < Fn[i - 1]) { /* Побират се всички предмети и още */
       Fn[i] = Fn[i - 1];
       memcpy(set[i], set[i - 1], N);
     }
  }
 
  displayFn();
  displaySet();
  
  /* Извеждане на резултата */
  printf("\nTake item #:\n");
  for (i = 1; i <= N; i++) {
    if (set[M][i] == 1) {
      printf("%5u", i);
    }
  }
  printf("\n");
  printf("Maximal value of Fn: %u\n", Fn[M]);
}

int main(void) {
  calculate();
  return 0;
}
