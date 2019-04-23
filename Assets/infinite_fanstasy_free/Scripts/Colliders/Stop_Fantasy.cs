using UnityEngine;
using System.Collections;

public class Stop_Fantasy : MonoBehaviour {

	public infinite_fantasy_free infinite_fantasy_script;
	
	void OnTriggerEnter(Collider other) {
		
		infinite_fantasy_script.Stop_onClick ();
		
		
		
	}
	
	void OnTriggerStay(Collider other) {
		
		
		
	}
	
	void OnTriggerExit(Collider other) {
		
		
		
	}
	
}