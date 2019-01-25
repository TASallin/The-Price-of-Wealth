using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvent : Event {
    	
	public ItemEvent (Item[] rewards, string txt) {
		text = txt;
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Item", new object[] {rewards}));
		optionText1 = "Take";
 	}
}
