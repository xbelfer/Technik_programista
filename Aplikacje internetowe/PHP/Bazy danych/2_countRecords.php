<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Klienci hurtowni:</h1>
    <?php
        $server = "localhost";
        $user = "3pto";
        $pwd = "qwerty";
        $db = "hurtownia";
        $con = mysqli_connect($server, $user, $pwd, $db);
        if(!$con)
        {
            die("Błąd połącznie z bazą : ".mysqli_connect_error());
        }
        $sql = "SELECT * FROM Klienci;";
        
        $ret = mysqli_query($con, $sql);
        if(($il=mysqli_num_rows($ret))>0){
            echo "<br> Ilośc rekordów: $il";
        }
    ?>
</body>
</html>