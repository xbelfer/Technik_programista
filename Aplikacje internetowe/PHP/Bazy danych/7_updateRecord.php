<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
        $server = "localhost";  
        $user = "3pto";
        $pwd = "qwerty";
        $db = "hurtownia";
        $con = mysqli_connect($server, $user, $pwd, $db);
        if(!$con)
        {
            die("Błąd połączenia z bazą ".mysqli_connect_error());
        }
        $sql = "UPDATE Pracownicy SET PlacaPracownika = PlacaPracownika * 1.1 WHERE IDpracownika = 4;";
        if( mysqli_query($con , $sql))
        {
            echo "<br>Zmienionono rekord";
        }
        else
        {
            echo "error: ".mysqli_error($con);
        }
    ?>
</body>
</html>