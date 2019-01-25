using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportSpecialButton : MonoBehaviour {
	public Special special;
	public int index;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}	
	
	void OnEnable () {
		if (Party.members[index] != null) {
		    Special current = Party.members[index].GetSupportSpecial();
		    gameObject.GetComponentInChildren<Text>().text = current.GetName();
	    	special = current;
    		if (Party.GetSP() < current.GetCost() || !Party.members[index].GetAlive() || Party.members[index].status.stunned > 0 
			    || Party.members[index].status.asleep > 0) {
			    gameObject.GetComponent<Button>().interactable = false;
		    } else {
	    		gameObject.GetComponent<Button>().interactable = true;
    		}
		} else {
			gameObject.GetComponent<Button>().interactable = false;
			gameObject.GetComponentInChildren<Text>().text = "Slot empty";
		}
	}
	
	public void OnClick () {
		gameObject.transform.parent.parent.GetComponent<Battle>().SupportSpecial(special, index);
	}
	
	public void Description () {
		if (special != null) {
		    gameObject.transform.parent.Find("Description").gameObject.GetComponent<Text>().text =
    			Party.members[index].ToString() + " - " + special.ToString();
		}
	}
	
	public void Hide () {
		gameObject.transform.parent.Find("Description").gameObject.GetComponent<Text>().text = "";
	}
}