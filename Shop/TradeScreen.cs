using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeScreen : MonoBehaviour {

    public int requested;
	public int selected;
	public GameObject itemToggle;
	public Button confirm;
	
	// Use this for initialization
	void OnEnable () {
		int yPosition = 75;
	    GameObject current;
	    Vector3 pos;
		selected = 0;
		foreach (Item item in Party.GetItems()) {
			if (item != null) {
			    current = Instantiate(itemToggle, gameObject.transform);
			    pos = new Vector3(0, yPosition, 0);
			    current.transform.localPosition = pos;
			    yPosition -= 20;
			    current.GetComponent<ItemToggle>().SetItem(item);
				selected++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(selected.ToString());
	    if (selected == requested) {
			confirm.interactable = true;
		} else {
			confirm.interactable = false;
		}
	}
	
	public void SetPrice (int num) {
		requested = num;
	}
	
	public void Confirm () {
		Item[] newItems = new Item[10];
		int index = 0;
		foreach (Transform child in transform) {
		    if (child.tag.Equals("Temp")) {
			    if (!child.gameObject.GetComponent<Toggle>().isOn) {
				    newItems[index] = child.gameObject.GetComponent<ItemToggle>().item;
				    index++;
			    }
				Destroy(child.gameObject);
		    }
		}
		Party.SetItems(newItems);
	}
	
	void OnDisable () {
		foreach (Transform child in transform) {
			if (child.tag.Equals("Temp")) {
				Destroy(child.gameObject);
			}
		}
	}
}
