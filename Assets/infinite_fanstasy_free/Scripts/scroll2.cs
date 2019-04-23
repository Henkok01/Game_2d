using UnityEngine;
using System.Collections;

public class scroll2 : MonoBehaviour {
	RectTransform rTrans;
	private float right_scroll = -0.08f;
	float left_scroll = 0.08f;
	float scroll_final;

	float x;
	void Start () {

		rTrans = (RectTransform) transform.GetComponent<RectTransform>();

	}
	
	// Update is called once per frame
	void Update () {


			if (x >= 1250.0f){
				scroll_final = right_scroll;
			}
			if (x <= 0.0f){
				scroll_final = left_scroll;
			}

		Vector3 temp = new Vector3(scroll_final,0,0);
		rTrans.transform.position += temp;
		x = rTrans.transform.position.x;
		//Debug.Log ("Position x is " + x );

	}
}
