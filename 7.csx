List<Tuple<string, List<Tuple<int, string>>>> input = (await File.ReadAllLinesAsync("7_input.txt"))
                     .Select(x => {
                         var parts = x.Split("bags contain");
                         List<string> contents = parts[1].Split(", ").ToList();
                         return new Tuple<string, List<Tuple<int, string>>>(parts[0].Trim(), contents.Select(y => new Tuple<int, string>(int.Parse(y.Remove(2, y.Count() -2).Replace("n", "0")), y.Remove(0,2).Replace("bags", "").Replace("bag", "").Replace(".", "").Replace("o other", "").Trim())).ToList());
                     }
                         )
                     .ToList();

/* Part 1 */
var shinyGoldHoldingBags = new HashSet<string>();
var result = GetShinyGoldCountFromContainer(input, "shiny gold", ref shinyGoldHoldingBags);

Console.WriteLine("Solution for part 1: " + (result.Count -1)); // -1 for self

HashSet<string> GetShinyGoldCountFromContainer(List<Tuple<string, List<Tuple<int, string>>>> input, string container, ref HashSet<string> goodBags){
    for(int i = 0; i < input.Count;i++){
        if(input[i].Item1 == container){
            goodBags.Add(input[i].Item1);
        }
        for(int j = 0; j < input[i].Item2.Count;j++){
            if(input[i].Item2[j].Item2 == container){
            goodBags.Add(input[i].Item1);   
            GetShinyGoldCountFromContainer(input, input[i].Item1, ref goodBags);
            }
        }
    }
return goodBags;
}

/* PART 2 */
var resultForDay2 = GetRequiredBagsInsideShinyGold(input, "shiny gold");

Console.WriteLine("Solution for part 2: " + resultForDay2);

int GetRequiredBagsInsideShinyGold(List<Tuple<string, List<Tuple<int, string>>>> input, string container){
    var count = 0;
    for(int i = 0; i < input.Count;i++){
        if(input[i].Item1 == container){
            for(int j = 0; j < input[i].Item2.Count;j++){
                if(input[i].Item2[j].Item1 > 0){
                count += input[i].Item2[j].Item1 * (GetRequiredBagsInsideShinyGold(input, input[i].Item2[j].Item2) + 1);
                // + 1 for self
                }
            }
        }
        }
        return count;
}