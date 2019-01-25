using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaSpotlight : MonoBehaviour {
    
	public string location;
	public GameObject map;
	public Text currentName;
	public Button shop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Enter () {
		Areas.location = location;
		SceneManager.LoadScene("Dungeon");
	}
	
	public void SetLocation(string location) {
		this.location = location;
		currentName.text = location;
		if (Areas.cleared[location]) {
			shop.gameObject.SetActive(true);
			Areas.currentShop = Areas.shops[location];
		} else {
			shop.gameObject.SetActive(false);
		}
	}
	
	public void Shop () {}
	
	public void Investigate () {}
	
	public void ToMap () {
		location = null;
		Areas.location = "overworld";
		gameObject.SetActive(false);
		map.SetActive(true);
	}
	
	public void Display () {
		gameObject.SetActive(true);
		map.SetActive(false);
	}
}
