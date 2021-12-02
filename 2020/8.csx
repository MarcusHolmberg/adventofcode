List<Tuple<string, int>> input = (await File.ReadAllLinesAsync("8_input.txt"))
                                 .Select(x => new Tuple<string, int>(x.Split(" ")[0], int.Parse(x.Split(" ")[1]))).ToList();

Console.WriteLine("Solution for part 1: " + GetFinalIndexAndAcc(input).Item2);

for(int i = 0; i < input.Count; i++){
var inputCopy = new List<Tuple<string, int>>(input);

    if(inputCopy[i].Item1 == "jmp"){
        inputCopy[i] = new Tuple<string, int>("nop", inputCopy[i].Item2);
    }
    else if(inputCopy[i].Item1 == "nop"){
        inputCopy[i] = new Tuple<string, int>("jmp", inputCopy[i].Item2);
    }
    var indexAndAcc = GetFinalIndexAndAcc(inputCopy);

    if(indexAndAcc.Item1 == input.Count){
        Console.WriteLine("Solution for part 2: " + indexAndAcc.Item2);
    }
}


Tuple<int, int> GetFinalIndexAndAcc(List<Tuple<string, int>> input){
    var acc = 0;
    var visitedIndex = new HashSet<int>();
    int i = 0;
    for(i = 0; i < input.Count; i = i*1){
        visitedIndex.Add(i);
        if(input[i].Item1 == "acc"){
            acc += input[i].Item2;
        }
        if(input[i].Item1 == "jmp"){
            if(visitedIndex.Contains(i + input[i].Item2)){
                break;
            }else{
            i = i + input[i].Item2;
            }
        }else{
            if(visitedIndex.Contains(i + 1)){
                break;
            }
            i = i + 1;
        }
    }
    return new Tuple<int, int>(i, acc);
}
