List<long> input = (await File.ReadAllLinesAsync("9_input.txt")).Select(x => long.Parse(x)).ToList();


// Part 1
var preamble = 25;
long part1;
for(int i = 0; i < input.Count; i++){
    if(i >= preamble){
        var res = hasSumOfTwo(input[i], input.Skip(i-preamble).Take(preamble).ToList());
    if(res > -1){
        part1 = res;
        Console.WriteLine("Solution for part 1: " + res);
    }
}
}

// Part 2

for(int i = 0; i < input.Count; i++){
    long sum = 0;
    var current = input.Skip(i).ToList();
    for(int j=0;j < current.Count;j++){
        sum += current[j];
        if(sum == part1){
            var range = input.Skip(i).Take(j+1).ToList();
            Console.WriteLine("Solution for part2: " + (range.Min() + range.Max()));
        }
    }
}


long hasSumOfTwo(long num, List<long> prevnums){
var match = false;
foreach(long n in prevnums){
    foreach(long m in prevnums){
        if(n != m){
            if(n+m == num){
                match = true;
            }
        }
    }
}
return match ? (long)-1 : num;
}