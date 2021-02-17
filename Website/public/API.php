<html>
<head>
    <style>
        table, th, td {
            border: 1px solid black;
        }
    </style>
</head>
<body>

<?php
    $server = "Proj-mysql.uopnet.plymouth.ac.uk";
    $username = "COMP2003_D";
    $password = "VitW270*";
    $con = mysqli_connect($server, $username, $password);
    $response = array();

    if ($con->connect_error) {
        die("Connection failed: " . $con->connect_error);
    }

    echo ("Connection ok". "<br>");
    $query = "SELECT * FROM comp2003_d.viewstats;";
    $result = $con->query($query);

    if ($result->num_rows > 0) {
        echo "    <div class='container'>
                            <table class='table table-bordered table-dark table-hover table-sm'>
                            <tr>
                                <th>User ID</th>
                                <th>User Name</th>
                                <th>High Score</th>
                                <th>Kills</th>
                                <th>Time</th>
                                <th>Balls Fired</th>
                                <th>Chest Collected</th>
                                
                            </tr>
                        ";

        while ($row = $result->fetch_assoc()) {
            echo"   <tr>
                                <td>" . $row["userID"] . "</td>
                                <td>" . $row["Username"] . "</td>
                                <td>" . $row["High Score"] . "</td>
                                <td>" . $row["username"] . "</td>
                                <td>" . $row["email"] . "</td>
                                <td>" . $row["password"] . "</td>
                            </tr>";
        }
    }
    else {
        echo "0 results";
    }
?>
