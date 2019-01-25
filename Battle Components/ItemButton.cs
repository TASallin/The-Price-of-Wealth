using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {
	
	public Item item;
	public int index;
	public Vector3 pos;
	public static int startingY = 50;
	public static int y = 50;
	public static int stepY = 25;
	public GameObject messageLog;
	
	public ItemButton(Item item) {this.item = item;}
	
	// Use this for initialization
	void Start () {
		index = gameObject.transform.parent.gameObject.GetComponent<ItemSpace>().indexes.Dequeue();
		item = Party.GetItem(index);
		gameObject.GetComponentInChildren<Text>().text = item.GetName();
		pos = new Vector3(0, y, 0);
		gameObject.transform.localPosition = pos;
		y = y - stepY;
		try {
		    messageLog = gameObject.transform.parent.parent.Find("Message Log").gameObject;
		} catch {
			messageLog = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Consume () {
	    y = y + stepY;
        Destroy(gameObject);		
	}
	
	public void Clicked () {
		Party.UseItem(index);
		try {
	        gameObject.transform.parent.parent.gameObject.GetComponent<Battle>().UseItem(item);
	    } catch {
			gameObject.transform.parent.parent.gameObject.GetComponent<Dungeon>().UseItem(item);
		}
	}
	
	void OnDestroy () {
		y = startingY;
	}
	
	public void Description () {
		gameObject.transform.parent.GetComponent<ItemSpace>().description.GetComponent<Text>().text = item.GetDescription();
	}
	
    public void Hide () {
		gameObject.transform.parent.GetComponent<ItemSpace>().description.GetComponent<Text>().text = "";
	}
}
