using System.Collections;
using System.Collections.Generic;

public class SelectMember : Event {

	TimedMethod[] results;
	
	public SelectMember(string txt, TimedMethod[] results) {
	    text = txt;
		this.results = results;
	}
	
	public override void Enact () {
		options1 = new LinkedList<TimedMethod>(results);
		options1.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {0}));
		optionText1 = Party.members[0].ToString();
		if (Party.members[1] != null) {
		    options2 = new LinkedList<TimedMethod>(results);
		    options2.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {1}));
		    optionText2 = Party.members[1].ToString();
		}
		if (Party.members[2] != null) {
		    options3 = new LinkedList<TimedMethod>(results);
		    options3.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {2}));
		    optionText3 = Party.members[2].ToString();
		}
		if (Party.members[3] != null) {
		    options4 = new LinkedList<TimedMethod>(results);
		    options4.AddFirst(new TimedMethod(0, "ChooseMember", new object[] {3}));
		    optionText4 = Party.members[3].ToString();
	    }
	}
}