using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEvent : Event {
	
	public BattleEvent (Character[] enemies, string txt) {
		text = txt;
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
 	}
	
	public BattleEvent () {}
}
