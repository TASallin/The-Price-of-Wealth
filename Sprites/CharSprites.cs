using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSprites : MonoBehaviour {
    
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject[] sprites;
	public Vector3 leadPositionP = new Vector3(-564, -20, 0);
	public Vector3 leadPositionE = new Vector3(500, -20, 0);
	
	// Use this for initialization
	void Start () {
		sprites = new GameObject[] {player1, player2, player3, player4, enemy1, enemy2, enemy3, enemy4};
		for (int i = 0; i < 8; i++) {
			if (i < 4 && Party.members[i] != null) {
				sprites[i].SetActive(true);
			} else if (i >= 4 && Party.enemies[i - 4] != null) {
				sprites[i].SetActive(true);
			} else {
				sprites[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//sprites = new GameObject[] {player1, player2, player3, player4, enemy1, enemy2, enemy3, enemy4};
		for (int i = 0; i < 8; i++) {
			if (i < 4 && Party.members[i] != null) {
				sprites[i].SetActive(true);
			} else if (i >= 4 && Party.enemies[i - 4] != null) {
				sprites[i].SetActive(true);
			} else {
				sprites[i].SetActive(false);
			}
		}
	}
	
	public void Switch (int a, int b) {
	    Vector3 tempMove = sprites[a].GetComponent<CharSprite>().moveTo;
		sprites[a].GetComponent<CharSprite>().moveTo = sprites[b].GetComponent<CharSprite>().moveTo;
		sprites[b].GetComponent<CharSprite>().moveTo = tempMove;
	}
	
	public void Switch(bool player, int a, int b) {
		if (player) {
		    Switch(a - 1, b - 1);
		} else {
			Switch(a + 3, b + 3);
		}
	}
}
