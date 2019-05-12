# UnityDeploymentBaseOnDatabase
Mainly talk about how to connect a database when using unity build WebGL platform<br>
<br>
<h3>Description:</h3><br>
&nbsp&nbsp1.Main Point: When we transfer unity project into a WebGL platform, WebGL could not directly connect with database.<br>
&nbsp&nbsp2.Therefore, we have to use php as a bridge to connect them.<br>
&nbsp&nbsp3.When WebGL access the database, php file and WebGL have to upload on the server.<br>
<br>
<h3>Condition:</h3><br>
&nbsp&nbsp1.Install XAMPP to run a server locally. Install Apache. <br>
&nbsp&nbsp2.Configure php version and database.dll, match them to achieve that using php file access the database information.<br>
&nbsp&nbsp3.Write Code in php file(aa.php) and run it within the Apache server to test it whether could show sql result on the html page.<br>
&nbsp&nbsp4.Write C# Script(ObjProp.cs) in the Unity Script and run it.<br>

Vedio url:https://www.youtube.com/watch?v=b4zh4xl4vLc
