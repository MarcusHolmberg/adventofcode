List<List<char>> input = (await File.ReadAllLinesAsync("3_input.txt"))
            .Select(x => x.ToCharArray().ToList()).ToList();

char tree = '#';
Console.Write(
"Solution for nr1: " + GetTreeHitsForSlope(3, 1) + "\n"
);
Console.WriteLine(
    "Solution for nr2: " + 
GetTreeHitsForSlope(1, 1) *
GetTreeHitsForSlope(3, 1) *
GetTreeHitsForSlope(5, 1) *
GetTreeHitsForSlope(7, 1) *
GetTreeHitsForSlope(1, 2) 
);

//Testinput for nr2 is 336 (2, 7, 3, 4, 2)

long GetTreeHitsForSlope(int right, int down){
long treeHits = 0; // long because big multiplication later
var pos = 0;

for (int i = 0; i < input.Count;i = i + 0){
    // Move
    pos = pos + right;
    i = i + down;
    // Check for treehit
    if(i < input.Count && i > 0){
    treeHits += IsItATree(input[i], pos) ? 1 : 0;
    }
}
return treeHits;
}
bool IsItATree(List<char> pattern, int pos){
    while(pos >= pattern.Count){
        pos = pos - pattern.Count;
    }
    return pattern[pos] == tree;
}

