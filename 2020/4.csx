List<Dictionary<string, string>> input = (await File.ReadAllTextAsync("4_input.txt"))
                .Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None).ToList()
                    .Select((string x) => x.Split(new[] { " ", "\n" }, StringSplitOptions.None).ToList()
                        .Select(y => new KeyValuePair<string,string>(y.Split(':')[0], y.Split(':')[1])).ToList().ToDictionary(x => x.Key.Trim(), x => x.Value.Trim()))
                        .ToList();
var requiredKeys = new List<string>{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
var validEyeColors = new List<string>{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
int validCount = 0;

foreach(var credential in input)
{
    bool valid = true;
    foreach(var req in requiredKeys)
    {
        if(!credential.ContainsKey(req))
        {
            valid = false;
            break;
        }

        foreach(KeyValuePair<string, string> pair in credential)
        {
            if(pair.Key == req){
            switch(pair.Key){
                case "byr":
                bool validInt = int.TryParse(pair.Value, out int value);
                if(!validInt || value < 1920 || value > 2002 ){
                    valid = false;
                    break;
                }
                break;
                case "iyr":
                bool validInt2 = int.TryParse(pair.Value, out int value2);
                if(!validInt2 || value2 < 2010 || value2 > 2020 ){
                    valid = false;
                    break;
                }
                break;
                case "eyr":
                bool validInt3 = int.TryParse(pair.Value, out int value3);
                if(!validInt3 || value3 < 2020 || value3 > 2030 ){
                    valid = false;
                    break;
                }
                break;
                case "hgt":
                var hasNumericHeight = int.TryParse(System.Text.RegularExpressions.Regex.Match(pair.Value, @"\d+").Value, out int height);
                if(!hasNumericHeight || (pair.Value.Contains("cm") && height < 150) || (pair.Value.Contains("cm") && height > 193) || 
                    (pair.Value.Contains("in") && height < 59) || (pair.Value.Contains("in") && height > 76) ){
                    valid = false;
                    break;
                }

                break;
                case "hcl":
                var isCorrectHairColor = pair.Value.Length == 7 && System.Text.RegularExpressions.Regex.IsMatch(pair.Value, "#[0-9a-f]{6}");
                if(!isCorrectHairColor){
                    valid = false;
                    break;
                }
                break;
                case "ecl":
                var isCorrectEyeColor  = pair.Value.Length == 3 && validEyeColors.Contains(pair.Value);
                if(!isCorrectEyeColor){
                    valid = false;
                    break;
                }
                break;
                case "pid":
                var isCorrectPassportId = pair.Value.Length == 9 && System.Text.RegularExpressions.Regex.IsMatch(pair.Value, "[0-9]{9}");
                if(!isCorrectPassportId){
                    valid = false;
                    break;
                }
                break;
                case "cid":
                break;
            }
            }
        }
    }
    validCount = validCount + (valid ? 1 : 0);
}

Console.WriteLine(validCount);

//Output is 1 more than it should be, can't figure out why :(