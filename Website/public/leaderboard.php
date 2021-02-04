<?php
?>
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">
        <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/sticky-footer/">
        <link href="sticky-footer.css" rel="stylesheet">

        <title>Pirates Treasure - Leaderboard</title>

    </head>
    <style>
        .header {
            padding: 80px;
            text-align: center;
            color: white;
            background-size:100% 100%;
            background-image: url("../assets/img/Game.png");
        }
        .footer {
            position: sticky;
            bottom: 0;
            width: 100%;
            height: 60px;
            line-height: 60px;
            background-color: #343a40;
        }
    </style>

    <body>
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                        <a class="navbar-brand" href="index.php"><img src="../assets/img/pirate.png" class="d-inline-block align-top"
                                                                      width="77.5" height="56"></a>

                        <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                            <li class="nav-item">
                                <a class="nav-link" href="index.php">Home </a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="leaderboard.php">Leaderboards</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="news.php">News</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="download.php">Download</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="about_us.php">About us</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="contact_us.php">Contact us</a>
                            </li>
                        </ul>
                    </div>
            </nav>
        </div>

        <div class="header">
            <img src="../assets/img/pirate_treasure.png">
            <p>A website created by group_D</p>
        </div>

        <div class="container-fluid mt-5 px-5">
            <div class="row">
                <div class="col-sm-12">
                    <h1>Leaderboard Data</h1>
                    <p>
                        Below you can see all of the data that is displayed from csv file on the leaderboard.
                    </p>
                    <p>
                        Here you can see details about the person that has entered it into the database
                        such as their username, first and last name.
                    </p>
                    <p>
                        Also you are able see the scores that they have achieved with information
                        about their time survived, their high score and the amount of coins they have collected.
                    </p>
                </div>
            </div>
        </div>

        <?php
        echo
        "   <div class='container'>
                    <table class='table table-bordered table-dark table-hover table-sm'>\n\n
                </div";

        $f = fopen("../Assets/data/data.csv", "r");
        while (($line = fgetcsv($f)) !== false) {
            echo "<tr>";
            foreach ($line as $cell) {
                echo "<td>" . htmlspecialchars($cell) . "</td>";
            }
            echo "</tr>\n";
        }
        fclose($f);
        echo "
                </table>";
        ?>
        </div>


        <footer class="footer">
                <div class="container">
                        <span class="text-muted">
                            Created by COMP2003 Group_D. Link to Github:
                            <a href="https://github.com/BRANDONHARRY/COMP2003_pirate_D">https://github.com/BRANDONHARRY/COMP2003_pirate_D</a>
                        </span>
                </div>
        </footer>
    </body>
</html>