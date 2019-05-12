# UnityDeploymentBaseOnDatabase
Mainly talk about how to connect a database when using unity build WebGL platform<br>
<br>
Description:
------------
1.Main Point: When we transfer unity project into a WebGL platform, WebGL could not directly connect with database.<br>
2.Therefore, we have to use php as a bridge to connect them.<br>
3.When WebGL access the database, php file and WebGL have to upload on the server.<br>
php connection senctence for Sql server:<br>
```
$id=$_GET["elementid"];
$serverName = "192.168.1.110"; //serverName\instanceName
// Since UID and PWD are not specified in the $connectionInfo array,
// The connection will be attempted using Windows Authentication.
$connectionInfo = array( "Database"=>"RAC_BASIC_SAMPLE_PROJECT_2019_02_15","UID"=>"sa","PWD"=>"Asbuiltdatabase123");
$conn = sqlsrv_connect( $serverName, $connectionInfo);
```
sql select sentence:
```
$sql = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='RAC_BASIC_SAMPLE_PROJECT';";
$stmt = sqlsrv_query($conn, $sql );
if( $stmt === false) {
   die( print_r( sqlsrv_errors(), true) );
}
while( $row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_NUMERIC) )
{
	//echo $row[0];
    $sqll= "SELECT *  FROM "."[RAC_BASIC_SAMPLE_PROJECT]."."[".$row[0]."]"." where ElementId=".$id; 
    $stmt1 = sqlsrv_query($conn, $sqll);
    if( $stmt1 === false) {
       continue;
    }
    else{ 
    while( $row1 = sqlsrv_fetch_array($stmt1, SQLSRV_FETCH_ASSOC) )
    	 //$sql2 = "select name from syscolumns where id = object_id('Doors')
{   foreach ($row1 as $column=>$value) 
    { 
     echo 
     $column.": " .$value."|"; 
    } 
} 
```

[Vedio] https://www.youtube.com/watch?v=b4zh4xl4vLc
