#include <stdio.h>
#include <stdlib.h>

typedef char *data;
typedef int  keyType;

struct tree {
  keyType key;
  data info;
  struct tree *left;
  struct tree *right;
};

/* Търсене в двоично дърво */
struct tree *search(keyType key, struct tree *T) {
  if (NULL == T) {
    return NULL;
  } else if (key < T->key) {
    return search(key, T->left);
  } else if (key > T->key) {
    return search(key, T->right);
  } else {
    return T;
  }
}

/* Включване в двоично дърво */
void insertKey(keyType key, data x, struct tree **T) {
  if (NULL == *T) {
    /* Това е случая, в който дървото още не е създадено */
    *T = (struct tree *) malloc(sizeof(**T)); /* динамично алокираме памет */
    (*T)->key   = key;  // задаваме ключ
    (*T)->info  = x;    // попълваме с информация
    (*T)->left  = NULL; // засега левия "крак" не сочи никъде
    (*T)->right = NULL; // засега десния "крак" не сочи никъде
  } else if (key < (*T)->key) {
    // Ключът е по-малък и трябва да отиде я левия крак
    insertKey(key, x, &(*T)->left); // Рекурсия!
  } else if (key > (*T)->key) {
    // Ключът е по-голям и трябва да отиде в десния крак
    insertKey(key, x, &(*T)->right);  // Рекурсия!
  } else {
    // Няма нужда да добавяме елемент, който вече е добавен
    fprintf(stderr, "Element is already in the tree!\n");
  }
}

void deleteKey(keyType key, struct tree **T) {
  if (NULL == *T) {
    // Такъв връх няма и не правим нищо
    fprintf(stderr,"Върхът,който трябва да се изключи, липсва!\n");
  } else {
    if (key < (*T)->key) {
      deleteKey(key, &(*T)->left);
    } else if (key > (*T)->key) {
      deleteKey(key, &(*T)->right);
    } else {
      /* елементът за изключване е намерен */
      if ((*T)->left && (*T)->right) {
        /* върхът има два наследника. Намира се върхът за размяна */
        struct tree *replace = findMin((*T)->right);
        (*T)->key = replace->key;
        (*T)->info = replace->info;
        
        /* върхът се изключва */
        deleteKey((*T)->key, &(*T)->right);
      } else {
        /* елементът има нула или едно поддървета */
        struct tree *temp = *T;
        if ((*T)->left) {
          *T = (*T)->left;
        } else {
          *T = (*T)->right;
        }
        // Паметта, която сме заделили динамично се освобождава
        free(temp);
      }
    }
  }
}

/* Изключване от двоично дърво */
/* Намиране на минималния елемент в дърво */
struct tree *findMin(struct tree *T) {
  while (NULL != T->left){
     T = T->left;
  }
  return T;
}

void printTree(struct tree *T) {
  if (NULL == T){
    return; // Условия за изход от рекурсия
  }
  printf("%d ", T->key);
  printTree(T->left);  // Рекурсия!
  printTree(T->right); // Рекурсия!
}

int main(void) {
  struct tree *T = NULL;
  struct tree *result;
  int i;

  /* включва 10 върха с произволни ключове */
  for (i = 0; i < 10; i++) {
    int ikey = (rand() % 20) + 1;
    printf("Insert element with key %d \n", ikey);
    insertKey(ikey, "someinfo", &T);
  }

  printf("Tree: ");
  printTree(T);// Печата дървото
  printf("\n");
  
  /* претърсва за елемента с ключ 5 */
  result = search(5, T);
  printf("Found: %s\n", result->info);
  
  /* изтрива произволни 10 върха от дървото */
  for (i = 0; i < 10; i++) {
    int ikey = (rand() % 20) + 1;
    printf("Delete element with key %d \n", ikey);
    deleteKey(ikey, &T);
  }
  
  printf("Tree: ");
  printTree(T);
  printf("\n");
  return 0;
}
