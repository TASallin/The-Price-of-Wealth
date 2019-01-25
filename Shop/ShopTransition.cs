using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ToShop() {
		SceneManager.LoadScene("Shop");
	}
	
	public void FromShop() {
		SceneManager.LoadScene("Overworld");
	}
}
