using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event {
    
	public string text;
	public LinkedList<TimedMethod> options1;
	public LinkedList<TimedMethod> options2;
	public LinkedList<TimedMethod> options3;
	public LinkedList<TimedMethod> options4;
	public string optionText1;
	public string optionText2;
	public string optionText3;
	public string optionText4;
	public static System.Random rng = new System.Random();
	
	public Event(string text, LinkedList<TimedMethod> options1, LinkedList<TimedMethod> options2,
	    LinkedList<TimedMethod> options3, LinkedList<TimedMethod> options4, string optionText1, string optionText2,
	    string optionText3, string optionText4) {
		this.text = text; this.options1 = options1; this.options2 = options2; this.options3 = options3; this.options4 = options4;
		this.optionText1 = optionText1; this.optionText2 = optionText2; this.optionText3 = optionText3; this.optionText4 = optionText4;
	}
	
	public Event () {}
	
	public virtual void Enact () {
		
	}

}
