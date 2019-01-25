using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour {

    Item item;
	int price;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetItem(Item item) {
		this.item = item;
		this.price = item.price;
		gameObject.transform.Find("Buy").Find("Name").gameObject.GetComponent<Text>().text = item.GetName();
		gameObject.transform.Find("Cost").gameObject.GetComponent<Text>().text = price.ToString() + " items";
	}
	
	public void Buy() {
		Party.AddItem(item);
	}
	
	public void Select() {
		gameObject.transform.parent.parent.gameObject.GetComponent<Shop>().OpenTrade(price);
		gameObject.transform.parent.parent.gameObject.GetComponent<Shop>().purchase = item;
	}
}
