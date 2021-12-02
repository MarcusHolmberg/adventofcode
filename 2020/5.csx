List<List<char>> input = (await File.ReadAllLinesAsync("5_input.txt"))
            .Select(x => x.Trim().ToCharArray().ToList()).ToList();

var max = 0;
var results = new List<int>();
foreach(List<char> boardingPass in input){
    var row = GetRow(boardingPass.Take(7).ToList());
    var col = GetColumn(boardingPass.Skip(7).ToList());
    var Id = (row * 8) + col;
    results.Add(Id);
    if (Id > max){
        max = Id;
    }
}
//Nr1: 
Console.WriteLine(max);

//Nr2:
results.Sort();
// my first seat is 6, so when index+6 and value doesn't add up, thats my seat.
for(int i = 0; i < results.Count();i++){
    if(results[i] != i+6){
        Console.WriteLine((i+6));
        break;
    }
}

int GetRow(List<char> rowIn){
    var lower = 0;
    var upper = 127;

    foreach(char c in rowIn){
        if(c == 'B'){
            lower = ((upper + lower) / 2) + 1;
        }
        if(c == 'F'){
            upper = (upper + lower) / 2;
        }
    }
    return rowIn[6] == 'B' ? upper : lower;
}

int GetColumn(List<char> columnIn){
    var lower = 0;
    var upper = 7;
        foreach(char c in columnIn){
        if(c == 'R'){
            lower = ((upper + lower) / 2) + 1;
        }
        if(c == 'L'){
            upper = (upper + lower) / 2;
        }
    }
    return columnIn[2] == 'R' ? upper : lower;
}