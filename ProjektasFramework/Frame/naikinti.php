
<?php
		     $db=mysqli_connect("localhost", "root", "", "frame");
			  $ID=$_GET['ID'];
			  echo $ID;
			  $sql = "DELETE FROM tvarkarastis WHERE ID='".$ID."'";
			   mysqli_query($db, $sql);
			  $sql="delete from valandos where Masinos_id='".$ID."'";
			   mysqli_query($db, $sql);
			  header("refresh:0.000000000001 url=index.php");

?> 