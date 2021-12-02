
using System;
var input = new List<decimal>{ 142536,
103450,
101545,
133505,
112476,
62461,
108718,
93376,
149609,
147657,
120888,
85008,
82501,
122988,
109493,
91656,
70001,
130308,
140298,
104623,
103542,
129220,
67381,
143889,
105384,
139467,
129004,
89271,
123863,
108567,
95453,
109698,
139953,
107458,
69734,
106036,
126036,
84832,
68715,
51484,
92833,
50734,
58267,
109650,
137004,
77709,
95073,
84817,
55711,
95408,
148990,
51697,
129180,
56196,
72692,
77049,
124294,
85102,
124400,
75981,
135842,
119561,
79871,
98771,
134213,
141322,
131828,
65692,
113994,
104632,
129273,
118023,
54700,
148185,
61618,
132304,
88308,
121386,
119548,
115527,
76627,
63168,
137582,
113598,
100899,
100167,
134345,
90716,
55476,
113403,
52745,
78755,
73421,
93337,
71171,
122979,
134298,
123117,
111244,
122177,
};
var testInput = new List<decimal>{100756};

Console.WriteLine(GetFuel(input));

public decimal GetFuel(List<decimal> masses) {
    decimal sum = new decimal(0);
    foreach(var mass in masses){
        decimal innerSum = 0;
        decimal lastSum = 1;
        decimal newInSum = mass;
        do
        {
            lastSum = GetFuel(newInSum);
            newInSum = lastSum;
            if(lastSum > 0){
            innerSum += lastSum;
            }
        }
        while(lastSum >= 0);
        sum += innerSum;
    }
return sum;
}

public decimal GetFuel(decimal mass){
    return Math.Floor((mass / 3))-2;
}

