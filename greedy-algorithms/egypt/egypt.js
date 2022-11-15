function solve(pp, qq)
{
	// Намира най-близката дроб с най-малък знаменател	
	writeln("Търсим дроб най-близка до "+pp+"/"+qq+"\n");  
	let denominator = 2;
	while (qq > pp*denominator) {
		denominator = denominator + 1;
	}
	return (denominator); // стойността на знаменателя
}

// Input
let p = 8; // 2
let q = 9; // 3

// Задавам начални стойности
let pCalc = p; 
let qCalc = q;

while (pCalc / qCalc > 0) {
  d = solve(pCalc, qCalc); // Намира_се_максималната_дроб_1/r_ненадвишаваща_p/q;
  writeln("1/"+d+"\n");
  pCalc = pCalc*d - qCalc;
  qCalc = qCalc*d;
}
