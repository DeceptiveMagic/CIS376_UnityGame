This is a game created in Unity for CIS376 with Professor Ira Woodring
Groupmates: Gabe Kucinich, Trevor Martin, Jayson Willey

The game is currently in the middle development stages.

Description:
	A 3D FPS-type game based on Baloons Tower Defense 1. The
	player will control a monkey character who can move about
	a map, popping balloons with darts. The balloons will move 
	across a set path, coming in predetermined waves. Balloons
	will have differing amounts of health, and differing movement
	speeds. By popping the balloons the player gains money which 
	may be spent on upgrades (attack speed, popping power) and 
	evolutions (change from original dart monkey to a more 
	powerful attack pattern).
	The player wins if they surpass all rounds (by popping all 
	balloons) with lives remaing. The player loses if a balloon 
	reaches the end of the stage, reducing the player lives to 0.

Balloon Behaviour:
	Red - 1 hp, 1 speed. Standard movement.
	Blue - 2 hp, 2 speed. Standard movement.
	Green - 3 hp, 3 speed. Standard movement.
	Yellow - 4 hp, 4 speed. Standard movement.
	Pink - 5 hp, 5 speed. Standard movement.
	Purple - 1 hp, 3 speed. AI fleeing movement.

TODO:
	Update lives according to a balloon passing the last waypoint
	Update money according to a balloon being popped
	Update rounds text according to round number
	Create purple balloon controller with AI to run from the player
	Create balloon spawner and rounds (may require premade list of points)
	(Optional) Upgrades:
		Attack speed
		Popping power
		Projectile speed + range
	(Optional) Evolutions

Asset Links:
	Monkey: https://assetstore.unity.com/packages/3d/characters/mr-mo-character-57859
	Dart: Blender made (Done, with material)
	Balloon: Blender made (Done, no material)
