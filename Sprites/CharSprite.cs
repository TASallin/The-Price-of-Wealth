using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSprite : MonoBehaviour {
    
	public Vector3 moveTo;
	public int defaultX;
	public int defaultY;
	
	// Use this for initialization
	void Start () {
		gameObject.transform.localPosition = new Vector3(defaultX, defaultY, 1);
		moveTo = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveTo != gameObject.transform.localPosition) {
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 
			    System.Math.Max(System.Math.Min(5, moveTo.x - gameObject.transform.localPosition.x), -5),
				gameObject.transform.localPosition.y + System.Math.Max(System.Math.Min(5, moveTo.y - gameObject.transform.localPosition.y), -5),
				gameObject.transform.localPosition.z + System.Math.Max(System.Math.Min(5, moveTo.z - gameObject.transform.localPosition.z), -5));
			//gameObject.transform.localPosition.x = gameObject.transform.localPosition.x + 
			  //  System.Math.Max(System.Math.Min(5, moveTo.x - gameObject.transform.localPosition.x), -5);
			//gameObject.transform.localPosition.y = gameObject.transform.localPosition.y + 
	    		//System.Math.Max(System.Math.Min(5, moveTo.y - gameObject.transform.localPosition.y), -5);
			//gameObject.transform.localPosition.z = gameObject.transform.localPosition.z + 
			  //  System.Math.Max(System.Math.Min(5, moveTo.z - gameObject.transform.localPosition.z), -5);
		}
	}
}
