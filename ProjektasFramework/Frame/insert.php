<?php

$sql=mysqli_connect("localhost", "root", "", "frame");


//$name = $_POST['namee'];
$nr = $_POST['nr'];

$query = "INSERT INTO tvarkarastis (Numeris)VALUES('".$nr."')";
mysqli_query($sql,$query);
$conversatio_id=mysqli_insert_id($sql);
$a=date('H:i:s',strtotime($_POST['atvyk']));
$b=date('H:i:s',strtotime($_POST['išvyk']));

$query = "INSERT INTO valandos (laiko_pradzia, laiko_pabaiga,Masinos_id)VALUES('".$a."','".$b."',".$conversatio_id.")";
mysqli_query($sql,$query);
echo $query;
header("refresh:0.000000000001 url=index.php");


?> 
