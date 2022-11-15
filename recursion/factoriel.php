<?php
// Намиране на сумата на числата от 1 до num

function Solve($num)  
{
  // Console.Write(". ");  
  if ($num < 2) {
    return 1;
  } else {
    return $num * Solve($num - 1);
  } 
}

$num = 75;
echo("Факториел(".$num.") = "  . Solve($num) ); 


 
 
