# jumper-assignment-VictorDeDecker
Tutorial

Jumper agent heeft een script 'JumperAgent' dat van over Agent overerft. Dit script zorgt voor de rewards en voor de agent zijn invoermethode.
Het MoveObstacle script zorgt ervoor dat de obstakels bewegen.
Het SpawnObject script spawned de obstakels in.

De agent krijgt een beloning (0.5) als het obstakel de muur achter de agent raakt. Als de agent het obstakel heeft geraakt dan krijgt de agent (-0.5) als reward. 
Als de agent sprint krijgt hij (-0.05) als reward. Dit zorgt ervoor dat de agent niet heel de tijd zal springen.
