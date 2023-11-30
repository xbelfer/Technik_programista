<?php
    $servername = "localhost";
    $username = "3pto";
    $password = "qwerty";
    // Create connection
    $conn = mysqli_connect($servername, $username, $password);
    // Check connection
    if (!$conn) {
        die("Connection failed: " . mysqli_connect_error());
    }
    echo "Connected successfully";
    // Create database
    $sql = "CREATE DATABASE IF NOT EXISTS myDB";

    if (mysqli_query($conn, $sql)) {
    echo "<br>Database created successfully";
    } else {
    echo "<br>Error creating database: " . mysqli_error($conn);
    }
    $sql = "USE myDB";
    if(mysqli_query($conn, $sql)){
        echo "<br>Connect to DB";
    }
    else
    {
        echo "<br>Error conecting to db: " . mysqli_error($conn);
    }
    $sql = "CREATE TABLE IF NOT EXISTS GUEST(
        id int AUTO_INCREMENT PRIMARY KEY,
        firstName varchar(30) NOT NULL,
        lastName varchar(30) NOT NULL,
        phoneNumber varchar(12) DEFAULT '000000000',
        pesel varchar(11) UNIQUE,
        age int CHECK(age>=18)
    );";
    if(mysqli_query($conn, $sql)){
        echo "<br>Table created";
    }
    else
    {
        echo "<br>Error creating table: " . mysqli_error($conn);
    }
    $sql = "INSERT INTO GUEST VALUES(NULL,'Jan','Nowak','123456789','12345678912',22)";
    if(mysqli_query($conn, $sql)){
        echo "<br>Data to table added";
    }
    else
    {
        echo "<br>Error add data: " . mysqli_error($conn);
    }
    mysqli_close($conn);
?>