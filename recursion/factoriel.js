function Solve( num)  
{
   if (num < 2) {
     return 1;
   } else {
     return num * Solve(num - 1);
   } 
}

let num = 75;
writeln("Факториел("+num+") = "  + Solve(num));  

/*
 0! = 1
 1! = 1 
 4! = 1 * 2 * 3 * 4
 5! = 1 * 2 * 3 * 4 * 5
    = 5 * 4 * 3 * 2 * 1 
    = 5 * 4!
    = 5 * (4 * 3!)
    = 5 * (4 * (3 * 2!))
 
 100! = 9.33262154439441e+157 JS
 100! = 9.3326215443944E+157 PHP
 factoriel(n) = n * factoriel(n - 1), n >= 1
 
 */
