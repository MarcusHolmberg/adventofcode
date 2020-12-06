List<Tuple<int, string, HashSet<char>>> input = (await File.ReadAllTextAsync("6_input.txt"))
                .Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None).ToList()
                    .Select((string x) =>
                    {
                        var group = x.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        var merged = string.Join("",group);
                        var uniqueAnswers = new HashSet<char>(merged);
                        return new Tuple<int,string,HashSet<char>>(group.Length, merged, uniqueAnswers);
                    }).ToList();
                  
int totalNr1 = 0;
int totalNr2 = 0;

foreach(var group in input){
    foreach(char uanswer in group.Item3){ 
        if(group.Item2.Count(x => x == uanswer) == group.Item1){
            totalNr2 += 1;
        }
    }
    totalNr1 += group.Item3.Count;
}
Console.WriteLine("Answer to nr1: " + totalNr1);
Console.WriteLine("Answer to nr2: " + totalNr2);
// Result of testinput should be 11 and 6