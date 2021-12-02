List<List<char>> input = (await File.ReadAllLinesAsync("11_input.txt")).Select(x => x.ToCharArray().ToList()).ToList();

int step = 1; //to get both solution on one run, step is basically part 2 when 1 and part 1 when 0...

while(step > -1){
var cont = true;
int simulationCount = 0;
var inputCopy = input.Select(x => x.Select(y => y).ToList()).ToList();
while (cont)
{
    var simulation = Simulate(inputCopy);
    simulationCount++;
    inputCopy = simulation.Item2.Select(x => x.Select(y => y).ToList()).ToList();
    cont = simulation.Item1;
    if (!cont)
    {
        Console.WriteLine("Result for part "+ (step+1) + ": " + OccupiedCount(simulation.Item2));
        Console.WriteLine("Simulation count: " + simulationCount);
    }
}
step--;
}

Tuple<bool, List<List<char>>> Simulate(List<List<char>> matrix)
{
    var output = matrix.Select(x => x.Select(y => y).ToList()).ToList();
    char empty = 'L';
    char occupied = '#';
    bool wasAltered = false;

    for (int y = 0; y < matrix.Count; y++)
    {
        for (int x = 0; x < matrix[0].Count; x++)
        {
            if (matrix[y][x] == empty)
            {
                if (AdjacentCharCount(matrix, y, x, occupied) == 0)
                {
                    output[y][x] = occupied;
                    wasAltered = true;
                }
            }
            if (matrix[y][x] == occupied)
            {
                if (AdjacentCharCount(matrix, y, x, occupied) >= (4+step))
                {
                    output[y][x] = empty;
                    wasAltered = true;
                }
            }
        }
    }
    return new Tuple<bool, List<List<char>>>(wasAltered, output);
}

int OccupiedCount(List<List<char>> npt)
{
    char occupied = '#';
    int count = 0;

    foreach (var row in npt)
    {
        foreach (char seat in row)
        {
            if (seat == occupied)
            {
                count = count + 1;
            }
        }
    }
    return count;
}


int AdjacentCharCount(List<List<char>> inpt, int y, int x, char h)
{
    int rowLength = inpt[0].Count;
    int columnLength = inpt.Count;
    int hasAdjancent = 0;

    //Part 2
    char floor = '.';
    int up = 1;
    int left = 1;
    int down = 1;
    int right = 1;
    int upleft = 1;
    int upright = 1;
    int downleft = 1;
    int downright = 1;

    if (y > 0)
    {
        //[y-1][x] up
        while(inpt[y - up][x] == floor && (y - up) > 0 && step > 0){
            up++;
        }
        if (inpt[y - up][x] == h)
        {
            hasAdjancent++;
        }
    }
    if (x > 0)
    {
        // [y][x-1] left
        while(inpt[y][x - left] == floor && x - left > 0 && step > 0){
            left++;
        }
        if (inpt[y][x - left] == h)
        {
            hasAdjancent++;
        }
        if (y > 0)
        {
            //[y-1][x-1] up-left
            while(inpt[y - upleft][x - upleft] == floor && x - upleft > 0 && y - upleft > 0 && step > 0){
                upleft++;
            }
            if (inpt[y - upleft][x - upleft] == h)
            {
                hasAdjancent++;
            }
        }
        if (y < columnLength - 1)
        {
            //[y+1][x-1] down-left
            while(inpt[y + downleft][x - downleft] == floor && y + downleft < columnLength -1 && x - downleft > 0 && step > 0){
                downleft++;
            }
            if (inpt[y + downleft][x - downleft] == h)
            {
                hasAdjancent++;
            }

        }
    }
    if (y < columnLength - 1)
    {
        //[y+1][x] down
        while(inpt[y + down][x] == floor && y + down < columnLength - 1 && step > 0){
            down++;
        }
        if (inpt[y + down][x] == h)
        {
            hasAdjancent++;
        }
    }
    if (x < rowLength - 1)
    {
        //[y][x+1] right
        while(inpt[y][x + right] == floor && x + right < rowLength - 1 && step > 0){
            right++;
        }
        if (inpt[y][x + right] == h)
        {
            hasAdjancent++;
        }

        if (y > 0)
        {
            //[y-1][x+1] up-right
            while(inpt[y - upright][x + upright] == floor && x + upright < rowLength - 1 && y - upright > 0 && step > 0){
                upright++;
            }
            if (inpt[y - upright][x + upright] == h)
            {
                hasAdjancent++;
            }
        }
        if (y < columnLength - 1)
        {
            //[y+1][x+1] down-right
            while(inpt[y + downright][x + downright] == floor && y + downright < columnLength - 1 && x + downright < rowLength -1 && step > 0){
                downright++;
            }
            if (inpt[y + downright][x + downright] == h)
            {
                hasAdjancent++;
            }
        }
    }
    return hasAdjancent;
}