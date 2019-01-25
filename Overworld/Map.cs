using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    public GameObject map;
	public GameObject spotlight;
	public static string selectedLocation;
	public static string currentPosition;
	// Use this for initialization
	void Start () {
		if (Areas.location == "overworld") {
			map.SetActive(true);
			spotlight.SetActive(false);
		} else {
			map.SetActive(false);
			spotlight.SetActive(true);
			spotlight.GetComponent<AreaSpotlight>().SetLocation(Areas.location);
		}
		map.transform.Find("Current Location").gameObject.GetComponent<Text>().text = "Current location: " + Map.currentPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Select (string location) {
		selectedLocation = location;
	}
}
