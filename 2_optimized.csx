Console.WriteLine(
    (await File.ReadAllLinesAsync("2_input.txt"))
        .Count(x => {
    var parts = x.Split(" ");
    var nums = parts[0].Split("-");
    int min = int.Parse(nums[0]);
    int max = int.Parse(nums[1]);
    char symbol = char.Parse(parts[1].Split(":")[0]);
    string password = parts[2];
     /*nr1:*/ //return (password.Count(x => x == symbol) >= min && password.Count(x => x == symbol) <= max);
    /*nr2:*/ return ((password[min-1] == symbol && password[max-1] != symbol) || (password[min-1] != symbol && password[max-1] == symbol) );
    }));