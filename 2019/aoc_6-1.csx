var input = await File.ReadAllLinesAsync("aoc_6_input.txt");

var testinput = new List<string> { "COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L" };

var separated = input.Select(x => { 
    var split = x.Split(')');
    return (split[0], split[1]);
     }).ToList();

var descendants = new List<(string, string)>();

foreach(var node in separated){
    descendants.AddRange(Descendants(node, separated));
}

Console.WriteLine(descendants.ToList().Count);

public IEnumerable<(string, string)> Descendants((string, string) node, IEnumerable<(string, string)> nodes){

    yield return node;

    var children = nodes.Where(x => node.Item2 == x.Item1).ToList();

    foreach (var childNode in children)
    {
        foreach (var child in Descendants(childNode, nodes)){
            yield return child;
        }
    }
}