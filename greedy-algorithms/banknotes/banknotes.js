let amount = 298;
let remainder = $amount;
//                0   2   3   4  5  6  7
banknotes    = [100, 50, 20, 10, 5, 2, 1];
numBanknotes = [  0,  0,  0,  0, 0, 0, 0];

for ($i = 0; $i < banknotes.length; i++) {
	numBanknotes[i] = remainder / banknotes[i];
	remainder       = remainder % $banknotes[i];
	writeln("1/"+remainder+"\n");
}


