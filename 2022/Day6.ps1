#[char[]] $data = get-content(".\Day6_sample.txt");
[char[]] $data = get-content(".\Day6_input.txt");
$index = 0;
$buffer = "";
$buffersize = 14;
foreach($char in $data){
    if($index -gt ($buffersize - 2)){
        $buffer = $data[($index - ($buffersize - 1))..$index]
        $uniques = [System.Collections.Generic.HashSet[string]]$buffer;

        if($buffer.Length -eq $uniques.Count){
            write-host(($index + 1));
            return;
        }
    }

    $index++;
}