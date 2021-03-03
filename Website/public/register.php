<?php
//Set up
$server = "Proj-mysql.uopnet.plymouth.ac.uk";
$server_username = "COMP2003_D";
$server_password = "VitW270*";

$con = mysqli_connect($server, $server_username, $server_password);

if($con === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}

// Define variables and initialize with empty values
$email = "";
$password = "";
$confirm_password = "";
$email_err = "";
$password_err = "";
$confirm_password_err = "";


// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
    // Validate email
    if(empty(trim($_POST["email"]))){
        $email_err = "Please enter your email.";
        echo (" enter a email ");
    }
    else{
        echo (" has email ");
        if($stmt = mysqli_prepare($con, "SELECT userID FROM comp2003_d.usertbl WHERE email = ?;")){
            echo (" connected ");
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "s", $checkEmail);

            // Set parameters
            $checkEmail = trim($_POST["email"]);

            // Attempt to execute the prepared statements
            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);

                if(mysqli_stmt_num_rows($stmt) > 0){
                    echo ("email taken ");
                    $email_err = "This email is already taken.";
                } else{
                    echo ("email not taken ");
                    $email = trim($_POST["email"]);
                }
            } else{
                echo "Oops! Something went wrong. Please try again later.";
            }
            mysqli_stmt_close($stmt);
        }
        echo (" hasnt connected ");
    }


    // Validate password
    if(empty(trim($_POST["password"]))){
        $password_err = "Please enter a password.";
    } elseif(strlen(trim($_POST["password"])) < 6){
        $password_err = "Password must have atleast 6 characters.";
    } else{
        $password = trim($_POST["password"]);
    }

    // Validate confirm password
    if(empty(trim($_POST["confirm_password"]))){
        $confirm_password_err = "Please confirm password.";
    } else{
        $confirm_password = trim($_POST["confirm_password"]);
        if(empty($password_err) && ($password != $confirm_password)){
            $confirm_password_err = "Password did not match.";
        }
    }

    // Check input errors before inserting in database
    if(empty($email_err) && empty($password_err) && empty($confirm_password_err)){
        if($stmt = mysqli_prepare($con, "INSERT INTO comp2003_d.usertbl (firstName, lastName, username, email, password) VALUES (?,?,?,?,?);")){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "sssss", $tempFirstName, $tempLastName, $tempUsername, $emailInput, $passwordInput);

            // Set parameters
            $tempFirstName = "setfirstname";
            $tempLastName = "setlastname";
            $tempUsername = "setusername";
            $emailInput = $email;
            $passwordInput = $password;

//             Attempt to execute the prepared statement
            if(mysqli_stmt_execute($stmt)){
                echo("done");
            } else{
                echo "Something went wrong. Please try again later.";
            }

            // Close statement
            mysqli_stmt_close($stmt);
        }
    }

//     Close connection
    mysqli_close($con);
}
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Sign Up</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.css">
        <style type="text/css">
            body{ font: 14px sans-serif; }
            .wrapper{ width: 350px; padding: 20px; }
        </style>
    </head>

    <body>
        <div class="wrapper">
            <h2>Sign Up</h2>
            <p>Please fill this form to create an account.</p>

            <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">

                <div class="form-group
                    <?php echo (!empty($email_err)) ? 'has-error' : ''; ?>">
                    <label>Email</label>
<!--                    --><?php //echo $email; ?>
                    <input type="text" name="email" class="form-control" value="">

                    <span class="help-block">
                        <?php echo $email_err; ?>
                    </span>
                </div>

                <div class="form-group
                    <?php echo (!empty($password_err)) ? 'has-error' : ''; ?>">
                    <label>Password</label>

                    <input type="password" name="password" class="form-control" value="<?php echo $password; ?>">

                    <span class="help-block">
                        <?php echo $password_err; ?>
                    </span>
                </div>

                <div class="form-group
                    <?php echo (!empty($confirm_password_err)) ? 'has-error' : ''; ?>">
                    <label>Confirm Password</label>

                    <input type="password" name="confirm_password" class="form-control" value="<?php echo $confirm_password; ?>">

                    <span class="help-block">
                        <?php echo $confirm_password_err; ?>
                    </span>
                </div>

                <div class="form-group">
                    <input name="submitBtn "type="submit" class="btn btn-primary" value="Submit">
                    <input type="reset" class="btn btn-default" value="Reset">
                </div>

                <p>Already have an account? <a href="login.php">Login here</a>.</p>

            </form>
        </div>
    </body>
</html>