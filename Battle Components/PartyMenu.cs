using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour {
    public Button char1;
	public Button char2;
	public Button char3;
	public Button char4;
	public Button enem1;
	public Button enem2;
	public Button enem3;
	public Button enem4;
	public Text status;
	public Button swap;
	public Button cancel;
	public Button special;
	public Button kick;
	public Button StandardS;
	public Button SupportS;
	public int active;
	public Item item;
	public Special currentSpecial;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnEnable () {
		if (Party.GetCharacter(0) != null) {
	        char1.GetComponentInChildren<Text>().text = Party.GetCharacter(0).GetName();
			char1.interactable = true;
		} else {
		    char1.interactable = false;	
		}
		if (Party.GetCharacter(1) != null) {
	        char2.GetComponentInChildren<Text>().text = Party.GetCharacter(1).GetName();
			char2.interactable = true;
		} else {
		    char2.interactable = false;	
		}
		if (Party.GetCharacter(2) != null) {
	        char3.GetComponentInChildren<Text>().text = Party.GetCharacter(2).GetName();
			char3.interactable = true;
		} else {
		    char3.interactable = false;	
		}
		if (Party.GetCharacter(3) != null) {
	        char4.GetComponentInChildren<Text>().text = Party.GetCharacter(3).GetName();
			char4.interactable = true;
		} else {
		    char4.interactable = false;	
		}
		if (Party.GetEnemy(0) != null) {
	        enem1.GetComponentInChildren<Text>().text = Party.GetEnemy(0).type;
			enem1.interactable = true;
		} else {
		    enem1.interactable = false;	
		}
		if (Party.GetEnemy(1) != null) {
	        enem2.GetComponentInChildren<Text>().text = Party.GetEnemy(1).type;
			enem2.interactable = true;
		} else {
		    enem2.interactable = false;	
		}
		if (Party.GetEnemy(2) != null) {
	        enem3.GetComponentInChildren<Text>().text = Party.GetEnemy(2).type;
			enem3.interactable = true;
		} else {
		    enem3.interactable = false;	
		}
		if (Party.GetEnemy(3) != null) {
	        enem4.GetComponentInChildren<Text>().text = Party.GetEnemy(3).type;
			enem4.interactable = true;
		} else {
		    enem4.interactable = false;	
		}
		SetActive(Party.GetActive());
	}
	
	void OnDisable() {SetActive(1);}
	
	public Character GetActive () {
		return Party.GetCharacter(active - 1);
	}
	
	public void SetActive(int i) {
		active = i;
		if (i < 5) {
		    status.text = Party.GetCharacter(i - 1).StatusText();
		} else {
			status.text = Party.GetEnemy(i - 5).StatusE();
		}
		if (i < 5 && (Party.members[i - 1].GetSpecial().usableOut || Party.members[i - 1].GetSupportSpecial().usableOut) && 
		    Party.GetSP() >= Party.members[i-1].GetSpecial().GetCost()) {
			special.interactable = true;
		} else {
			special.interactable = false;
		}
		if (i == 1) {
		    kick.interactable = false;
		} else {
			kick.interactable = true;
		}
		if (item == null && currentSpecial == null) {
		    if (i == Party.playerSlot || i >= 5) {
	    		swap.interactable = false;
    		} else {
			    if (Party.GetCharacter(i-1).GetAlive()) {	
		    	    swap.interactable = true;
	    		} else {
    				swap.interactable = false;
			    }
		    }
		} else {
			swap.interactable = true;
		}
	}
	
	public void Change () {
		Party.playerSlot = active;
	}
	
	public void UseItem () {
		item.UseOutOfCombat(active-1);
	}
	
	public int ConfirmCharacter () {
		return active - 1;
	}
	
	public void Replace () {
		Party.fullRecruit.SetPlayer(true);
		Party.members[active - 1] = Party.fullRecruit;
		Party.latestRecruit = Party.fullRecruit;
		Party.fullRecruit = null;
	}
	
	public void Kick () {
		Party.members[active - 1] = null;
	}
	
	public void Special () {
	    if (Party.members[active - 1].GetSpecial().usableOut && !Party.members[active - 1].GetSupportSpecial().usableOut) {
		    Party.members[active - 1].GetSpecial().UseOutOfCombat();
			CloseParty();
		} else if (!Party.members[active - 1].GetSpecial().usableOut && Party.members[active - 1].GetSupportSpecial().usableOut) {
			Party.members[active - 1].GetSupportSpecial().UseOutOfCombat();
			CloseParty();
		} else {
			StandardS.gameObject.SetActive(true);
			SupportS.gameObject.SetActive(true);
			StandardS.GetComponentInChildren<Text>().text = Party.members[active - 1].GetSpecial().GetName();
			SupportS.GetComponentInChildren<Text>().text = Party.members[active - 1].GetSupportSpecial().GetName();
		}
	}
	
	public void StandardSpecial () {
		Party.members[active - 1].GetSpecial().UseOutOfCombat();
		StandardS.gameObject.SetActive(false);
		SupportS.gameObject.SetActive(false);
		CloseParty();
	}
	
	public void SupportSpecial() {
		Party.members[active - 1].GetSupportSpecial().UseOutOfCombat();
		StandardS.gameObject.SetActive(false);
		SupportS.gameObject.SetActive(false);
		CloseParty();
	}
	
	public void CloseParty() {
		gameObject.transform.parent.gameObject.GetComponent<Dungeon>().CloseParty();
	}
}
