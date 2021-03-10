<?php
//Set up
$server = "Proj-mysql.uopnet.plymouth.ac.uk";
$server_username = "COMP2003_D";
$server_password = "VitW270*";

$con = mysqli_connect($server, $server_username, $server_password);

if($con === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
?>