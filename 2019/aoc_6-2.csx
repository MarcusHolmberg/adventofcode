var input = await File.ReadAllLinesAsync("aoc_6_input.txt");

var testinput = new List<string> { "COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L","K)YOU","I)SAN" };

var separated = testinput.Select(x => { 
    var split = x.Split(')');
    return (split[0], split[1]);
     }).ToList();

var you = ("TPD","YOU");
var san = ("YTC","SAN");

var testSan = ("I", "SAN");

var commonAncestors = new List<(string, string)>();

foreach(var node in separated){
var ancestors = Ancestors(node, separated);
foreach(var ancestorNode in ancestors){
var descendants = Descendants(ancestorNode, separated);
if(descendants.Any(x => x.Item1 == "K" && x.Item2 == "YOU") && descendants.Any(x => x.Item1 == "I" && x.Item2 == "SAN")){
commonAncestors.Add(ancestorNode);
}
}
}
var commonDistinct = commonAncestors.Distinct().ToList();
    (string, string) lowstAncestor;
foreach(var anc in commonDistinct){
    var lowestAncestorCount = 100000;

    var ancestsOfAnc = Ancestors(anc, separated).ToList().Count;
    if(ancestsOfAnc < lowestAncestorCount){
        lowestAncestorCount = ancestsOfAnc;
        lowstAncestor = anc;
    }
}

var descendantsOfLowest = Descendants(lowstAncestor, separated).Distinct().ToList().Count;

Console.WriteLine(descendantsOfLowest);


public IEnumerable<(string, string)> Ancestors((string, string) node, IEnumerable<(string, string)> nodes){

var parent = nodes.FirstOrDefault(x => node.Item1 == x.Item2);
if(parent.Item1 != null){
yield return parent;

foreach(var ancestor in Ancestors(parent, nodes)){
    yield return ancestor;
}
}
}

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