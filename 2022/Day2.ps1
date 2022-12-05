#[string[]]$data = get-content(".\Day2_sample.txt");
[string[]]$data = get-content(".\Day2_input.txt");

#rock A X 1, paper B Y 2 scissor C Z 3
#loss 0, draw 3, win 6
#Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.

$rock,$paper,$scissor,$loss,$draw,$win = 1,2,3,0,3,6;

first;
second;

function first{
$sum = 0;
foreach($row in $data){
$sum += (get-score -p1 $row.Substring(0,1) -p2 $row.Substring(2,1)); 
}
write-host($sum);
}

function second
{
    $sum = 0;
foreach($row in $data){
$sum += (get-score-second -p1 $row.Substring(0,1) -p2 $row.Substring(2,1)); 
}
write-host($sum);
}
function get-score($p1, $p2){
    if(($p1.Equals("A") -and $p2.Equals("X"))){
        return $draw + $rock;
    }
    if($p1.Equals("A") -and $p2.Equals("Y")){
        return $win + $paper;
    }
    if($p1.Equals("A") -and $p2.Equals("Z")){
        return $loss + $scissor;
    }
    if($p1.Equals("B") -and $p2.Equals("X")){
        return $loss + $rock;
    }
    if($p1.Equals("B") -and $p2.Equals("Y")){
        return $draw + $paper;
    }
    if($p1.Equals("B") -and $p2.Equals("Z")){
        return $win + $scissor;
    }
    if($p1.Equals("C") -and $p2.Equals("X")){
        return $win + $rock;
    }
    if($p1.Equals("C") -and $p2.Equals("Y")){
        return $loss + $paper;
    }
    if($p1.Equals("C") -and $p2.Equals("Z")){
        return $draw + $scissor;
    }
}

#X = loss, Y = draw, Z = win
function get-score-second($p1, $p2){
    if(($p1.Equals("A") -and $p2.Equals("X"))){
        return $loss + $scissor;
    }
    if($p1.Equals("A") -and $p2.Equals("Y")){
        return $draw + $rock;
    }
    if($p1.Equals("A") -and $p2.Equals("Z")){
        return $win + $paper;
    }
    if($p1.Equals("B") -and $p2.Equals("X")){
        return $loss + $rock;
    }
    if($p1.Equals("B") -and $p2.Equals("Y")){
        return $draw + $paper;
    }
    if($p1.Equals("B") -and $p2.Equals("Z")){
        return $win + $scissor;
    }
    if($p1.Equals("C") -and $p2.Equals("X")){
        return $loss + $paper;
    }
    if($p1.Equals("C") -and $p2.Equals("Y")){
        return $draw + $scissor;
    }
    if($p1.Equals("C") -and $p2.Equals("Z")){
        return $win + $rock;
    }
}