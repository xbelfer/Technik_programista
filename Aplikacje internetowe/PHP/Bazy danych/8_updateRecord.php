<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
        <form action="index.php" method = "POST">
            <p>Id: <input type = "number" name = "id"></p>
            <p>Imie: <input type = "text" name = "imie"></p>
            <p>Nazwisko: <input type = "text" name = "nz"></p>
            <p>Miasto: <input type = "text" name = "miasto"></p>
            <p>Telefon: <input type = "number" name = "telefon"></p>
            <p>Płaca: <input type = "number" name = "placa"></p>
            <input type = "submit" value ="Dodaj rekord" name="add">
        </form>
    <?php
        if(isset($_POST["add"]))
        {
            $server = "localhost";  
            $user = "3pto";
            $pwd = "qwerty";
            $db = "hurtownia";
            $con = mysqli_connect($server, $user, $pwd, $db);
            $id = htmlspecialchars($_POST["id"]);
            $imie = htmlspecialchars($_POST["imie"]);
            $nazwisko = htmlspecialchars($_POST["nz"]);
            $miasto = htmlspecialchars($_POST["miasto"]);
            $telefon = htmlspecialchars($_POST["telefon"]);
            $placa = htmlspecialchars($_POST["placa"]);
            if(!$con)
            {
                die("Błąd połączenia z bazą ".mysqli_connect_error());
            }
            $sql = "UPDATE Pracownicy 
                    SET 
                        ImiePracownika = '$imie',
                        NazwiskoPracownika = '$nazwisko',
                        MiastoPracownika = '$miasto',
                        TelefonPracownika = '$telefon',
                        PlacaPracownika = $placa
                    WHERE IDpracownika = $id;";
            if( mysqli_query($con , $sql))
            {
                echo "<br>Zmienionono rekord";
            }
            else
            {
                echo "error: ".mysqli_error($con);
            }
        }
    ?>
</body>
</html>