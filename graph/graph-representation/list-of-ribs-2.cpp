#include <stdio.h>
#define MAX 200

int rib[MAX][3]; // Двумерен масив 
int n;

int main(void) {
  // Елементарен насочен претеглен граф, който използва двумерен масив. 
  //
  //        +-------------+   +---+
  //        |             V   |   |
  // 1 ---> 2 ---> 3 ---> 4   --5<+    6     7
  // |      ^      ^                         |
  // +-------------+                         |
  //        |                                |
  //        +--------------------------------+
  
  n = 6;
  
  // представяне на граф чрез списък от ребра
  //  от връх:       до връх:         тегло:
  rib[0][0] = 1; rib[0][1] = 3; rib[0][2] = 1;
  rib[1][0] = 1; rib[1][1] = 2; rib[1][2] = 2;
  rib[2][0] = 2; rib[2][1] = 3; rib[2][2] = 99;
  rib[3][0] = 2; rib[3][1] = 4; rib[3][2] = 58;
  rib[4][0] = 3; rib[4][1] = 4; rib[4][2] = 43;
  
  // Добавяме нов връх, който е свързан със самия себе си
  rib[5][0] = 5; rib[5][1] = 5; rib[5][2] = 55;
   
  // Добаваме нов връх, който не свързан
  rib[6][0] = 6; rib[6][1] = 0; rib[6][2] = 0; // служебна стойност, нула, не сочи никъде!
  
  // Добавяме нов връх 7, който е свързан с връх 2
  rib[7][0] = 7; rib[7][1] = 2; rib[7][2] = 10;
  
}

/*
me says:Александра: 
me says:1 -> 3 
me says:2 -> 3 
me says:3 -> 3 
me says:Андрей Тодоров: 
me says:1 -> 4 
me says:2 ->4 
me says:2 -> 3 
me says:3 ->4 
me says:Антоан Минев: 
me says:1 -> 2 
me says:2 -> 3 
me says:3 -> 4 
me says:1 -> 4 
me says:1 -> 3 
me says:Атанас Нинов: 
me says:1 -> 3 
me says:2 -> 3 
me says:3 -> 1 
me says:3 -> 2 
me says:Георги Илиев: 
me says:1 -> 3 
me says:2 -> 3 
me says:3 -> 4 
me says:4 -> 5 
me says:Евгени: 
me says:1 -> 3 
me says:2 -> 3 
me says:3 -> 4 
me says:2 -> 4 
me says:4 -> 4 
me says:Андрей Попов: 
me says:1 -> 5 
me says:5 -> 2 
me says:2 -> 4 
me says:4 - > 3 
me says:Борис Аладжов 
me says:1 -> 6 
me says:2 -> 6 
me says:3 -> 6 
me says:4 -> 4 
me says:5 - сама 
me says:Иван Галев 
me says:1 -> 6 
me says:2 сама 
me says:3 сама 
me says:4 сама 
me says:5 -> 6 
me says:#include <stdio.h>
*/
