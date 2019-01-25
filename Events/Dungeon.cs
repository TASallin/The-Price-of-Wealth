using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dungeon : MonoBehaviour {

	public Event current;
	public Event consequence;
	public GameObject eventSpace;
	public EventSpace e;
	public GameObject nextMenu;
	public GameObject partyMenu;
	public GameObject itemMenu;
	public GameObject bagMenu;
	public GameObject useItemMenu;
	public GameObject nameMenu;
	public bool isEvent;
    public int y;
	public int partyIndex;
	Type t;
	MethodInfo method;
	public Queue<TimedMethod> effects1;
	public Queue<TimedMethod> effects2;
	public Queue<TimedMethod> effects3;
	public Queue<TimedMethod> effects4;

	// Use this for initialization
	void Start () {
		effects1 = new Queue<TimedMethod>();
		effects2 = new Queue<TimedMethod>();
		effects3 = new Queue<TimedMethod>();
		effects4 = new Queue<TimedMethod>();
		t = this.GetType();
		if (Areas.followUp != null) {
			consequence = Areas.followUp;
			Areas.followUp = null;
			Next();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Next () {
		y = 0;
		//if (Areas.tower.Count == 0) {
			//SceneManager.LoadScene("Overworld");
			//return;
		//}
		if (consequence == null) {
		    current = Areas.Next();
			if (current == null) {return;}
		} else {
			current = consequence;
			consequence = null;
		}
		current.Enact();
		e.text.text = current.text;
		effects1 = new Queue<TimedMethod>();
		effects2 = new Queue<TimedMethod>();
		effects3 = new Queue<TimedMethod>();
		effects4 = new Queue<TimedMethod>();
		if (current.options1 != null) {
			foreach (TimedMethod t in current.options1) {
			    effects1.Enqueue(t);
			}
			e.option1.GetComponentInChildren<Text>().text = current.optionText1;
			e.option1.gameObject.SetActive(true);
		} else {
			e.option1.gameObject.SetActive(false);
		}
		
		if (current.options2 != null) {
			foreach (TimedMethod t in current.options2) {
			    effects2.Enqueue(t);
			}
			e.option2.GetComponentInChildren<Text>().text = current.optionText2;
			e.option2.gameObject.SetActive(true);
		} else {
			e.option2.gameObject.SetActive(false);
		}
		
		if (current.options3 != null) {
			foreach (TimedMethod t in current.options3) {
			    effects3.Enqueue(t);
			}
			e.option3.GetComponentInChildren<Text>().text = current.optionText3;
			e.option3.gameObject.SetActive(true);
		} else {
			e.option3.gameObject.SetActive(false);
		}
		
		if (current.options4 != null) {
			foreach (TimedMethod t in current.options4) {
			    effects4.Enqueue(t);
			}
			e.option4.GetComponentInChildren<Text>().text = current.optionText4;
			e.option4.gameObject.SetActive(true);
		} else {
			e.option4.gameObject.SetActive(false);
		}
		
		//nextMenu.SetActive(false);
		nextMenu.transform.Find("Next").gameObject.GetComponent<Button>().interactable = false;
		nextMenu.transform.Find("Exit").gameObject.GetComponent<Button>().interactable = false;
		isEvent = true;
		eventSpace.SetActive(true);
	}
	
	public void Resolve () {
		//nextMenu.SetActive(true);
		nextMenu.transform.Find("Next").gameObject.GetComponent<Button>().interactable = true;
		nextMenu.transform.Find("Exit").gameObject.GetComponent<Button>().interactable = true;
		isEvent = false;
		eventSpace.SetActive(false);
	}
	
	public void OpenParty() {
	    nextMenu.SetActive(false);
		eventSpace.SetActive(false);
        partyMenu.SetActive(true);		
	}
	
	public void CloseParty() {
		partyMenu.SetActive(false);
		nextMenu.SetActive(true);
		if (isEvent) {
			eventSpace.SetActive(true);
		}
	}
	
	public void click1() {
	    foreach (TimedMethod current in effects1) {
			method = t.GetMethod(current.method);
			if (current.args == null) {
				method.Invoke(this, null);
			} else {
				method.Invoke(this, current.args);
			}	
		}
	}
	
	public void click2() {
	    foreach (TimedMethod current in effects2) {
			method = t.GetMethod(current.method);
			if (current.args == null) {
				method.Invoke(this, null);
			} else {
				method.Invoke(this, current.args);
			}	
		}
	}
	
	public void click3() {
	    foreach (TimedMethod current in effects3) {
			method = t.GetMethod(current.method);
			if (current.args == null) {
				method.Invoke(this, null);
			} else {
				method.Invoke(this, current.args);
			}	
		}
	}
	
	public void click4() {
	    foreach (TimedMethod current in effects4) {
			method = t.GetMethod(current.method);
			if (current.args == null) {
				method.Invoke(this, null);
			} else {
				method.Invoke(this, current.args);
			}	
		}
	}
	
	public void CauseEvent (Event e) {
		consequence = e;
		Next();
	}
	
	public void NextEvent (Event e) {
		Areas.followUp = e;
		Resolve();
	}
	
	
	public void Battle (Character [] enemies) {
		foreach (Character c in enemies) {
			Party.AddEnemy(c);
	    }
		Party.area = "Dungeon";
		isEvent = false;
		SceneManager.LoadScene("Battle");
	}
	
	public void Item (Item[] loot) {
		foreach (Item current in loot) {
			Party.AddLoot(current);
		}
		itemMenu.SetActive(true);
		eventSpace.SetActive(false);
		nextMenu.SetActive(false);
	}
	
	public void LoseItems() {
		Party.SetItems(new Item[10]);
	}
	
	public void LoseItem(int index) {
		Party.GetItems()[index] = null;
	}
	
	public void CloseItem () {
		itemMenu.SetActive(false);
		nextMenu.SetActive(true);
		nextMenu.transform.Find("Next").gameObject.GetComponent<Button>().interactable = true;
		nextMenu.transform.Find("Exit").gameObject.GetComponent<Button>().interactable = true;
		isEvent = false;
	}
	
	public void OpenBag () {
		bagMenu.SetActive(true);
		nextMenu.SetActive(false);
		eventSpace.SetActive(false);
	}
	
	public void CloseBag () {
		bagMenu.SetActive(false);
		nextMenu.SetActive(true);
		if (isEvent) {
			eventSpace.SetActive(true);
		}
	}
	
	public void UseItem (Item item) {
		bagMenu.SetActive(false);
		useItemMenu.SetActive(true);
		useItemMenu.GetComponent<PartyMenu>().item = item;
	}
	
	public void CancelItemUse () {
		Party.AddItem(useItemMenu.GetComponent<PartyMenu>().item);
		bagMenu.SetActive(true);
		useItemMenu.SetActive(false);
		useItemMenu.GetComponent<PartyMenu>().item = null;
	}
	
	public void ConfirmItemUse () {
		useItemMenu.SetActive(false);
		nextMenu.SetActive(true);
		useItemMenu.GetComponent<PartyMenu>().item = null;
		if (isEvent) {
			eventSpace.SetActive(true);
		}
	}
	
	public void OpenName () {
		Party.latestRecruit = partyMenu.GetComponent<PartyMenu>().GetActive();
		nameMenu.transform.Find("Name").gameObject.GetComponent<InputField>().text = Party.latestRecruit.GetName();
		nameMenu.SetActive(true);
		partyMenu.SetActive(false);
	}
	
	public void Name () {
		Party.latestRecruit.SetName(nameMenu.transform.Find("Name").gameObject.GetComponent<InputField>().text);
		Party.latestRecruit = null;
		nextMenu.SetActive(true);
		nameMenu.SetActive(false);
		if (isEvent) {
			eventSpace.SetActive(true);
		}
	}
	
	public void Poison (int amount) {
		for (int i = 0; i < 4; i++) {
			Character current = Party.GetCharacter(i);
			if (current != null) {
				current.status.Poison(amount);
			}
		}
	}
	
	public void DamageAll (int amount) {
		for (int i = 0; i < 4; i++) {
			Character current = Party.GetCharacter(i);
			if (current != null) {
				current.Damage(amount);
				if (current.GetHealth() <= 0) {
					if (current.GetChampion()) {
						SceneManager.LoadScene("GameOver");
						return;
					}
					Party.playerCount--;
					Party.members[i] = null;
				}
			}
		}
	}
	
	public void Damage (int amount) {
		Party.members[partyIndex].Damage(amount);
		if (Party.members[partyIndex].GetHealth() <= 0) {
			if (Party.members[partyIndex].GetChampion()) {
				SceneManager.LoadScene("GameOver");
				return;
			}
			Party.playerCount--;
			Party.members[partyIndex] = null;
		}
	}
	
	public void Heal (int amount) {
		for (int i = 0; i < 4; i++) {
			Character current = Party.GetCharacter(i);
			if (current != null) {
				current.SetHealth(System.Math.Min(current.GetHealth() + amount, current.GetMaxHP()));
			}
		}
	}
	
	public void GainSP (int amount) {
		Party.UseSP(amount * -1);
	}
	
	public void ChooseMember (int index) {
		partyIndex = index;
	}
	
	public void StatChange (string stat, int amount) {
		MethodInfo m = Party.members[partyIndex].GetType().GetMethod(stat);
		m.Invoke(Party.members[partyIndex], new object[] {amount});
	}
	
	public void Ally (Character[] recruits) {
		foreach (Character c in recruits) {
			Party.AddPlayer(c);
		}
		Resolve();
	}
	
	public void Shortcut (int number) {
		for (int i = 1; i <= number; i++) {
			Areas.Next();
		}
	}
	
	public void Exit () {
		SceneManager.LoadScene("Overworld");
	}
}