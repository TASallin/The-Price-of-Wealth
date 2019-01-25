using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hireling : MonoBehaviour {

    Character c;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Party.GetSP() >= 10) {
			gameObject.GetComponent<Button>().interactable = true;
		} else {
			gameObject.GetComponent<Button>().interactable = false;		
		}
	}
	
	public void SetCharacter(Character c) {
		this.c = c;
		gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = c.type;
	}
	
	public void Hire() {
		gameObject.transform.parent.parent.gameObject.GetComponent<Shop>().Hire(c);
	}
}