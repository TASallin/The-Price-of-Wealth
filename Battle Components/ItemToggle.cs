using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;

public class ItemToggle : MonoBehaviour {

    public Item item;
	public static bool switched = false;
	int index;
    public static int x;
	public Vector3 pos;
	public static int startingY = 75;
	public static int y = 75;
	public static int stepY = 20;
	public GameObject messageLog;
	
	// Use this for initialization
	void Start () {
		try {
		index = gameObject.transform.parent.gameObject.GetComponent<WinMenu>().indexes.Dequeue();
		if (index >= 10) {
			if (!switched) {
				switched = true;
				y = startingY;
			}
		    item = Party.GetLootAt(index - 10);
			pos = new Vector3(150, y, 0);
		} else {
			item = Party.GetItem(index);
			pos = new Vector3(-150, y, 0);
		}
		gameObject.GetComponentInChildren<Text>().text = item.GetName();
		gameObject.transform.localPosition = pos;
		y = y - stepY;
		try {
		    messageLog = gameObject.transform.parent.parent.Find("Message Log").gameObject;
		} catch {
			messageLog = gameObject.transform.parent.Find("Descriptor").gameObject;
		}
		} catch {
			messageLog = gameObject.transform.parent.parent.Find("Message Log").gameObject;
			gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetItem(Item item) {
		this.item = item;
		gameObject.GetComponentInChildren<Text>().text = item.GetName();
	}
	
	public void OnToggle () {
		messageLog.GetComponent<Text>().text = item.GetDescription();
		if (gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn) {
			try {
			    gameObject.transform.parent.gameObject.GetComponent<WinMenu>().ChangeNum(1);
			} catch {
				//Debug.Log("Oi");
			    gameObject.transform.parent.gameObject.GetComponent<TradeScreen>().selected += 1;
			}
		} else {
		    try {
			    gameObject.transform.parent.gameObject.GetComponent<WinMenu>().ChangeNum(-1);
			} catch {
			    gameObject.transform.parent.gameObject.GetComponent<TradeScreen>().selected -= 1;
			}
		}
	}
	
	public static void Left() {x = -200; y = startingY;}
	
	public static void Right() {x = 100; y = startingY;}
}
