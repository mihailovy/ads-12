#include <string.h>
#include <stdio.h>

#define NOT_CALCULATED (unsigned) (-1) /* Специална стойност */

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
const unsigned m[MAXN] = {0, 30, 15, 50, 10, 20, 40, 5, 65}; /* Тегла */
const unsigned c[MAXN] = {0,  5,  3,  9,  1,  2,  7, 1, 12}; /* Стойности, ценност */

/* Данни за раницата */
const unsigned M = 70; /* Обща вместимост на раницата */
const unsigned N = 8;  /* Брой предмети */

void displayFn() {
  unsigned i;
  
  printf("\n\nFn[%u]\n", M);
  for (i = 0; i < M; i++){
    if (Fn[i] == NOT_CALCULATED) {
      // printf("%u => X, ", i, Fn[i]);
    } else {
      printf("%u => %u, ", i, Fn[i]);
    }
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

/* Пресмята стойността на функцията за k */
void F(unsigned k) { 
  /* Моментни стойности */
  unsigned i;      /* Брояч */
  unsigned fnCur;  /* Момента стойност на fn или mi */
  
  /* Оптимални стойности */
  unsigned bestI;  /* индекс на масив fn, където fn има най-добра стойност */
  unsigned fnBest; /* Стойност на fn, където fn има най-добра стойност */
  
  //displayFn();
  //displaySet();
 
  /* Пресмятане на най-голямата стойност на F */
  bestI  = 0;
  fnBest = 0;
  for (i = 1; i <= N; i++) {
    if (k >= m[i]) {
      
      if (NOT_CALCULATED == Fn[k - m[i]]) {
        F(k - m[i]); /* рекурсия */
      }
       
      if (!set[k - m[i]][i]) {
        fnCur = c[i] + Fn[k - m[i]];
      } else {
        fnCur = 0;
      }
      
      /* Ако моменнтана стойност на fn е по-голяма от най-добрата до тук, 
         то запомняме нейния индекс i в bestI и нейната стойност fnCur в fnBest */
      if (fnCur > fnBest) {
        bestI  = i;
        fnBest = fnCur;
      }
    }
  }
  
  /* Регистриране на най-голямата стойност на функцията */
  Fn[k] = fnBest;
  if (bestI > 0) {
    memcpy(set[k], set[k - m[bestI]], N);
    set[k][bestI] = 1;
  }
}

/* Пресмятане на стойността на целевата функция */
void calculate(void) {
 
  unsigned i;    /* Брояч */
  unsigned sumM; /* Сума на масите*/
  
 
  /* Инициализиране */
  memset(set, 0, sizeof(set)); /* Иниц. на мемоизиращата таблица */
  
  /* Иниц. на целевата "функция"
     Целева "функция" - това е масив с максимален брой елементи MAXM и 
     реален брой елементи M:
                          0,              1, ...     (М-1) = 69  M = 70
     Fn[M] = NOT_CALCULATED, NOT_CALCULATED, ... NOT_CALCULATED, NOT_CALCULATED
  */
  for (i = 0; i <= M; i++) {   
    Fn[i] = NOT_CALCULATED;
  }
  
  /* Дали не можем да вземем всички предмети? */
  sumM = m[1];
  for (i = 2; i <= N; i++) {
    sumM += m[i];
  }
  if (M >= sumM) {
    printf("\nYou can take all items.");
    return;
  } else {
    /* Пресмятане на стойността */
    F(M); /* Параметър ви е общата вместимост на раницата - F(70) */
    
    printf("Final values of the set[][] array:\n");
    displaySet();
     
    /* Отпечатване на резултата */
    printf("\nTake item number:\n");
    for (i = 1; i <= N; i++) {
      if (set[M][i] == 1) {
        printf("%u, ", i);
      }
    }
    printf("\nMaximal value reached value: %u", Fn[M]);
  }
}

int main(void) {
  printf("%s%u", "\nNumber of items, N = ", N);
  printf("%s%u", "\nM =  ", M);
  calculate();
  return 0;
}
