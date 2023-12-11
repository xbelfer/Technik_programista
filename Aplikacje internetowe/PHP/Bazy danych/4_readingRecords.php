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
        if(mysqli_num_rows($ret)>0){
            $cnt=1;
            // każdy wiersz jest tablicą o indeksach całkowity począwszy od 0
            // indeksy odpowiadają kolejności występowania kolumn w tabeli jeżeli pytanie z *
            // lub kolejności wymienionych kolumn w zapytaniu po SELECT
            while($row = mysqli_fetch_row($ret)) 
            {
                echo "<br>Klient: ".$cnt++;
                echo "<br> Imie: ".$row[1]."<br>Nazwisko: ".$row[2]."<br>Miasto: ".$row[5];
                echo "<br>";
            }
        }
    ?>
</body>
</html>