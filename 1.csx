
var input = await File.ReadAllLinesAsync("1_1_input.txt");

var inputList = input.Select(x => int.Parse(x)).ToList();


var resultList = new List<Tuple<int,int>>();

foreach(int number in inputList){
  foreach(int num in inputList.Except(new List<int>{number})){
      if(number+num == 2020){
          resultList.Add(new Tuple<int, int>(number, num));
      }
  }
}

Console.WriteLine($"{resultList[0].Item1} {resultList[0].Item2}");
Console.WriteLine(resultList[0].Item1*resultList[0].Item2);

var resultList2 = new List<Tuple<int,int,int>>();

foreach(int number in inputList){
  foreach(int num in inputList.Except(new List<int>{number})){
      foreach(int n in inputList.Except(new List<int>{number, num}))
      if(number+num+n == 2020){
          resultList2.Add(new Tuple<int, int, int>(number, num, n));
      }
  }
}

Console.WriteLine($"{resultList2[0].Item1} {resultList2[0].Item2} {resultList2[0].Item3}");
Console.WriteLine(resultList2[0].Item1*resultList2[0].Item2*resultList2[0].Item3);