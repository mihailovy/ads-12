<?php

// begin: Input data
$amount    = 298;
$remainder = $amount;
//                 0   1   2  3  4  5
$banknotes    = [100, 20, 50, 5, 2, 1];
$numBanknotes = [  0,  0,  0, 0, 0, 0];
// end: Input data

/*
for ($i = 0; $i < count($banknotes); $i++) {
	$max      = $banknotes[$i];
	$maxIndex = $i;
	for ($j = $i; $j < count($banknotes); $j++){
		if ($banknotes[$j] > $max) {
			$max      = $banknotes[$j];
			$maxIndex = $j;
		}
	}
	$temp                 = $banknotes[$maxIndex];
	$banknotes[$maxIndex] = $banknotes[$i];
	$banknotes[$i]        = $temp; 
} 
* */

// print_r($banknotes); exit (0);

// 30 + 5 + 5 - 3 banknotes
// 20 + 20    - 2 banknoets
 
for ($i = 0; $i < count($banknotes); $i++) {
	$numBanknotes[$i] = floor($remainder / $banknotes[$i]);
  echo ("remainder = ".$remainder.", ");
  echo ( "banknote = ".$banknotes[$i].", ");
  echo ( '$numBanknotes['.$i.'] = '.$numBanknotes[$i]." \n"); 
	$remainder    = $remainder % $banknotes[$i];	
}

print_r($numBanknotes);
	
/*
$amount    = 3367;
$remainder = $amount;

$b100 = 0; // Ammount of banknotes or coins
$b50  = 0;
$b20  = 0;
$b10  = 0;
$b5   = 0;
$b2   = 0;
$b1   = 0;

$b50          = floor($remainder / 50);
$remainder    = $remainder % 50;

$b20          = floor($remainder / 20);
$remainder    = $remainder % 20;

$b10          = floor($remainder / 10);
$remainder    = $remainder % 10;

$b5           = floor($remainder / 5);
$remainder    = $remainder % 5;

$b2           = floor($remainder / 2);
$remainder    = $remainder % 2;

$b1           = floor($remainder / 1);
$remainder    = $remainder % 1;

echo("100-> ".$b100."\n");
echo("50 -> ".$b50."\n");
echo("20 -> ".$b20."\n");
echo("10 -> ".$b10."\n");
echo("5  -> ".$b5."\n");
echo("2  -> ".$b2."\n");
echo("1  -> ".$b1."\n");
*/
