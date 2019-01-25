using System.Collections;
using System.Collections.Generic;

public class TextEvent : Event {
	
	public TextEvent(string txt) {
		text = txt;
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod("Resolve"));
		optionText1 = "Continue";
	}
	
	public TextEvent(string txt, Event following) {
		text = txt;
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "CauseEvent", new object[] {following}));
		optionText1 = "Continue";
	}
}