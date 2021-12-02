int lowest = 272091;
int highest = 815432;

for(int i = lowest; i<=highest; i++){
    if(increases(i);
}

public bool increases(int value){
    var individualValues = value.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
    
    for(int i = 0; i < individualValues.Count; i++){
        if(individualValues.Skip(i).Any(x => x < individualValues[i]))
        return true;
    }
    return false;
}