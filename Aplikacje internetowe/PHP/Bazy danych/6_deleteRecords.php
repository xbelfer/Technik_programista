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
        if(isset($_POST["del"]))
        {
            echo "<br> Rozpoczęcie delete o id=".$_POST["id"];
            $sql = "DELETE FROM Klienci WHERE IDKlienta= ".$_POST["id"];
            
            $ret = mysqli_query($con, $sql);
            if($ret == false)
            {
                echo "Error:".mysqli_error($con);
            }
        }
        $sql = "SELECT ImieKlienta, NazwiskoKlienta, MiastoKlienta, IDKlienta FROM Klienci;";
        
        $ret = mysqli_query($con, $sql);
        if(mysqli_num_rows($ret)>0){
            $tab = "<table border='1'>";
            $tab .= "<tr>";
            $tab .= "<th>Imię</th>";
            $tab .= "<th>Nazwisko</th>";
            $tab .= "<th>Miasto</th>";
            $tab .= "<th>Usuń</th>";
            $tab .= "</tr>";
            while($row = mysqli_fetch_row($ret)) 
            {
                $tab .="<tr>";
                $tab .="<td>".$row[0]."</td>";
                $tab .="<td>".$row[1]."</td>";
                $tab .="<td>".$row[2]."</td>";
                $tab .= "<td><form action ='index.php' method = 'POST'><input type ='hidden' name ='id' value =$row[3] > <input type = 'submit' name = 'del' value='Delete'></form></td>";
                $tab .="</tr>";
            }
            $tab .="</table>";
            echo $tab;
        }
    ?>
</body>
</html>