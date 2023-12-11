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
            $im = "";
            $nz = "";
            $mt = "";
            $tel = "";
            $pl = "";
            $id = 0;

            $server = "localhost";  
            $user = "3pto";
            $pwd = "qwerty";
            $db = "hurtownia";
            $con = mysqli_connect($server, $user, $pwd, $db);
            if(!$con)
            {
                die("Błąd połączenia z bazą ".mysqli_connect_error());
            }
            //Update record
            if(isset($_POST["add"]))
            {
    
                $id = htmlspecialchars($_POST["id"]);
                $imie = htmlspecialchars($_POST["imie"]);
                $nazwisko = htmlspecialchars($_POST["nz"]);
                $miasto = htmlspecialchars($_POST["miasto"]);
                $telefon = htmlspecialchars($_POST["telefon"]);
                $placa = htmlspecialchars($_POST["placa"]);
    
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
                    //echo "<br>Zmienionono rekord";
                }
                else
                {
                    echo "error: ".mysqli_error($con);
                }
            }
            //Generate data for form
            if($_POST)
            {
                $id = htmlspecialchars($_POST["id"]);
                $sql = "SELECT * FROM Pracownicy WHERE IDpracownika = $id";
                $ret = mysqli_query($con, $sql);
                if(mysqli_num_rows($ret)>0)
                {
                    $row = mysqli_fetch_assoc($ret);
                    $im = $row["ImiePracownika"];
                    $nz = $row["NazwiskoPracownika"];
                    $mt = $row["MiastoPracownika"];
                    $tel = $row["TelefonPracownika"];
                    $pl = $row["PlacaPracownika"];
                }
            }
            //Generate Option
            $sql = "SELECT * FROM Pracownicy";
            $ret = mysqli_query($con, $sql);
            $options ="<option value = 0>Wybierz pracownika</option>";
            if(mysqli_num_rows($ret)>0)
            {
                while($row = mysqli_fetch_assoc($ret))
                {
                    if($id == $row["IDpracownika"])
                    {
                        $options .="<option value =".$row["IDpracownika"]." selected>"
                        .$row["NazwiskoPracownika"]."  ".$row["ImiePracownika"]
                        ."</option>";
                    }
                    else
                    {
                        $options .="<option value =".$row["IDpracownika"].">"
                                .$row["NazwiskoPracownika"]."  ".$row["ImiePracownika"]
                                ."</option>";
                    }
                }
            }
            mysqli_close($con);
        ?>
        <form action="index.php" method = "POST" name = "form1">
            <p>Id: <SELECT name = "id" onchange = "getDataFromWorker()">
                        <?php echo $options ?>
                   </SELECT>
            </p>
            <p>Imie: <input type = "text" name = "imie" value = <?php echo $im  ?> ></p>
            <p>Nazwisko: <input type = "text" name = "nz" value = <?php echo $nz  ?>></p>
            <p>Miasto: <input type = "text" name = "miasto" value = <?php echo $mt ?>></p>
            <p>Telefon: <input type = "number" name = "telefon" value = <?php echo $tel  ?>></p>
            <p>Płaca: <input type = "number" name = "placa" value = <?php echo $pl  ?>></p>
            <input type = "submit" value ="Zmień rekord" name="add">
        </form>
        <script>
            function getDataFromWorker()
            {
                document.forms["form1"].submit();
            }
        </script>
</body>
</html>