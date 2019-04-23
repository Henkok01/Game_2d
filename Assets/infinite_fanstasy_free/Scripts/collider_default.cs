using UnityEngine;
using System.Collections;

public class collider_default : MonoBehaviour {

	public infinite_fantasy_free infinite_fantasy_script;

	void OnTriggerEnter(Collider other) {
	
		//How to use it

		//EXAMPLE:

		//Set the "theme" to Adventure when the Player enters the Trigger zone
		//infinite_fantasy_script.Adventure_onClick ();

		//Set the "intensity" level to soft when the Player enters the Trigger zone
		//infinite_fantasy_script.Soft_onClick ();

	}
	
	void OnTriggerStay(Collider other) {

		//Set the "theme" to Adventure when the Player is inside the Trigger zone
		//infinite_fantasy_script.Adventure_onClick ();
		
		//Set the "intensity" level to medium when the Player is inside the Trigger zone
		//infinite_fantasy_script.Med_onClick ();

	}
	
	void OnTriggerExit(Collider other) {

		//Set the "theme" to Adventure when the Player leaves the Trigger zone
		//infinite_fantasy_script.Adventure_onClick ();
		
		//Set the "intensity" level to forte when the Player leaves the Trigger zone
		//infinite_fantasy_script.Forte_onClick ();

	}

}
