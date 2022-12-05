#$data = get-content(".\Day1_sample.txt");
$data = get-content(".\Day1_input.txt");
$sums = @();
$sum = 0;

foreach ($el in $data) {
    if(![string]::IsNullOrEmpty($el)){ $sum += $el } 
    else{ $sums += $sum; $sum = 0;}
} 

$result = $sums | sort-object -Descending;
Write-Host($result[0]+$result[1]+$result[2]);