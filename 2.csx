var input = await File.ReadAllLinesAsync("2_input.txt");

var inputList = input.Select(x => {
    var parts = x.Split(" ");
    int min = int.Parse(parts[0].Split("-")[0]);
    int max = int.Parse(parts[0].Split("-")[1]);
    char symbol = char.Parse(parts[1].Split(":")[0]);
    string password = parts[2];
    /*nr1:*/ // bool valid = password.Count(x => x == symbol) >= min && password.Count(x => x == symbol) <= max;
    /*nr2:*/   bool valid = (password[min-1] == symbol && password[max-1] != symbol) || (password[min-1] != symbol && password[max-1] == symbol);
    return (min: min, max: max,symbol: symbol,password: password,valid: valid);
}).ToList();

Console.WriteLine(inputList.Count(x => x.valid == true));