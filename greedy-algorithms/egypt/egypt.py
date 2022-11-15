def solve(pp, qq):	
  print "Searchin for " + str(pp) + "/" + str(qq); 
  denominator = 2;	 
  while qq > pp*denominator:
	  denominator = denominator + 1;
  return denominator
  
# Input
p = 8; # 2
q = 9; # 3

d = solve(p, q) # Find maximal  1/r <  p/q;
print "1/" + str(d);

