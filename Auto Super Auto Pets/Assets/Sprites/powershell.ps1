Get-ChildItem -Filter *.svg | % {
    $src = $_.FullName
    $dst = $_.BaseName + ".png"
    inkscape "$src" --export-filename="$dst" -w 128 -h 128
}
Write-Host "done !"