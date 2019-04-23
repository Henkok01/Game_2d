Infinite Fantasy FREE : SETUP GUIDE
Dear Unity Developer,
Thank you for downloading this package and supporting my work!

This Asset contains:

- A forest background loop.

- Three different moods: Ambiant, Adventure and Heroic.

- Three intensity levels: Soft, Medium and Forte.

- A unique Prefab that you can simply drag and drop into your game for easy "in game" integration.

- A demo scene to test the script and music.

How to use the Prefab:
-------------------------------------------------

All you need to do is to drag and drop the Prefab into your scene.

Then reposition, resize, rotate and duplicate/delete the triggers as necessary.
Once you have positioned them correctly, disable their mesh renderers and you are all set!

The "use triggers" public boolean (if enabled) allows you to set the music's intensity as a function of the Player's distance to a 
number of gameObjects.  Simply drag the "Player" gameobject into the "Player" cell in the script (Prefab) and a number of GameObjects in the "
"Enemy 1" through "Enemy 5" cells.  If these gameobjects are destroyed or no longer needed,you will have to reassign other gameobjects or 
triggers to those cells via script.

The "Trigger_med" public float is the distance between the gameobject and player at which the "medium" mood will start playing.  
The "soft" mood will play whenever the player is farther away than that number from any triggers you have set inside your game.
The "Trigger_forte" public float is the distance between the gameobject and player at which the "forte" mood will start playing.

Choose these values wisely!  For instance, setting the "Trigger_forte" value to a very low number will make the "forte" intensity come in too late
by the time you reach the trigger.  If you enter a very high number for the "Trigger_med", the "soft" intensity may never end up playing as you will 
always be close enough to a "medium intensity" trigger.  In the video (see my Youtube channel), I have entered a value of "40" for the Trigger_med and 20 for the Trigger_forte, which means that once the player is at a distance of between 40 and 20 to an enemy, the "medium" intensity starts playing, once he is at 20 or closer, the "forte" intensity starts playing. The changes will only happen at "natural" transition points within the music so plan changes in the mood a little ahead in your game!

The "nearest_enemy" shows you the distance of the closest "trigger".  
The fadeout float values are there if you want to tweak the parameters, but I recommend you leave these values to the ones I have set.

If you do not wish to use the automatic triggers script, disable the "use_triggers" boolean in the inspector.  You can then set the intensity either via the prefabs provided, or "manually" by calling 4 public methods inside the script:

Soft_onClick();   ==> Sets the intensity level to "soft"
Med_onClick();    ==> Sets the intensity level to "medium"
Forte_onClick();  ==> Sets the intensity level to "forte"
Stop_onClick();   ==> Stops the music

You can also set the "mood" manually by calling these public methods inside the script:

Adventure_onClick();     ==> Sets the mood to "adventure".
Heroic_onClick();        ==> Sets the mood to "heroic".
Light_Forest_onClick();  ==> Sets the mood to "ambiant".
Background_onClick();    ==> Starts/Stops the "forest" environment loop.

You can call these public methods from another script inside your game.

Example of code that you need to include inside the script that has your triggers/events in case you use the "manual" method:
-----------------------------------------------------------------------------------------------------------------------------



//creates a public variable - drag and drop the game object to which the "rock_XXX" script 
is attached into the cell created in your script.


public infinite_fantasy_free infinite_fantasy_script;
//drop the GameObject which has the "infinite_fantasy_free" script is attached to it in this box in the inspector.


public bool no_enemies;


void Update(){
	
	if (no_enemies) {
		rock_XXX.Soft_onClick();		
	}


	if (tension_starts){
		rock_XXX.Med_onClick();
	}
	if (enemy_is_close){
		rock_XXX.Forte_onClick();
	}
	if (stop_the_music){
		rock_XXX.Stop_onClick();
	}
}
// sets the booleans inside the "rock_XXX" script.

------------------------------------------------------------------------------------------------------------------------------------

I have also included a script entitled "collider_default" which can help you setup the change of "mood" via scripting.  Check out my video demo to see how it works!

If you have any trouble using the samples, let me know and I will be happy to help!

********************************************************************************************************************************************************************************************************
GENERAL REMARKS:

- DO NOT, under any circumstance, change the folder structure of the "Resources" folder.  The resources folder HAS to be located in your asset folder and the folder structure HAS to remain untouched.
  The reason is that many scrips rely on this folder structure to load the samples into arrays. Many scripts could stop working if you change the folder structure.

- Be sure to add an audio listener to your camera or the game object you attach the script on.  Apparently, this helps with the overall performance of the script.

*********************************************************************************************************************************************************************************************************

-------------------------------------------------------------------------------------------------------------------------
IMPORTANT THINGS TO REMEMBER:

- Make sure only ONE boolean is set to "true" at all times, otherwise you'll hear a mishmash of two or more tracks!
- Whenever you set a boolean to "false", the script waits until the musical phrase is over. This can take some time so be patient! :-)

-------------------------------------------------------------------------------------------------------------------------

I hope you'll be able to make use of this!
Don't forget to leave a review and suggestions/ideas for how to make this work even better!

Thanks again for your support and don't hesitate to contact me if you have any questions/suggestions! 

sincerely,

Marma

CONTACT: marma.developer@gmail.com
WEBSITE: http://marmadeveloper.wix.com/marmamusic