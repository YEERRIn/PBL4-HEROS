<?php
$hostname='localhost';
$username='pbl_guest';
$password='ghkdlxld1042~!';
$database='pbl4';

try{
	$dbh=new PDO('mysql:host='.$hostname.';dbname='.$database,$username,$password);
}

catch(PDOException $e)
{
	echo '<h1> An error has occured.</h1><pre>', $e->getMessage(),'</pre>';
}

$sth = $dbh->query('SELECT * FROM count_people ORDER BY _id DESC LIMIT 1');
$sth->setFetchMode(PDO::FETCH_ASSOC);

$result=$sth->fetchALL();

if(count($result)>0)
{
	foreach($result as $r)
	{
		echo $r['COUNT'];
	}
}