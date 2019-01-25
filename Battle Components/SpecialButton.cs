using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialButton : MonoBehaviour {
	public Special special;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}	
	
	void OnEnable () {
		Special current = Party.GetPlayer().GetSpecial();
		gameObject.GetComponentInChildren<Text>().text = current.GetName();
		special = current;
		if (Party.GetSP() < current.GetCost() || Party.GetPlayer().status.asleep > 0 || Party.GetPlayer().status.stunned > 0) {
			gameObject.GetComponent<Button>().interactable = false;
		} else {
			gameObject.GetComponent<Button>().interactable = true;
		}
	}
	
	public void OnClick () {
		gameObject.transform.parent.parent.GetComponent<Battle>().UseSpecial(special);
	}
	
	public void Description () {
		gameObject.transform.parent.Find("Description").gameObject.GetComponent<Text>().text = special.ToString();
	}
	
	public void Hide () {
		gameObject.transform.parent.Find("Description").gameObject.GetComponent<Text>().text = "";
	}
}