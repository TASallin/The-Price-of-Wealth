using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject storeUI;
	public GameObject tradeItems;
	public GameObject messageLog;
	public GameObject replaceMember;
	public GameObject productPrefab;
	public GameObject hirelingPrefab;
	bool resting;
	public Item purchase;
	Character hireling;
	Inventory inventory;
	
	
	// Use this for initialization
	int yPosition = 75;
	GameObject current;
	Vector3 pos;
	void Start () {
		inventory = Areas.currentShop;
		foreach (Item item in inventory.products) {
		    current = Instantiate(productPrefab, gameObject.transform.Find("StoreUI"));
			pos = new Vector3(250, yPosition, 0);
			current.transform.localPosition = pos;
			yPosition -= 35;
			current.GetComponent<Product>().SetItem(item);
		}
		yPosition = 75;
		foreach (Character hireling in inventory.hirelings) {
			current = Instantiate(hirelingPrefab, gameObject.transform.Find("StoreUI"));
			pos = new Vector3(50, yPosition, 0);
			current.transform.localPosition = pos;
			yPosition -= 35;
			current.GetComponent<Hireling>().SetCharacter(hireling);
		}
	}
	
	public void UpdateUI () {
		foreach (Transform child in storeUI.transform) {
			if (child.tag.Equals("Temp")) {
			    Destroy(child.gameObject);
		    }
		}
		foreach (Item item in inventory.products) {
		    current = Instantiate(productPrefab, gameObject.transform.Find("StoreUI"));
			pos = new Vector3(250, yPosition, 0);
			current.transform.localPosition = pos;
			yPosition -= 35;
			current.GetComponent<Product>().SetItem(item);
		}
		yPosition = 75;
		foreach (Character hireling in inventory.hirelings) {
			current = Instantiate(hirelingPrefab, gameObject.transform.Find("StoreUI"));
			pos = new Vector3(50, yPosition, 0);
			current.transform.localPosition = pos;
			yPosition -= 35;
			current.GetComponent<Hireling>().SetCharacter(hireling);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OpenTrade(int cost) {
		//if (Party.BagContains(new Coupon())) {
		//	AskCoupon(cost);
		//} else {
			//Debug.Log("Hello");
			storeUI.SetActive(false);
			tradeItems.SetActive(true);
			tradeItems.GetComponent<TradeScreen>().SetPrice(cost);
		//}
	}
	
	public void CancelTrade() {
		tradeItems.SetActive(false);
		replaceMember.SetActive(false);
		storeUI.SetActive(true);
	}
	
	public void Hire(Character hireling) {
		Party.UseSP(10);
		if (Party.playerCount < 4) {
			inventory.RemoveH(hireling);
			Party.AddPlayer(hireling);
			UpdateUI();
			messageLog.GetComponent<Text>().text = "New member added";
		} else {
			Party.fullRecruit = hireling;
			replaceMember.SetActive(true);
			storeUI.SetActive(false);
		}
	}
	
	public void Scout() {
		if (Party.GetSP() >= 5) {
			Party.UseSP(5);
			messageLog.GetComponent<Text>().text = "You scouted an area but it wasn't coded yet";
		} else {
			messageLog.GetComponent<Text>().text = "You are broke!";
		}
	}
	
	public void Rest() {
		resting = true;
		OpenTrade(Party.playerCount);
	}
	
	public void ConfirmPurchase() {
		if (resting) {
			foreach (Character c in Party.members) {
				if (c != null) {
				    c.Heal(10);
				}
			}
		} else {
			inventory.RemoveP(purchase);
			Party.AddItem(purchase);
			UpdateUI();
		}
		resting = false;
		purchase = null;
		tradeItems.SetActive(false);
		storeUI.SetActive(true);
	}
	
	public void CancelPurchase() {
		resting = false; purchase = null;
	}
	
	public void BackToShop() {
		storeUI.SetActive(true);
		tradeItems.SetActive(false);
		replaceMember.SetActive(false);
	}
}
