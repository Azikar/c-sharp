 
 <style>
 .center {
    margin: auto;
    width: 20%;
    border: 4px solid green;
    padding: 10px;
}
 </style>
 
 

 <br><center><font size="7">Tvarkaraščių lentelė</font></center><br>

<table class="center" border="1" cellspacing="0" cellpadding="3">

 <tr><td><b>ID</b></td><td><b>Atvykimo Laikas</b></td><td><b>Laiko_pabaiga</b></td><td><b>numeriai</b></td></tr>
<?php
		     $db=mysqli_connect("localhost", "root", "", "frame");
            $sql = "SELECT * FROM `tvarkarastis` join valandos on tvarkarastis.id=valandos.Masinos_id ";
			$result = mysqli_query($db, $sql);
			if (!$result || (mysqli_num_rows($result) < 1))  
			{//echo "Klaida skaitant lentelę users";
		}
		
		        while($row = mysqli_fetch_assoc($result)) 
	{	 
          echo "<tr>";
          echo "<td>" . $row['ID'] . "</td>";
          echo "<td>" . $row['laiko_pradzia'] . "</td>";
		  echo "<td>" . $row['laiko_pabaiga'] . "</td>";
          echo "<td>" . $row['Numeris'] . "</td>";
		  echo "<td><a href='naikinti.php?ID=".$row['ID']."'>Naikinti</a> </td>";
          echo "</tr>";      		
	}
?> 

</table>


    <br><center><font size="6" >Prideti automobili</font>
    <form method="post" name="input" class="center">        
    <p>Laikas atvykimo:</p>
    <input name="atvyk" type="time" required /></br>
	<p>Laikas išvykimo:</p>
    <input name="išvyk" type="time"required /></br>
	<p> Numeris:</p>
    <input name="nr" type="text"required /></br>
    <input type="submit" name="submit_1" formaction="insert.php" value="Prideti" /><br></center>
	</form>