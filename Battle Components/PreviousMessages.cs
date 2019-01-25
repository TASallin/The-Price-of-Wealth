using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousMessages : MonoBehaviour {

    public GameObject messageLog;
    public LinkedList<string> messages;
	public Text display;
	public LinkedListNode<string> current;
	public Button nextButton;
	public Button prevButton;
	int index;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnEnable () {
		messages = messageLog.GetComponent<MessageLog>().previous;
		current = messages.First;
		display.text = current.Value;
		index = 0;
		nextButton.interactable = false;
		prevButton.interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void previous () {
		current = current.Next;
		display.text = current.Value;
		index++;
		nextButton.interactable = true;
		if (index == messages.Count - 1) {
			prevButton.interactable = false;
		}
	}
	
	public void Next () {
		current = current.Previous;
		display.text = current.Value;
		index--;
		prevButton.interactable = true;
		if (index == 0) {
			nextButton.interactable = false;
		}
	}
}
