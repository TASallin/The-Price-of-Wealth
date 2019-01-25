using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelButton : MonoBehaviour {
    
	public GameObject map;
	public GameObject spotlight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick () {
		Areas.location = Map.selectedLocation;
		spotlight.GetComponent<AreaSpotlight>().SetLocation(Map.selectedLocation);
		if (Map.selectedLocation == Map.currentPosition) {
			spotlight.GetComponent<AreaSpotlight>().Display();
		} else {
			Map.currentPosition = Map.selectedLocation;
			map.transform.Find("Current Location").gameObject.GetComponent<Text>().text = "Current location: " + Map.currentPosition;
			gameObject.GetComponent<OverworldEncounters>().Battle();
			//spotlight.GetComponent<AreaSpotlight>().Display();
		}
	}
}
