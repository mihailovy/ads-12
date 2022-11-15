<?php

function solve($pp, $qq)
{
  // Намира най-близката дроб с най-малък знаменател	
  echo("Търсим дроб най-близка до ".$pp."/".$qq."\n");  
  $denominator = 2;
  while ($qq > $pp*$denominator) {
    $denominator = $denominator + 1;
  }
  return ($denominator); // стойността на знаменателя
}

// Вход
$p = 3; // 2
$q = 9; // 3

// Задаваме начални стойности
$pCalc = $p; 
$qCalc = $q;

while ($pCalc / $qCalc > 0) {
  $d = solve($pCalc, $qCalc); // Намира_се_максималната_дроб_1/r_ненадвишаваща_p/q;
  echo ("1/".$d."\n");
  $pCalc = $pCalc*$d - $qCalc;
  $qCalc = $qCalc*$d;
} 
