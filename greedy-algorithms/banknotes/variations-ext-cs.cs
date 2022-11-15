using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
class Program
{
  const uint MAXN = 4;

  /* От 4 елемента ще генериране вариации по 2 елемента */
  const uint n = 4; 
  const uint k = 3;
  static uint[] taken  = {0,0,0,0};
  static char[] person = {'B', 'M', 'C', 'A'};

  static void Main(string[] args)
  {
    uint t;
    t = variate(0);
  }
  
  static void print(uint i)
  { 
    uint l;
  
    Console.Write("( ");
    for (l = 0; l <= i - 1; l++){
      Console.Write(person[taken[l]]);
    }
    Console.Write(")");
    Console.WriteLine(); 
  }
  
  /* рекурсия */
  static uint variate(uint i) {
    uint j;
    /* без if (i>=k) и return; тук (а само print(i); ако искаме всички
     * генерирания с дължина 1,2, …, k, а не само вариациите с дължина k */
    if (i >= k) {
      Console.Write(i);
      return 0;
    }
    for (j = 0; j < n; j++) {
      /* if (allowed(i)) { */
      taken[i] = j;
      variate(i + 1);
    }
    return 0;
  }

}
